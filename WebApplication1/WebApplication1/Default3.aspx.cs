using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "onblur", "<script>document.getElementById('txtPoraka').onblur = function(){ document.getElementById(\"btnPrvaStrana\").disabled = false;}</script>", false);
        }

        protected void btnProveri_Click(object sender, EventArgs e)
        {
            if(txtLozinka.Text.Equals("asd"/*"мрежно програмирање"*/))
            {
                txtPoraka.ReadOnly = false;
                txtPoraka.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "alertMessage", "alert('Wrong Password')", true);
            }
        }

        protected void btnPrvaStrana_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}