using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Client.Models;
using RestSharp;

namespace Client
{
    /// <summary>
    /// не использовал шаблон mvp, так это тестовое задание
    /// </summary>
    public partial class MainWindow : Window
    {
        private Service RestService = new Service();
        public MainWindow()
        {
            InitializeComponent();
            LoadList();

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += (sender, args) => LoadList();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }



        private void LoadList()
        {
            var responce = RestService.Get<List<SessionList>>("sessions");

            if (responce.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Сервис недоступен");
            }
            else
            {
                sessionList.ItemsSource = responce.Content;
            }
        }

        private void CreateOrder(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var data = (SessionList)button.DataContext;
            var dialog = new OrderDialog(data);
            dialog.Show();
            dialog.Closed += DialogOnClosed;
        }

        private void DialogOnClosed(object sender, EventArgs eventArgs)
        {
            this.Activate();
        }
    }
}
