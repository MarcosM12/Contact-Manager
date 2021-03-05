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
	}
}
