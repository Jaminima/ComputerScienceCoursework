using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CourseworkProject.Backend.Data.DatabaseInteraction
{
    public class SQL
    {
        private OleDbConnection Conn;
        private OleDbCommand Command;
        private string DBase = "";
        public SQL(string DataBase)
        {
            DBase = DataBase;
            RestartConn();
        }

        private void RestartConn()
        {
            if (Conn != null) { if (Conn.State == System.Data.ConnectionState.Open) { Conn.Close(); } }
            Conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + DBase + ".accdb");
            Conn.Open();
        }

        List<String[]> ExecuteReader(OleDbCommand Command)
        {
            OleDbDataReader Results = Command.ExecuteReader();
            List<String[]> LResults = new List<string[]> { };
            while (Results.Read())
            {
                string[] Data = new string[Results.FieldCount];
                for (int i = 0; i < Results.FieldCount; i++) { Data[i] = Results.GetValue(i).ToString(); }
                LResults.Add(Data);
            }
            Results.Close();
            return LResults;
        }
        public List<String[]> ExecuteReader(string sCommand)
        {
            Command = new OleDbCommand(sCommand, Conn);
            return ExecuteReader(Command);
        }

        public bool Execute(string Command)
        {
            return Execute(new OleDbCommand(Command, Conn));
        }

        public bool Execute(OleDbCommand Command)
        {
            try { Command.ExecuteNonQuery(); /*RestartConn();*/ return true; } catch (Exception E) { Console.WriteLine(E.Message); return false; }
        }
    }
}
