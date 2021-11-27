using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ban_my_pham
{
    public class Role
    {
        public int id { get; set; }
        public string tenQuyen { get; set; }
        public Role()
        {
        }
        public Role(int id, string tenQuyen)
        {
            this.id = id;
            this.tenQuyen = tenQuyen;
        }
    }
}
