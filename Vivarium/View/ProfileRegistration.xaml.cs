using System.Windows;
using System.Windows.Controls;
using Vivarium.Authorization;
using Vivarium.Control;

namespace Vivarium.View
{
	/// <summary>
	/// Логика взаимодействия для ProfileRegistration.xaml
	/// </summary>
	public partial class ProfileRegistration : Window
	{
		private string login;
		private string password;
		public ProfileRegistration()
		{
			InitializeComponent();
		}

		private void RegButton_Click(object sender, RoutedEventArgs e)
		{
			login = LoginBox.Text;
			password = PasswordBox.Text;

			var registered = new Controller(login, password).TryToSignUp();
			if (registered)
			{
				Logged.IsLoggedIn = true;
				var loader = new DataLoader(login);
				MessageBox.Show("Вы были успешно зарегистрированы!");
			}
			else
			{
				Logged.IsLoggedIn = false;
				MessageBox.Show("Произошла ошибка!");
			}
		}

		//private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
		//{

		//}

		private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		//private void PhoneBox_TextChanged(object sender, TextChangedEventArgs e)
		//{

		//}
	}
}
