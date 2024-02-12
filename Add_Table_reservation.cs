﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DbConnection;
using MySql.Data.MySqlClient;

namespace Restaurant_Project
{
    public partial class Add_Table_reservation : Form
    {
        DB_Connection_class DbObject = new DB_Connection_class();
        Validation_Class vObject = new Validation_Class();

        static Regex validate_emailaddress = email_validation();
        string pay_method = null;
        int total_payment = 0;

        public Add_Table_reservation()
        {
            InitializeComponent();
            
        }

        public void size_ValueChanged(object sender, EventArgs e)
        {
           
        }
         private void Table_reservation_Load(object sender, EventArgs e)
        {
          
            monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd ");
            start_picker.Format = DateTimePickerFormat.Custom;
            start_picker.CustomFormat = "hh : mm tt";
            end_picker.Format = DateTimePickerFormat.Custom;
            end_picker.CustomFormat = "hh : mm tt";

             monthCalendar1.MinDate = DateTime.Now.Date;
             monthCalendar1.MaxDate = DateTime.Now.Date.AddDays(2);
             time_validations();
             btn_check.Visible = false;

            ClearLabels();   
        }
        public void remove_comboBox()
        {
            string val = radio_selection();

            string str = "select DISTINCT table_no from booking where table_size=  '" + val + "' and ((s_time between '" + start_picker.Value.ToShortTimeString() + "' and '" + end_picker.Value.ToShortTimeString() + "' ) or (e_time between '" + start_picker.Value.ToShortTimeString() + "' and '" + end_picker.Value.ToShortTimeString() + "' ))";
            DbObject.OpenConnection();
            MySqlDataReader drd = DbObject.DataReader(str);
            while (drd.Read())
            {
                table_box.Items.Remove(drd["table_no"].ToString());
            }

        }

