using MyWinForms.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinForms
{
    public partial class CategoryForm : Form
    {
        AppEFContext myContext = new AppEFContext();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void LoadList()
        {
            tvCategory.Nodes.Clear();
            foreach (var c in myContext.Categories
                .Where(x => x.ParentId == null).ToList())
            {
                TreeNode node = new TreeNode(c.Title);
                node.Tag = c;
                node.Nodes.Add("");
                tvCategory.Nodes.Add(node);
            }
        }
        private void ClearInput()
        {
            txtPrioritet.Text = "0";
            txtTitle.Text = "";
            pbImage.Image = Image.FromFile($"images/upload.png");
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string dir = "images";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            Bitmap bitmap = new Bitmap(image);
            string imageName = Path.GetRandomFileName() + ".jpg";
            bitmap.Save(Path.Combine(dir, imageName), ImageFormat.Jpeg);

            Category category = new Category();
            category.DateCreated = DateTime.Now;
            category.Title = txtTitle.Text;
            category.Image = imageName;
            category.Priority = int.Parse(txtPrioritet.Text);
            myContext.Categories.Add(category);
            myContext.SaveChanges();

            ClearInput();
            LoadList();

        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            ClearInput();

            LoadList();
        }


        
        private string image;

        private void pbImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbImage.Image = Image.FromFile(dlg.FileName);
                    image = dlg.FileName;
                }
                catch
                {
                    MessageBox.Show("Файл не підтримується!");
                }
                
            }
        }
    }
}
