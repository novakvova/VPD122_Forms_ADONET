using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinForms
{
    public partial class AddUserForm : Form
    {
        public string Pib { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddUserForm()
        {
            InitializeComponent();
            pbImage.Image = Image.FromFile("select.jfif");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Pib = txtName.Text;
            this.Email = txtEmail.Text;
            this.Phone = txtPhone.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
