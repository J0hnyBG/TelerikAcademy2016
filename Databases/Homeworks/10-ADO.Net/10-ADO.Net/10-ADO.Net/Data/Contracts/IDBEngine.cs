using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_ADO.Net.Data.Contracts
{
    public interface IDBEngine
    {
        int ExecuteScalar();
    }
}
