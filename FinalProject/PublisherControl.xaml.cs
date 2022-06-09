using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace FinalProject
{
    /// <summary>
    /// PublisherControl.xaml etkileşim mantığı
    /// </summary>
    public partial class PublisherControl : UserControl
    {
        int id = 0;
        public PublisherControl()
        {
            InitializeComponent();
            loadPublisher();
        }
        static string con_string = "data source=DESKTOP-RUD4QA2\\KAMET;initial catalog=FinalProject;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        SqlConnection db = new SqlConnection(con_string);

        public void loadPublisher()
        {
            db.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Publisher", db);
            System.Data.DataTable dt = new System.Data.DataTable();

            adapter.Fill(dt);

            dgPublisher.ItemsSource = dt.DefaultView;

            db.Close();
        }

        public void clear()
        {
            tbName.Text = "";
        }

        public bool controlInput()
        {
            if (tbName.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (controlInput())
            {
                string query = "INSERT INTO Publisher (name, created_at) VALUES ('" + tbName.Text + "', '" + dtpCreatedAt.SelectedDate.ToString() + "')";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                command.ExecuteNonQuery();
                db.Close();

                MessageBox.Show("New Publisher saved succesfully!", "Success");

                loadPublisher();
                clear();
            }
            else
            {
                MessageBox.Show("Please fill all blanks!", "Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (controlInput())
            {
                int id = getID();
                string query = "UPDATE Publisher SET name = '" + tbName.Text + "', created_at = '" + dtpCreatedAt.Text + "' WHERE id = '" + id + "'";
                SqlCommand command = new SqlCommand(query, db);

                db.Open();
                command.ExecuteNonQuery();
                db.Close();

                MessageBox.Show("Publisher updated succesfully!", "Success");

                loadPublisher();
                clear();
            }
            else
            {
                MessageBox.Show("Please fill all blanks!", "Error");
            }
        }

        public void setID(int id1)
        {
            id = id1;
        }

        public int getID()
        {
            return id;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = getID();
            if (id != 0)
            {
                string query = "DELETE FROM Publisher WHERE id = '" + id + "'";
                SqlCommand command = new SqlCommand(query, db);

                db.Open();
                command.ExecuteNonQuery();
                db.Close();

                MessageBox.Show("Publisher deleted succesfully!", "Success");

                loadPublisher();
                clear();
            }
            else
            {
                MessageBox.Show("Please select the row that you want to delete!", "Warning");
            }
        }

        private void dgPublisher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgPublisher.SelectedItem;
            if (item != null)
            {
                var id = Convert.ToInt32((dgPublisher.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                setID(id);
                tbName.Text = (dgPublisher.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                dtpCreatedAt.Text = (dgPublisher.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            }
        }
    }
}
