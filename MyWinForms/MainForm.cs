using MyWinForms.Data;
using System.Drawing.Imaging;

namespace MyWinForms
{
    public partial class MainForm : Form
    {
        private readonly AppEFContext _context = new AppEFContext();
        public MainForm()
        {
            InitializeComponent();
            LoadList();
        }
        private void LoadList()
        {
            dgvUsers.Rows.Clear();
            var users = _context.Users.ToList();
            foreach (var user in users)
            {
                object[] row = { user.Id, Image.FromFile(Path.Combine("images", user.Photo)),
                    user.Name, user.Email, user.Phone };
                dgvUsers.Rows.Add(row);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUserForm dlg = new AddUserForm();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                string dir = "images";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                Bitmap bitmap = new Bitmap(dlg.ImagePhoto);
                string imageName = Path.GetRandomFileName() + ".jpg";
                bitmap.Save(Path.Combine(dir, imageName), ImageFormat.Jpeg);
                AppUser user = new AppUser()
                {
                    Name = dlg.Pib,
                    Phone = dlg.Phone,
                    Email = dlg.Email,
                    Photo = imageName
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                LoadList();


            }
        }
    }
}