using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace fooditems_servicelibrary
{
    [ServiceContract]
    public interface Ifooditemsservice
    {
        [OperationContract]
        DataSet GetFoodItems();

        [OperationContract]
        void AddFoodItem(FoodItem foodItem);

        [OperationContract]
        FoodItem GetFoodItem(string foodName);

        [OperationContract]

        void UpdateFoodItem(FoodItem foodItem);

        [OperationContract]

        void DeleteFoodItem(string foodName);


    }
}
