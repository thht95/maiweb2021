using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class DanhSachUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<User> lstUser = UserDB.GetAllUsers();
                lvUser.DataSource = lstUser;
                lvUser.DataBind();
            }
        }
    }
}