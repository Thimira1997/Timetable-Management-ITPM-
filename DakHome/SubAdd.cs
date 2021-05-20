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
    public partial class SubAdd : Form
    {
        Subject S = new Subject();
        public SubAdd()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            S.Name = textBox3.Text;
            S.Subject_Code = textBox2.Text;
            S.Offered_Year = comboBox1.Text;
            S.Offered_Semester = comboBox2.Text;
            S.NumOfLecHours = numericUpDown1.Text;
            S.NumOfTuteHours = numericUpDown2.Text;
            S.NumOfLabHours = numericUpDown3.Text;
            S.NumOfEvaHours = numericUpDown4.Text;


            bool y = S.Insert(S);
            if (y == true)
            {
                MessageBox.Show("Successfully");
            }
            else if (y == false)
            {
                MessageBox.Show("UnSuccessfully");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
