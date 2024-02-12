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
    public partial class View_Discount : Form
    {
        private static ArrayList List_ID = new ArrayList();
        private static ArrayList List_category = new ArrayList();
        private static ArrayList List_name = new ArrayList();
        private static ArrayList List_foodID = new ArrayList();
        private static ArrayList List_status = new ArrayList();
        private static ArrayList List_size = new ArrayList();
        private static ArrayList List_selection = new ArrayList();
        private static ArrayList List_percentage = new ArrayList();
        private static ArrayList List_fixed = new ArrayList();
        private static ArrayList List_deducted = new ArrayList();
        private static ArrayList List_current = new ArrayList();
        private static ArrayList List_start = new ArrayList();
        private static ArrayList List_end = new ArrayList();
        private static ArrayList List_addedBy = new ArrayList();
        private static ArrayList List_addedOn = new ArrayList();
        public string discount_id = null;
        string id;
        DB_Connection_class DbObject = new DB_Connection_class();
        public View_Discount()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Add_Discount form1 = new Add_Discount();
            form1.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (discount_grid.Rows.Count > 0)
            {
                string str = "DELETE from discount WHERE discount_id = '" + discount_id + "'";
                DbObject.OpenConnection();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE the record ", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DbObject.ExecuteQueries(str);
                    MessageBox.Show("Deleted Sucessfully", "DELETED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    discount_grid.Rows.RemoveAt(discount_grid.SelectedRows[i].Index);


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

        private void View_Discount_Load(object sender, EventArgs e)
        {
            loadData();
           // discount_grid.DataSource = DbObject.ShowDataInGridView("select * from discount");
        }
        public void loadData()
        {
            array_clear();
            string query = "select * from discount ";
            GetFoodData(query);

            if (List_ID.Count > 0)
            {
                updateFoodDataGridView();
            }
            else
            {
                MessageBox.Show("Data Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void array_clear()
        {
            List_ID.Clear();
            List_category.Clear();
            List_name.Clear();
            List_foodID.Clear();
            List_status.Clear();
            List_size.Clear();
            List_selection.Clear();
            List_percentage.Clear();
            List_fixed.Clear();
            List_deducted.Clear();
            List_current.Clear();
            List_start.Clear();
            List_end.Clear();
            List_addedBy.Clear();
            List_addedOn.Clear();

        }
        public void GetFoodData(string qry)
        {
            try
            {
                DbObject.OpenConnection();
                string query = qry;

                MySqlDataReader row;
                row = DbObject.DataReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        List_ID.Add(row["discount_id"].ToString());
                        List_category.Add(row["category"].ToString());
                        List_name.Add(row["food_name"].ToString());
                        List_foodID.Add(row["food_id"].ToString());
                        List_status.Add(row["status"].ToString());
                        List_size.Add(row["sizes"].ToString());
                        List_selection.Add(row["selection"].ToString());
                        List_percentage.Add(row["dis_percent"].ToString());
                        List_fixed.Add(row["fixed_price"].ToString());
                        List_deducted.Add(row["deduct_price"].ToString());
                        List_current.Add(row["current_price"].ToString());
                        List_start.Add(row["start_from"].ToString());
                        List_end.Add(row["end_on"].ToString());
                        List_addedBy.Add(row["added_by"].ToString());
                        List_addedOn.Add(row["added_on"].ToString());
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
        private void updateFoodDataGridView()
        {
           discount_grid.Rows.Clear();
            for (int i = 0; i < List_ID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(discount_grid);
                newRow.Cells[0].Value = List_ID[i];
                newRow.Cells[1].Value = List_category[i];
                newRow.Cells[2].Value = List_name[i];
                newRow.Cells[3].Value = List_foodID[i];
                newRow.Cells[4].Value = List_status[i];
                newRow.Cells[5].Value = List_size[i];
                newRow.Cells[6].Value = List_selection[i];
                newRow.Cells[7].Value = List_percentage[i];
                newRow.Cells[8].Value = List_name[i];
                newRow.Cells[9].Value = List_fixed[i];
                newRow.Cells[10].Value = List_deducted[i];
                newRow.Cells[11].Value = List_current[i];
                newRow.Cells[12].Value = List_start[i];
                newRow.Cells[13].Value = List_end[i];
                newRow.Cells[14].Value = List_addedBy[i];
                newRow.Cells[15].Value = List_addedOn[i];

                discount_grid.Rows.Add(newRow);

             
            }
        }

        private void discount_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = discount_grid.Rows[e.RowIndex];
                discount_id = row.Cells[0].Value.ToString();
                id = discount_grid.Rows[e.RowIndex].Cells["ID_column"].Value.ToString();

            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem.ToString() == "All")
            {
                loadData();
            }
            else
            {
                string query = "Select * FROM discount wHERE status = '" + comboBox2.SelectedItem.ToString() + "'";
                GetFoodData(query);

                if (List_ID.Count > 0)
                {
                    updateFoodDataGridView();
                }
                else
                {
                    MessageBox.Show("Data Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
          
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Add_Discount form = new Add_Discount();

            form.btn_add.Visible = false;
            form.btn_update.Show();
            form.btn_reset.Hide();

            form.txt_ID.Text = discount_grid.CurrentRow.Cells[0].Value.ToString();
            form.cathegory_box.SelectedItem = discount_grid.CurrentRow.Cells[1].Value.ToString();
            form.name_box.SelectedItem = discount_grid.CurrentRow.Cells[2].Value.ToString();
            form.txt_food_id.Text = discount_grid.CurrentRow.Cells[3].Value.ToString();
            form.status_box.SelectedItem = discount_grid.CurrentRow.Cells[4].Value.ToString();
           
            string size = discount_grid.CurrentRow.Cells[5].Value.ToString();

            if (size == form.radio_all.Text)
            {
                form.radio_all.Checked = true;
            }
            else
            {
                form.radio_special.Checked = true;

            }
            form.size_box.SelectedItem = discount_grid.CurrentRow.Cells[6].Value.ToString();
            form.discount_value.Value = (decimal)discount_grid.CurrentRow.Cells[7].Value;
            form.txt_fixed.Text = discount_grid.CurrentRow.Cells[8].Value.ToString();
            form.txt_deducted.Text = discount_grid.CurrentRow.Cells[9].Value.ToString();
            form.txt_current.Text = discount_grid.CurrentRow.Cells[10].Value.ToString();
            form.start_calender.SelectionStart = DateTime.Parse(discount_grid.CurrentRow.Cells[11].Value.ToString());
            form.start_calender.SelectionEnd = DateTime.Parse(discount_grid.CurrentRow.Cells[11].Value.ToString());
            form.end_calender.SelectionStart = DateTime.Parse(discount_grid.CurrentRow.Cells[12].Value.ToString());
            form.end_calender.SelectionEnd = DateTime.Parse(discount_grid.CurrentRow.Cells[12].Value.ToString());
            form.discount_id = id;
            form.ShowDialog();
        }
    }
}
