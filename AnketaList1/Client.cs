using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketaList1
{
    class Client
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        
        public override string ToString()
        {
            return $"Surname: {surname}, Name: {name}, email: {email}, tel:{tel}";
        }
    }
}
