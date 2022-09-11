using WinFormsStepByStep.Data;

namespace WinFormsStepByStep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                MyDataContext myData = new MyDataContext();
                var users = myData.Users.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error start app " + ex.Message);
            }
            

        }
    }
}