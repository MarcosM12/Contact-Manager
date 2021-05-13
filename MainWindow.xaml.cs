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

namespace Contact_manager {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 


	public partial class MainWindow : Window {

		private LoginWindow back_to_login; //MainWindow is the child window of LoginWindow

		public MainWindow(ImageSource pic, LoginWindow loginW) {
			InitializeComponent();
			if(pic!=null)
				ImageBox.Source=pic;
			user_window_label.Content="Welcome back, "+ App.usersd;
			back_to_login=loginW;
		}

		private void GoToEditProfileWindow_PreviewMouseDown(object sender, MouseButtonEventArgs e) {

		}

		private void GoToLoginWindow_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
			Close();
			back_to_login.Show();
		}
	}
}
