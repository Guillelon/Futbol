using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using Futbol.Models;
using System.Net;

namespace Futbol
{
    public class FutbolService : DataService<FutbolContext> 
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Equipoes", EntitySetRights.AllWrite | EntitySetRights.AllRead);
            //Set a reasonable paging site
            config.SetEntitySetPageSize("*", 25);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

        protected override FutbolContext CreateDataSource()
        {
            var context = base.CreateDataSource();
            var cred = new NetworkCredential("admin", "123456");
            context.Configuration.ProxyCreationEnabled = false;
            return context;
        }
    }
}
