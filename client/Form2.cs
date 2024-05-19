using client.ServiceReference3;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.ServiceReference3.IcustomerserviceClient proxy = new client.ServiceReference3.IcustomerserviceClient("WSHttpBinding_Icustomerservice");
            Customer customer = new Customer
            {
                cId=int.Parse(textBox1.Text),
                cName=textBox2.Text,
                cPhone=textBox3.Text
            };
            proxy.AddCustomer(customer);
            MessageBox.Show("Customer added successfully");
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.ServiceReference3.IcustomerserviceClient proxy = new client.ServiceReference3.IcustomerserviceClient("WSHttpBinding_Icustomerservice");
            int cId;
            if(int.TryParse(textBox1.Text,out cId))
            {
                Customer customer=proxy.GetCustomer(cId);
                if(customer!=null)
                {
                    textBox2.Text = customer.cName;
                    textBox3.Text = customer.cPhone;
                }
                else
                {
                    MessageBox.Show("Customer not found!");
                }
            }
            else
            {
                MessageBox.Show("Invalid customer ID!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Form4 form4 = new Form4();
            form4.Show();*/
            Form5 form5 = new Form5();
            form5.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;

            // Set foreground color and font for labels
            label1.ForeColor = Color.DarkBlue;
            label1.Font = new Font("Arial", 10, FontStyle.Bold);

            // Set background color for text boxes
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;

            button1.BackColor = Color.Teal; // Using MediumSeaGreen color
            button1.ForeColor = Color.White;
            button2.BackColor = Color.Teal; // Using MediumSeaGreen color
            button2.ForeColor = Color.White;
            button3.BackColor = Color.Teal; // Using MediumSeaGreen color
            button3.ForeColor = Color.White;
        }
    }
}
