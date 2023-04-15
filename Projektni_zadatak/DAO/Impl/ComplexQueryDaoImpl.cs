using Projektni_zadatak.ConnectionPool;
using Projektni_zadatak.DTO;
using Projektni_zadatak.Model;
using Projektni_zadatak.Utilis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.DAO.Impl
{
    public class ComplexQueryDaoImpl : IComplexQueryDao
    {
        private static readonly IDrzavaDAO drzave = new DrzavaDAOImpl();
        public SkakaciDrzava SkakaciJedneDrzave(string idd)
        {
            if (!drzave.ExistsById(idd))
                throw new Exception("Drzava sa ID: " + idd + ", ne postoji.");

            SkakaciDrzava skakaciDrzava = new SkakaciDrzava();
            string query = "select idsc, imesc, przsc, idd, titule, pbsc from skakac where idd =:idd";
            List<Skakac> skakaci = new List<Skakac>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idd", DbType.String, 50);
                    ParameterUtil.SetParameterValue(command, "idd", idd);
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skakac skakac = new Skakac(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetDouble(5));
                            skakaci.Add(skakac);
                        }
                    }
                }
            }

            skakaciDrzava.IdD = idd;
            skakaciDrzava.skakaci = skakaci;
            skakaciDrzava.UkupanBrojTitula =skakaci.Sum(x => x.Titule);

            return skakaciDrzava;
        }

        public List<TipSkakaonice> SkokoviPoTipu()
        {
            
            List<TipSkakaonice> tipSkakaonices = new List<TipSkakaonice>();
            string query = "select skakaonica.tipsa, count(skok.idsk), count(skok.idsc) from skok " +
                            "inner join skakaonica on skok.idsa = skakaonica.idsa" +
                            " group by skakaonica.tipsa";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        { 

                      
                            TipSkakaonice item = new TipSkakaonice(reader.GetString(0), reader.GetInt32(1),
                                reader.GetInt32(2));
                            
                            tipSkakaonices.Add(item);
                        }
                    }
                }
            }

            return tipSkakaonices;
        }
    }
    
}
