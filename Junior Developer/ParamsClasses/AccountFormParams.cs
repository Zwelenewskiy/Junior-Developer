using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior_Developer
{
    public class AccountFormParams
    {
        public Structs.Action action { get; set; }
        public int id { get; set; }
        public DataGridViewRow user_info { get; set; }

        public AccountFormParams()
        {
            id = -1;
        }
    }
}
