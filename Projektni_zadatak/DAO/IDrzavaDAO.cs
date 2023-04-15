using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.DAO
{
    public interface IDrzavaDAO
    {
        bool ExistsById(string id);
    }
}
