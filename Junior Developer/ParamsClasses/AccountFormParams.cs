using System;
using System.Windows.Forms;

namespace Junior_Developer
{
    public class AccountFormParams
    {
        public Structs.UserAction action { get; set; }
        public int id { get; set; }
        public DataGridViewRow user_info { get; set; }

        public AccountFormParams()
        {
            id = -1;
        }
    }
}
