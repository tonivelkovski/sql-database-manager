using System.Collections.Generic;

namespace SQL_Database_Generator.Models
{
    public class MailSettings
    {
        public string DefaultSender { get; set; } = "noreply_pi@foi.hr";
        public List<string> DefaultBccRecepients { get; set; } = new List<string> { "mmijac@foi.hr" };
        public string DefaultSubject { get; set; } = "Baza podataka za projekt iz Programskog inženjerstva";
    }
}
