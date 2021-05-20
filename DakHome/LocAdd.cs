using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    public partial class LocAdd : Form
    {
        Location l = new Location();
        public LocAdd()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            l.buildingname = comboBox1.Text;
            l.roomname = textBox2.Text;
            l.type = comboBox3.Text;
            l.capacity = textBox1.Text;


            bool y = l.Insert(l);
            if(y == true)
            {
                MessageBox.Show("Successfully");
            }
            else if(y == false)
            {
                MessageBox.Show("UnSuccessfully");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
