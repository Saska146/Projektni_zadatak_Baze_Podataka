using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.DAO
{
   public interface ICRUDDAO<S, ID>
	{
		int Count();

		int Delete(S entity);

		int DeleteAll();

		int DeleteById(ID id);

		bool ExistsById(ID id);

		IEnumerable<S> FindAll();

		IEnumerable<S> FindAllById(IEnumerable<ID> ids);

		S FindById(ID id);

		int Save(S entity);

		int SaveAll(IEnumerable<S> entities);

	}
}
