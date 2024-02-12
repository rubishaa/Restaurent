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
    public partial class View_Employee : Form
    {
        private static ArrayList List_employeeID = new ArrayList();
        private static ArrayList List_fname = new ArrayList();
        private static ArrayList List_lname = new ArrayList();
        private static ArrayList List_profile= new ArrayList();
        private static ArrayList List_nic = new ArrayList();
        private static ArrayList List_gender= new ArrayList();
        private static ArrayList List_age = new ArrayList();
        private static ArrayList List_date = new ArrayList();
        private static ArrayList List_street = new ArrayList();
        private static ArrayList List_town = new ArrayList();
        private static ArrayList List_district = new ArrayList();
        private static ArrayList List_email = new ArrayList();
        private static ArrayList List_mobile = new ArrayList();
        private static ArrayList List_role = new ArrayList();

        string employeegrid_id = null;
        DB_Connection_class DbObject = new DB_Connection_class();
        public View_Employee()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Add_Employee form1 = new Add_Employee();

            form1.register_button.Visible = true;
           
            form1.ShowDialog();
        }

        private void View_Employee_Load(object sender, EventArgs e)
        {
            array_clear();
            GetFoodData();

            if (List_employeeID.Count > 0)
            {
                updateFoodDataGridView();
            }
            else
            {
                MessageBox.Show("Data Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void updateFoodDataGridView()
        {
            employee_grid.Rows.Clear();
            for (int i = 0; i < List_employeeID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(employee_grid);
                newRow.Cells[0].Value = List_employeeID[i];
                newRow.Cells[1].Value = List_fname[i];
                newRow.Cells[2].Value = List_lname[i];
                //newRow.Cells[3].Value = List_Image[i];
                newRow.Cells[4].Value = List_nic[i];
            
                newRow.Cells[5].Value = List_age[i];
                newRow.Cells[6].Value = List_date[i];
                newRow.Cells[7].Value = List_street[i];
                newRow.Cells[8].Value = List_town[i];
                newRow.Cells[9].Value = List_district[i];
                newRow.Cells[10].Value = List_email[i];
                newRow.Cells[11].Value = List_mobile[i];
                newRow.Cells[11].Value = List_role[i];

                employee_grid.Rows.Add(newRow);
            }
        }

        private void GetFoodData()
        {
            string query = "select * from employee ";
            add_Data(query);
        }

        private void add_Data(string query)
        {
            try
            {
                DbObject.OpenConnection();
                MySqlDataReader row;
                row = DbObject.DataReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {               
                        List_employeeID.Add(row["e_id"].ToString());
                        List_fname.Add(row["fname"].ToString());
                        List_lname.Add(row["lname"].ToString());
                        //List_profile.Add(row["profile"].ToString());
                        List_nic.Add(row["nic_no"].ToString());
                        List_gender.Add(row["gender"].ToString());
                        List_age.Add(row["age"].ToString());
                        List_date.Add(row["date_join"].ToString());
                        List_street.Add(row["s_name"].ToString());
                        List_town.Add(row["t_name"].ToString());
                        List_district.Add(row["district"].ToString());
                        List_email.Add(row["email"].ToString());
                        List_mobile.Add(row["mobile"].ToString());
                        List_role.Add(row["role"].ToString());

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

        private void array_clear()
        {
            List_employeeID.Clear();
            List_fname.Clear();
            List_lname.Clear();
            //List_profile.Clear();
            List_nic.Clear();
            List_gender.Clear();
            List_age.Clear();
            List_date.Clear();
            List_street.Clear();
            List_town.Clear();
            List_district.Clear();
            List_email.Clear();
            List_mobile.Clear();
            List_role.Clear();
        }

        private void employee_grid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = employee_grid.Rows[e.RowIndex];
                employeegrid_id = row.Cells[0].Value.ToString();

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (employee_grid.Rows.Count > 0)
            {
                string str = "DELETE from food_management WHERE food_id = '" + employeegrid_id + "'";
                DbObject.OpenConnection();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE the record ", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DbObject.ExecuteQueries(str);
                    MessageBox.Show("Deleted Sucessfully", "DELETED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    employee_grid.Rows.RemoveAt(employee_grid.SelectedRows[i].Index);


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
    }
}