        private void btn_check_available_Click(object sender, EventArgs e)
        {
            table_box.Items.Clear();
            load_comboBox();
            remove_comboBox();
            table_box.Enabled = true;
                DbObject.CloseConnection();
            
        }
        public string radio_selection()
        {
            string val = null;
            if (small.Checked)
            {
                val = "small";
                total_payment = 100;
            }
            if (medium.Checked)
            {
                val = "medium";
                total_payment = 200;
            }
            if (big.Checked)
            {
                val = "big";
                total_payment = 300;
            }
            if (large.Checked)
            {
                val = "large";
                total_payment = 400;
            }
            if (ex_large.Checked)
            {
                val = "ex_large";
                total_payment = 600;
            }
            return val;
        }
        public string paymentSelection()
        {
           
            if (cash_radio.Checked)
            {
                pay_method = cash_radio.Text;
            }
            if (card_radio.Checked)
            {
                pay_method = card_radio.Text;
            }
            return pay_method;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            string t_size = radio_selection();
            pay_method = paymentSelection();
            try
            {
                if (cus_name.Text == null || size.Text == null || monthCalendar1.SelectionStart.Date == null || start_picker.Text == null || end_picker.Text == null || table_box.SelectedIndex ==-1 || address_txt.Text == null ||
                       mobile_txt.Text == null || (cash_radio.Checked==false && card_radio.Checked== false) || point_txt.Text == null || price_txt.Text== null )
                {
                    MessageBox.Show("Please Fill Empty Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {

                    DbObject.OpenConnection();
                    DbObject.ExecuteQueries("insert into booking (cus_name, no_person, table_size, date, s_time, e_time, table_no, address, mobile, email, comment, payment, loyalty_points, pay_method) Values('" + cus_name.Text + "','" + size.Text + "','" + t_size + "','" + monthCalendar1.SelectionStart.ToShortDateString() +
                         "', '" + start_picker.Value.ToShortTimeString()+ "', '" + end_picker.Value.ToShortTimeString() + "','" + table_box.SelectedItem + "','" + address_txt.Text + "','" + mobile_txt.Text + "' ,'" + email_txt.Text + "' ,'" + comment_txt.Text + "','" + price_txt.Text + "','" + point_txt.Text + "','" + pay_method + "')");
                    DbObject.CloseConnection();
                    MessageBox.Show("Added Sucessfully", "SAVED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetFields();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void load_comboBox()
        {
            string radio_select = radio_selection();
            string str = "select DISTINCT table_no from table_reservation where table_size = '" +radio_select +"'";
            DbObject.OpenConnection();
            MySqlDataReader drd = DbObject.DataReader(str);
            while (drd.Read())
            {
                table_box.Items.Add(drd["table_no"].ToString());
            }
            DbObject.CloseConnection();
        }

        private void small_CheckedChanged(object sender, EventArgs e)
        {
            table_box.Items.Clear();
            table_box.Enabled = false;
        }
        private void medium_CheckedChanged(object sender, EventArgs e)
        {
            table_box.Items.Clear();
            table_box.Enabled = false;

        }
        private void big_CheckedChanged(object sender, EventArgs e)
        {
            table_box.Items.Clear();
            table_box.Enabled = false;

        }

        private void large_CheckedChanged(object sender, EventArgs e)
        {
            table_box.Items.Clear();
            table_box.Enabled = false;

        }

        private void ex_large_CheckedChanged(object sender, EventArgs e)
        {
            table_box.Items.Clear();
            table_box.Enabled = false;

        }

        private void start_picker_ValueChanged(object sender, EventArgs e)
        {
           
           var dt  = RoundUp(DateTime.Parse(start_picker.Value.ToString()), TimeSpan.FromMinutes(15));
           start_picker.Value = DateTime.Parse(dt.ToString());

            DateTime t1 = DateTime.Parse(start_picker.Value.ToString());
            DateTime t2 = DateTime.Parse(end_picker.Value.ToString());
            int compared = TimeSpan.Compare(t1.TimeOfDay, t2.TimeOfDay);

            if (compared == -1 || compared == 0)
            {
                end_picker.MinDate = start_picker.Value.AddMinutes(15);
                
            }
          
        }

        private void end_picker_ValueChanged(object sender, EventArgs e)
        {
            end_picker.MaxDate = DateTime.Parse(start_picker.Value.AddHours(2).ToShortTimeString());
            var dt = RoundUp(DateTime.Parse(end_picker.Value.ToString()), TimeSpan.FromMinutes(15));
            end_picker.Value = DateTime.Parse(dt.ToString());

           DateTime t1 = DateTime.Parse(start_picker.Value.ToString());
           DateTime t2 = DateTime.Parse(end_picker.Value.ToString());

          int compared =   TimeSpan.Compare(t1.TimeOfDay, t2.TimeOfDay);
         
            if (compared == 1 || compared == 0)
            {
                MessageBox.Show("Invalid Time", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                end_picker.Value = start_picker.Value.AddMinutes(15);
                btn_check.Visible = false;
            }
            else
            {
                
                btn_check.Visible = true;
                
            }

        }
        private void resetFields()
        {
            cus_name.Clear();
            size.Value = 0;

            var today = DateTime.Today;
            monthCalendar1.SelectionStart = DateTime.Now.Date;
            monthCalendar1.SelectionEnd = DateTime.Now.Date;

            small.Enabled = false;
            medium.Enabled = false;
            big.Enabled = false;
            large.Enabled = false;
            ex_large.Enabled = false;

            start_picker.Value = DateTime.Now;
            end_picker.Value = DateTime.Now;
            table_box.Items.Clear();
            address_txt.Clear();
            mobile_txt.Clear();
            email_txt.Clear();
            comment_txt.Clear();
            price_txt.Clear();
            cash_radio.Checked = false;
            card_radio.Checked = false;
            point_txt.Clear();
            ClearLabels();
         }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
        public static Regex name_validation()
        {
            string pattern = @"^[a-zA-Z]+$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        public static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
              + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
              + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public void cus_name_TextChanged(object sender, EventArgs e)
        {
            ClearLabels();
            name_error_lbl.Visible = false;
            bool verify = vObject.validattion(cus_name.Text);

            if (verify == false)
            {
                name_error_lbl.Visible = true;
                name_error_lbl.Text = "! Invalid input";
                cus_name.Clear();
            }
            else
            {
                name_error_lbl.Visible = false;
            }
        }
       

        public void ClearLabels()
        {
          

            name_error_lbl.Visible = false;
            email_error.Visible = false;
            address_lbl_error.Visible = false;
        }

        public void email_txt_TextChanged(object sender, EventArgs e)
        {
            ClearLabels();
            if (validate_emailaddress.IsMatch(email_txt.Text) != true)
            {
                email_error.Visible = true;
                email_error.Text = "! Invalid input";
                email_txt.Clear();

                return;
            }
        }
        public void decide_Size()
        {
            if (size.Value > 0 && size.Value <= 2)
            {
                small.Checked = true;
                small.Enabled = true;
                medium.Enabled = false;
                big.Enabled = false;
                large.Enabled = false;
                ex_large.Enabled = false;


            }
            if (size.Value > 2 && size.Value <= 5)
            {
                medium.Checked = true;
                medium.Enabled = true;
                small.Enabled = false;
                big.Enabled = false;
                large.Enabled = false;
                ex_large.Enabled = false;


            }
            if (size.Value > 6 && size.Value <= 10)
            {
                big.Checked = true;
                big.Enabled = true;
                medium.Enabled = false;
                small.Enabled = false;
                large.Enabled = false;
                ex_large.Enabled = false;


            }
            if (size.Value > 10 && size.Value <= 15)
            {
                large.Checked = true;
                large.Enabled = true;
                medium.Enabled = false;
                small.Enabled = false;
                big.Enabled = false;
                ex_large.Enabled = false;

            }
            if (size.Value > 15 && size.Value <= 20)
            {
                ex_large.Checked = true;
                ex_large.Enabled = true;
                medium.Enabled = false;
                small.Enabled = false;
                big.Enabled = false;
                large.Enabled = false;

            }
            if (size.Value > 20)
            {
                medium.Enabled = false;
                small.Enabled = false;
                big.Enabled = false;
                large.Enabled = false;
                ex_large.Enabled = false;
                string message = "Invalid number. try Again";
                string title = "Invalid";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);

            }


        }

        private void comment_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mobile_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string query = "select COUNT(mobile)  from booking WHERE mobile = '" + mobile_txt.Text + "'";
                DbObject.OpenConnection();
                int times = DbObject.CountData(query);
                DbObject.CloseConnection();
                if (times > 0)
                {
                    MessageBox.Show("Mobile Number Found", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mobile Number Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                point_txt.Text = (times * 10).ToString();

            }
        }

        private void point_txt_TextChanged(object sender, EventArgs e)
        {
            price_txt.Text = (total_payment - (int.Parse(point_txt.Text))).ToString();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (cus_name.Text == null || size.Text == null || monthCalendar1.SelectionStart.Date == null || start_picker.Text == null || end_picker.Text == null || table_box.SelectedIndex == -1 || address_txt.Text == null ||
                     mobile_txt.Text == null || (cash_radio.Checked == false && card_radio.Checked == false) || point_txt.Text == null || price_txt.Text == null)
                {
                    MessageBox.Show("Please Fill Empty Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                else
                {
                    View_table_reservation vr = new View_table_reservation();
                    int i = vr.booking_view.SelectedCells[0].RowIndex;

                    string t_size = radio_selection();
                    DbObject.OpenConnection();
                    string query = "UPDATE booking SET cus_name ='" + cus_name.Text + "', no_person= '" + size.Text + "', table_size= '" + t_size + "',date= '" + monthCalendar1.SelectionStart.ToShortDateString() + "' s_time = '" + start_picker.Value.ToShortTimeString() + "', etime= '" + end_picker.Value.ToShortTimeString() + "', table_no= '" + table_box.SelectedItem + "', address= '" + address_txt.Text + "', mobile=  '" + mobile_txt.Text + "',email= '" + email_txt.Text + "', comment= '" + comment_txt.Text + "','" + price_txt.Text + "','" + point_txt.Text + "','" + pay_method + "' WHERE booking_id = '" + vr.booking_view.SelectedRows[i].Cells[0].Value.ToString() + "' ";
                    DbObject.ExecuteQueries(query);
                    MessageBox.Show("Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DbObject.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void end_picker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (monthCalendar1.SelectionStart.Date == DateTime.MinValue.Date || (start_picker.Value == DateTime.Now && start_picker.Value == DateTime.Now))
                {
                    table_box.Enabled = false;
                    btn_check.Enabled = false;
                    btn_check.Visible = false;
                }
                else
                {
                    btn_check.Visible = true;
                    btn_check.Enabled = true;
                    table_box.Enabled = true;
                }

            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
           
        }
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }
        private void time_validations()
        {
            DateTime t1 = DateTime.Parse(DateTime.Now.ToString());
            DateTime t2 = DateTime.ParseExact("11 : 00 AM", "hh : mm tt",null);
           

            int compared_start = TimeSpan.Compare(t1.TimeOfDay, t2.TimeOfDay);

            if (compared_start == -1 || compared_start == 0)
            {
                start_picker.MinDate = DateTime.ParseExact("11 : 00 AM", "hh : mm tt", null);
            }
            else
            {
                start_picker.MinDate = DateTime.Now;
            }
           start_picker.MaxDate =  DateTime.ParseExact("09 : 30 PM", "hh : mm tt", null);
           end_picker.MinDate = DateTime.Parse(start_picker.Value.AddMinutes(15).ToShortTimeString());
        }

        private void size_MouseUp(object sender, MouseEventArgs e)
        {
            if (size.Value == 0)
            {
                monthCalendar1.Visible = false;
                start_picker.Enabled = false;
                end_picker.Enabled = false;

            }
            else
            {
                decide_Size();
                monthCalendar1.Visible = true;
            }

        }

        private void monthCalendar1_VisibleChanged(object sender, EventArgs e)
        {
           
          
        }

        private void monthCalendar1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            table_box.Items.Clear();
            start_picker.Enabled = true;
            end_picker.Enabled = true;
        }
    }
   
        
}
