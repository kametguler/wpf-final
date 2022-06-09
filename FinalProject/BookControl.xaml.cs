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
    /// BookControl.xaml etkileşim mantığı
    /// </summary>
    public partial class BookControl : UserControl
    {
        int id = 0;
        public BookControl()
        {
            InitializeComponent();
            getBooks();
            fillComboBoxes();
            clear();
            System.Console.WriteLine("qweqw");
        }

        FinalProjectEntities db = new FinalProjectEntities();

        public void getBooks()
        {
            var data = (from book in db.Book
                        join author in db.Author
                        on book.author_id equals author.id
                        join publisher in db.Publisher
                        on book.publisher_id equals publisher.id
                        select new
                        {
                            ID = book.id,
                            BookName = book.name,
                            Category = book.type,
                            Author = author.name + " " + author.lastname,
                            Publisher = publisher.name,
                            PublishedDate = book.published_date
                        }).ToList();

            dgBookList.ItemsSource = data;

        }

        public void fillComboBoxes()
        {
            var cB_author = (from author in db.Author
                             select new
                             {
                                 author_name = author.name + " " + author.lastname,
                                 author_id = author.id
                             });

            cbAuthor.ItemsSource = cB_author.ToList();
            cbAuthor.DisplayMemberPath = "author_name";
            cbAuthor.SelectedValuePath = "author_id";

            var cB_publisher = (from publisher in db.Publisher
                                select new
                                {
                                    publisher_id = publisher.id,
                                    publisher_name = publisher.name
                                }).ToList();

            cbPublisher.ItemsSource = cB_publisher;
            cbPublisher.DisplayMemberPath = "publisher_name";
            cbPublisher.SelectedValuePath = "publisher_id";
        }

        public bool controlTextBoxes()
        {
            if (tbName.Text == "" || cbCategory.Text == "" || cbPublisher.Text == "" || cbAuthor.Text == "" || dtpPublishedDate.Text == "") { return false; } else { return true; }
        }

        public void clear()
        {
            tbName.Text = "";
            cbCategory.Text = "";
            cbAuthor.Text = "";
            cbPublisher.Text = "";
            dtpPublishedDate.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (controlTextBoxes())
            {
                Book new_book = new Book();
                new_book.name = tbName.Text;
                new_book.author_id = Int32.Parse(cbAuthor.SelectedValue.ToString());
                new_book.publisher_id = Int32.Parse(cbPublisher.SelectedValue.ToString());
                new_book.published_date = dtpPublishedDate.SelectedDate.Value;
                new_book.type = cbCategory.Text;
                db.Book.Add(new_book);
                db.SaveChanges();

                MessageBox.Show("You saved correctly", "Success");

                getBooks();
                clear();
            }
            else
            {
                MessageBox.Show("You must fill the blanks", "Error");
            }
        }

        public int getSelectedId()
        {
            return id;
        }

        public void setID(int id1)
        {
            id = id1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (controlTextBoxes())
            {
                int book_id = getSelectedId();

                if (book_id != 0)
                {
                    Console.WriteLine(book_id);
                    var update_book = db.Book.First(x => x.id == book_id);
                    update_book.name = tbName.Text;
                    update_book.author_id = Int32.Parse(cbAuthor.SelectedValue.ToString());
                    update_book.publisher_id = Int32.Parse(cbPublisher.SelectedValue.ToString());
                    update_book.published_date = dtpPublishedDate.SelectedDate.Value;
                    update_book.type = cbCategory.Text.ToString();
                    db.SaveChanges();

                    MessageBox.Show("Data Updated", "Success");

                    getBooks();
                    clear();
                }
                else
                {
                    MessageBox.Show("Please select the row that you want to update!", "Error");
                }


            }
            else
            {
                MessageBox.Show("You must fill the blanks", "Error");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int deleted_id = getSelectedId();

            if (deleted_id != 0)
            {
                var deleted_book = db.Book.First(x => x.id == deleted_id);

                db.Book.Remove(deleted_book);

                MessageBox.Show("The Book deleted successfully", "Deleted");

                db.SaveChanges();

                getBooks();
                clear();
            }
            else
            {
                MessageBox.Show("Please select the row that you want to delete!", "Error");
            }


        }



        private void dgBookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgBookList.SelectedItem;
            if (item != null)
            {
                var id = Convert.ToInt32((dgBookList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                setID(id);
                tbName.Text = (dgBookList.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                cbCategory.Text = (dgBookList.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                cbAuthor.Text = (dgBookList.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                cbPublisher.Text = (dgBookList.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                dtpPublishedDate.Text = (dgBookList.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            }
            
        }


    }
}
