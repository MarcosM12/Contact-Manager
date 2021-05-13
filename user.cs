using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace Contact_manager {
	class User {

		private Database db = new Database();

		//Verify if alredy exists a registration with username in the database
		public bool is_registered(String username) {
			try {
				var con = db.GetMySqlConnection;
				db.OpenMySqlConnection();
				var cmd = new MySqlCommand("is_registered", con);
				cmd.CommandType=System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("user", username);

				//Use MySqlDataReader to read the SELECT statement result
				MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (reader.Read()) {
					if ((int)reader.GetValue(0)==1) {  //If SELECT statement return 1 then username exists in the database
						db.CloseMySqlConnection();
						return true;
					}
					else {
						db.CloseMySqlConnection();
						return false;
					}
				}
				//Error on ExecuteReader
				db.CloseMySqlConnection();
				return false;
			}
			catch(Exception e){
				db.CloseMySqlConnection();
				Console.WriteLine(e.Message);
				return false;
			}
		}
		
		//Add a user to the database
		public String add_user_to_DB(String first_name, String last_name,String username, String password, String pic_path) {
			try {
				
				var con = db.GetMySqlConnection;
				db.OpenMySqlConnection();
				var cmd = new MySqlCommand("add_user", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("first_name", first_name);
				cmd.Parameters.AddWithValue("last_name", last_name);
				cmd.Parameters.AddWithValue("user", username);
				cmd.Parameters.AddWithValue("pass", password);
				cmd.Parameters.AddWithValue("pic", pic_path);
				cmd.ExecuteNonQuery();
				return null;
			}
			catch(Exception e){
				return e.Message;
			}
		}

		//Get user's password from the contact manager database
		public String get_password(String username) {
			try {
				
				var con = db.GetMySqlConnection;
				db.OpenMySqlConnection();
				var cmd = new MySqlCommand("get_password", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("user", username);
				//Use MySqlDataReader to read the SELECT statement result
				MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (reader.Read()) {
					String user_pass = (String)reader.GetValue(0);
					db.CloseMySqlConnection();
					return user_pass;	
				}
				else {
					db.CloseMySqlConnection();
					return null;
				}
				
			}
			catch(Exception e){
				return e.Message;
			}
		}

		//Get user's picture from the contact manager database
		public ImageSource get_picture(String username) {
			try {
				
				var con = db.GetMySqlConnection;
				db.OpenMySqlConnection();
				var cmd = new MySqlCommand("get_picture", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("user_name", username);
				//Use MySqlDataReader to read the SELECT statement result
				MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (reader.Read()) {

					String user_pic_path = (String)reader.GetValue(0);
					BitmapImage bitmap = new BitmapImage(); 
					bitmap.BeginInit();
					bitmap.UriSource=new Uri(user_pic_path);
					bitmap.EndInit(); 

					ImageSource imgSrc = bitmap;
					db.CloseMySqlConnection();
					return imgSrc;	
				}
				else {
					db.CloseMySqlConnection();
					return null;
				}
				
			}
			catch(Exception e){
				return null;
			}
		}
	}
}
