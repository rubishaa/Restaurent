using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbConnection;
using MySql.Data.MySqlClient;

namespace Restaurant_Project
{
    public partial class Billing_Form : Form
    {
        DB_Connection_class DbObject = new DB_Connection_class();
        int i = 0;
        string small;
        string medium;
        string large;
        double total = 0.00;
        double discount = 0.00;
        double pay = 0.00;
        double balance = 0.00;
        string cus_name = "N/A";
        string mobile = "N/A";
        public string cus_id = "NBC/";
        public Billing_Form()
        {
            InitializeComponent();
        }
        private void Billing_Form_Load(object sender, EventArgs e)
        {
            main_flow.AutoScroll = true;
            main_flow.WrapContents = false;
            txt_total.Text = total.ToString();
            txt_discount.Text = discount.ToString();
            txt_pay.Text = pay.ToString();
            txt_balance.Text = balance.ToString();
            getBillNo();
            getCustomer_ID();
        }

        private void cathegory_box_SelectionChangeCommitted(object sender, EventArgs e)
        {

            cathegory_box.Enabled = false;
            i++;
            FlowLayoutPanel flowpanels = new FlowLayoutPanel();
            
            flowpanels.Size = new Size(1159, 40);
            flowpanels.Name = "panel" + i.ToString();
           
            flowpanels.FlowDirection = FlowDirection.LeftToRight;
            flowpanels.BorderStyle = BorderStyle.FixedSingle;
            flowpanels.HorizontalScroll.Visible = false;
            main_flow.Controls.Add(flowpanels);
         
            ComboBox menubox = new ComboBox();
            menubox.Name = "menu_box"+ i.ToString();
            menubox.DropDownStyle = ComboBoxStyle.DropDownList;

            ComboBox sizebox = new ComboBox();
            sizebox.DropDownStyle = ComboBoxStyle.DropDownList;
            sizebox.Name = "size_box" + i.ToString();

            Label price_lbl = new Label();
            price_lbl.Name = "price"+i.ToString();

            NumericUpDown quantity = new NumericUpDown();
            quantity.Name = "quantity"+i.ToString();
            quantity.Value = 1;
            quantity.Maximum = 100;

            Label amount = new Label();
            amount.Name = "amount"+i.ToString();

            Button rem_bt = new Button();
            rem_bt.Text = "X";
            rem_bt.Size = new Size(46, 46);
            rem_bt.Name = "remove"+i.ToString();


            flowpanels.FlowDirection = FlowDirection.LeftToRight;
            flowpanels.WrapContents = false;
            menubox.Size = new Size(255, 56);
            sizebox.Size = new Size(91, 56);
            price_lbl.Size = new Size(130, 56);
            quantity.Size = new Size(130, 56);
            amount.Size = new Size(130, 56);

            flowpanels.Controls.Add(menubox);
            flowpanels.Controls.Add(sizebox);
            flowpanels.Controls.Add(price_lbl);
            flowpanels.Controls.Add(quantity);
            flowpanels.Controls.Add(amount);
            flowpanels.Controls.Add(rem_bt);

            string str_menu = "select DISTINCT food_name from food_management where cathegory=  '" + cathegory_box.SelectedItem.ToString() + "'";
            DbObject.OpenConnection();
            MySqlDataReader drd = DbObject.DataReader(str_menu);
            while (drd.Read())
            {
                menubox.Items.Add(drd["food_name"].ToString());
            }
            menubox.SelectedIndexChanged += name_IndexChanged;
            sizebox.SelectedIndexChanged += size_IndexChanged;
            quantity.ValueChanged += quantity_ValueChanged;
            rem_bt.Click += remove_button_Click;
            amount.TextChanged += amount_TextChanged;
         
        }
        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n1 = this.Controls.Find("quantity"+i, true).First() as NumericUpDown;
            Label lb2 = this.Controls.Find("price"+i, true).First() as Label;
            Label lb3 = this.Controls.Find("amount"+i, true).First() as Label;
           
