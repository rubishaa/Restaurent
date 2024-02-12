using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DbConnection;
using MySql.Data.MySqlClient;

namespace Restaurant_Project
{
    public partial class Add_Discount : Form
    {
        double f_price = 0;
        double d_amount = 0;
        DB_Connection_class Dbobject = new DB_Connection_class();
        string small;
        string medium;
        string large;
        string selection = null;
        public string discount_id = "";
        DashBoard_form d_form = new DashBoard_form();


        public Add_Discount()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Discount_Load(object sender, EventArgs e)
        {
            start_calender.MinDate = DateTime.Today;
            start_calender.MaxDate = DateTime.Today.AddMonths(1);
            end_calender.MinDate = DateTime.Today;
            start_calender.MaxDate = DateTime.Today.AddMonths(1);
            txt_fixed.Text = 0.ToString();
            txt_current.Text = 0.ToString();
            txt_deducted.Text = 0.ToString();
           
            getDiscountlNo();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cathegory_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            
                name_box.Enabled = true;
                string str_menu = "select DISTINCT food_name from food_management where cathegory=  '" + cathegory_box.SelectedItem.ToString() + "'";
                Dbobject.OpenConnection();
                MySqlDataReader drd = Dbobject.DataReader(str_menu);
                while (drd.Read())
                {
                    name_box.Items.Add(drd["food_name"].ToString());
                }
                string query= "select size_available from cathegory where name=  '" + cathegory_box.SelectedItem.ToString() + "'";
                string selection  = Dbobject.Max_No(query);

                if(selection == "Yes")
                {
                    radio_special.Enabled = true;
                }
                else
                {
                    radio_special.Enabled = false;
                }
            
        }

        private void status_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (status_box.SelectedItem.ToString() == "Cancelled" || status_box.SelectedItem.ToString() == "Expired")
            {
                discount_value.Value = 0;
            }
        }

        private void status_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void discount_value_ValueChanged(object sender, EventArgs e)
        {
            f_price = double.Parse(txt_fixed.Text);
            txt_deducted.Text = ((((double)discount_value.Value) / 100) * f_price).ToString();
        }

        

        private void cathegory_box_Click(object sender, EventArgs e)
        {
            cathegory_box.Items.Clear();
            loadCathegory();
        }
        public void loadCathegory()
        {
            string query = "select name FROM cathegory";
            Dbobject.OpenConnection();
            MySqlDataReader drd = Dbobject.DataReader(query);
            while (drd.Read())
            {
                cathegory_box.Items.Add(drd["name"].ToString());
            }
            Dbobject.CloseConnection();
        }

        private void name_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string qry = "SELECT food_id FROM food_management WHERE food_name = '"+name_box.SelectedItem.ToString()+"'";

