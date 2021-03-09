using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Contact_manager {
	class Database {
		
		//MySQL connvection
        private MySqlConnection conn = new MySqlConnection("datasource=localhost;user=root;database=contactmanager_database;port=3306;password=1234");
		
		public MySqlConnection GetMySqlConnection {
			get { return conn; }

		}

		public void OpenMySqlConnection() {
			if (conn.State==System.Data.ConnectionState.Closed) {

				conn.Open();
			}

		}

	}
}
