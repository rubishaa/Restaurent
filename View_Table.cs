using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DbConnection;


namespace Restaurant_Project
{
    public partial class View_Table : Form
    {
        private static ArrayList List_ID = new ArrayList();
        private static ArrayList List_Size = new ArrayList();
        private static ArrayList List_No = new ArrayList();
        private static ArrayList List_Shape = new ArrayList();
        private static ArrayList List_Condition = new ArrayList();
        private static ArrayList List_Dimension = new ArrayList();
        private static ArrayList List_People = new ArrayList();
        private static ArrayList List_Price = new ArrayList();
        private static ArrayList List_Manufacturer = new ArrayList();
        private static ArrayList List_Date = new ArrayList();
        DB_Connection_class DbObject = new DB_Connection_class();
        string tablegrid_id = null;
    
        public View_Table()
        {
            InitializeComponent();
        }

        private void View_Table_Load(object sender, EventArgs e)
        {

            loadData();
        }
        public void GetTableData()
        {
            try
            {
                DbObject.OpenConnection();
                string query = "select * from table_reservation ";

                MySqlDataReader row;
                row = DbObject.DataReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {

                        List_ID.Add(row["table_id"].ToString());
                        List_Size.Add(row["table_size"].ToString());
                        List_No.Add(row["table_no"].ToString());
                        List_Shape.Add(row["table_shape"].ToString());
                        List_Condition.Add(row["table_condition"].ToString());
                        List_Dimension.Add(row["table_dimension"].ToString());
                        List_People.Add(row["no_of_people"].ToString());
                        List_Price.Add(row["reservation_price"].ToString());
                        List_Manufacturer.Add(row["table_manufacturer"].ToString());
                        List_Date.Add(row["table_date_purchase"].ToString());

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
        public void updateTableDataGridView()
        {
            TableGridView.Rows.Clear();
            for (int i = 0; i < List_ID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
               
                newRow.CreateCells(TableGridView);
                newRow.Cells[0].Value = List_ID[i];
                newRow.Cells[1].Value = List_Size[i];
                newRow.Cells[2].Value = List_No[i];
                newRow.Cells[3].Value = List_Shape[i];
                newRow.Cells[4].Value = List_Condition[i];
                newRow.Cells[5].Value = List_Dimension[i];
                newRow.Cells[6].Value = List_People[i];
                newRow.Cells[7].Value = List_Price[i];
                newRow.Cells[8].Value = List_Manufacturer[i];
                newRow.Cells[9].Value = List_Date[i];

                TableGridView.Rows.Add(newRow);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {

            int i = 0;
            if (TableGridView.Rows.Count > 0 )
            {
                string str = "DELETE from table_reservation WHERE table_id = '" + tablegrid_id + "'";
                DbObject.OpenConnection();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE the record ", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DbObject.ExecuteQueries(str);
                    MessageBox.Show("Deleted Sucessfully", "DELETED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TableGridView.Rows.RemoveAt(TableGridView.SelectedRows[i].Index);


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

        private void add_button_Click(object sender, EventArgs e)
        {
            Add_Tables table = new Add_Tables();
            table.btn_add.Visible = true;
            table.btn_update.Hide();
           
            table.ShowDialog();
           
        }
       
        private void update_button_Click(object sender, EventArgs e)
        {
            Add_Tables table = new Add_Tables();
           
            table.btn_add.Visible = false;
            table.btn_update.Show();
            table.btn_reset.Hide();

            table.size_box.SelectedItem = TableGridView.CurrentRow.Cells[1].Value.ToString();
            table.loadComboBox();

            table.table_no.Value = int.Parse(TableGridView.CurrentRow.Cells[2].Value.ToString());
            table.shape_box.SelectedItem = TableGridView.CurrentRow.Cells[3].Value.ToString();
            table.condition_box.SelectedItem = TableGridView.CurrentRow.Cells[4].Value.ToString();
            table.dimension_box.SelectedItem = TableGridView.CurrentRow.Cells[5].Value.ToString();
            table.people_txt.Text = TableGridView.CurrentRow.Cells[6].Value.ToString();
            table.price_txt.Text = TableGridView.CurrentRow.Cells[7].Value.ToString();
            table.txt_manufacturer.Text = TableGridView.CurrentRow.Cells[8].Value.ToString();
            table.monthCalendar1.SelectionStart = DateTime.Parse(TableGridView.CurrentRow.Cells[9].Value.ToString());
            table.monthCalendar1.SelectionEnd = DateTime.Parse(TableGridView.CurrentRow.Cells[9].Value.ToString());


            table.ShowDialog();

        }

        public void loadData()
        {
            GetTableData();

            if (List_ID.Count > 0)
            {
                updateTableDataGridView();
            }
            else
            {
                MessageBox.Show("Data Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void TableGridView_DoubleClick(object sender, EventArgs e)
        {
          

        }

        private void TableGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void TableGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = TableGridView.Rows[e.RowIndex];
                tablegrid_id = row.Cells[0].Value.ToString();

            }
        }
    }
    
}
