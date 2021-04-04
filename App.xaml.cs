using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace Contact_manager {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {

		private void Application_Startup(object sender, StartupEventArgs e) {
			
			// Create startup windows
			LoginWindow login = new LoginWindow();
			MainWindow main = new MainWindow();
			// Show the login window
			login.ShowDialog();
			if (login.DialogResult.HasValue || login.DialogResult.Value)
			{	//Show main window
				main.Show();
				
			}
			

		}	
	}

	
}
