using Projektni_zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.DAO
{
    public interface ISkakacDAO : ICRUDDAO<Skakac, int>
    {
        IEnumerable<Skok> PrikazivanjePoTipu(string tip);
    }
}
