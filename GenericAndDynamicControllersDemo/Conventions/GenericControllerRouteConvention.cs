using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GenericAndDynamicControllersDemo.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GenericAndDynamicControllersDemo.Conventions
{
    public class GenericControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                // find the generic type
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                // get the GeneratedControllerAttribute attribute
                var customNameAttribute = genericType.GetCustomAttribute<GeneratedControllerAttribute>();

                // check if Route is specified
                if (customNameAttribute?.Route != null)
                {
                    // apply inline attribute route [Route(...)]
                    controller.Selectors.Add(new SelectorModel
                    {
                        AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route))
                    });
                }
            }
        }
    }
}
