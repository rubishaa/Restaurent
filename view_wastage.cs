using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_Project
{
    public partial class view_wastage : Form
    {
        public view_wastage()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Add_Wastage form1 = new Add_Wastage();

            form1.btn_add.Visible = true;

            form1.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }
    }
}
