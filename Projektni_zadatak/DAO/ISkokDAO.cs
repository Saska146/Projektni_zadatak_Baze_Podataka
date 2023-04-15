using Projektni_zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.DAO
{
    public interface ISkokDAO
    {
        IEnumerable<Skok> Skokovi(string tip);
        int UkupanBrojSkokva(string tip);

    }
}
