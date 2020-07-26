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
        //static async Task<Product> GetAPIAsync(string path)

        //{

        //    Product project = null;

        //    HttpResponseMessage response = await client.GetAsync(path);

        //    if (response.IsSuccessStatusCode)

        //    {

        //        project = await response.Content.ReadAsAsync<Product>();

        //    }

        //    return project;

        //}

        //public class Product
        //{
        //    public string Name { get; set; }
        //    public int Value { get; set; }
        //    public string Image { get; set; }

        //    public Product(string name,int value, string image)
        //    {
        //        Name = name;
        //        Value = value;
        //        Image = image;
        //    }
        //}
        //private List<Product> GetProducts()
        //{
        //    return new List<Product>()
        //    {
        //        new Product("Product 1", 1,"D:\\programmig\\C#\\texode\\texode\\data\\images\\Grokking_Algorithms.jpg"),
        //        new Product("Product 2", 2,"D:\\programmig\\C#\\texode\\texode\\data\\images\\clean_code.jpg"),
        //        new Product("Product 3",3, "D:\\programmig\\C#\\texode\\texode\\data\\images\\Swift.jpg"),
        //        new Product("Product 4", 4,"D:\\programmig\\C#\\texode\\texode\\data\\images\\Swift.jpg"),
        //        new Product("Product 5", 5,"D:\\programmig\\C#\\texode\\texode\\data\\images\\java.jpg"),
        //        new Product("Product 6", 6,"D:\\programmig\\C#\\texode\\texode\\data\\images\\security.jpg"),
        //        new Product("Product 7", 7,"D:\\programmig\\C#\\texode\\texode\\data\\images\\clr.jpg"),
        //        new Product("Product 8",  8,"D:\\programmig\\C#\\texode\\texode\\data\\images\\deep_learning.jpg")
        //    };
        //}
        public MainWindow()
        {
            InitializeComponent();
            RunAsync().GetAwaiter().GetResult();

            //var products = GetProducts();
            if (data.books.Count > 0)
                ListViewProducts.ItemsSource = data.books;
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

        static async Task<CollectionBook> GetAllAsync()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/book/GetAllBooks");
            if (response.IsSuccessStatusCode)
            {
                data.books = await response.Content.ReadAsAsync<List<Books>>();
            }
            return data;
        }
    }

}
