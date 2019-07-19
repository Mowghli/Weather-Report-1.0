using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GeoCodeService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "GeoCoder?address={address}")]             
        string[] GeoCoder(string address);      // method to determine the zipcode and coordinates of given location
    }


    
}
