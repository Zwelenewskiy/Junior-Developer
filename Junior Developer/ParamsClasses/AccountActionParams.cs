using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior_Developer
{
    public class AccountActionParams
    {
        public Structs.UserAction action { get; set; }
        public DateTime date { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string patronymic { get; set; }
        public double sum { get; set; }
        public  int id { get; set; }

        public AccountActionParams()
        {
            id = -1;
        }
    }
}
