using BeginApp.Abstracts;
using BeginApp.Services;
using Microsoft.EntityFrameworkCore;
using MyWinForms.Data;
using System.Drawing.Imaging;

namespace MyWinForms
{
    public partial class MainForm : Form
    {
        private readonly AppEFContext _context = new AppEFContext();
        private int currentPage = 1; //поточна сторінка де ми знаходимося
        private int pageSize = 2; //кількість записів, яки ми показуємо
        private int totalPages = 0; //Кількість сторінок, які можна відображати
        private string fileSendEmail=string.Empty;
        public MainForm()
        {
            InitializeComponent();
            LoadList();
        }
        private void LoadList()
        {
            dgvUsers.Rows.Clear();
            var query = _context.Users
                .Include(x=>x.AppUserRoles)
                .ThenInclude(x=>x.Role)
                .AsQueryable(); //робимо sql запит до БД
            var users = query
                .Skip((currentPage - 1) * pageSize) //Кількість запитів, яку я хочу пропустить
                .Take(pageSize) //Кільсть записів, які ми беремо із БД
                .ToList(); //Отримуємо записи із БД
            foreach (var user in users)
            {
                var roleData = "";
                foreach (var role in user.AppUserRoles)
                {
                    roleData += role.Role.Name + "  ";
                }
                object[] row = { user.Id, Image.FromFile(Path.Combine("images", user.Photo)),
                    user.Name, roleData, user.Email, user.Phone };

                dgvUsers.Rows.Add(row);
            }

            int count = query.Count();
            totalPages = (int)Math.Ceiling(count / (double)pageSize);

            btnNext.Enabled = currentPage == totalPages ? false : true;
            btnPrev.Enabled = currentPage == 1 ? false : true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadList();
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
                foreach (var item in dlg.RolesChecket)
                {
                    var userRole = new AppUserRole()
                    {
                        RoleId = item,
                        UserId = user.Id
                    };
                    _context.UserRoles.Add(userRole);
                    _context.SaveChanges();
                }
                LoadList();


            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadList();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectRow = dgvUsers.GetCellCount(DataGridViewElementStates.Selected);
            if (selectRow > 0)
            {
                if(dgvUsers.AreAllCellsSelected(true))
                {
                    MessageBox.Show("All cell are selected");
                }
                else
                {
                    if(selectRow>1)
                    {
                        MessageBox.Show("Оберіть один рядок");
                        return;
                    }
                    var index = dgvUsers.SelectedCells[0].RowIndex;
                    int id = (int)dgvUsers.Rows[index].Cells[0].Value;
                    var user = _context.Users
                        .Include(x=>x.AppUserRoles)
                        .SingleOrDefault(x=>x.Id==id);
                    if (user != null)
                    {
                        string userImage = Path.Combine("images", user.Photo);
                        EditUserForm dlg = new EditUserForm();
                        dlg.Pib=user.Name;
                        dlg.ImagePhoto = userImage;
                        dlg.Email = user.Email;
                        dlg.Phone = user.Phone;
                        dlg.Id = user.Id;
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (dlg.ImagePhoto != userImage) //Заміняємо старе фото
                            {
                                Bitmap bitmap = new Bitmap(dlg.ImagePhoto);
                                string imageName = Path.GetRandomFileName() + ".jpg";
                                bitmap.Save(Path.Combine("images", imageName), ImageFormat.Jpeg);
                                user.Photo = imageName;
                            }
                            user.Email = dlg.Email;
                            user.Phone = dlg.Phone;
                            user.Name=dlg.Pib;
                            //_context.Users.Update(user);
                            _context.SaveChanges();
                            //Clear roles
                            foreach (var userRole in user.AppUserRoles)
                            {
                                _context.UserRoles.Remove(userRole);
                            }
                            _context.SaveChanges();
                            //Add roles
                            foreach (var item in dlg.RolesChecket)
                            {
                                var userRole = new AppUserRole()
                                {
                                    RoleId = item,
                                    UserId = user.Id
                                };
                                _context.UserRoles.Add(userRole);
                                _context.SaveChanges();
                            }
                            LoadList();
                        }
                    }

                    //MessageBox.Show("id = " + id);
                }
            }
            else
            {
                MessageBox.Show("Оберіть рядок, який треба міняти");
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            CategoryForm dlg = new CategoryForm();
            dlg.ShowDialog();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendEmail();
            //SMSService sMS = new SMSService();
            //sMS.Send(txtPhone.Text,txtMessage.Text);
        }
        private void SendEmail()
        {
            try
            {
                BeginApp.Message message = new BeginApp.Message();
                message.Body = "Привіт <b>козак</b>!";
                message.Subject = "Будьмо уважні та обережні :)";
                message.To = "novakvova@gmail.com";
                message.FilePath = fileSendEmail;

                IEmailService emailService = new SmtpEmailService();
                emailService.Send(message);
                //string data = sender.ReadEmailDataPop3();
                //Console.WriteLine(data);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Problem send", ex.Message);
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                fileSendEmail = dlg.FileName;
            }
        }
    }
}