using client.ServiceReference4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace client
{
    public partial class Form5 : Form
    {
        private Dictionary<string, decimal> foodPrices;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;

            // Set foreground color for controls
            label1.ForeColor=Color.DarkBlue;
            label2.ForeColor=Color.DarkBlue;
            label5.ForeColor = Color.DarkBlue;
            label9.ForeColor = Color.DarkGreen;

            // Customize font for labels
            label1.Font = new Font("Arial", 10, FontStyle.Bold);
            label2.Font = new Font("Arial", 10, FontStyle.Bold);
            label5.Font = new Font("Arial", 10, FontStyle.Bold);
            label9.Font = new Font("Arial", 10, FontStyle.Bold);

            // Set background color for the button
            button1.BackColor = Color.LightBlue;
            button1.ForeColor = Color.Black;

            client.ServiceReference2.IfooditemsserviceClient proxy = new client.ServiceReference2.IfooditemsserviceClient("WSHttpBinding_Ifooditemsservice");
            client.ServiceReference3.IcustomerserviceClient proxy1 = new client.ServiceReference3.IcustomerserviceClient("WSHttpBinding_Icustomerservice");

            DataSet ds = proxy.GetFoodItems();
            DataSet dss = proxy1.GetCustomerIds();
            comboBox1.DataSource = dss.Tables[0];
            comboBox1.DisplayMember = "cId";

            foodPrices = new Dictionary<string, decimal>(); // Initialize the dictionary

            // Assuming the column names in the dataset are "FoodName" and "Price"
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string foodName = row.Field<string>("foodName");

                // Check if the price column is null or DBNull
                if (!row.IsNull("price"))
                {
                    // Try parsing the price as a decimal
                    if (decimal.TryParse(row["price"].ToString(), out decimal price))
                    {
                        // Add the food item and price to the dictionary
                        foodPrices.Add(foodName, price);
                    }
                }
    
            }

            // Add food items to the CheckBoxList
            foreach (var foodItem in foodPrices.Keys)
            {
                checkedListBox1.Items.Add(foodItem);
            }
        }

        private List<string> checkedFoodItems = new List<string>();
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            string itemName = checkedListBox1.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                checkedFoodItems.Add(itemName); // Add the item to the list if checked
            }
            else
            {
                checkedFoodItems.Remove(itemName); // Remove the item from the list if unchecked
            }


            CalculateTotal();
            UpdateSelectedFoodNames();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (string foodItem in checkedFoodItems)
            {
                total += foodPrices[foodItem];
            }
            label9.Text = total.ToString();
        }
        private void UpdateSelectedFoodNames()
        {
            string selectedFoodNames = string.Join(", ", checkedFoodItems);
            label5.Text = selectedFoodNames;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int totalInt= (int)Math.Round(decimal.Parse(label9.Text)); ;
                
                if (!int.TryParse(label9.Text, out totalInt))
                {
                    MessageBox.Show("Invalid total amount.");
                    return;
                }

                int orderId;
      
                if (!int.TryParse(textBox1.Text, out orderId))
                {
                    MessageBox.Show("Invalid order ID. Please enter a valid numeric value.");
                    return;
                }

                int cId;
                if (comboBox1.SelectedItem is DataRowView selectedCustomerRow)
                {
                    
                    if (!int.TryParse(selectedCustomerRow.Row["cId"].ToString(), out cId))
                    {
                        MessageBox.Show("Invalid customer ID. Please select a valid customer.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No customer selected. Please select a customer.");
                    return;
                }


                string selectedFoodItems = string.Join(", ", checkedListBox1.CheckedItems.Cast<string>());


                client.ServiceReference4.IorderClient proxy = new client.ServiceReference4.IorderClient("WSHttpBinding_Iorder");
               // foreach (var foodItem in selectedFoodItems)
                
                    Order order = new Order
                    {
                        oId = orderId,
                        foodName = selectedFoodItems,
                        cId = cId,
                        total = totalInt
                    };
                    proxy.AddOrder(order);
                

                MessageBox.Show("Orders placed successfully");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {

                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;


                int customerId = Convert.ToInt32(selectedRow[0]);


                client.ServiceReference3.IcustomerserviceClient proxy = new client.ServiceReference3.IcustomerserviceClient("WSHttpBinding_Icustomerservice");
                client.ServiceReference3.Customer cust = proxy.GetCustomer(customerId);


                label7.Text = cust.cId.ToString();
            }


        }
    }
}
