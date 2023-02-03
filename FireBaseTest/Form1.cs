using Firebase.Database;

namespace FireBaseTest
{
    public partial class Form1 : Form
    {
        public static string URL = "https://test-7bcdc-default-rtdb.asia-southeast1.firebasedatabase.app/",
            Secret = "nskA8DU277kqufzBZAtRWSYXn4kNMJ2Lq4A7Codx", child = "Data";
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSendData_Click(object sender, EventArgs e)
        {
            var client = new FireBaseDB(URL, Secret);
            for (int i = 0; i < 1000; i++)
            {
                await client.SaveToFireBase(child, new TestClass
                {
                    Name = txtName.Text,
                    Time = DateTime.Now,
                    Id = DateTime.Now.ToShortTimeString(),
                    //Key = DateTime.Now.ToShortTimeString() + txtName.Text,
                });
            }

            //dgFireBase.DataSource = await
            //     client.GetDataFromFireBase<TestClass>(child);
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            var client = new FireBaseDB(URL, Secret);
            dgFireBase.DataSource = await
                 client.GetDataFromFireBase<TestClass>(child);
        }
    }
}