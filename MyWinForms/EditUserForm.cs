using Microsoft.EntityFrameworkCore;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyWinForms
{
    public partial class EditUserForm : Form
    {
        public int Id { get; set; }
        public string Pib { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImagePhoto{ get; set; }
        public List<int> RolesChecket { get; set; } = new List<int>();

        public EditUserForm()
        {
            InitializeComponent();
            
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
            var list = clbRoles.CheckedItems;
            foreach (var item in list)
            {
                var role = item as AppRole;
                RolesChecket.Add(role.Id);
            }
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

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            pbImage.Image = Image.FromFile(ImagePhoto);
            txtName.Text = Pib;
            txtEmail.Text=Email;
            txtPhone.Text= Phone;
            AppEFContext context = new AppEFContext();
            var user = context.Users
                .Include(x => x.AppUserRoles)
                .SingleOrDefault(x => x.Id == Id);

            foreach (var item in context.Roles)
            {
                bool select = false;
                if (user.AppUserRoles.SingleOrDefault(r => r.RoleId == item.Id) != null)
                    select = true;
                clbRoles.Items.Add(item, select);
            }
        }
    }
}
