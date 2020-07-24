using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GenericAndDynamicControllersDemo.Attributes;
using GenericAndDynamicControllersDemo.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace GenericAndDynamicControllersDemo.FeatureProviders
{
    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(GenericTypeControllerFeatureProvider).Assembly;

            // find types who are decorated with the GeneratedControllerAttribute
            var candidates = currentAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

            foreach (var candidate in candidates)
            {
                // add BaseController<> of candidate's type
                feature.Controllers.Add(typeof(BaseController<>).MakeGenericType(candidate).GetTypeInfo());
            }
        }
    }
}
