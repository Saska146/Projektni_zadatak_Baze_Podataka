using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.DTO
{
    public class TipSkakaonice
    {
        public string TipSk { get; set; }
        public int BrojSkokva { get; set; }
        public int RazlicitiSkakaci { get; set; }

        public TipSkakaonice() { }
        public TipSkakaonice(string tipSk, int brojSkokva, int razlicitiSkakaci)
        {
            TipSk = tipSk;
            BrojSkokva = brojSkokva;
            RazlicitiSkakaci = razlicitiSkakaci;
        }

 
    }
}
