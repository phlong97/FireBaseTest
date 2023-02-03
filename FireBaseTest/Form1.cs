using Firebase.Database;

namespace FireBaseTest
{
    public partial class Form1 : Form
    {
        public static string URL = "", Secret = "", child = "";
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSendData_Click(object sender, EventArgs e)
        {
            var client = new FireBaseDB(URL, Secret);
            await client.SaveToFireBase(child, new TestClass
            {
                Name = txtName.Text,
                Time = DateTime.Now,
                Id =
                DateTime.Now.ToShortTimeString(),
                Key = FirebaseKeyGenerator.Next()
            });
            dgFireBase.DataSource = await
                 client.GetDataFromFireBase<TestClass>(child);
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            var client = new FireBaseDB(URL, Secret);
            dgFireBase.DataSource = await
                 client.GetDataFromFireBase<TestClass>(child);
        }
    }
}