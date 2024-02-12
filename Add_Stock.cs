using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_Project
{
    public partial class Add_Stock : Form
    {
        Validation_Class vObject = new Validation_Class();
        public Add_Stock()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            lbl_error_name.Visible = false;
            bool verify = vObject.validattion(txt_name.Text);

            if (verify == false)
            {
                lbl_error_name.Visible = true;
                lbl_error_name.Text = "! Invalid";
                txt_name.Clear();
            }
            else
            {
                lbl_error_name.Visible = false;
            }
        }

        private void txt_description_TextChanged(object sender, EventArgs e)
        {
            lbl_error_description.Visible = false;
            bool verify = vObject.validattion(txt_description.Text);

            if (verify == false)
            {
                lbl_error_description.Visible = true;
                lbl_error_description.Text = "! Invalid";
                txt_description.Clear();
            }
            else
            {
                lbl_error_description.Visible = false;
            }
        }

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void measurement_box_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void measurement_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            if (measurement_box.SelectedItem.ToString() == "head")
            {
                count_value.Visible = true;
                txt_count.Visible = false;
                count_value.Increment = 1;
            }
            else
            {
                count_value.Visible = false;
                txt_count.Visible = true;
            }

        }

        private void txt_manufacturer_TextChanged(object sender, EventArgs e)
        {
            lbl_error_manufacturer.Visible = false;
            bool verify = vObject.validattion(txt_manufacturer.Text);

            if (verify == false)
            {
                lbl_error_manufacturer.Visible = true;
                lbl_error_manufacturer.Text = "! Invalid";
                txt_manufacturer.Clear();
            }
            else
            {
                lbl_error_manufacturer.Visible = false;
            }
        }

        private void Add_Stock_Load(object sender, EventArgs e)
        {
          
            monthCalendar1.MinDate = DateTime.Today;
            monthCalendar1.MaxDate = DateTime.Today.AddYears(10);
            if (txt_count.Text == " ")
            {
                txt_count.Text = "0";
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void cathegory_box_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public string radio_selection()
        {
            string val = null;
            if(expiry_y.Checked == true)
            {
                val = expiry_y.Text;
                monthCalendar1.Visible = true;
            }
            if (expiry_n.Checked == true)
            {
                val = expiry_n.Text;
                monthCalendar1.Visible =false;
            }

            return val;
        }

        private void expiry_y_CheckedChanged(object sender, EventArgs e)
        {
            radio_selection();
        }

        private void expiry_n_CheckedChanged(object sender, EventArgs e)
        {
            radio_selection();
        }

        private void count_value_ValueChanged(object sender, EventArgs e)
        {
            double u_price = double.Parse(txt_price.Text);
            int count = (int)count_value.Value;
            txt_cost.Text = (u_price * count).ToString();
        }

        private void txt_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            
        }

        private void txt_count_TextChanged(object sender, EventArgs e)
        {
            if(txt_count.Text == " ")
            {
                txt_count.Text = "0";
            }
            double u_price = double.Parse(txt_price.Text);
            double count = double.Parse(txt_count.Text);
            txt_cost.Text = (u_price * count).ToString();
        }

        private void btn_supplier_Click(object sender, EventArgs e)
        {
            Add_Supplier form = new Add_Supplier();
            form.btn_update.Visible = false;
            form.ShowDialog();
        }

        private void txt_count_VisibleChanged(object sender, EventArgs e)
        {
            if (txt_count.Text == " ")
            {
                txt_count.Text = "0";
            }
        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void cathegory_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cathegory_box.SelectedItem.ToString() == "Kitchen Appliances")
            {
                lbl_date_selection.Text = "Has Warranty   :";
                lbl_date.Text = "Warranty Date :";
                measurement_box.SelectedItem = "head";
                measurement_box.Enabled = false;
                count_value.Visible = true;
                txt_count.Visible = false;
                txt_price.MaxLength = 6;
            }
            else
            {
                lbl_date_selection.Text = "Has Expiry   :";
                lbl_date.Text = "Expiry Date   :";
                txt_price.MaxLength = 4;
                measurement_box.Enabled = true;
                measurement_box.SelectedIndex = -1;
                count_value.Visible = false;
                txt_count.Visible = true;
            }
        }
    }
}
