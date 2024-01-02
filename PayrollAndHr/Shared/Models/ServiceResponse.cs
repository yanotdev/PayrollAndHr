using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollAndHr.Shared.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;

        public string Message { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string UserRole { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
    }
}
