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
    public partial class Add_Food : Form
    {
        DB_Connection_class Dbobject = new DB_Connection_class();
        string price_of_small = "NOT AVAILABLE";
        string price_of_medium = "NOT AVAILABLE";
        string price_of_large = "NOT AVAILABLE";
        string ingredients = "NOT AVAILABLE";
        string description = "NOT AVAILABLE";

        Validation_Class vObject = new Validation_Class();

        public Add_Food()
        {
            InitializeComponent();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                photo_box.Image = new Bitmap(opnfd.FileName);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

            this.Dispose();
            DashBoard_form df = new DashBoard_form();
            df.Show();
        }

        private void Add_Food_Load(object sender, EventArgs e)
        {           
        }
        public string choice_selection()
        {
            string choice = null;

            if (ingredient_y.Checked)
            {
                choice = ingredient_y.Text;
                ingredients_txt.Visible = true;
            }
            else
            {
                choice = ingredient_n.Text;
                ingredients_txt.Visible = false;
            }
            return choice;
        }
        public string foodtype_selection()
        {
            string food_type = null;

            if (veg_select.Checked)
            {
                food_type = veg_select.Text;

            }
            if (nonveg_select.Checked)
            {
                food_type = nonveg_select.Text;
            }
            return food_type;
        }

        private void add_food_button_Click(object sender, EventArgs e)
        {
            string food_type = foodtype_selection();
            string choice = choice_selection();
            string query = "INSERT INTO food_management(cathegory, food_name, food_image, ingredient_available, ingredients, food_type, small, medium, large, description)VALUES('" + cathegory_box.SelectedItem + "','" + food_name.Text + "','" + photo_box.Image + "','" + choice + "','" + ingredients + "','" + food_type + "','" + price_of_small + "','" + price_of_medium + "','" + price_of_large + "','" + description + "')";
            try
            {
                if (cathegory_box.SelectedIndex == -1 || food_name.Text == null || photo_box.Image == null || (ingredient_y.Checked == false && ingredient_n.Checked == false) || (veg_select.Checked == false && nonveg_select.Checked == false))
                {
                    MessageBox.Show("Please Fill Mandotory Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
               else if (ingredient_y.Checked == true && ingredients_txt.Text == null)
                {
                    MessageBox.Show("Please Add Ingredients!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
               else if ((small_size.Checked == true && small_price.Text == null) || (medium_size.Checked == true && medium_price.Text == null) || (large_size.Checked == true && large_price.Text == null))
                {
                    MessageBox.Show("Please Input the price!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    Dbobject.OpenConnection();
                    Dbobject.ExecuteQueries(query);
                    MessageBox.Show("Added Sucessfully", "SAVED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dbobject.CloseConnection();
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void small_size_CheckedChanged(object sender, EventArgs e)
        {
            
            if (small_size.Checked == true)
            {
                if ((medium_price.Text == " " && medium_size.Checked) || (large_price.Text == " " && large_size.Checked))
                {
                    small_price.Visible = false;
                    price_lbl.Visible = true; ;
                }
                else
                {
                    price_lbl.Show();
                    small_price.Visible = true;
                }
                             
            }
           
            else
            {
                if ((medium_price.Text == " " && medium_size.Checked) || (large_price.Text == " " && large_size.Checked))
                {
                    small_price.Visible = false;
                    price_lbl.Show();
                }
                else
                {
                    small_price.Visible = false;
                    price_lbl.Hide();
                }
               
            }
           
        }        
        private void medium_size_CheckedChanged(object sender, EventArgs e)
        {
            if (medium_size.Checked == true)
            {
                price_lbl.Visible = true;
                medium_price.Visible = true;
            }
            else if ((small_price.Text == null && small_size.Checked == true) || (large_price.Text == null && large_size.Checked == true))
            {
                medium_price.Visible = false;
                price_lbl.Visible = true;
            }
            else
            {               
                   medium_price.Visible = false;
                    price_lbl.Visible = false;
            }

        }
        private void large_size_CheckedChanged(object sender, EventArgs e)
        {
            if (large_size.Checked)
            {
                price_lbl.Visible = true;
                large_price.Visible = true;
            }
            else if ((medium_price.Text == null && medium_size.Checked == true) || (small_price.Text == null && small_size.Checked == true))
            {
                large_price.Visible = false;
                price_lbl.Visible = true;
            }

            else
                {
                  large_price.Visible = false;
                    price_lbl.Visible = false;
                }
        }

        private void small_price_TextChanged(object sender, EventArgs e)
        {
            price_lbl.Visible = false;
            price_of_small = small_price.Text;
        }

        private void medium_price_TextChanged(object sender, EventArgs e)
        {
            price_lbl.Visible = false;
            price_of_medium = medium_price.Text;
        }

        private void large_price_TextChanged(object sender, EventArgs e)
        {
            price_lbl.Visible = false;
            price_of_large = large_price.Text;
        }

        private void ingredient_y_CheckedChanged(object sender, EventArgs e)
        {
            ingredients_txt.Visible = true;
        }

        private void ingredient_n_CheckedChanged(object sender, EventArgs e)
        {
            ingredients_txt.Visible = false;
        }

        private void ingredients_txt_TextChanged(object sender, EventArgs e)
        {
            ingredients = ingredients_txt.Text;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (cathegory_box.SelectedItem == null || food_name.Text == null || photo_box.Image == null || (ingredient_y.Checked == false && ingredient_n.Checked == false) || (small_size.Checked == false && medium_size.Checked == false && large_size.Checked == false ) || 
                     (veg_select.Checked == false && nonveg_select.Checked == false))
                {
                    MessageBox.Show("Please Fill Empty Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   
                }
                if (ingredient_y.Checked == true && ingredients_txt.Text == null)
                {
                    MessageBox.Show("Please Add Ingredients!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                if ((small_size.Checked == true && small_price.Text == null) || (medium_size.Checked == true && medium_price.Text == null) || (large_size.Checked == true && large_price.Text == null))
                {
                    MessageBox.Show("Please Input the price!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                else
                {
                    view_food vf = new view_food();
                    int i = vf.FoodGridView.SelectedCells[0].RowIndex;

                    string food_type = foodtype_selection();
                    string choice = choice_selection();
                    Dbobject.OpenConnection();
                    string query = "UPDATE food_management SET cathegory ='" + cathegory_box.SelectedItem.ToString() + "', food_name = '" + food_name.Text + "', food_image = '" +photo_box.Image + "',ingredients_available= '" + choice + "' ingredients= '" + ingredients_txt.Text + "', food_type= '" + food_type + "', small= '" + price_of_small+ "', medium= '" +  price_of_medium + "', large=  '" + price_of_large + "',description= '" + description + "'  WHERE food_id = '" + vf.FoodGridView.SelectedRows[i].Cells[0].Value.ToString() + "' ";
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

        private void btn_reset_Click(object sender, EventArgs e)
        {
            reset();
            lbl_error.Visible = false;
        }
        private void reset()
        {
            cathegory_box.SelectedIndex = -1;
            food_name.Clear();
            if(photo_box.Image != null)
            {
                photo_box.Image.Dispose();
            }
           
            ingredient_y.Checked = false;
            ingredient_n.Checked = false;
            ingredients_txt.Clear();
            veg_select.Checked = false;
            nonveg_select.Checked = false;
            small_size.Checked = false;
            small_price.Visible = false;
            medium_size.Checked = false;
            medium_price.Visible = false;
            large_size.Checked = false;
            large_price.Visible = false;
            price_lbl.Visible = false;
            if(description_txt.Text != null)
            {
                description_txt.Clear();
            }
           
        }

        private void btn_cathegory_add_Click(object sender, EventArgs e)
        {
           
            Add_Cathegory form = new Add_Cathegory();
            form.btn_cathegory_update.Visible = false;
            form.ShowDialog();
           
          
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

        private void cathegory_box_Click(object sender, EventArgs e)
        {
            cathegory_box.Items.Clear();
            loadCathegory();
        }

        private void cathegory_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cathegory_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string size = null;
            string type = null;
            string query = "select size_available, type_available FROM cathegory WHERE name = '" + cathegory_box.SelectedItem.ToString() + "'";
            Dbobject.OpenConnection();
            MySqlDataReader drd = Dbobject.DataReader(query);
            while (drd.Read())
            {
                size = drd["size_available"].ToString();
                type = drd["type_available"].ToString();
            }
            if (size == "No")
            {
               size_grp.Visible = false;
               txt_price.Visible = true;
               lbl_main_price.Text = "Price";

            }
            if (type == "No")
            {
                type_grp.Visible = false;
            }
        }

        private void food_name_TextChanged(object sender, EventArgs e)
        {
            if(food_name.Text == null)
            {
                lbl_error.Visible = false;

            }
            lbl_error.Visible = false;

            bool verify = vObject.validattion(food_name.Text);

            if (verify == false)
            {
                lbl_error.Visible = true;
                lbl_error.Text = "! Invalid input";
                food_name.Clear();
            }
            else
            {
                lbl_error.Visible = false;
            }
        }

        private void small_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
          
        }

        private void medium_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
          
        }

        private void large_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
          
        }

        private void description_txt_TextChanged(object sender, EventArgs e)
        {
            description = description_txt.Text ;
        }
    }
}
