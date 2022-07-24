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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.UserIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserImageCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.UserNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserEmailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPhoneCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(810, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 33);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserIdCol,
            this.UserImageCol,
            this.UserNameCol,
            this.UserEmailCol,
            this.UserPhoneCol});
            this.dgvUsers.Location = new System.Drawing.Point(23, 91);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 100;
            this.dgvUsers.Size = new System.Drawing.Size(890, 261);
            this.dgvUsers.TabIndex = 1;
            // 
            // UserIdCol
            // 
            this.UserIdCol.HeaderText = "Id";
            this.UserIdCol.MinimumWidth = 6;
            this.UserIdCol.Name = "UserIdCol";
            this.UserIdCol.ReadOnly = true;
            this.UserIdCol.Visible = false;
            this.UserIdCol.Width = 125;
            // 
            // UserImageCol
            // 
            this.UserImageCol.HeaderText = "Фото";
            this.UserImageCol.MinimumWidth = 6;
            this.UserImageCol.Name = "UserImageCol";
            this.UserImageCol.ReadOnly = true;
            this.UserImageCol.Width = 150;
            // 
            // UserNameCol
            // 
            this.UserNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserNameCol.HeaderText = "ПІБ";
            this.UserNameCol.MinimumWidth = 6;
            this.UserNameCol.Name = "UserNameCol";
            this.UserNameCol.ReadOnly = true;
            // 
            // UserEmailCol
            // 
            this.UserEmailCol.HeaderText = "Пошта";
            this.UserEmailCol.MinimumWidth = 6;
            this.UserEmailCol.Name = "UserEmailCol";
            this.UserEmailCol.ReadOnly = true;
            this.UserEmailCol.Width = 150;
            // 
            // UserPhoneCol
            // 
            this.UserPhoneCol.HeaderText = "Телефон";
            this.UserPhoneCol.MinimumWidth = 6;
            this.UserPhoneCol.Name = "UserPhoneCol";
            this.UserPhoneCol.ReadOnly = true;
            this.UserPhoneCol.Width = 150;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(23, 9);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 33);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(863, 355);
            this.btnNext.Margin = new System.Windows.Forms.Padding(1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 27);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(810, 355);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 27);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(23, 46);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(103, 33);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Змінити";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 399);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnSearch);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Головне вікно";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSearch;
        private DataGridView dgvUsers;
        private Button btnAdd;
        private Button btnNext;
        private Button btnPrev;
        private DataGridViewTextBoxColumn UserIdCol;
        private DataGridViewImageColumn UserImageCol;
        private DataGridViewTextBoxColumn UserNameCol;
        private DataGridViewTextBoxColumn UserEmailCol;
        private DataGridViewTextBoxColumn UserPhoneCol;
        private Button btnEdit;
    }
}