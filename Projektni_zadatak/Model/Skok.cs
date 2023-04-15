using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.Model
{
    public class Skok
    {
        public string IdSk { get; set; }
        public int IdSc { get; set; }
        public string IdSa { get; set; }
        public int BDuzina { get; set; }
        public int BStil { get; set; }
        public int BVetar { get; set; }

        public Skok() { }

        public Skok(string idSk, int idSc, string idSa, int bDuzina, int bStil, int bVetar)
        {
            IdSk = idSk;
            IdSc = idSc;
            IdSa = idSa;
            BDuzina = bDuzina;
            BStil = bStil;
            BVetar = bVetar;
        }

        public override string ToString()
        {
            return string.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}",
                IdSk, IdSc, IdSa, BDuzina, BStil, BVetar);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}",
                "IDSK", "IDSC", "IDSA", "BDUZINA", "BSTIL", "BVETAR");
        }

        public override bool Equals(object obj)
        {
            var skok = obj as Skok;
            return skok != null &&
                   IdSk == skok.IdSk &&
                   IdSc == skok.IdSc &&
                   IdSa == skok.IdSa &&
                   BDuzina == skok.BDuzina &&
                   BStil == skok.BStil &&
                   BVetar == skok.BVetar;
        }


    }
}
