
namespace Restaurant_Project
{
    partial class view_food
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_heading = new System.Windows.Forms.Label();
            this.food_panel = new System.Windows.Forms.Panel();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.FoodGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_cathegory = new System.Windows.Forms.Button();
            this.cathegory_box = new System.Windows.Forms.ComboBox();
            this.lbl_cathegory = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.food_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FoodGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbl_heading);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1576, 117);
            this.panel2.TabIndex = 7;
            // 
            // lbl_heading
            // 
            this.lbl_heading.AutoSize = true;
            this.lbl_heading.Font = new System.Drawing.Font("Monotype Corsiva", 26F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbl_heading.ForeColor = System.Drawing.Color.Snow;
            this.lbl_heading.Location = new System.Drawing.Point(561, 23);
            this.lbl_heading.Name = "lbl_heading";
            this.lbl_heading.Size = new System.Drawing.Size(295, 63);
            this.lbl_heading.TabIndex = 2;
            this.lbl_heading.Text = "Manage Food";
            // 
            // food_panel
            // 
            this.food_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.food_panel.Controls.Add(this.btn_update);
            this.food_panel.Controls.Add(this.btn_delete);
            this.food_panel.Controls.Add(this.panel1);
            this.food_panel.Controls.Add(this.btn_add);
            this.food_panel.Controls.Add(this.FoodGridView);
            this.food_panel.Location = new System.Drawing.Point(2, 210);
            this.food_panel.Name = "food_panel";
            this.food_panel.Size = new System.Drawing.Size(1560, 660);
            this.food_panel.TabIndex = 8;
            this.food_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.food_panel_Paint);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_update.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btn_update.FlatAppearance.BorderSize = 3;
            this.btn_update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_update.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_update.ForeColor = System.Drawing.Color.Snow;
            this.btn_update.Location = new System.Drawing.Point(561, 506);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(251, 65);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "&UPDATE";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_delete.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btn_delete.FlatAppearance.BorderSize = 3;
            this.btn_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_delete.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_delete.ForeColor = System.Drawing.Color.Snow;
            this.btn_delete.Location = new System.Drawing.Point(860, 506);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(251, 65);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "&DELETE";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(0, 618);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1556, 36);
            this.panel1.TabIndex = 8;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_add.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btn_add.FlatAppearance.BorderSize = 3;
            this.btn_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_add.ForeColor = System.Drawing.Color.Snow;
            this.btn_add.Location = new System.Drawing.Point(263, 506);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(251, 65);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "&ADD";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // FoodGridView
            // 
            this.FoodGridView.AllowUserToAddRows = false;
            this.FoodGridView.AllowUserToResizeColumns = false;
            this.FoodGridView.AllowUserToResizeRows = false;
            this.FoodGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Sitka Heading", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FoodGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FoodGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FoodGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Id_Column,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column13,
            this.Column12});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FoodGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.FoodGridView.EnableHeadersVisualStyles = false;
            this.FoodGridView.Location = new System.Drawing.Point(-2, -2);
            this.FoodGridView.Name = "FoodGridView";
            this.FoodGridView.ReadOnly = true;
            this.FoodGridView.RowHeadersWidth = 62;
            this.FoodGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Sitka Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.FoodGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.FoodGridView.RowTemplate.Height = 33;
            this.FoodGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FoodGridView.Size = new System.Drawing.Size(1562, 471);
            this.FoodGridView.TabIndex = 2;
            this.FoodGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FoodGridView_CellDoubleClick);
            this.FoodGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FoodGridView_CellMouseClick);
            this.FoodGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.FoodGridView_RowPostPaint);
            this.FoodGridView.Click += new System.EventHandler(this.FoodGridView_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Id_Column
            // 
            this.Id_Column.HeaderText = "Food_ID";
            this.Id_Column.MinimumWidth = 8;
            this.Id_Column.Name = "Id_Column";
            this.Id_Column.ReadOnly = true;
            this.Id_Column.Visible = false;
            this.Id_Column.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Category";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Name";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Available Ingriedient";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Ingredients";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Food Type";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Price of Small";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Price of Medium";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 150;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Price of Large";
            this.Column10.MinimumWidth = 8;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 150;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Description";
            this.Column11.MinimumWidth = 8;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 150;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Discount";
            this.Column13.MinimumWidth = 8;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 150;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Added By";
            this.Column12.MinimumWidth = 8;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 150;
            // 
            // btn_cathegory
            // 
            this.btn_cathegory.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_cathegory.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btn_cathegory.FlatAppearance.BorderSize = 3;
            this.btn_cathegory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_cathegory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_cathegory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cathegory.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_cathegory.ForeColor = System.Drawing.Color.Snow;
            this.btn_cathegory.Location = new System.Drawing.Point(1335, 138);
            this.btn_cathegory.Name = "btn_cathegory";
            this.btn_cathegory.Size = new System.Drawing.Size(225, 55);
            this.btn_cathegory.TabIndex = 5;
            this.btn_cathegory.Text = "&CATEGORIES";
            this.btn_cathegory.UseVisualStyleBackColor = false;
            this.btn_cathegory.Click += new System.EventHandler(this.btn_cathegory_Click);
            // 
            // cathegory_box
            // 
            this.cathegory_box.BackColor = System.Drawing.Color.MintCream;
            this.cathegory_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cathegory_box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cathegory_box.Font = new System.Drawing.Font("Sitka Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cathegory_box.FormattingEnabled = true;
            this.cathegory_box.ItemHeight = 32;
            this.cathegory_box.Items.AddRange(new object[] {
            "",
            ""});
            this.cathegory_box.Location = new System.Drawing.Point(283, 138);
            this.cathegory_box.Name = "cathegory_box";
            this.cathegory_box.Size = new System.Drawing.Size(285, 40);
            this.cathegory_box.TabIndex = 1;
            this.cathegory_box.SelectedIndexChanged += new System.EventHandler(this.cathegory_box_SelectedIndexChanged);
            this.cathegory_box.Click += new System.EventHandler(this.cathegory_box_Click);
            // 
            // lbl_cathegory
            // 
            this.lbl_cathegory.AutoSize = true;
            this.lbl_cathegory.BackColor = System.Drawing.Color.Honeydew;
            this.lbl_cathegory.Font = new System.Drawing.Font("Sitka Display", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_cathegory.Location = new System.Drawing.Point(67, 138);
            this.lbl_cathegory.Name = "lbl_cathegory";
            this.lbl_cathegory.Size = new System.Drawing.Size(159, 40);
            this.lbl_cathegory.TabIndex = 0;
            this.lbl_cathegory.Text = "Category    :";
            // 
            // view_food
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1576, 881);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cathegory);
            this.Controls.Add(this.lbl_cathegory);
            this.Controls.Add(this.cathegory_box);
            this.Controls.Add(this.food_panel);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "view_food";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View_Food";
            this.Load += new System.EventHandler(this.View_Food_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.food_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FoodGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_heading;
        private System.Windows.Forms.Panel food_panel;
        private System.Windows.Forms.ComboBox cathegory_box;
        private System.Windows.Forms.Button btn_add;
        public System.Windows.Forms.DataGridView FoodGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_cathegory;
        private System.Windows.Forms.Label lbl_cathegory;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}