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

namespace Voltooid
{
    /// <summary>
    /// Interaction logic for AddParticipiantWindow.xaml
    /// </summary>
    ///

    public partial class AddParticipiantWindow : Window
    {
        ScientistsEntities entities = new ScientistsEntities();

        public AddParticipiantWindow()
        {
            InitializeComponent();

            List<string> strings = new List<string>();

            foreach (var item in entities.Stage)
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
            string login = usernamebox.Text;

            if (surname == "" || name == "" || login == "" || patronymic == "" || country == "" || password == "" || stagebox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            var stage = entities.Stage.Where((x) => x.Name == this.stagebox.SelectedItem.ToString()).FirstOrDefault();


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
                entities.SystemUsers.Add(participant);
                entities.SaveChanges();

                MessageBox.Show("Okay");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
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
