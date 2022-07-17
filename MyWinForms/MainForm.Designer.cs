namespace MyWinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.UserIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserEmailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPhoneCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(772, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 44);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserIdCol,
            this.UserNameCol,
            this.UserEmailCol,
            this.UserPhoneCol});
            this.dgvUsers.Location = new System.Drawing.Point(26, 121);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 29;
            this.dgvUsers.Size = new System.Drawing.Size(863, 348);
            this.dgvUsers.TabIndex = 1;
            // 
            // UserIdCol
            // 
            this.UserIdCol.HeaderText = "Id";
            this.UserIdCol.MinimumWidth = 6;
            this.UserIdCol.Name = "UserIdCol";
            this.UserIdCol.Visible = false;
            this.UserIdCol.Width = 125;
            // 
            // UserNameCol
            // 
            this.UserNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserNameCol.HeaderText = "ПІБ";
            this.UserNameCol.MinimumWidth = 6;
            this.UserNameCol.Name = "UserNameCol";
            // 
            // UserEmailCol
            // 
            this.UserEmailCol.HeaderText = "Пошта";
            this.UserEmailCol.MinimumWidth = 6;
            this.UserEmailCol.Name = "UserEmailCol";
            this.UserEmailCol.Width = 150;
            // 
            // UserPhoneCol
            // 
            this.UserPhoneCol.HeaderText = "Телефон";
            this.UserPhoneCol.MinimumWidth = 6;
            this.UserPhoneCol.Name = "UserPhoneCol";
            this.UserPhoneCol.Width = 150;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(26, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 44);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 506);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnSearch);
            this.Name = "MainForm";
            this.Text = "Головне вікно";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSearch;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn UserIdCol;
        private DataGridViewTextBoxColumn UserNameCol;
        private DataGridViewTextBoxColumn UserEmailCol;
        private DataGridViewTextBoxColumn UserPhoneCol;
        private Button btnAdd;
    }
}