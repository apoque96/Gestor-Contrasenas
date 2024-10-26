using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Gestor_Contraseñas.Models
{
    public class Account
    {
        public readonly Guid id = Guid.NewGuid();
        public string site_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string url { get; set; }
        public ExtraFields extra_fields { get; set; }
        public string notes { get; set; }
        public List<string> tags { get; set; }
        public string creation_date { get; set; }
        public string update_date { get; set; }
        public string icon { get; set; }

        public Account(
        string siteName,
        string username,
        string password,
        string url,
        ExtraFields extraFields,
        string notes,
        List<string> tags,
        string creation_date,
        string update_date,
        string icon)
        {
            this.site_name = siteName;
            this.username = username;
            this.password = password;
            this.url = url;
            this.extra_fields = extraFields;
            this.notes = notes;
            this.tags = tags ?? new List<string>();  // Assigns an empty list if null
            this.icon = icon;
            this.creation_date = creation_date;
            this.update_date = update_date;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
