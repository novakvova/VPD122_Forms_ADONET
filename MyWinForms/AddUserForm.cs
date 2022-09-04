using MyWinForms.Data;
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
        public string ImagePhoto{ get; set; }
        public List<int> RolesChecket { get; set; } = new List<int>();
        public AddUserForm()
        {
            InitializeComponent();
            pbImage.Image = Image.FromFile("select.jfif");
            AppEFContext context = new AppEFContext();
            foreach (var item in context.Roles)
            {
                clbRoles.Items.Add(item);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var list = clbRoles.CheckedItems;
            foreach (var item in list)
            {
                var role = item as AppRole;
                RolesChecket.Add(role.Id);
            }
            this.Pib = txtName.Text;
            this.Email = txtEmail.Text;
            this.Phone = txtPhone.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(dlg.FileName);
                ImagePhoto=dlg.FileName;
                //MessageBox.Show("Select image " + dlg.FileName);
            }
        }
    }
}
