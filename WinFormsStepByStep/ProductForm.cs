using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WinFormsStepByStep.Data;

namespace WinFormsStepByStep
{
    public partial class ProductForm : Form
    {
        private MyDataContext myData = new MyDataContext();
        public ProductForm()
        {
            InitializeComponent();
            try
            {
                lvProducts.LargeImageList=new ImageList();
                lvProducts.LargeImageList.ImageSize = new Size(64, 64);

                foreach (var p in myData.Products
                    .Include(x=>x.ProductImages)
                    .ToList())
                {
                    var pImage = p.ProductImages.OrderBy(x => x.Priority).FirstOrDefault();
                    string id = "0";
                    string image = "no-image.jpg";
                    if (pImage != null)
                    {
                        image = pImage.Name;
                        id = pImage.Id.ToString();
                    }
                    lvProducts.LargeImageList.Images.Add(id,
                        Image.FromFile($"images/{image}"));
                    ListViewItem item = new ListViewItem();
                    item.Text = $"{p.Name}\r\n{p.Price}";
                    item.ImageKey = $"{id}";

                    //item.Image
                    //item.
                    lvProducts.Items.Add(item);
                }
                //
                //var products = myData.Products.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error start app " + ex.Message);
            }
            

        }
    }
}