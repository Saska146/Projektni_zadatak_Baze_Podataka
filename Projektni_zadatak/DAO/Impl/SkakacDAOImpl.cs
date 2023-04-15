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
    public class SkakacDAOImpl : ISkakacDAO
    {
        public int Count()
        {
            string query = "select count(*) from skakac";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int Delete(Skakac entity)
        {
            return DeleteById(entity.IdSc);
        }

        public int DeleteAll()
        {
            string query = "delete from skakac";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteById(int id)
        {
            string query = "delete from theatre where id_sc=:id_sc";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id_th", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id_th", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(int id)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(int id, IDbConnection connection)
        {
            string query = "select * from theatre where id_sc=:id_sc";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "id_sc", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "id_sc", id);
                return command.ExecuteScalar() != null;
            }
        }


        public IEnumerable<Skakac> FindAll()
        {
            string query = "select id_sc, ime_sc, prz_sc, id_d, titule, pb_sc from skakac";
            List<Skakac> theatreList = new List<Skakac>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skakac skakac = new Skakac(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetFloat(5));
                            theatreList.Add(skakac);
                        }
                    }
                }
            }

            return theatreList;
        }

        public IEnumerable<Skakac> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select id_sc, ime_sc, prz_sc, id_d, titule, pb_sc from skakac where id_sc in (");
            foreach (int id in ids)
            {
                sb.Append(":id" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1); 
            sb.Append(")");

            List<Skakac> theatreList = new List<Skakac>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "id" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "id" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skakac skakac= new Skakac(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetFloat(5));
                            theatreList.Add(skakac);
                        }
                    }
                }
            }

            return theatreList;
        }

        public Skakac FindById(int id)
        {
            string query = "select id_sc, ime_sc, prz_sc, id_, titule, pb_sc " +
                       "from skakac where id_sc = :id_sc";
            Skakac skakac = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id_sc", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id_sc", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            skakac = new Skakac(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetFloat(5));
                        }
                    }
                }
            }
            return skakac;
        }


        public List<Skakac> GetSkakaceIzDrzave(int idD)
        {

            string query = "select idSc, imeSc, przSc, idD, Titule, pbSc from skakac natural join drzava where idD=:id";
            List<Skakac> skakaci = new List<Skakac>();
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idD", DbType.String);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idD", idD);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skakac skakac = new Skakac();
                            skakac.IdSc = reader.GetInt32(0);
                            skakac.ImeSc = reader.GetString(1);
                            skakac.PrzSc = reader.GetString(2);
                            skakac.IdD = reader.GetString(3);
                            skakac.Titule = reader.GetInt32(4);
                            skakac.PbSc = reader.GetFloat(5);
                        
                            skakaci.Add(skakac);
                        }
                    }
                }
            }
            return skakaci;

        }

        public int BrojTitulaSkakaca(Skakac item)
        {
            string query = "select count(*) from rezultat natural join staza where drzs=:drz and plasman = 1 and idv = :idv";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idSc", DbType.Int32);
                    ParameterUtil.AddParameter(command, "idD", DbType.String);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idSc", item.IdSc);
                    ParameterUtil.SetParameterValue(command, "idD", item.IdD);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int UkupanBrojTitula(string idD)
        {
            throw new NotImplementedException();
        }

        public int Save(Skakac entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        public int Save(Skakac skakac, IDbConnection connection)
        {
            string insertSql = "insert into skakac (ime_sc, prz_sc, id_d, titule, pb_sc, id_sc) " +
                "values (:ime_sc, :prz_sc, :id_d, :titule, :pb_sc, :id_sc)";
            string updateSql = "update skakac set ime_sc=:ime_sc, prz_sc=:prz_sc, " +
                "=id_d=:id_d, titule=:titule, pb_sc=:pb_sc where id_sc=:id_sc";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(skakac.IdSc, connection) ? updateSql : insertSql;
                ParameterUtil.AddParameter(command, "ime_sc", DbType.String, 50);
                ParameterUtil.AddParameter(command, "prz_sc", DbType.String, 50);
                ParameterUtil.AddParameter(command, "id_d", DbType.String, 50);
                ParameterUtil.AddParameter(command, "titule", DbType.Int32, 50);
                ParameterUtil.AddParameter(command, "pb_sc", DbType.Double); //double je stavljen da bi valsnik mogla da nastavi da radi dalje
                ParameterUtil.AddParameter(command, "id_sc", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "id_sc", skakac.IdSc);
                ParameterUtil.SetParameterValue(command, "prz_sc", skakac.ImeSc);
                ParameterUtil.SetParameterValue(command, "id_d", skakac.PrzSc);
                ParameterUtil.SetParameterValue(command, "titule", skakac.IdD);
                ParameterUtil.SetParameterValue(command, "pb_sc", skakac.Titule);
                ParameterUtil.SetParameterValue(command, "id_sc", skakac.PbSc);
                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<Skakac> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction(); 

                int numSaved = 0;

               
                foreach (Skakac entity in entities)
                {
                   
                    numSaved += Save(entity, connection);
                }

                
                transaction.Commit();

                return numSaved;
            }
        }

        public IEnumerable<Skok> PrikazivanjePoTipu(string tip)
        {
            string query = "select * from skok where idsa in (select idsa from skakaonica where tipsa = :tip)";
            List<Skok> skokovi = new List<Skok>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "tip", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "tip", tip);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skok skok = new Skok(reader.GetString(0), reader.GetInt32(1),
                                reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));
                            skokovi.Add(skok);
                        }
                    }
                }
            }

            return skokovi;
        }
    
    }
}
