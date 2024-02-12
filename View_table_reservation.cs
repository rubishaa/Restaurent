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
    public partial class View_table_reservation : Form
    {
        private static ArrayList List_ID = new ArrayList();
        private static ArrayList List_CusName = new ArrayList();
        private static ArrayList List_Person = new ArrayList();
        private static ArrayList List_Size = new ArrayList();
        private static ArrayList List_Date = new ArrayList();
        private static ArrayList List_Stime = new ArrayList();
        private static ArrayList List_Etime = new ArrayList();
        private static ArrayList List_No= new ArrayList();
        private static ArrayList List_Address = new ArrayList();
        private static ArrayList List_Mobile = new ArrayList();
        private static ArrayList List_email = new ArrayList();
        private static ArrayList List_comment = new ArrayList();
        private static ArrayList List_payment = new ArrayList();
        private static ArrayList List_points = new ArrayList();
        private static ArrayList List_method = new ArrayList();
        string booking_id = null;
        public View_table_reservation()
        {
            InitializeComponent();
           
        }
        DB_Connection_class DbObject = new DB_Connection_class(); 

        private void View_table_reservation_Load(object sender, EventArgs e)
        {
            loadData();

        }
        


        private void add_button_Click(object sender, EventArgs e)
        {
           
            Add_Table_reservation form = new Add_Table_reservation();
            form.btn_update.Visible = false;
            form.btn_add.Visible = true;
            form.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
        public void GetData()
        {
            try
            {
                DbObject.OpenConnection();
                string query = "select * from booking ";

                MySqlDataReader row;
                row = DbObject.DataReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                         
                        List_ID.Add(row["booking_id"].ToString());
                        List_CusName.Add(row["cus_name"].ToString());
                        List_Person.Add(row["no_person"].ToString());
                        List_Size.Add(row["table_size"].ToString());
                        List_Date.Add(row["date"].ToString());
                        List_Stime.Add(row["s_time"].ToString());
                        List_Etime.Add(row["e_time"].ToString());
                        List_No.Add(row["table_no"].ToString());
                        List_Address.Add(row["address"].ToString());
                        List_Mobile.Add(row["mobile"].ToString());
                        List_email.Add(row["email"].ToString());
                        List_comment.Add(row["comment"].ToString());
                        List_payment.Add(row["payment"].ToString());
                        List_points.Add(row["loyalty_points"].ToString());
                        List_method.Add(row["pay_method"].ToString());
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
        private void updateDataGridView()
        {
           booking_view.Rows.Clear();
            for (int i = 0; i < List_ID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(booking_view);
                newRow.Cells[0].Value = List_ID[i];
                newRow.Cells[1].Value = List_CusName[i];
                newRow.Cells[2].Value = List_Person[i];
                newRow.Cells[3].Value = List_Size[i];
                newRow.Cells[4].Value = List_Date[i];
                newRow.Cells[5].Value = List_Stime[i];
                newRow.Cells[6].Value = List_Etime[i];
                newRow.Cells[7].Value = List_No[i];
                newRow.Cells[8].Value = List_Address[i];
                newRow.Cells[9].Value = List_Mobile[i];
                newRow.Cells[10].Value = List_email[i];
                newRow.Cells[11].Value = List_comment[i];
                newRow.Cells[12].Value = List_payment[i];
                newRow.Cells[13].Value = List_points[i];
                newRow.Cells[14].Value = List_method[i];

                booking_view.Rows.Add(newRow);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            int i = 0;
            if(booking_view.Rows.Count > 0)
            {
                string str = "DELETE from booking WHERE '" + booking_id + "'";
                DbObject.OpenConnection();
               
                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE the record ", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DbObject.ExecuteQueries(str);
                    MessageBox.Show("Deleted Sucessfully", "DELETED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    booking_view.Rows.RemoveAt(booking_view.SelectedRows[i].Index);


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

        private void btn_order_Click(object sender, EventArgs e)
        {

           
            Billing_Form bill_form = new Billing_Form();
            lbl_head.Text = "Food Order";
            
            dateTimePicker1.Visible = false;
            this.view_panel.Controls.Clear();
            

            this.view_panel.Controls.Add(bill_form.bill_panel);

         
            

            bill_form.bill_panel.Anchor = AnchorStyles.Top;

            bill_form.bill_panel.Anchor = AnchorStyles.Right;

            bill_form.bill_panel.Anchor = AnchorStyles.Left;

            bill_form.bill_panel.Anchor = AnchorStyles.Bottom;
            bill_form.bill_panel.Dock = DockStyle.Fill;
            bill_form.bill_panel.AutoScroll = true;

        }

        private void booking_view_Click(object sender, EventArgs e)
        {
        }
        public void loadData()
        {

            GetData();

            if (List_ID.Count > 0)
            {
                updateDataGridView();
            }
            else
            {
                MessageBox.Show("Data Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void booking_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void booking_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void booking_view_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = booking_view.Rows[e.RowIndex];
                booking_id = row.Cells[0].Value.ToString();

            }
        }

        private void booking_view_DoubleClick(object sender, EventArgs e)
        {
            Add_Table_reservation form = new Add_Table_reservation();
            form.cus_name.Text = booking_view.CurrentRow.Cells[1].Value.ToString();
            form.size.Value = int.Parse(booking_view.CurrentRow.Cells[2].Value.ToString());
            string t_size = booking_view.CurrentRow.Cells[3].Value.ToString();

            if (t_size == "small")
            {
                form.small.Checked = true;
                form.small.Enabled = true;
                form.medium.Enabled = false;
                form.big.Enabled = false;
                form.large.Enabled = false;
                form.ex_large.Enabled = false;
            }
            if (t_size == "medium")
            {
                form.medium.Checked = true;
                form.medium.Enabled = true;
                form.small.Enabled = false;
                form.big.Enabled = false;
                form.large.Enabled = false;
                form.ex_large.Enabled = false;
            }
            if (t_size == "big")
            {
                form.big.Checked = true;
                form.big.Enabled = true;
                form.medium.Enabled = false;
                form.small.Enabled = false;
                form.large.Enabled = false;
                form.ex_large.Enabled = false;
            }
            if (t_size == "large")
            {
                form.large.Checked = true;
                form.large.Enabled = true;
                form.medium.Enabled = false;
                form.small.Enabled = false;
                form.big.Enabled = false;
                form.ex_large.Enabled = false;
            }
            if (t_size == "ex_large")
            {
                form.ex_large.Checked = true;
                form.ex_large.Enabled = true;
                form.medium.Enabled = false;
                form.small.Enabled = false;
                form.big.Enabled = false;
                form.large.Enabled = false;

            }

            form.monthCalendar1.SelectionStart = DateTime.Parse(booking_view.CurrentRow.Cells[4].Value.ToString());
            form.monthCalendar1.SelectionEnd = DateTime.Parse(booking_view.CurrentRow.Cells[4].Value.ToString());
            form.start_picker.Text = booking_view.CurrentRow.Cells[5].Value.ToString();
            form.end_picker.Text = booking_view.CurrentRow.Cells[6].Value.ToString();
            form.table_box.Enabled = false;
            form.btn_check.Visible = true;
            form.btn_check.Enabled = true;
            form.load_comboBox();
          
            form.table_box.SelectedItem= booking_view.CurrentRow.Cells[7].Value.ToString();
            form.address_txt.Text = booking_view.CurrentRow.Cells[8].Value.ToString();
            form.mobile_txt.Text = booking_view.CurrentRow.Cells[9].Value.ToString();
            form.email_txt.Text = booking_view.CurrentRow.Cells[10].Value.ToString();
            form.comment_txt.Text = booking_view.CurrentRow.Cells[11].Value.ToString();
            form.price_txt.Text = booking_view.CurrentRow.Cells[12].Value.ToString();
            form.point_txt.Text = booking_view.CurrentRow.Cells[13].Value.ToString();

            string method = booking_view.CurrentRow.Cells[14].Value.ToString();
            if (method == "Cash")
            {
                form.cash_radio.Checked = true;
            }
            if (method == "Card")
            {
                form.card_radio.Checked = true;
            }

            this.Dispose();
           
            form.btn_update.Visible = true;
            form.btn_add.Visible = false;
            form.btn_reset.Visible = false;
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void view_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
