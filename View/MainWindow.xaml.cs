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
    public partial class MainWindow : BaseWindow
    {
        private SystemUsers this_user;

        public MainWindow(SystemUsers usr)
        {
            InitializeComponent();

            this_user = usr;

            if(usr.Role == 3)
            {
                AddButton.Visibility = Visibility.Collapsed;
            }

            current_scientist.ItemsSource = DBManager.GetContext().SystemUsers.ToList();
            current_scientist.SelectedValuePath = "TabelId";

            UpdateList();
        }

        void UpdateList()
        {
            var confs = from user in DBManager.GetContext().SystemUsers
                where user.Role == 3
                join con in DBManager.GetContext().Contributions
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

            var confs = from user in DBManager.GetContext().SystemUsers
                where user.TabelId == id
                join con in DBManager.GetContext().Contributions
                    on user.TabelId equals con.TabelId into w
                from contribution in w
                join conf in DBManager.GetContext().Conferences
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
    }
}
