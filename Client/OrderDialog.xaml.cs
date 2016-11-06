using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Windows;
using Client.Models;
using RestSharp;

namespace Client
{
    public partial class OrderDialog : Window
    {
        private Service RestService = new Service();
        private SessionList _session;
        public OrderDialog()
        {
            InitializeComponent();
        }

        public OrderDialog(SessionList session)
        {
            InitializeComponent();
            _session = session;
            FilmName.Text = $"Сеанс: {session.Film.Name}";
            SessionDate.Text = $"Дата: {session.StartingDate}";
        }

        public bool Canceled { get; set; }

        private void CanselOrder(object sender, System.Windows.RoutedEventArgs e)
        {
            Canceled = true;
            Close();
        }

        private void CreateOrder(object sender, System.Windows.RoutedEventArgs e)
        {
            var count = 0;
            int.TryParse(CountInput.Text, out count);
            var model = new OrderCreate()
            {
                SessionID = _session.ID,
                Count = count
            };

            var res = RestService.Post("orders", model);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Заказ был добавлен");
                Close();
            }
            if (res.StatusCode == HttpStatusCode.BadRequest)
            {
                var modelState = (Dictionary<string, dynamic>)res.Content["ModelState"];
                foreach (var error in modelState)
                {
                    MessageBox.Show(error.Value[0]);
                }
            }
            Canceled = false;
        }
    }
}
