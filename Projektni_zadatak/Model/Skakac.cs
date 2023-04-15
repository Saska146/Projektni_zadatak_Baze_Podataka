using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.Model
{
    public class Skakac
    {
        public int IdSc { get; set; }
        public string ImeSc { get; set; }
        public string PrzSc { get; set; }
        public string IdD { get; set; }
        public int Titule { get; set; }
        public double PbSc { get; set; }

        public Skakac() { }

        public Skakac(int idSc, string imeSc, string przSc, string idD, int titule, double pbSc)
        {
            IdSc = idSc;
            ImeSc = imeSc;
            PrzSc = przSc;
            IdD = idD;
            Titule = titule;
            PbSc = pbSc;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-35} {2,-20} {3,-35} {4,-30} {5,-20}",
                IdSc, ImeSc, PrzSc, IdD, Titule, PbSc);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-35} {2,-20} {3,-35} {4,-30}, {5,-20}",
                "IDSC", "IMESC", "PREZSC", "ID_DRZAVE", "TITULE", "PBSC");
        }

        public override bool Equals(object obj)
        {
            var skakac = obj as Skakac;
            return skakac != null &&
                   IdSc == skakac.IdSc &&
                   ImeSc == skakac.ImeSc &&
                   PrzSc == skakac.PrzSc &&
                   IdD == skakac.IdD &&
                   Titule == skakac.Titule &&
                   PbSc == skakac.PbSc;
        }





    }
}
