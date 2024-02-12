using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_Project
{
    public partial class DashBoard_form : Form
    {
        public DashBoard_form()
        {
            InitializeComponent();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_menu.Text;
            view_food form1 = new view_food();
            form1.TopLevel = false;
            form1.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form1);
            form1.Dock = DockStyle.Fill;
            form1.Show();
            
        }

        private void btn_reservation_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_reservation.Text;
            View_table_reservation form6 = new View_table_reservation();
            form6.TopLevel = false;
            form6.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form6);
            form6.Dock = DockStyle.Fill;
            form6.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_order.Text;
            Billing_Form form2= new Billing_Form();
            form2.TopLevel = false;
            form2.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form2);
            form2.Dock = DockStyle.Fill;
            form2.Show();
        }






        private void btn_table_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_table.Text;
            View_Table form4 = new View_Table();
            form4.TopLevel = false;
            form4.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form4);
            form4.Dock = DockStyle.Fill;
            form4.Show();
        }

  

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_form_Load(object sender, EventArgs e)
        {
            lbl_date.Text = DateTime.Today.ToShortDateString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_tim.Text = DateTime.Now.ToShortTimeString();
        }

        private void people_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void people_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void btn_discount_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_discount.Text;
            View_Discount form7 = new View_Discount();
            form7.TopLevel = false;
            form7.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form7);
            form7.Dock = DockStyle.Fill;
            form7.Show();
        }

        private void btn_wastage_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_wastage.Text;
            view_wastage form5 = new view_wastage();
            form5.TopLevel = false;
            form5.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form5);
            form5.Dock = DockStyle.Fill;
            form5.Show();
        }

        private void btn_invoice_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_invoice.Text;
            View_Bill form8 = new View_Bill();
            form8.TopLevel = false;
            form8.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form8);
            form8.Dock = DockStyle.Fill;
            form8.Show();
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_Stock.Text;
            View_Stock form9 = new View_Stock();
            form9.TopLevel = false;
            form9.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form9);
            form9.Dock = DockStyle.Fill;
            form9.Show();
        }

      

        private void btn_employee_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_employee.Text;
            View_Employee form10 = new View_Employee();
            form10.TopLevel = false;
            form10.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form10);
            form10.Dock = DockStyle.Fill;
            form10.Show();
            
        }

        private void btn_supplier_Click(object sender, EventArgs e)
        {
            lbl_head.Text = btn_supplier.Text;
            View_Suppliers form11 = new View_Suppliers();
            form11.TopLevel = false;
            form11.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form11);
            form11.Dock = DockStyle.Fill;
            form11.Show();
        }

        private void main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_delivery_Click(object sender, EventArgs e)
        {

        }

        private void btn_report_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void winChartViewer1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            lbl_head.Text = "Home";
           

             this.main_panel.Controls.Clear();


            this.main_panel.Controls.Add(this.dash_board_panel);

           

        }

        private void btn_myprofile_Click(object sender, EventArgs e)
        {
            lbl_head.Text = "My Profile";


            this.main_panel.Controls.Clear();
            Add_Employee form = new Add_Employee();

            this.main_panel.Controls.Add(form.main_panel);
            form.main_panel.Anchor = AnchorStyles.Top;
            form.main_panel.Anchor = AnchorStyles.Left;
            form.main_panel.Anchor = AnchorStyles.Right;
            form.main_panel.Anchor = AnchorStyles.Bottom;
            form.main_panel.Dock = DockStyle.Fill;
            form.btn_update.Visible = true;
            form.register_button.Visible = false;
            form.back_btn.Visible = false;
            form.main_panel.AutoScroll = true;
            form.position_box.Enabled = false;
            form.checkBox1.Visible = false;
            form.user_grp.Visible = true;
            form.txt_ID.ReadOnly = true;
            form.fname_txt.ReadOnly = true;
            form.lname_txt.ReadOnly = true;
            form.nic_txt.ReadOnly = true;
            form.age_txt.ReadOnly = true;
            form.street_txt.ReadOnly = true;
            form.mobile_txt.ReadOnly = true;
            form.town_txt.ReadOnly = true;
            form.email_txt.ReadOnly = true;
            form.age_txt.ReadOnly = true;
            form.radio_male.Enabled = false;
            form.female_select.Enabled = false;
            form.district_box.Enabled = false;
            form.email_txt.ReadOnly = false;
            form.upload.Visible = false;
            form.dateTimePicker1.Enabled = false;

        }

        private void btn_notification_Click(object sender, EventArgs e)
        {
            View_cathegory form1 = new View_cathegory();
            form1.TopLevel = false;
            form1.TopMost = true;
            this.main_panel.Controls.Clear();
            this.main_panel.Controls.Add(form1);
            form1.Dock = DockStyle.Fill;
            form1.Show();
        }
    }
}
