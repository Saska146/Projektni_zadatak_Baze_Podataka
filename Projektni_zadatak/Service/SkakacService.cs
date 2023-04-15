using Projektni_zadatak.DAO;
using Projektni_zadatak.DAO.Impl;
using Projektni_zadatak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.Service
{
    public class SkakacService
    {
        private static readonly ISkakacDAO skakaci = new SkakacDAOImpl();

        public int Count()
        {
            return skakaci.Count();
        }

        public void Delete(Skakac entity)
        {
            skakaci.Delete(entity);
        }

        public void DeleteAll()
        {
            skakaci.DeleteAll();
        }

        public void DeleteById(int id)
        {
            skakaci.DeleteById(id);
        }

        public bool ExistsById(int id)
        {
            return skakaci.ExistsById(id);
        }

        public IEnumerable<Skakac> FindAll()
        {
            return skakaci.FindAll();
        }

        public Skakac FindById(int id)
        {
            return skakaci.FindById(id);
        }
        public void Save(Skakac entity)
        {
            skakaci.Save(entity);
        }

        public void SaveAll(IEnumerable<Skakac> entities)
        {
            skakaci.SaveAll(entities);
        }

      
        public IEnumerable<Skok> PrikazivanjePoTipu(string tip)
        {
            return skakaci.PrikazivanjePoTipu(tip);
        }
    }
}

