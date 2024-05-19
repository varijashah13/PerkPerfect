using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace customer_servicelibrary
{

    [ServiceContract]
    public interface Icustomerservice
    {
        [OperationContract]
        DataSet GetCustomerIds();

        [OperationContract]
        void AddCustomer(Customer customer);

        [OperationContract]

        Customer GetCustomer(int cId);
    }
}
