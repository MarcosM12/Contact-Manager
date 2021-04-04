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

namespace Contact_manager {
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	
	public partial class LoginWindow : Window {

		public LoginWindow() {
			InitializeComponent();
		
		}

		private void Button_Click(object sender, RoutedEventArgs e) {

			RegisterWindow register = new RegisterWindow();
			register.Show();
			Close();


		}

		//User Login
		private void Button_Login(object sender, MouseButtonEventArgs e) {
			String user_name = usernameText.Text;
			String given_user_password = passwordText.Password;
			User newuser = new User();

			if (newuser.is_registered(user_name)) {
				String user_password = newuser.get_password(user_name);
				if (user_password!=null) {
					if (user_password.Equals(given_user_password)) {
						//MessageBox.Show("Login Succesful", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
						Close();

					}
						
					else
						MessageBox.Show("Wrong password!!", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				}
				else {
					MessageBox.Show("Error - Null password", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
				}

			}
			else {
				MessageBox.Show("Invalid username", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

	
	}
	
	
}