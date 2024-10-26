using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gestor_Contraseñas.Models
{
    public class ExtraFields
    {
        public string extra1 { get; set; }
        public string extra2 { get; set; }
        public string extra3 { get; set; }
        public string extra4 { get; set; }
        public string extra5 { get; set; }

        public ExtraFields(string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            this.extra1 = extra1;
            this.extra2 = extra2;
            this.extra3 = extra3;
            this.extra4 = extra4;
            this.extra5 = extra5;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
