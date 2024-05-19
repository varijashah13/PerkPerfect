using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;

           
          

            // Set background color for buttons and set text color to white
            button1.BackColor = Color.Teal; // Using RoyalBlue color
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.Teal; // Using RoyalBlue color
            button2.ForeColor = Color.Black;

        }
    }
}
