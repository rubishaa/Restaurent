using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_Project
{
    public partial class View_Suppliers : Form
    {
        public View_Suppliers()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
          Add_Supplier form1 = new Add_Supplier();

            form1.btn_add.Visible = true;

            form1.ShowDialog();
        }

        private void View_Suppliers_Load(object sender, EventArgs e)
        {

        }
    }
}
