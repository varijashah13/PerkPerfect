using client.ServiceReference1;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.ServiceReference1.IchefserviceClient proxy = new client.ServiceReference1.IchefserviceClient("WSHttpBinding_Ichefservice");
            Chef chef = new Chef
            {

                chefId = int.Parse(textBox1.Text),
                Name = textBox2.Text
            };
            proxy.AddChef(chef);
            MessageBox.Show("Chef added successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.ServiceReference1.IchefserviceClient proxy = new client.ServiceReference1.IchefserviceClient("WSHttpBinding_Ichefservice");
            Chef chef = new Chef
            {
                chefId = int.Parse(textBox1.Text),
                Name = textBox2.Text
            };
            proxy.UpdateChef(chef);
            MessageBox.Show("Chef updated successfully!");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.ServiceReference1.IchefserviceClient proxy = new client.ServiceReference1.IchefserviceClient("WSHttpBinding_Ichefservice");
            int chefId;
            if (int.TryParse(textBox1.Text, out chefId))
            {
                proxy.DeleteChef(chefId);
                MessageBox.Show("Chef deleted successfully!");
               
            }
            else
            {
                MessageBox.Show("Invalid chef ID!");
              
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.ServiceReference1.IchefserviceClient proxy = new client.ServiceReference1.IchefserviceClient("WSHttpBinding_Ichefservice");
            int chefId;
            if (int.TryParse(textBox1.Text, out chefId))
            {
                Chef chef = proxy.GetChef(chefId);
                if (chef != null)
                {
                    textBox2.Text = chef.Name;

                }
                else
                {
                    MessageBox.Show("Chef not found!");
                }

            }
            else
            {
                MessageBox.Show("Invalid chef ID!");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;

            // Set foreground color and font for labels
            label1.ForeColor = Color.DarkBlue;
            label1.Font = new Font("Arial", 10, FontStyle.Bold);
            /*label2.ForeColor = Color.DarkBlue;
            label2.Font = new Font("Arial", 10, FontStyle.Bold);*/

            // Set background color for text boxes
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;

            // Set background color for buttons and set text color to white
            button1.BackColor = Color.Crimson; // Using Crimson color
            button1.ForeColor = Color.White;
            button2.BackColor = Color.Crimson; // Using Crimson color
            button2.ForeColor = Color.White;
            button3.BackColor = Color.Crimson; // Using Crimson color
            button3.ForeColor = Color.White;
            button4.BackColor = Color.Crimson; // Using Crimson color
            button4.ForeColor = Color.White;
        }
    }
}
