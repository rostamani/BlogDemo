using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Application.Contracts.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
    }
}
