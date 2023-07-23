using SQL_Database_Generator.Repositories;
using System;

namespace SQL_Database_Generator.Models
{
    public class Database
    {
        public string TeamNumber { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Today;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        public int EmailSent { get; set; } = 0;
        public int Archived { get; set; } = 0;
        public string ContactEmail { get; set; }

        public string GetInfo() =>
            $"Poštovani," + Environment.NewLine + Environment.NewLine +
            $"Vaši podaci za bazu su sljedeći: " + Environment.NewLine +
            $"Server Type: Database Engine" + Environment.NewLine +
            $"Server Name: " + DbConnector.Server + Environment.NewLine +
            $"Authentication: SQL Server Authentication" + Environment.NewLine +
            $"Login: " + Username + Environment.NewLine +
            $"Password: " + Password + Environment.NewLine +
            $"Database: " + Name + Environment.NewLine + Environment.NewLine +
            $"Baza podataka je MS SQL. Preporučamo pristupanje preko klijentske aplikacije Microsoft SQL " +
            $"Management Studio v.18." + Environment.NewLine + Environment.NewLine + "Lijep pozdrav!";
    }
}
