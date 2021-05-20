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
    public partial class TagAdd : Form
    {
        Tag T = new Tag();
        public TagAdd()
        {
            InitializeComponent();
        }

        private void TagAdd_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            T.Tag_Code = textBox3.Text;
            T.Sub_Code = textBox2.Text;
            T.Tag_Name = comboBox1.Text;
            T.Related_Tag = comboBox2.Text;


            bool y = T.Insert(T);
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