            string id = Dbobject.Max_No(qry);
            txt_food_id.Text = id;
            
        }

        private void radio_special_CheckedChanged(object sender, EventArgs e)
        {
            if(radio_special.Checked == true)
            {
                size_box.Visible = true;
                size_lbl.Visible = true;
                amount_box.Visible = true;

            }
            if (radio_special.Checked == false && radio_all.Checked == true)
            {
                size_box.Visible = false;
                size_lbl.Visible = false;
                amount_box.Visible = false;


            }
        }

        private void size_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (size_box.SelectedItem.ToString() == "S")
            {
                txt_fixed.Text = small;
            }
            if (size_box.SelectedItem.ToString() == "M")
            {
                txt_fixed.Text = medium;
            }
            if (size_box.SelectedItem.ToString() == "L")
            {
                txt_fixed.Text = large;
            }
        }

        private void size_box_VisibleChanged(object sender, EventArgs e)
        {
            if(size_box.Visible == true)
            {
                
                Dbobject.OpenConnection();
                string str_small = "select * from food_management where food_name ='" + name_box.SelectedItem.ToString() + "'";
                MySqlDataReader drd = Dbobject.DataReader(str_small);
                if (drd.Read())
                {
                    small = (drd["small"].ToString());
                    if (small != "NOT AVAILABLE")
                    {
                        size_box.Items.Add("S");
                    }

                    medium = (drd["medium"].ToString());
                    if (medium != "NOT AVAILABLE")
                    {
                        size_box.Items.Add("M");
                    }
                    large = (drd["large"].ToString());
                    if (large != "NOT AVAILABLE")
                    {
                        size_box.Items.Add("L");
                    }
                }
                Dbobject.CloseConnection();
            }
        }

        private void txt_deducted_TextChanged(object sender, EventArgs e)
        {
            d_amount = double.Parse(txt_deducted.Text);
            txt_current.Text = (f_price - d_amount).ToString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string type = typeSelection();
   
            try
            {
                if (cathegory_box.SelectedIndex == -1 || name_box.SelectedIndex == -1 || status_box.SelectedIndex == -1 || type == null || discount_value.Value == 0 || start_calender.SelectionStart.Date == null || end_calender.SelectionStart.Date == null)
                {
                    MessageBox.Show("Please Fill Mandotory Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(type == radio_special.Text && size_box.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Fill Mandotory Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    string query = "INSERT INTO discount VALUES('" + txt_ID.Text + "','" + cathegory_box.SelectedItem.ToString() + "','" + name_box.SelectedItem.ToString()+ "','" + txt_food_id.Text + "', '" + status_box.SelectedItem.ToString() + "', '" + type + "', '" + size_box.SelectedItem.ToString() + "', '" + discount_value.Value + "', '" + start_calender.SelectionStart.ToString() + "', '" + end_calender.SelectionStart.ToString() + "', '" + d_form.lbl_name + "', '" + d_form.lbl_date + "')";

                    Dbobject.OpenConnection();
                    Dbobject.ExecuteQueries(query);
                    MessageBox.Show("Added Sucessfully", "SAVED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    Dbobject.CloseConnection();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getDiscountlNo()
        {
            string qry = "SELECT discount_id FROM discount ORDER BY discount_id DESC LIMIT 1";

            string max_no = Dbobject.Max_No(qry);


            int no = Convert.ToInt32(max_no.Substring(2, (max_no.Length - 2)));
            no++;
            txt_ID.Text = "D/" + no;


        }
        private string typeSelection()
        {

            
            if(radio_all.Checked == true)
            {
                selection = radio_all.Text;
            }
            else
            {
                selection = radio_special.Text;
            }


            return selection;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            txt_food_id.Clear();
            cathegory_box.SelectedIndex = -1;
            name_box.SelectedIndex = -1;
            radio_special.Checked = false;
            radio_special.Enabled = false;
            radio_all.Checked = true;
            discount_value.Value = 0;
            start_calender.SelectionStart = DateTime.Now.Date;
            start_calender.SelectionEnd = DateTime.Now.Date;
            end_calender.SelectionStart = DateTime.Now.Date;
            end_calender.SelectionEnd = DateTime.Now.Date;

        }

        private void cathegory_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string type = typeSelection();
         
            try
            {
                if (cathegory_box.SelectedIndex == -1 || name_box.SelectedIndex == -1 || status_box.SelectedIndex == -1 || type == null || discount_value.Value == 0 || start_calender.SelectionStart.Date == null || end_calender.SelectionStart.Date == null)
                {
                    MessageBox.Show("Please Fill Mandotory Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (type == radio_special.Text && size_box.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Fill Mandotory Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                else
                {
                    Dbobject.OpenConnection();
                    string query = "UPDATE discount SET discount_id ='" + txt_ID.Text + "', category = '" + cathegory_box.SelectedItem.ToString() + "', food_name= '" + name_box.SelectedItem.ToString() + "', food_id= '" + txt_food_id.Text + "', status= '" + status_box.SelectedItem.ToString() + "', sizes= '" + type + "', selection= '" + size_box.SelectedItem.ToString() + "', dis_percent= '" + discount_value.Value + "', fixed_price= '" + txt_fixed.Text + "', deduct_price= '" + txt_deducted.Text + "', current_price= '" +txt_current.Text+ "', start_from= '" + start_calender.SelectionStart.ToString() + "', end_on= '" + end_calender.SelectionStart.ToString() + "', added_by= '" + d_form.lbl_name + "', added_on = '" + d_form.lbl_date + "' WHERE discount_id = '" + discount_id + "'";
                    Dbobject.ExecuteQueries(query);
                    MessageBox.Show("Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dbobject.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
