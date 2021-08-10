using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SalesDelivery
{
    public static class AppVariables
    {
        public static string DeviceName { get; set; }
        public static string UpdatedBy { get; set; }
        public static RoleType RoleName { get; set; }
        public static bool WithoutInternet { get; set; }        
        public static string DeviceIP { get; set; }
        public static string MacAddress { get; set; }

        public static List<WebRefSales.FGLineContract> FGLoadingLines { get; set; }

        public static readonly string VersionNumber = "Version 2.8.0.0";
        public static readonly string ProjectName = "SaleService";
        public static readonly string NetworkDown = "Network/WiFi is down. Please contact Network administrator.";
    }
}
