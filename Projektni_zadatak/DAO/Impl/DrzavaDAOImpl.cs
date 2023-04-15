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
    public class DrzavaDAOImpl : IDrzavaDAO
    {
        public bool ExistsById(string id)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        public bool ExistsById(string id, IDbConnection connection)
        {
            string query = "select * from drzava where idd=:idd";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "idd", DbType.String);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idd", id);
                return command.ExecuteScalar() != null;
            }
        }
    }

       
    
}
