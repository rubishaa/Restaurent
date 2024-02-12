using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DbConnection;


namespace Restaurant_Project
{
    public partial class Add_Employee : Form
    {
        string role = null;
        public Add_Employee()
        {
            InitializeComponent();
        }
        static Regex validate_emailaddress = email_validation();
      
        static Regex validate_nic = nic_validation();
        DB_Connection_class DbObject = new DB_Connection_class();
        Validation_Class vObject = new Validation_Class();


        private void Employee_Load(object sender, EventArgs e)
        {
            ClearLabels();
            dateTimePicker1.MaxDate = DateTime.Now.Date;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
           

        }


        private void register_button_Click(object sender, EventArgs e)
        {
            bool correction = code_verify();
            // email address validating by calling regex function
            if (validate_emailaddress.IsMatch(email_txt.Text) != true)
            {
                MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                email_txt.Focus();
                email_txt.Clear();

                return;
            }


            // checking whether the password and confirm password strings are same
            else if (password_txt.Text != confirm_txt.Text)
            {
                MessageBox.Show("Password is not Matching!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                confirm_txt.Focus();
                confirm_txt.Clear();

                return;
            }
           
            else if (correction == false)
            {
                MessageBox.Show("Something went wrong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string gender;
                try
                {
                    bool usernameexists = DbObject.checkExistence("select count(*) from customer where username='" + user_txt.Text + "'");
                    bool emailexists = DbObject.checkExistence("select count(*) from customer where email='" + email_txt.Text + "'");
                    if (id_txt.Text == null || fname_txt.Text == null || lname_txt.Text == null || nic_txt.Text == null || street_txt.Text == null || town_txt.Text == null || district_box.SelectedIndex == -1 ||
                        email_txt.Text == null || mobile_txt.Text == null || user_txt.Text == null || password_txt.Text == null || roleBox.SelectedItem.ToString() == null || txt_code.Text == null)
                    {
                        MessageBox.Show("Please Fill Empty Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }


                    else if (validate_emailaddress.IsMatch(email_txt.Text) != true)
                    {
                        MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        email_txt.Focus();
                        email_txt.Clear();

                        return;
                    }
                    else if (usernameexists == true)
                    {
                        MessageBox.Show("Username has Already taken!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        user_txt.Focus();
                        user_txt.Clear();
                    }
                    else if (emailexists == true)
                    {
                        MessageBox.Show("This email is already in use!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        email_txt.Focus();
                        email_txt.Clear();
                    }

                    else
                    {
                        string dst = dateTimePicker1.Value.ToString();
                        if (radio_male.Checked == true)
                        {
                            gender = "male";
                        }
                        else
                        {
                            gender = "female";

                        }
                        role_selection();
                        DbObject.OpenConnection();
                        DbObject.ExecuteQueries("insert into employee (e_id , fname, lname , profile , nic_no, gender, age, date_join, s_name, t_name, district, email, mobile, user_name, password,role) Values('" + id_txt.Text + "','" + fname_txt.Text + "','" + lname_txt.Text + "','" + photo_box.Image +
                             "', '" + nic_txt.Text + "', '" + gender + "','" + age_txt.Text + "','" + this.dateTimePicker1.Text + "','" + street_txt.Text + "' ,'" + town_txt.Text + "' ,'" + district_box.SelectedItem.ToString() + "','" + email_txt.Text + "','" + mobile_txt.Text + "','" + user_txt.Text + "' ,'" + password_txt.Text + "','" + role + "')");
                        DbObject.CloseConnection();
                        MessageBox.Show("Added Sucessfully", "SAVED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        // regex function for email validation

        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
              + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
              + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        // regex function name validation
      
        private static Regex nic_validation()
        {
            string pattern = @"^[0-9V]+$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }

        //make error lables invisibles
        private void ClearLabels()
        {


            lbl_fname_error.Visible = false;
            lbl_lname_error.Visible = false;
            lbl_street_error.Visible = false;
            lbl_town_error.Visible = false;

            nic_error_lbl.Visible = false;
        }

        // function for uploading profile
        private void reset_button_Click(object sender, EventArgs e)
        {

            ClearLabels();
            id_txt.Clear();
            fname_txt.Clear();
            lname_txt.Clear();
            photo_box.Image = null;
            radio_male.Checked = false;
            female_select.Checked = false;
            age_txt.Clear();
            street_txt.Clear();
            town_txt.Clear();
            district_box.SelectedIndex = -1;
            email_txt.Clear();
            mobile_txt.Clear();
            user_txt.Clear();
            password_txt.Clear();
            confirm_txt.Clear();
            nic_txt.Clear();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";
        }
     


        private string role_selection()
        {

            if (roleBox.SelectedItem.ToString() == "Management")
            {
                role = roleBox.SelectedItem.ToString();

            }
            if (roleBox.SelectedItem.ToString() == "Inventory Manager")
            {
                role = roleBox.SelectedItem.ToString();
            }
            if (roleBox.SelectedItem.ToString() == "User")
            {
                role = roleBox.SelectedItem.ToString();
            }
            return role;
        }

       

      

        private bool code_verify()
        {
            bool correct = false;
           
                if ((role == "Management") && (txt_code.Text == "Elite@1"))
                {
                    correct = true;
                }
                if ((role == "Inventory Manager") && (txt_code.Text == "Elite@2"))
                {
                    correct = true;
                }
                if ((role == "User") && (txt_code.Text == "Elite@3"))
                {
                    correct = true;
                }
            return correct;
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                role_grp.Visible = true;
            }
            else
            {
                role_grp.Visible = false;
            }
        }

        
        

        private void password_txt_TextChanged(object sender, EventArgs e)
        {
          bool validated =  ValidatePassword(password_txt.Text);
          if(validated == false)
            {
                password_erro_lbl.Visible = true;
                password_erro_lbl.Text = "Invalid password";
            }
            else
            {
                password_erro_lbl.Visible = false;
            }
        }
        static bool ValidatePassword(string passWord)
        {
            int validConditions = 0;
            foreach (char c in passWord)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in passWord)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in passWord)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1) return false;
            if (validConditions == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' };   
                if (passWord.IndexOfAny(special) == -1) return false;
            }
            return true;
        }

        private void main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roleBox_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            role_selection();
            txt_code.Visible = true;
            txt_code.Clear();
            txt_code.Enabled = true;
        }

        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                bool verification = code_verify();
                if (verification == true)
                {
                    user_grp.Visible = true;
                }
                else
                {
                    MessageBox.Show("Something went wrong", "Error");
                }
            }
        }

        private void roleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code.Clear();
            user_grp.Visible = false;
        }

        private void user_grp_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void street_txt_TextChanged(object sender, EventArgs e)
        {
            ClearLabels();
            lbl_street_error.Visible = false;
            bool verify = vObject.validattion(street_txt.Text);

            if (verify == false)
            {
                lbl_street_error.Visible = true;
                lbl_street_error.Text = "! Invalid input";
                street_txt.Clear();
            }
            else
            {
                lbl_street_error.Visible = false;
            }
        }

      

        private void town_txt_TextChanged(object sender, EventArgs e)
        {
            ClearLabels();
            lbl_town_error.Visible = false;
            bool verify = vObject.validattion(town_txt.Text);

            if (verify == false)
            {
                lbl_town_error.Visible = true;
                lbl_town_error.Text = "! Invalid input";
                town_txt.Clear();
            }
            else
            {
                lbl_town_error.Visible = false;
            }
        }

        private void fname_txt_TextChanged(object sender, EventArgs e)
        {
            ClearLabels();
            lbl_fname_error.Visible = false;
            bool verify = vObject.validattion(fname_txt.Text);

            if (verify == false)
            {
                lbl_fname_error.Visible = true;
                lbl_fname_error.Text = "! Invalid input";
                fname_txt.Clear();
            }
            else
            {
                lbl_fname_error.Visible = false;
            }
        }

        private void lname_txt_TextChanged(object sender, EventArgs e)
        {
            ClearLabels();
            lbl_lname_error.Visible = false;
            bool verify = vObject.validattion(lname_txt.Text);

            if (verify == false)
            {
                lbl_lname_error.Visible = true;
                lbl_lname_error.Text = "! Invalid input";
                lname_txt.Clear();
            }
            else
            {
                lbl_lname_error.Visible = false;
            }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                photo_box.Image = new Bitmap(opnfd.FileName);
            }
        }

        private void nic_txt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                string year;
                int y, age, gender_select;

                
                if (nic_txt.Text.Length < 10)
                {
                    nic_error_lbl.Visible = true;
                    nic_error_lbl.Text = "! Invalid input";
                    nic_txt.Clear();

                }


                if (nic_txt.TextLength == 10)
                {
                    if (nic_txt.Text.EndsWith("V") == true)
                    {
                        year = "19" + (nic_txt.Text).Substring(0, 2);
                        y = int.Parse(year);
                        age = DateTime.Now.Year - y;
                        age_txt.Text = age.ToString();

                        gender_select = int.Parse(nic_txt.Text.Substring(2, 3));

                        if (gender_select < 500)
                        {
                            radio_male.Enabled = true;
                            radio_male.Checked = true;
                        }
                        else
                        {
                            female_select.Enabled = true;
                            female_select.Checked = true;
                        }
                    }
                    else
                    {
                        nic_error_lbl.Visible = true;
                        nic_error_lbl.Text = "! Invalid input";
                    }
                }
                else if (nic_txt.TextLength == 12)
                {
                    y = int.Parse(nic_txt.Text.Substring(0, 4));
                    age = DateTime.Now.Year - y;

                    gender_select = int.Parse(nic_txt.Text.Substring(4, 3));


                    if (gender_select < 500)
                    {
                        radio_male.Enabled = true;
                        radio_male.Checked = true;
                    }
                    else if (gender_select > 500)
                    {
                        female_select.Enabled = true;
                        female_select.Checked = true;
                    }
                    age_txt.Text = age.ToString();
                }
                else
                {
                    nic_error_lbl.Visible = true;
                    nic_error_lbl.Text = "! Invalid input";
                }
            }
        }

        private void district_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearLabels();
        }

        private void nic_txt_TextChanged(object sender, EventArgs e)
        {
            ClearLabels();
            age_txt.Clear();
            radio_male.Checked = false;
            female_select.Checked = false;
            radio_male.Enabled = false;
            female_select.Enabled = false;
            if (validate_nic.IsMatch(nic_txt.Text) != true)
            {
                nic_error_lbl.Visible = true;
                nic_error_lbl.Text = "! Invalid input";
                nic_txt.Clear();

                return;
            }

        }

        private void age_txt_TextChanged(object sender, EventArgs e)
        {
            nic_error_lbl.Visible = false;
        }
    }
}

