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
using System.Windows.Markup;

namespace FinalProject
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadForm();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        public void loadForm(String wType="home")
        {
            mainPanel.Children.Clear();
            if (wType == "home")
            {
                mainPanel.Children.Add(new Home());
            }
            else if(wType == "Author")
            {
                mainPanel.Children.Add(new AuthorControl());
            }
            else if (wType == "Publisher")
            {
                mainPanel.Children.Add(new PublisherControl());
            }
            else if (wType == "Book")
            {
                mainPanel.Children.Add(new BookControl());
            }

        }

        public void clearXaml()
        {
            this.mainPanel.Children.Clear();

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            loadForm();
            this.Cursor = null;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            loadForm("Book");
            this.Cursor = null;
        }

        private void btnAuthor_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            loadForm("Author");
            this.Cursor = null;
        }

        private void btnPublisher_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            loadForm("Publisher");
            this.Cursor = null;
        }
    }
}
