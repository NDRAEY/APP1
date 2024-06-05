using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using Voltooid.Models;

namespace Voltooid
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : BaseWindow
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginbox.Text.Trim();
            string passwd = passwordbox.Password;

            string hash = MD5.MD5Hash(passwd);


            var rq = DBManager.GetContext().SystemUsers.Where(u => u.Login == login && u.PasswordHash == hash);

            if (!rq.Any())
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            var usr = rq.First();


            MainWindow mw = new MainWindow(usr);
            Close();
            mw.Show();
        }
    }
}
