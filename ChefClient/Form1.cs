using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChefClient.ServiceReference2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChefClient
{
    public partial class Form1 : Form
    {
        private Ichefservice chefservice;
        private int currchefId;
        ChefClient.ServiceReference2.IchefserviceClient proxy;
        public Form1()
        {
            InitializeComponent();
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            proxy = new ChefClient.ServiceReference2.IchefserviceClient("WSHttpBinding_Ichefservice");

        }


        private void Add_Click(object sender, EventArgs e)
        {
            //ChefClient.ServiceReference2.IchefserviceClient proxy = new ChefClient.ServiceReference2.IchefserviceClient("WSHttpBinding_Ichefservice");
            Chef chef = new Chef
            {
                Name = textBox2.Text,
                chefId = int.Parse(textBox1.Text),
            };
            proxy.AddChef(chef);
            MessageBox.Show("Chef added successfully!");
            ClearFields();


        }

        private void Show_Click(object sender, EventArgs e)
        {
            //ChefClient.ServiceReference2.IchefserviceClient proxy = new ChefClient.ServiceReference2.IchefserviceClient("WSHttpBinding_Ichefservice");
            int chefId;
            if (int.TryParse(textBox1.Text, out chefId))
            {
                Chef chef = proxy.GetChef(chefId);
                if (chef != null)
                {
                    textBox2.Text = chef.Name;
                    currchefId = chefId;
                }
                else
                {
                    MessageBox.Show("Chef not found!");
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Invalid chef ID!");
                ClearFields();
               
            }


        }

        private void Update_Click(object sender, EventArgs e)
        {
            //ChefClient.ServiceReference2.IchefserviceClient proxy = new ChefClient.ServiceReference2.IchefserviceClient("WSHttpBinding_Ichefservice");
            Chef chef = new Chef
            {
                chefId = currchefId,
                Name = textBox2.Text
            };
            proxy.UpdateChef(chef);
            MessageBox.Show("Chef updated successfully!");

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //ChefClient.ServiceReference2.IchefserviceClient proxy = new ChefClient.ServiceReference2.IchefserviceClient("WSHttpBinding_Ichefservice");
            int chefId;
            if (int.TryParse(textBox1.Text, out chefId))
            {
                proxy.DeleteChef(chefId);
                MessageBox.Show("Chef deleted successfully!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Invalid chef ID!");
                ClearFields();
            }

        }
        private void ClearFields()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        
    }
}