            int l2_val = int.Parse(lb2.Text);
            int l3_val = (int)(l2_val * (n1.Value));
            lb3.Text =  l3_val.ToString();
            
        }
        private void name_IndexChanged(object sender, EventArgs e)
        {
           ComboBox menu = this.Controls.Find("menu_box"+i,true).First() as ComboBox;
             ComboBox size = this.Controls.Find("size_box" + i, true).First() as ComboBox;
            DbObject.OpenConnection();
            string str_small = "select * from food_management where food_name ='" + menu.SelectedItem.ToString() + "'";
            MySqlDataReader drd = DbObject.DataReader(str_small);
            if (drd.Read())
            {
                small = (drd["small"].ToString());
                if (small != "NOT AVAILABLE") 
                {
                    size.Items.Add("S");
                }

                medium = (drd["medium"].ToString());
                if (medium != "NOT AVAILABLE")
                {
                    size.Items.Add("M");
                }
                large = (drd["large"].ToString());
                if (large != "NOT AVAILABLE")
                {
                    size.Items.Add("L");
                }
                if (large == "NOT AVAILABLE" && medium == "NOT AVAILABLE" && small == "NOT AVAILABLE")
                {
                    size.Items.Add("N/A");
                }
            }
           
        }
        private void size_IndexChanged(object sender, EventArgs e)
        {
            ComboBox size_one = this.Controls.Find("size_box" + i, true).First() as ComboBox;
            Label price_lb = this.Controls.Find("price"+i, true).First() as Label;
            Label amount_lb = this.Controls.Find("amount" + i, true).First() as Label;
            if (size_one.SelectedItem.ToString() == "S")
            {
                price_lb.Text = small;
            }
            if (size_one.SelectedItem.ToString() == "M")
            {
                price_lb.Text =  medium;
            }
            if (size_one.SelectedItem.ToString() == "L")
            {
                price_lb.Text = large;
            }
            if (size_one.SelectedItem.ToString() == "N/A")
            {
                price_lb.Text = small;
            }
            amount_lb.Text = price_lb.Text;
        }
        private void remove_button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            string bt_name = button.Name;
           
