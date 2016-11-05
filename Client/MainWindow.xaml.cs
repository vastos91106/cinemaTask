using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadList();
        }

        private void LoadList()
        {
            var list = new List<ListSession>()
            {
                new ListSession()
                {
                    Color="red",
                    StartingDate = DateTime.Now.ToString(""),
                    ID = 1,
                    Film = new FilmVM()
                    {
                        ID = 1,
                        Name = "Звездные войны"
                    }
                },
                new ListSession()
                {
                    Color="red",
                    StartingDate = DateTime.Now.ToString("g"),
                    ID = 1,
                    Film = new FilmVM()
                    {
                        ID = 1,
                        Name = "Звездные войны"
                    }
                }
            };

            sessionList.ItemsSource = list;
        }
    }

    public class ListSession
    {
        public string Color { get; set; }
        public int ID { get; set; }
        public FilmVM Film { get; set; }

        public string StartingDate { get; set; }
    }

    public class FilmVM
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
