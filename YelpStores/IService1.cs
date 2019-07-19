using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace YelpStores
{
    
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string YelpStoreFinder(string PlaceName, string location);  // method that provides the location details of nearest store
    }


    
}
