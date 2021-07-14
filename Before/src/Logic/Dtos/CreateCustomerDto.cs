using Logic.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dtos
{
    public class CreateCustomerDto
    {
        public /*CustomerName*/string  Name { get; set; }
        public /*Email*/ string Email{ get; set; }
    }
}
