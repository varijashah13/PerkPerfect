using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace chef_servicelibrary
{
    [ServiceContract]
    public interface Ichefservice
    {
        [OperationContract]
        void AddChef(Chef chef);

        [OperationContract]
        DataSet GetChefs(int chefId);

        [OperationContract]
        Chef GetChef(int chefId);

        [OperationContract]
        void UpdateChef(Chef chef);

        [OperationContract]
        void DeleteChef(int chefId);

    }
}
