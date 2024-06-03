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
using System.Windows.Shapes;
using Voltooid.Models;

namespace Voltooid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ScientistsEntities sc = new ScientistsEntities();

        private SystemUsers this_user;

        public MainWindow(SystemUsers usr)
        {
            InitializeComponent();

            this_user = usr;

            current_scientist.ItemsSource = sc.SystemUsers.ToList();
            current_scientist.SelectedValuePath = "TabelId";

            UpdateList();
        }

        void UpdateList()
        {
            var confs = from user in sc.SystemUsers
                where user.Role == 3
                join con in sc.Contributions
                    on user.TabelId equals con.TabelId into g
                select new
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Patronymic = user.Patronymic,
                    Count = g.Count()
                };

            list_scientists.ItemsSource = confs.OrderByDescending(x => x.Count).ToList();
        }

        private void Current_scientist_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = (int)current_scientist.SelectedValue;

            var confs = from user in sc.SystemUsers
                where user.TabelId == id
                join con in sc.Contributions
                    on user.TabelId equals con.TabelId into w
                from contribution in w
                join conf in sc.Conferences
                    on contribution.ConferenceId equals conf.Id into z
                from conference in z
                select new
                {
                    Date = conference.Date,
                    Name = conference.Name,
                    Place = conference.Place,
                    Topic = contribution.Topic
                };

            list_filtered.ItemsSource = confs.OrderByDescending(item => item.Date).ToList();    
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddParticipiantWindow add_scientist = new AddParticipiantWindow();
            add_scientist.ShowDialog();

            UpdateList();
        }

        //Вызывается при нажатии на кнопку сворачивания окна
        private void Minimize_btn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Вызывается при нажатии на кнопку расширения окна
        private void Maximize_btn_OnClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        //Вызывается при нажатии на кнопку закрытия окна
        private void Close_btn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Вызывается при нажатии на окно
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

    }
}
