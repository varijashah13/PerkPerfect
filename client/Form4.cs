using client.ServiceReference3;
using client.ServiceReference4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;

            // Set foreground color and font for labels
            label1.ForeColor = Color.DarkBlue;
            label1.Font = new Font("Arial", 10, FontStyle.Bold);
            label2.ForeColor = Color.DarkBlue;
            label2.Font = new Font("Arial", 10, FontStyle.Bold);
            label3.ForeColor = Color.DarkBlue;
            label3.Font = new Font("Arial", 10, FontStyle.Bold);

            // Set background color for combo box
            comboBox2.BackColor = Color.White;

            // Set background color for list box
            listBox1.BackColor = Color.White;

            // Set background color for text boxes
            textBox1.BackColor = Color.White;

            // Set background color for button and set text color to white
            button1.BackColor = Color.DarkOrange;
            button1.ForeColor = Color.White;
            client.ServiceReference2.IfooditemsserviceClient proxy=new client.ServiceReference2.IfooditemsserviceClient("WSHttpBinding_Ifooditemsservice");
            client.ServiceReference3.IcustomerserviceClient proxy1 = new client.ServiceReference3.IcustomerserviceClient("WSHttpBinding_Icustomerservice");
            DataSet ds=proxy.GetFoodItems();
            DataSet dss = proxy1.GetCustomerIds();
            comboBox2.DataSource = dss.Tables[0];
            comboBox2.DisplayMember = "cId";
      

            listBox1.DataSource = ds.Tables[0].DefaultView;
            List<string> foodItems = new List<string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string foodName = row["FoodName"].ToString();
                string price = row["Price"].ToString();
                string displayString = $"{foodName} - {price}"; 
                foodItems.Add(displayString);
            }

            
            listBox1.DataSource = foodItems;
            
            proxy.Close();
            proxy1.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            client.ServiceReference2.IfooditemsserviceClient proxy = new client.ServiceReference2.IfooditemsserviceClient("WSHttpBinding_Ifooditemsservice");
            client.ServiceReference4.IorderClient proxy1 = new client.ServiceReference4.IorderClient("WSHttpBinding_Iorder");
            client.ServiceReference2.FoodItem fooditem = proxy.GetFoodItem(listBox1.SelectedValue.ToString());
            label6.Text = fooditem.foodName;
            string selectedFoodItem = listBox1.SelectedItem.ToString();
            string[] parts = selectedFoodItem.Split('-');
            if(parts.Length>=2)
            {
                string foodName = parts[0].Trim();
                string priceString = parts[1].Trim();
                if (decimal.TryParse(priceString, out decimal price))
                {
                    
                    label6.Text = foodName;

                    
                    label9.Text = priceString;
                }
            }
            

        }
     

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (comboBox2.SelectedItem != null)
            {

                DataRowView selectedRow = comboBox2.SelectedItem as DataRowView;


                int customerId = Convert.ToInt32(selectedRow[0]);


                client.ServiceReference3.IcustomerserviceClient proxy = new client.ServiceReference3.IcustomerserviceClient("WSHttpBinding_Icustomerservice");
                client.ServiceReference3.Customer cust = proxy.GetCustomer(customerId);


                label7.Text = cust.cId.ToString();
            }






        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int totalInt = (int)Math.Round(decimal.Parse(label9.Text));

                int orderId;
                if (!int.TryParse(textBox1.Text, out orderId))
                {
                    MessageBox.Show("Invalid order ID. Please enter a valid numeric value.");
                    return;
                }

                int cId;
                if (comboBox2.SelectedItem != null && comboBox2.SelectedValue != null)
                {
                    // Check if the selected item is a DataRowView
                    if (comboBox2.SelectedItem is DataRowView selectedRow)
                    {
                        // Try to parse the customer ID from the selected DataRowView
                        if (!int.TryParse(selectedRow.Row["cId"].ToString(), out cId))
                        {
                            MessageBox.Show("Invalid customer ID. Please select a valid customer.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid customer selection. Please select a valid customer.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No customer selected. Please select a customer.");
                    return;
                }

                // Proceed with creating the order
                client.ServiceReference4.IorderClient proxy = new client.ServiceReference4.IorderClient("WSHttpBinding_Iorder");
                Order order = new Order
                {
                    oId = orderId,
                    foodName = listBox1.SelectedValue.ToString(),
                    cId = cId,
                    total = totalInt
                };
                proxy.AddOrder(order);
                MessageBox.Show("Order placed successfully");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: Invalid input format. " + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Error: Value is too large or too small. " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }
    }
}
