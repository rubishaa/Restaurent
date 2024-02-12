using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_Project
{
    public partial class Add_Supplier : Form
    {
        Validation_Class vObject = new Validation_Class();
        public Add_Supplier()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
    }
}
