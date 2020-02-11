using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DzCLass
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
			String connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\klyos\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\Students.mdf";
			OleDbConnection con = new OleDbConnection(connectionString);
			List<String> Names = new List<String>();
			using (con)
			{
				con.Open();
				OleDbCommand cmd = new OleDbCommand("SELECT Name FROM Name", con);
				OleDbDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Names.Add(reader.GetString(0));
				}
			}

			foreach (String Name in Names)
				Console.WriteLine(Name);
		}
    }
}
