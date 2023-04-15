using Projektni_zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.DTO
{
    public class SkakaciDrzava
    {
        public string IdD { get; set; }
        public List<Skakac> skakaci { get; set; }

        public int UkupanBrojTitula { get; set; }
      

    }
}
