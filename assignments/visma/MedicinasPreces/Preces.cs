using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace MedicinasPreces
{
    public partial class Preces : Form
    {
        static SQLiteConnection m_dbConnection;

        public Preces()
        {
            InitializeComponent();
            ShowDBInfo();
            ShowXmlInfo();
            initTestData();
        }

        private async Task ShowDBInfo()
        {
            string dbConStr = System.Configuration.ConfigurationManager.ConnectionStrings["Products"].ConnectionString;
            m_dbConnection = new SQLiteConnection(dbConStr);
            m_dbConnection.Open();

            string sql;
            SQLiteCommand command;

            sql = "select 'OK' test from preces";
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = await Task.Run(() => command.ExecuteReader());
            if (reader.Read())
            {
                dbRecCount.Text = reader["test"].ToString();
            }
            m_dbConnection.Close();
        }

        private async Task ShowXmlInfo()
        {
            string xmlPath = System.Configuration.ConfigurationManager.ConnectionStrings["Ingredients"].ConnectionString;
            XmlDocument xmlD = new XmlDocument();
            await Task.Run(() => xmlD.Load(xmlPath));
            xmlRecCount.Text = "OK";
        }
        
        private void buttonTask1_Click(object sender, EventArgs e)
        {
            textBoxAnswerTask1.Text = "?";
        }

        private void buttonTask2_Click(object sender, EventArgs e)
        {
            textBoxAnswerTask2.Text = "?";
        }

        private void initTestData()
        {
            //An example
            listViewIngredientsTask3.Items.Add("A vitamin");
            listViewIngredientsTask3.Items.Add("B vitamin");
            listViewIngredientsTask3.Items.Add("B1 vitamin");
            listViewIngredientsTask3.Items.Add("B2 vitamin");
            listViewIngredientsTask3.Items.Add("C vitamin");
            listViewIngredientsTask3.Items.Add("D vitamin");
        }

    }
}
