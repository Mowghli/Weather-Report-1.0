using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DistCalcService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string[] DistanceCalculator(string source, string destination);     // method that will calculate distance and duration to reach destination location from source location.
    } 
}
