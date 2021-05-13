using System;
using System.Collections.Generic;
using System.IO;
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


namespace Contact_manager {
	/// <summary>
	/// Interaction logic for RegisterWindow.xaml
	/// </summary>
	public partial class RegisterWindow : Window {

		private LoginWindow login_wind;
		// Prep stuff needed to remove close button on window
		private const int GWL_STYLE = -16;
		private const int WS_SYSMENU = 0x80000;
		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);



		public RegisterWindow(LoginWindow login) {
			InitializeComponent();
			login_wind = login;
			Loaded += ToolWindow_Loaded;
		}


		void ToolWindow_Loaded(object sender, RoutedEventArgs e){
			// Code to remove close box from window
			var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
			SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
		}

	
		private void GoToRegisterWindow_PreviewMouseDown(object sender, MouseButtonEventArgs e) {

			login_wind.Show();
			Close();
			

		}

		private void Button_Click(object sender, RoutedEventArgs e) {

			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

			dlg.DefaultExt="PNG Files (*.png)";
			dlg.Filter="PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|TIFF Files (*.tiff)|*.tiff";

			Nullable<bool> result = dlg.ShowDialog();
			if (result.HasValue && result.Value) {
				string filename = dlg.FileName;
				BitmapImage bitmap = new BitmapImage();  
				bitmap.BeginInit();  
				bitmap.UriSource = new Uri(filename);  
				bitmap.EndInit();
				PictureBox.Source=bitmap;
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
				var newuser = new User();
				if (newuser.is_registered(user)) {
				
					MessageBox.Show("This username already exists!!!", "Invalid Username", MessageBoxButton.OK, MessageBoxImage.Error);

				}
				else {
					ImageSource img = PictureBox.Source;
					String filepath = ((System.Windows.Media.Imaging.BitmapImage)img).UriSource.ToString();
					if (filepath != null) {
						filepath=filepath.Replace("file:///", " ");	
					}
					String message = newuser.add_user_to_DB(firstname, lastname, user, password, filepath);
					if(message==null) {
						MessageBox.Show("Registration Successful", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
						Close();
						login_wind.Show();
						
					}
					else {
						MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				
				}
				
			}
			
		}	
		



	}
}
