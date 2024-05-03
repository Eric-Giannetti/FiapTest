using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDtos
{
    public class RetornoDto<T>
    {
        public T Object { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsFailed { get; set; }
    }
}
