using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Voltooid
{
    public class BaseWindow : Window
    {
        //Вызывается при нажатии на кнопку сворачивания окна
        protected void Minimize_btn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Вызывается при нажатии на кнопку расширения окна
        protected void Maximize_btn_OnClick(object sender, RoutedEventArgs e)
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
        protected void Close_btn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Вызывается при нажатии на окно
        protected void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
