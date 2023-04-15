using Projektni_zadatak.DAO;
using Projektni_zadatak.DAO.Impl;
using Projektni_zadatak.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.Service
{
    public class ComplexQueryService
    {
        private static readonly IComplexQueryDao complexQueryDao = new ComplexQueryDaoImpl();
        private static readonly IDrzavaDAO drzaveDao = new DrzavaDAOImpl();
        private static readonly ISkakacDAO skakacDao = new SkakacDAOImpl();

        public SkakaciDrzava SkakaciJedneDrzave(string idd)
        {
            return complexQueryDao.SkakaciJedneDrzave(idd);
        }

        public List<TipSkakaonice> SkokoviPoTipu()
        {
            return complexQueryDao.SkokoviPoTipu();
        }
    }
}