            char  b = bt_name.Last();
            string p_name = "panel" + b.ToString();
            FlowLayoutPanel fp = this.Controls.Find(p_name , true).First() as FlowLayoutPanel;
            fp.Controls.Clear();            
            fp.Dispose();
            cathegory_box.Enabled = true;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Clear All? ", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                main_flow.Controls.Clear();
                 total = 0.00;
                 discount = 0.00;
                 pay = 0.00;
                 balance = 0.00;
                txt_total.Text = total.ToString();
                txt_discount.Text = total.ToString();
                txt_pay.Text = total.ToString();
                txt_balance.Text = balance.ToString();
                txt_paid.Clear();
            }
          
        }
        private void btn_add_Click_1(object sender, EventArgs e)
        {
            if (i == 0)
            {
                MessageBox.Show("Please add menu before finish", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int j = 1; j <= i; j++)
                {
                    string amount = "amount" + j.ToString();
                    Label amount_lbl = this.Controls.Find(amount, true).First() as Label;

                    if(amount_lbl.Text == null)
                    {
                        MessageBox.Show("Please complete fields before finish", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        total += Double.Parse(amount_lbl.Text);

                    }
                }
                txt_total.Text = total.ToString();
                txt_pay.Text = (total - discount).ToString();
            }
            
           
        }
        private void cathegory_box_Click(object sender, EventArgs e)
        {
            cathegory_box.Items.Clear();            
            string query = "select name FROM cathegory";
            DbObject.OpenConnection();
            MySqlDataReader drd = DbObject.DataReader(query);
            while (drd.Read())
            {
                cathegory_box.Items.Add(drd["name"].ToString());
            }
            DbObject.CloseConnection();
        }

        private void btn_receipt_Click(object sender, EventArgs e)
        {
            DashBoard_form form = new DashBoard_form();
            if (total == 0 || txt_paid.Text == 0.ToString() || i == 0)
            {
                MessageBox.Show("Please complete fields before finish", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm Billing? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    receipt_box.AppendText("\t\t" + "TASTE ELITE- JAFFNA" + Environment.NewLine);
                    receipt_box.AppendText("\t\t" + "Restaurant Invoice" + Environment.NewLine);
                    receipt_box.AppendText("--------------------------------------------------" + Environment.NewLine);
                    receipt_box.AppendText("Bill No       : " + txt_billNo.Text + Environment.NewLine);
                    receipt_box.AppendText("Order Date    : " + DateTime.Today.ToShortDateString() + Environment.NewLine);
                    receipt_box.AppendText("Order Time    : " + DateTime.Now.ToShortTimeString() + Environment.NewLine);
                    receipt_box.AppendText("Customer Name : " + cus_name + Environment.NewLine);
                    receipt_box.AppendText("Mobile No     : " + mobile + Environment.NewLine);
                    receipt_box.AppendText("--------------------------------------------------" + Environment.NewLine);
                    receipt_box.AppendText("                " + Environment.NewLine);
                    receipt_box.AppendText("Description          Qty U_Price Amount   " + Environment.NewLine);
                    receipt_box.AppendText("--------------------------------------------------" + Environment.NewLine);



                    DbObject.OpenConnection();
                    for (int j = 1; j <= i; j++)
                    {
                        string menu = "menu_box" + j.ToString();
                        string size = "size_box" + j.ToString();
                        string quantity = "quantity" + j.ToString();
                        string amount = "amount" + j.ToString();

                        ComboBox menu_box = this.Controls.Find(menu, true).First() as ComboBox;
                        ComboBox size_box = this.Controls.Find(size, true).First() as ComboBox;
                        NumericUpDown n_box = this.Controls.Find(quantity, true).First() as NumericUpDown;
                        Label amount_lbl = this.Controls.Find(amount, true).First() as Label;
                        DbObject.ExecuteQueries("INSERT INTO billing VALUES('" + txt_billNo.Text + "', '" + menu_box.SelectedItem.ToString() + "', '" + size_box.SelectedItem.ToString() + "','" + n_box.Value + "','" + double.Parse(amount_lbl.Text) + "')  ");

                        receipt_box.AppendText(size_box.SelectedItem.ToString() + "_" + menu_box.SelectedItem.ToString() + "          " + n_box.Value.ToString() + "     " + amount_lbl.Text + "     " + Environment.NewLine);

                    }
                    receipt_box.AppendText("" + Environment.NewLine);
                    receipt_box.AppendText("" + Environment.NewLine);


                    receipt_box.AppendText("Total Charge : Rs." + txt_total.Text + Environment.NewLine);
                    receipt_box.AppendText("Discount     : Rs." + txt_discount.Text + Environment.NewLine);
                    receipt_box.AppendText("Amount To Pay: Rs." + txt_pay.Text + Environment.NewLine);
                    receipt_box.AppendText("Paid Amount  : Rs." + txt_paid.Text + Environment.NewLine);
                    receipt_box.AppendText("Balance      : Rs." + txt_balance.Text + Environment.NewLine);
                    receipt_box.AppendText("--------------------------------------------------" + Environment.NewLine);
                    MessageBox.Show("Added Sucessfully", "SAVED!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    DbObject.ExecuteQueries("INSERT INTO invoices VALUES('" + txt_billNo.Text + "', '" + txt_cus.Text + "', '" + i + "','" + double.Parse(txt_total.Text) + "','" + double.Parse(txt_discount.Text) + "','" + double.Parse(txt_pay.Text) + "','" + double.Parse(txt_paid.Text) + "','" + double.Parse(txt_balance.Text) + "','" +form.lbl_name+ "','" + form.lbl_date + "','" + form.lbl_tim + "')  ");



                    DbObject.CloseConnection();
                }
            }
        }

        private void txt_paid_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                double paid = Double.Parse(txt_paid.Text);
                txt_paid.Text = paid.ToString();
                if (e.KeyChar == 13)
                {
                    balance = paid - pay;
                    txt_balance.Text = balance.ToString();
                }
        }
        private void getBillNo()
        {
            string qry = "SELECT bill_id FROM invoices ORDER BY bill_id DESC LIMIT 1";
            
            string max_no = DbObject.Max_No(qry);


            int no = Convert.ToInt32(max_no.Substring(2, (max_no.Length - 2)));
            no++;
            txt_billNo.Text = "B/" + no;
           

        }

        private void bill_panel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void amount_TextChanged(object sender, EventArgs e)
        {
            cathegory_box.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument documentToPrint = new PrintDocument();
            printDialog.Document = documentToPrint;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                StringReader reader = new StringReader(receipt_box.Text);
                printDialog.Document = documentToPrint;
                documentToPrint.PrintPage += new PrintPageEventHandler(DocumentToPrint_PrintPage);
                documentToPrint.Print();
            }
        }
        private void DocumentToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringReader reader = new StringReader(receipt_box.Text);
            float LinesPerPage = 0;
            float YPosition = 0;
            int Count = 0;
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            string Line = null;
            Font PrintFont = this.receipt_box.Font;
            SolidBrush PrintBrush = new SolidBrush(Color.Black);

            LinesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);

            while (Count < LinesPerPage && ((Line = reader.ReadLine()) != null))
            {
                YPosition = TopMargin + (Count * PrintFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(Line, PrintFont, PrintBrush, LeftMargin, YPosition, new StringFormat());
                Count++;
            }

            if (Line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            PrintBrush.Dispose();
        }

        private void txt_paid_TextChanged(object sender, EventArgs e)
        {

        }
        private void getCustomer_ID()
        {
            string qry = "SELECT cus_id FROM invoices ORDER BY cus_id DESC LIMIT 1";

            string max_no = DbObject.Max_No(qry);


            int no = Convert.ToInt32(max_no.Substring(4, (max_no.Length - 4)));
            no++;
            txt_cus.Text = cus_id + no;


        }
    }

}
