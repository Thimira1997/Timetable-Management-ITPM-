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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            panelLectureSubmenuPanel.Visible = false;
            panelSubjectSubmenuPanel.Visible = false;
            panelSessionSubmenuPanel.Visible = false;
            panelLocationSubmenuPanel.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelLectureSubmenuPanel.Visible == true)
                panelLectureSubmenuPanel.Visible = false;
            if (panelSubjectSubmenuPanel.Visible == true)
                panelSubjectSubmenuPanel.Visible = false;
            if (panelSessionSubmenuPanel.Visible == true)
                panelSessionSubmenuPanel.Visible = false;
            if (panelLocationSubmenuPanel.Visible == true)
                panelLocationSubmenuPanel.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (SideBar.Width == 270)
            {
                SideBar.Visible = false;
                SideBar.Width = 50;
                SideBarWrapper.Width = 90;
                AnimationSideBar.Show(SideBar);
            }
            else
            {
                SideBar.Visible = false;
                SideBar.Width = 270;
                SideBarWrapper.Width = 300;
                AnimationSideBarBack.Show(SideBar);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximize.Visible = false;
            Restore.Visible = true;
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restore.Visible = false;
            Maximize.Visible = true;
        }

       

        private void MenuSideBar_Click(object sender, EventArgs e)
        {
            if(SideBar.Width == 270)
            {
                SideBar.Visible = false;
                SideBar.Width = 50;
                SideBarWrapper.Width = 90;
                AnimationSideBar.Show(SideBar);
            }
            else
            {
                SideBar.Visible = false;
                SideBar.Width = 270;
                SideBarWrapper.Width = 300;
                AnimationSideBarBack.Show(SideBar);
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelChildForm.Controls.Add(childForm);
            PanelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void Lecturebtn_Click(object sender, EventArgs e)
        {
           
            showSubMenu(panelLectureSubmenuPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new LecHome());
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new WorkHome());
            hideSubMenu();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubjectSubmenuPanel);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new SubHome());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new TagHome());
            hideSubMenu();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSessionSubmenuPanel);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new SessionHome());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new seconHome());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new sessionParallelHome());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new SeNonOverHome());
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new SessionNotAvaHome());
            hideSubMenu();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Locationbtn_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLocationSubmenuPanel);
        }

        private void Staticbtn_Click(object sender, EventArgs e)
        {
            openChildForm(new Static());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openChildForm(new LocHome());
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openChildForm(new LocNormalSessionHome());
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new LocConHome());
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openChildForm(new LocParallelSessionHome());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openChildForm(new LocNotAvaHome());
        }

        private void PanelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Studentbtn_Click(object sender, EventArgs e)
        {
            openChildForm(new StudentGroupHome());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openChildForm(new HomePanel());
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            openChildForm(new HomePanel());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            openChildForm(new TimeTable());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            openChildForm(new TimeTable());
        }
    }
    }

