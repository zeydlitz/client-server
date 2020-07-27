using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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


namespace client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        public static CollectionBook data = new CollectionBook();

        public static string a;
  
        public MainWindow()
        {
            InitializeComponent();
            GetAll();
            //RunAsync().GetAwaiter().GetResult();
            if (data.books.Count > 0)
                ListViewBooks.ItemsSource = data.books;
            else MessageBox.Show("No data");
        }
        static void GetAll()
        {
            var url = String.Format("{0}{1}", "http://localhost:5000/", "api/book/GetAllBooks");
            var request =
                client.GetAsync(url);

            var response =
                request.Result.Content.
                    ReadAsAsync<ObservableCollection<Book>>();
            data.books = response.Result;

        }
        static void Delete(int id )
        {
            var url = String.Format("{0}{1}{2}", "http://localhost:5000/", "api/book/DeleteBook?id=",id.ToString());
            var request =
                client.GetAsync(url);

            var response =
                request.Result.Content.
                    ReadAsAsync<ObservableCollection<Book>>();
            data.books = response.Result;

        }


        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            ListViewBooks.Items.SortDescriptions.Add(
                new System.ComponentModel.SortDescription("Name_file", System.ComponentModel.ListSortDirection.Ascending));
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var a = ListViewBooks.SelectedItem;
            int id = ListViewBooks.Items.IndexOf(ListViewBooks.SelectedItem);
            if (ListViewBooks.SelectedItems.Count > 1 || id<0)
            {
                MessageBox.Show("Incorrecte choose");
                return;
            }

            ListViewBooks.ClearValue(ItemsControl.ItemsSourceProperty);
            Delete(id);
            ListViewBooks.ItemsSource = data.books;
        }
    }

}
