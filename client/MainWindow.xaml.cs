using System;
using System.Collections.Generic;
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
            //RunAsync().GetAwaiter().GetResult();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = String.Format("{0}{1}", "http://localhost:5000/", "api/book/GetAllBooks");
            var request =
                client.GetAsync(url);

            var response =
                request.Result.Content.
                    ReadAsAsync<List<Book>>();
            data.books = response.Result;
            //var products = GetProducts();
            if (data.books.Count > 0)
                ListViewBooks.ItemsSource = data.books;
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                await GetAllAsync();
               

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static async Task GetAllAsync()
        {
            var url = String.Format("{0}{1}", "http://localhost:5000/", "api/book/GetAllBooks");
            var result = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false); ;
            var response = Task.Run(() => result);
            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                //data.books = await result.Content.ReadAsAsync<List<Book>>();
                a= await result.Content.ReadAsAsync<string>();
            }
        }
    }

}
