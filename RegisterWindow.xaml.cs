﻿using System;
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
using MySql.Data.MySqlClient;

namespace Contact_manager {
	/// <summary>
	/// Interaction logic for RegisterWindow.xaml
	/// </summary>
	public partial class RegisterWindow : Window {

		bool IsClosed = false;
		public RegisterWindow() {
			InitializeComponent();
		}


		private void GoToRegisterWindow_PreviewMouseDown(object sender, MouseButtonEventArgs e) {

			MainWindow main = new MainWindow();
			main.Show();
			Close();

		}

		private void Button_Click(object sender, RoutedEventArgs e) {

			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

			dlg.DefaultExt=".png";
			dlg.Filter="JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

			Nullable<bool> result = dlg.ShowDialog();
			if (result.HasValue && result.Value) {
				string filename = dlg.FileName;
				PictureBox.Source = new BitmapImage(new Uri(dlg.FileName));
			}

		}

		private bool CheckEmptyFields(String username, String password, ImageSource picture) {


			if (username.Length==0&&password.Length==0) {
				MessageBox.Show("Need to specify the username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return true;
			}
			else if (password.Length==0) {
				MessageBox.Show("Need to specify the password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return true;
			}
			else if (username.Length==0) {
				MessageBox.Show("Need to specify the username.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return true;
			}
			else if (picture == null) {
				MessageBox.Show("Upload a picture.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return true;

			}
			return false;
		}


		
		private void Register_Click(object sender, RoutedEventArgs e) {

			string firstname=first_name.Text;
			string lastname = last_name.Text;
			string user = username.Text;
			string password = TextPassword.Password;


			//Check empty fields (namely, username and password fields)
			if (!CheckEmptyFields(user, password, PictureBox.Source)) {
				Database db = new Database();
				var con = db.GetMySqlConnection;
				db.OpenMySqlConnection();
				var cmd = new MySqlCommand("INSERT into users(username,password) VALUES(@user,@pass)", con);
				cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value=user;
				cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value=password;

				cmd.ExecuteNonQuery();
			}
			
		}	
		



	}
}