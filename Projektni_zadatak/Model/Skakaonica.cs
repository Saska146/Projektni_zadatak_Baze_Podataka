using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.Model
{
   public class Skakaonica
    {
        public string IdSa { get; set; }
        public string NazivSa { get; set; }
        public int DuzinaSa { get; set; }
        public string TipSa { get; set; }
        public string IdD { get; set; }

        public Skakaonica() { } 

        public Skakaonica(string idSa, string nazivSa, int duzinaSa, string tipSa, string idD)
        {
            IdSa = idSa;
            NazivSa = nazivSa;
            DuzinaSa = duzinaSa;
            TipSa = tipSa;
            IdD = idD;
        }

      

        public override string ToString()
        {
            return string.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}",
                IdSa, NazivSa, DuzinaSa, TipSa, IdD);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}",
                "IDSA", "NAZIVSA", "DUZINASA", "TIPSA", "IDD");
        }

        public override bool Equals(object obj)
        {
            var skakaonica = obj as Skakaonica;
            return skakaonica != null &&
                   IdSa == skakaonica.IdSa &&
                   NazivSa == skakaonica.NazivSa &&
                   DuzinaSa == skakaonica.DuzinaSa &&
                   IdD == skakaonica.IdD &&
                   TipSa == skakaonica.TipSa;
                   
        }

   
    }
}
