using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_API.Core
{
    public class BaseEntity
    {
        public List<string> Validations { get; set; }
        public bool IsValid => !Validations.Any();

        public BaseEntity()
        {
            Validations = new List<string>();
        }
    }
}
