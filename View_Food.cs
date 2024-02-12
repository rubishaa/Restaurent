using System;
using System.Collections;
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

 
    public partial class view_food : Form
    {
      
        private static ArrayList List_FoodID = new ArrayList();
        private static ArrayList List_Cathegory = new ArrayList();
        private static ArrayList List_Name = new ArrayList();
        private static ArrayList List_Image = new ArrayList();
        private static ArrayList List_AvailableIngredients = new ArrayList();
        private static ArrayList List_Ingredients= new ArrayList();
        private static ArrayList List_Type = new ArrayList();
        private static ArrayList List_Small = new ArrayList();
        private static ArrayList List_Medium = new ArrayList();
        private static ArrayList List_Large = new ArrayList();
        private static ArrayList List_Description = new ArrayList();
        string foodgrid_id = null;
        DB_Connection_class DbObject = new DB_Connection_class();
        Add_Food form1 = new Add_Food();

        public view_food()
        {
            InitializeComponent();
        }
     
        private void View_Food_Load(object sender, EventArgs e)
        {
           /* string query = "select * from food_management ";
            DataTable table = (DataTable)DbObject.ShowDataInGridView(query);
            FoodGridView.DataSource = table;*/
           array_clear();
            GetFoodData();

            if (List_FoodID.Count > 0)
            {
                updateFoodDataGridView();
            }
            else
            {
                MessageBox.Show("Data Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }        
        private void cathegory_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query;
            array_clear();

            if(cathegory_box.SelectedItem.ToString() == "All")
            {
                query = "select * from food_management ";
            }
            else
            {
                query = "select * from food_management WHERE cathegory = '" + cathegory_box.SelectedItem.ToString() + "'";
            }
            add_Data(query);

            if (List_FoodID.Count > 0)
            {
                updateFoodDataGridView();
            }
            else
            {
                MessageBox.Show("Data Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void GetFoodData()
        {               
                string query = "select * from food_management ";
                add_Data(query);
        }
        private void updateFoodDataGridView()
        {
            FoodGridView.Rows.Clear();
            for (int i = 0; i < List_FoodID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(FoodGridView);
                newRow.Cells[1].Value = List_FoodID[i];
                newRow.Cells[2].Value = List_Cathegory[i];
                newRow.Cells[3].Value = List_Name[i];
                //newRow.Cells[4].Value = List_Image[i];
                newRow.Cells[5].Value = List_AvailableIngredients[i];
                newRow.Cells[6].Value = List_Ingredients[i];
                newRow.Cells[7].Value = List_Type[i];
                newRow.Cells[8].Value = List_Small[i];
                newRow.Cells[9].Value = List_Medium[i];
                newRow.Cells[10].Value = List_Large[i];
                newRow.Cells[11].Value = List_Description[i];             
                FoodGridView.Rows.Add(newRow);
            }
        }
        private void FoodGridView_Click(object sender, EventArgs e)
        {

        }

        private void FoodGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {           
        }
        private void btn_add_Click(object sender, EventArgs e)
        {                    
            form1.add_food_button.Visible = true;
            form1.btn_update.Hide();
            form1.ShowDialog();
        }     
      private void add_Data(string query)
        {
                try { 
                DbObject.OpenConnection();
                MySqlDataReader row;
                row = DbObject.DataReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {

                        List_FoodID.Add(row["food_id"].ToString());
                        List_Cathegory.Add(row["cathegory"].ToString());
                        List_Name.Add(row["food_name"].ToString());
                        //List_Image.Add(row["food_image"].ToString());
                        List_AvailableIngredients.Add(row["ingredient_available"].ToString());
                        List_Ingredients.Add(row["ingredients"].ToString());
                        List_Type.Add(row["food_type"].ToString());
                        List_Small.Add(row["small"].ToString());
                        List_Medium.Add(row["medium"].ToString());
                        List_Large.Add(row["large"].ToString());
                        List_Description.Add(row["description"].ToString());

                    }
                }
                else
                {
                    MessageBox.Show("Data Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                DbObject.CloseConnection();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void cathegory_box_Click(object sender, EventArgs e)
        {
            FoodGridView.Rows.Clear();
            cathegory_box.Items.Clear();
            cathegory_box.Items.Add("All");
            string query = "select name FROM cathegory";
            DbObject.OpenConnection();
            MySqlDataReader drd = DbObject.DataReader(query);
            while (drd.Read())
            {
                cathegory_box.Items.Add(drd["name"].ToString());
            }
            DbObject.CloseConnection();
        }
        private void array_clear()
        {
            List_FoodID.Clear();
            List_Cathegory.Clear();
            List_Name.Clear();
            List_Image.Clear();
            List_AvailableIngredients.Clear();
            List_Ingredients.Clear();
            List_Type.Clear();
            List_Small.Clear();
            List_Medium.Clear();
            List_Large.Clear();
            List_Description.Clear();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            int i = 0;
            if (FoodGridView.Rows.Count > 0)
            {
                string str = "DELETE from food_management WHERE food_id = '" + foodgrid_id + "'";
                DbObject.OpenConnection();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE the record ", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DbObject.ExecuteQueries(str);
                    MessageBox.Show("Deleted Sucessfully", "DELETED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FoodGridView.Rows.RemoveAt(FoodGridView.SelectedRows[i].Index);


                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("BACK TO THE FORM", "RETURN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Please Select the row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void FoodGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = FoodGridView.Rows[e.RowIndex];
                foodgrid_id  = row.Cells[1].Value.ToString();

            }
        }    
        private void btn_cathegory_Click(object sender, EventArgs e)
        {
            View_cathegory cathegory_form = new View_cathegory();
            lbl_heading.Text = "View Cathegory";
            lbl_cathegory.Visible = false;
            cathegory_box.Visible = false;
            food_panel.Controls.Clear();
            // food_panel.Visible= false;

            food_panel.Controls.Add(cathegory_form.cathegory_panel);
            food_panel.Controls.Add(cathegory_form.bottom_panel);
            cathegory_form.cathegory_panel.Dock = DockStyle.Fill;
            cathegory_form.bottom_panel.Dock = DockStyle.Bottom;

            cathegory_form.cathegory_panel.Anchor = AnchorStyles.Top;

            cathegory_form.cathegory_panel.Anchor = AnchorStyles.Right;

            cathegory_form.cathegory_panel.Anchor = AnchorStyles.Left;

            cathegory_form.cathegory_panel.Anchor = AnchorStyles.Bottom;
        }

        private void FoodGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.FoodGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            form1.add_food_button.Visible = false;
            form1.btn_reset.Visible = false;
            form1.btn_update.Show();
            form1.cathegory_box.SelectedItem = FoodGridView.CurrentRow.Cells[2].Value.ToString();
            form1.food_name.Text = FoodGridView.CurrentRow.Cells[3].Value.ToString();
            //form1.food_name.Text = FoodGridView.CurrentRow.Cells[4].Value.ToString();
            string ingre_available = FoodGridView.CurrentRow.Cells[5].Value.ToString();
            if (ingre_available == form1.ingredient_y.Text)
            {
                form1.ingredient_y.Checked = true;
            }
            else
            {
                form1.ingredient_n.Checked = true;
            }
            form1.ingredients_txt.Text = FoodGridView.CurrentRow.Cells[6].Value.ToString();
            string food_type = FoodGridView.CurrentRow.Cells[7].Value.ToString();

            if (food_type == form1.veg_select.Text)
            {
                form1.veg_select.Checked = true;

            }
            else
            {
                form1.nonveg_select.Checked = true;
            }
            string small = FoodGridView.CurrentRow.Cells[8].Value.ToString();
            if (small != "NOT AVAILABLE")
            {
                form1.small_size.Checked = true;
                form1.small_price.Visible = true;
                form1.small_price.Text = small;
            }
            else
            {
                form1.small_size.Checked = false;
                form1.small_price.Visible = false;

            }
            string medium = FoodGridView.CurrentRow.Cells[9].Value.ToString();
            if (medium != "NOT AVAILABLE")
            {
                form1.medium_size.Checked = true;
                form1.medium_price.Visible = true;
                form1.medium_price.Text = small;
            }
            else
            {
                form1.medium_size.Checked = false;
                form1.medium_price.Visible = false;

            }
            string large = FoodGridView.CurrentRow.Cells[10].Value.ToString();
            if (large != "NOT AVAILABLE")
            {
                form1.large_size.Checked = true;
                form1.large_price.Visible = true;
                form1.large_price.Text = small;
            }
            else
            {
                form1.large_size.Checked = false;
                form1.large_price.Visible = false;

            }
            form1.description_txt.Text = FoodGridView.CurrentRow.Cells[11].Value.ToString();
            form1.ShowDialog();
        }

        private void food_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
