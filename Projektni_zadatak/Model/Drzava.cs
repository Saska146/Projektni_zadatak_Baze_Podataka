using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.Model
{
    public class Drzava
    {

        public string IdD { get; set; }
        public string NazivD { get; set; }

        public Drzava() { }
        public Drzava(string idD, string nazivD)
        {
            IdD = idD;
            NazivD = nazivD;
        }

        public override string ToString()
        {
            return string.Format("{0,-35} {1, -35}",
                IdD, NazivD);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-35} {1, -35}",
               "IDD", "NAZIVD");
        }

        public override bool Equals(object obj)
        {
            var drzava = obj as Drzava;
            return drzava != null &&
                   IdD == drzava.IdD &&
                   NazivD == drzava.NazivD;
        }

    
    }
}
