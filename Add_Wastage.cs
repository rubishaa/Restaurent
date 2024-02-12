using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_Project
{
    public partial class Add_Wastage : Form
    {
        public Add_Wastage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Wastage_Load(object sender, EventArgs e)
        {
            monthCalendar1.MaxDate = DateTime.Today;
            monthCalendar1.MinDate = DateTime.Now.Date.AddDays(-7);
            radio_food.Checked = true;
            
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(measure_box.SelectedItem.ToString() == "head" || radio_food.Checked == true)
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
           

        }

        private void txt_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }

        private void txt_reason_TextChanged(object sender, EventArgs e)
        {

        }

        private void radio_raw_CheckedChanged(object sender, EventArgs e)
        {
            if(radio_raw.Checked == true)
            {
                lbl_food_cathegory.Visible = false;
                food_cathegory_box.Visible = false;
            }
            else
            {
                lbl_food_cathegory.Visible = true;
                food_cathegory_box.Visible = true;
            }
        }
    }
}
