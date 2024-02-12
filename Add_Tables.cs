using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DbConnection;

namespace Restaurant_Project
{
    public partial class Add_Tables : Form
    {
        DB_Connection_class DbObject = new DB_Connection_class();
        View_Table vt = new View_Table();
        DashBoard_form db = new DashBoard_form();
        Validation_Class vObject = new Validation_Class();

        public Add_Tables()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void size_box_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                if (size_box.SelectedItem.ToString() == "Select" || table_no.Value == 0 || shape_box.SelectedIndex == -1 || condition_box.SelectedIndex == -1 || dimension_box.SelectedIndex == -1 || people_txt.Text == null || txt_manufacturer.Text == null)
                {
                    MessageBox.Show("Please Fill Empty Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {

                    DbObject.OpenConnection();
                    DbObject.ExecuteQueries("insert into table_reservation (table_size, table_no, table_shape, table_condition, table_dimension, no_of_people, reservation_price, table_manufacturer, table_date_purchase) " +
                        "Values('" + size_box.SelectedItem + "','" + table_no.Value + "','" + shape_box.SelectedItem + "','" + condition_box.SelectedItem + "','" + dimension_box.SelectedItem + "','" + people_txt.Text + "','" + price_txt.Text + "','" + txt_manufacturer.Text+ "','" + monthCalendar1.SelectionRange.Start.ToShortDateString() + "')");
                    DbObject.CloseConnection();
                    MessageBox.Show("Added Sucessfully", "SAVED!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    vt.updateTableDataGridView();
                   
                    resetFields();
                    vt.loadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            //checkTableNo();
            try
                {
                    if (size_box.SelectedItem.ToString() == "Select" || table_no.Value == 0 || shape_box.SelectedIndex == -1 || condition_box.SelectedIndex == -1 || dimension_box.SelectedIndex == -1 || people_txt.Text == null || txt_manufacturer.Text == null)
                    {
                        MessageBox.Show("Please Fill Empty Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
              
                    else
                    {
                       
                        int i = vt.TableGridView.SelectedCells[0].RowIndex;

                      
                        DbObject.OpenConnection();
                        string query = "UPDATE table_reservation SET table_size ='" + size_box.SelectedItem + "', table_no = '" + table_no.Value + "', table_shape= '" + shape_box.SelectedItem+ "',table_condition = '" + condition_box.SelectedItem + "' table_dimension = '" + dimension_box.SelectedItem + "'," +
                        " no_of_people= '" + people_txt.Text + "', reservation_price= '" +price_txt.Text + "', table_manufacturer= '" + txt_manufacturer.Text + "', table_date_purchase =  '" + monthCalendar1.SelectionStart.ToString() + "' WHERE table_id = '" + vt.TableGridView.SelectedRows[i].Cells[0].Value.ToString() + "' ";
                        DbObject.ExecuteQueries(query);
                        MessageBox.Show("Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vt.TableGridView.Update();
                        vt.TableGridView.Refresh();
                        resetFields();

                    DbObject.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        private void resetFields()
            {
            size_box.SelectedItem = "Select";
            table_no.Value = 0;
            shape_box.SelectedIndex = -1;
            dimension_box.SelectedIndex = -1;
            condition_box.SelectedIndex = -1;
            people_txt.Clear();
            price_txt.Clear();
            txt_manufacturer.Clear();
            
            monthCalendar1.SelectionStart = DateTime.Now.Date;
            monthCalendar1.SelectionEnd = DateTime.Now.Date;

        }

            private void Manage_Tables_Load(object sender, EventArgs e)
            {
                monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd ");
            monthCalendar1.MaxDate = DateTime.Now.Date;
           
            }

     
        private void shape_box_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void shape_box_Click(object sender, EventArgs e)
        {
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Dispose();
           

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            resetFields();
        }
        private void checkTableNo()
        {

            string query = "select DISTINCT table_no from table_reservation WHERE table_size = '" + size_box.SelectedItem.ToString() + "' AND table_no = '" + table_no.Value + "' ";
            bool check = DbObject.checkExistence(query);

            if (check == true)
            {
                MessageBox.Show("Table No relavant to the cathegory is already exists.", "Try Another", MessageBoxButtons.OK, MessageBoxIcon.Error);
                table_no.Value = 0;
                table_no.Focus();
            }
        }

        private void size_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            table_no.Value = 0;
            shape_box.Items.Clear();
            dimension_box.Items.Clear();
            loadComboBox();

        }
        public void loadComboBox()
        {
          
            if (size_box.SelectedItem.ToString() == "small")
            {
                table_no.Maximum = 15;

                shape_box.Items.Add("round");
                shape_box.Items.Add("square");
                dimension_box.Items.Add("5");
                dimension_box.Items.Add("4");
                dimension_box.Items.Add("4.5");
                people_txt.Text = "1-3";
                price_txt.Text = "RS.100";
            }
            if (size_box.SelectedItem.ToString() == "medium")
            {
                table_no.Maximum = 12;
                shape_box.Items.Add("round");
                shape_box.Items.Add("square");
                shape_box.Items.Add("rectangle");
                dimension_box.Items.Add("10");
                dimension_box.Items.Add("12");
                dimension_box.Items.Add("14");
                people_txt.Text = "4-6";
                price_txt.Text = "RS.200";
            }
            if (size_box.SelectedItem.ToString() == "big")
            {
                table_no.Maximum = 10;

                shape_box.Items.Add("round");
                shape_box.Items.Add("Square");
                shape_box.Items.Add("rectangle");
                dimension_box.Items.Add("15");
                dimension_box.Items.Add("16");
                dimension_box.Items.Add("17");
                people_txt.Text = "6-10";
                price_txt.Text = "RS.300";
            }
            if (size_box.SelectedItem.ToString() == "large")
            {
                table_no.Maximum = 6;

                shape_box.Items.Add("oval");
                shape_box.Items.Add("rectangle");
                dimension_box.Items.Add("18");
                dimension_box.Items.Add("19");
                dimension_box.Items.Add("20");
                people_txt.Text = "10-15";
                price_txt.Text = "RS.400";
            }

            if (size_box.SelectedItem.ToString() == "ex_large")
            {
                table_no.Maximum = 3;
                shape_box.Items.Add("oval");
                shape_box.Items.Add("rectangle");
                dimension_box.Items.Add("21");
                people_txt.Text = "15-20";
                price_txt.Text = "RS.600";
            }

        }

        private void shape_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            checkTableNo();
        }

        private void txt_manufacturer_TextChanged(object sender, EventArgs e)
        {
            lbl_error_manufacturer.Visible = false;
            bool verify = vObject.validattion(txt_manufacturer.Text);

            if (verify == false)
            {
                lbl_error_manufacturer.Visible = true;
                lbl_error_manufacturer.Text = "! Invalid";
                txt_manufacturer.Clear();
            }
            else
            {
                lbl_error_manufacturer.Visible = false;
            }
        }
    }
   
}
