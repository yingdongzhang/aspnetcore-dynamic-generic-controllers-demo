using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericAndDynamicControllersDemo.Attributes;

namespace GenericAndDynamicControllersDemo.Models
{
    [GeneratedController("api/book")]
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
