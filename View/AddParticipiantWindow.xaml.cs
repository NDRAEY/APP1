using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    /// Interaction logic for AddParticipiantWindow.xaml
    /// </summary>
    ///

    public partial class AddParticipiantWindow : BaseWindow
    {
        public AddParticipiantWindow()
        {
            InitializeComponent();

            List<string> strings = new List<string>();

            foreach (var item in DBManager.GetContext().Stage)
            {
                strings.Add(item.Name);
            }

            this.stagebox.ItemsSource = strings;
        }

        public void AddParticipiant(object sender, RoutedEventArgs e)
        {
            string surname = this.surnamebox.Text;
            string name = this.namebox.Text;
            string patronymic = this.patronymicbox.Text;
            string country = this.countrybox.Text;
            string password = this.passwordbox.Password;
            string password_again = this.password_again_box.Password;
            string login = usernamebox.Text;

            if (surname == "" || name == "" || login == "" || patronymic == "" || country == "" || password == "" || stagebox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if(password != password_again)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            var stage = DBManager.GetContext().Stage.Where((x) => x.Name == this.stagebox.SelectedItem.ToString()).FirstOrDefault();


            SystemUsers participant = new SystemUsers();

            participant.Surname = surname;
            participant.Name = name;
            participant.Patronymic = patronymic;
            participant.Country = country;
            participant.Login = login;
            participant.Role = 3;
            participant.Stage = stage.Id;
            participant.PasswordHash = MD5.MD5Hash(password);

            try
            {
                DBManager.GetContext().SystemUsers.Add(participant);
                DBManager.GetContext().SaveChanges();

                Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при создании участника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
