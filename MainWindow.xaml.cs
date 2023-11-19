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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users;
        public MainWindow()
        {
            InitializeComponent();
            users = new List<User>
            {
                new User("admin", "12345","Анатолий","М"),
                new User("user", "56789", "Петя","М")
            };
        }

        private void Registrate_Click(object sender, RoutedEventArgs e)
        {
            string name = null;
            string email = null;
            string gender = null;
            string pass = null;

            if (!String.IsNullOrWhiteSpace(nameRegBox.Text))
            {
                name = nameRegBox.Text.Trim();
                nameRegBox.BorderBrush = new SolidColorBrush(Colors.White);
            }
            else
            {
                nameRegBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }


            if (String.IsNullOrWhiteSpace(emailRegBox.Text))
            {
                emailRegBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if (emailRegBox.Text.Contains("@") && emailRegBox.Text.Contains("."))
                {
                    email = emailRegBox.Text.Trim();
                    emailRegBox.BorderBrush = new SolidColorBrush(Colors.White);
                }
                else
                {
                    emailRegBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }


            if (String.IsNullOrWhiteSpace(passRegBox.Text))
            {
                passRegBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                passRegBox.BorderBrush = new SolidColorBrush(Colors.White);
            }


            if (!String.IsNullOrWhiteSpace(retryPassRegBox.Text))
            {
                if (retryPassRegBox.Text == passRegBox.Text){
                    pass = passRegBox.Text.Trim();
                    retryPassRegBox.BorderBrush = new SolidColorBrush(Colors.White);
                }
                else
                {
                    retryPassRegBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                retryPassRegBox.BorderBrush= new SolidColorBrush(Colors.Red);
            }


            if (manGenderButton.IsChecked != true && girlGenderButton.IsChecked != true)
            {
                MessageBox.Show("Выберите пол");
            }
            else if (manGenderButton.IsChecked == true)
            {
                gender = "М";
            }
            else if (girlGenderButton.IsChecked == true)
            {
                gender = "Ж";
            }


            if (email != null && name != null && gender != null && pass != null)
            {
                users.Add(new User(email, pass, name, gender));
            }
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if(users != null)
            {
                foreach(User user in users){
                    if (user.login.Equals(loginBox.Text) && user.password.Equals(passwordBox.Password))
                    {
                        loginBox.BorderBrush = new SolidColorBrush(Colors.White);
                        passwordBox.BorderBrush = new SolidColorBrush(Colors.White);
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        this.Close();
                    }
                    else {
                        expectionBlock.Text = "Неверные логин или пароль";
                        loginBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                }
            }
        }
    }
}
