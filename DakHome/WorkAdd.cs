using System;
using System.Collections;
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
    public partial class WorkAdd : Form
    {
        WorkingDays w = new WorkingDays();

        public WorkAdd()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        ArrayList arr = new ArrayList();
        private void button11_Click(object sender, EventArgs e)
        {
            //String day = "";
            if(checkBox1.Checked)
            {
                arr.Add("Monday");
            }
            if (checkBox2.Checked)
            {
                arr.Add("Tuesday");
            }
            if(checkBox3.Checked)
            {
                arr.Add("Wedenday");
            }
             if (checkBox4.Checked)
            {
                arr.Add("Thursday");
            }
            if (checkBox5.Checked)
            {
                arr.Add("Friday");
            }
            if (checkBox6.Checked)
            {
                arr.Add("Saturday");
            }
            if (checkBox7.Checked)
            {
                arr.Add("Sunday");
            }

            String[] Arr = (String[])arr.ToArray(typeof(String));
            String days = String.Join(",", Arr);
            //MessageBox.Show(days);
            w.Emp_ID = textBox1.Text;
            w.NoOfWork = numericUpDown1.Text;
            w.WorkDays = days;
            w.WorkingPerDay = textBox2.Text;


            bool y = w.Insert(w);
            if (y == true)
            {
                MessageBox.Show("Successfully");

                for(int i = arr.Count - 1; i >= 0; i--)
                {
                    arr.RemoveAt(i);
                }
            }
            else if (y == false)
            {
                MessageBox.Show("UnSuccessfully");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
