using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace chef_servicelibrary
{
    [DataContract]
    public class Chef
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int chefId { get; set; }


    }
}
