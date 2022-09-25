using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsStepByStep
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
            lvImages.LargeImageList = new ImageList();
            lvImages.LargeImageList.ImageSize = new Size(64,64);

        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string key = Guid.NewGuid().ToString();
                ListViewItem item = new ListViewItem();
                item.Tag = dlg.FileName;
                item.Text = Path.GetFileName(dlg.FileName);
                item.ImageKey = key;
                lvImages.LargeImageList.Images.Add(key, Image.FromFile(dlg.FileName));
                lvImages.Items.Add(item);

                //MessageBox.Show("Select image " + dlg.FileName);
            }
        }
    }
}
