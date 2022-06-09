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

namespace FinalProject
{
    /// <summary>
    /// Author.xaml etkileşim mantığı
    /// </summary>
    public partial class AuthorControl : UserControl
    {
        int id = 0;
        public AuthorControl()
        {
            InitializeComponent();
            getAuthor();
        }
        FinalProjectEntities db = new FinalProjectEntities();

        public void getAuthor()
        {
            System.Console.WriteLine("merhaba");
            var data = (from author in db.Author
                        select new
                        {
                            ID = author.id,
                            Name = author.name,
                            LastName = author.lastname,
                        });
            dgAuthorList.ItemsSource = data.ToList();
        }

        public void setId(int id1)
        {
            this.id = id1;
        }

        public int getId()
        {
            return id;
        }

        public void clear()
        {
            tbFirstName.Text = tbLastName.Text = "";
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int book_id = getId();
            if (book_id != 0)
            {
                var update_data = db.Author.First(x => x.id == book_id);

                update_data.name = tbFirstName.Text;
                update_data.lastname = tbLastName.Text;

                db.SaveChanges();

                MessageBox.Show("Data Updated", "Success");

                getAuthor();
                clear();
            }
            else
            {
                MessageBox.Show("Please select the row that you want to update!", "Error");
            }
        }

        public bool controlTextBoxes()
        {
            if (tbFirstName.Text != "" && tbLastName.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (controlTextBoxes())
            {
                Author new_author = new Author();
                new_author.name = tbFirstName.Text;
                new_author.lastname = tbLastName.Text;

                db.Author.Add(new_author);
                db.SaveChanges();

                MessageBox.Show("You saves succesfully", "Success");

                getAuthor();
                clear();
            }
            else
            {
                MessageBox.Show("Please dont leave blank input", "Error");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleted_id = getId();
            if (deleted_id != 0)
            {
                var deleted_author = db.Author.First(x => x.id == deleted_id);

                db.Author.Remove(deleted_author);

                MessageBox.Show("The Author deleted successfully", "Deleted");

                db.SaveChanges();

                getAuthor();
                clear();
            }
            else
            {
                MessageBox.Show("Please select the row that you want to delete!", "Error");
            }
        }

        private void dgAuthorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgAuthorList.SelectedItem;
            if (item != null)
            {
                var id = Convert.ToInt32((dgAuthorList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                setId(id);
                tbFirstName.Text = (dgAuthorList.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                tbLastName.Text = (dgAuthorList.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            }
        }
    }
}
