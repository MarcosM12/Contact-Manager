using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Media;

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
		public String add_user_to_DB(String first_name, String last_name,String username, String password, ImageSource pic) {
			try {
				
				var con = db.GetMySqlConnection;
				db.OpenMySqlConnection();
				var cmd = new MySqlCommand("add_user", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("first_name", first_name);
				cmd.Parameters.AddWithValue("last_name", last_name);
				cmd.Parameters.AddWithValue("user", username);
				cmd.Parameters.AddWithValue("pass", password);
				cmd.Parameters.AddWithValue("pic", pic);
				cmd.ExecuteNonQuery();
				return null;
			}
			catch(Exception e){
				return e.Message;
			}


		}
		
	}
}
