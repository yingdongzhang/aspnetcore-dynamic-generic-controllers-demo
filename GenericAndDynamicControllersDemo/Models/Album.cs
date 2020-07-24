using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericAndDynamicControllersDemo.Attributes;

namespace GenericAndDynamicControllersDemo.Models
{
    [GeneratedController("api/v1/album")]
    public class Album
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
    }
}
