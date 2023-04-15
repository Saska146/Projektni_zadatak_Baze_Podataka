using Projektni_zadatak.ConnectionPool;
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
    public class SkokDAOImpl : ISkokDAO
    {
        public IEnumerable<Skok> Skokovi(string tip)
        {
            string query = "select * from skok where tipSa=:tipSa";
            List<Skok> skokovi = new List<Skok>();
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {

                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "tipSa", DbType.String);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "tipSa", tip);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skok skok = new Skok
                            {
                                IdSk = reader.GetString(0),  
                                IdSc = reader.GetInt32(1),
                                IdSa = reader.GetString(2),
                                BDuzina = reader.GetInt32(3),
                                BStil = reader.GetInt32(4),
                                BVetar = reader.GetInt32(5),
                            };
                            skokovi.Add(skok);
                        }
                    }
                }
            }
            return skokovi;
        }


        public int UkupanBrojSkokva(string tip)
        {
            throw new NotImplementedException();
        }
    }
}
