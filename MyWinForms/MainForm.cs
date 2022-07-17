namespace MyWinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUserForm dlg = new AddUserForm();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                object[] row = { 1, Image.FromFile(dlg.ImagePhoto), 
                    dlg.Pib, dlg.Email, dlg.Phone };
                dgvUsers.Rows.Add(row);
            }
        }
    }
}