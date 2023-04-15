using Projektni_zadatak.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.DAO
{
    public interface IComplexQueryDao
    {
        SkakaciDrzava SkakaciJedneDrzave(string idd);
        List<TipSkakaonice> SkokoviPoTipu();
    }
}
