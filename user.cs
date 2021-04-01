using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Media;

namespace Contact_manager {
	class user {

		public String add_user_to_DB(String first_name, String last_name,String username, String password, ImageSource pic) {
			try {
			
				Database db = new Database();
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
