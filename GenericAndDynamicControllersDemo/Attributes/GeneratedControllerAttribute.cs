using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace GenericAndDynamicControllersDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public string Route { get; set; }

        public GeneratedControllerAttribute(string route)
        {
            Route = route;
        }
    }
}
