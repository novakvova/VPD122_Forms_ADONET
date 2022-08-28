using MyWinForms.Data;
using MyWinForms.Helpers;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

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
            tvCategory.ImageList = new ImageList();
            foreach (var c in myContext.Categories
                .Where(x => x.ParentId == null).ToList())
            {
                tvCategory.ImageList.Images.Add(c.Id.ToString(), Image.FromFile($@"images\32_{c.Image}"));
                TreeNode node = new TreeNode(c.Title);
                node.Tag = c;
                node.ImageKey=c.Id.ToString();
                node.SelectedImageKey = c.Id.ToString();
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
            int? parentId = null;
            if (cbIsSubCategory.Checked)
            {
                var node = tvCategory.SelectedNode;
                var catParent = node.Tag as Category;
                parentId= catParent.Id;
                //MessageBox.Show(node);
            }
            string dir = "images";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            int[] fileSize = { 32, 100, 300 };
            Bitmap bitmap = new Bitmap(image);
            string imageName = Path.GetRandomFileName() + ".jpg";
            
            foreach (var size in fileSize)
            {
                var img = ImageWorker.CompressImage(bitmap, size, size, false);
                img.Save(Path.Combine(dir, $"{size}_{imageName}"), ImageFormat.Jpeg);
            }
            

            Category category = new Category();
            category.DateCreated = DateTime.Now;
            category.Title = txtTitle.Text;
            category.Image = imageName;
            category.Priority = int.Parse(txtPrioritet.Text);
            category.ParentId = parentId;
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

        private void cbIsSubCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsSubCategory.Checked)
            {
                var node = tvCategory.SelectedNode;
                if (node!=null)
                {
                    Category c = node.Tag as Category;
                    cbIsSubCategory.Text = $"Підкатегорія - {c.Title}";
                }
                else
                {
                    cbIsSubCategory.Checked = false;
                    MessageBox.Show("Оберіть підкатегорію");

                }
            }
            else
                cbIsSubCategory.Text = $"Підкатегорія";
        }

        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = tvCategory.SelectedNode;
            var cat = node.Tag as Category;
            cbIsSubCategory.Text = $"Підкатегорія - {cat.Title}";
        }

        private void tvCategory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var hitTest = e.Node.TreeView.HitTest(e.Location);
            if (hitTest.Location != TreeViewHitTestLocations.PlusMinus)
                return;
            if (!e.Node.IsExpanded)
                return;
            var item = e.Node.Tag as Category;
            var list = myContext.Categories.Where(x => x.ParentId == item.Id).ToList();
            e.Node.Nodes.Clear();
            if (list.Count > 0)
            {
                foreach (var c in list)
                {
                    TreeNode node = new TreeNode(c.Title);
                    tvCategory.ImageList.Images.Add(c.Id.ToString(), Image.FromFile($"images\\32_{c.Image}"));
                    node.ImageKey = c.Id.ToString();
                    node.SelectedImageKey = c.Id.ToString();
                    node.Nodes.Add("");
                    node.Tag = c;
                    e.Node.Nodes.Add(node);
                }
            }

        }
    }
}
