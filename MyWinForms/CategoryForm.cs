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
    public partial class CategoryForm : Form
    {
        AppEFContext myContext = new AppEFContext();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            
            Category category = new Category();
            category.DateCreated = DateTime.Now;
            category.Title = "ПК";
            category.Priority = 1;
            myContext.Categories.Add(category);
            myContext.SaveChanges();

        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            foreach(var c in myContext.Categories
                .Where(x=>x.ParentId==null).ToList())
            {
                TreeNode node = new TreeNode(c.Title);
                node.Tag = c;
                node.Nodes.Add("");
                tvCategory.Nodes.Add(node);
            }
        }
    }
}
