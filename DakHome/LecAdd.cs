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
    public partial class LecAdd : Form
    {
        Lecture l = new Lecture();
        public LecAdd()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string v = comboBox4.Text +'.' + textBox1.Text;

            MessageBox.Show(v);
            l.empId = textBox1.Text;
            l.name = textBox3.Text;
            l.faculty = comboBox1.Text;
            l.dep = comboBox2.Text;
            l.campus = comboBox3.Text;
            l.building = comboBox5.Text;
            l.level = comboBox4.Text;
            l.rank = v;

            bool y = l.Insert(l);
            if (y == true)
            {
                MessageBox.Show("Successfully");
            }
            else if (y == false)
            {
                MessageBox.Show("UnSuccessfully");
            }
        }
    }
}
