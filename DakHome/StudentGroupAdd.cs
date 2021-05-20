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
    public partial class StudentGroupAdd : Form
    {
        Student s = new Student();

        public StudentGroupAdd()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            s.groupId = textBox1.Text;
            s.subgroupId = textBox2.Text;
            s.yearsem = comboBox4.Text;
            s.program = comboBox3.Text;
            s.grpno = comboBox2.Text;
            s.subgrpno = comboBox1.Text;

            bool y = s.Insert(s);
            if (y == true)
            {
                MessageBox.Show("Successfully");
            }
            else if (y == false)
            {
                MessageBox.Show("UnSuccessfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String grpid = comboBox4.Text.Trim() + "." + comboBox2.Text.Trim() + "(" + comboBox3.Text.Trim() + ")";
            String subgrpid = comboBox4.Text.Trim() + "." + comboBox2.Text.Trim() + "." + comboBox1.Text.Trim() + "(" + comboBox3.Text.Trim() + ")";

            textBox1.Text = grpid;
            textBox2.Text = subgrpid;
        }
    }
}
