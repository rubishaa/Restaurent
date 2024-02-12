using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_Project
{
    public partial class View_Stock : Form
    {
        public View_Stock()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Add_Stock form1 = new Add_Stock();

          
            form1.ShowDialog();
        }

        private void View_Stock_Load(object sender, EventArgs e)
        {

        }
    }
}
