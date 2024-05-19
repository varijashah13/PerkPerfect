using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace order_servicelibrary
{
    [ServiceContract]
    public interface Iorder
    {
        [OperationContract]
        void AddOrder(Order order);

        [OperationContract]

        void RemoveOrder(int oId);

    }
}
