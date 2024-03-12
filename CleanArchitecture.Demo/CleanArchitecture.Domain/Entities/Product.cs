using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Color { get; set; }
    }
}
