using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fooditems_servicelibrary
{
    [DataContract]
    public class FoodItem
    {
        [DataMember]
        public string foodName { get; set; }

        [DataMember]

        public string price { get; set; }
    }
}
