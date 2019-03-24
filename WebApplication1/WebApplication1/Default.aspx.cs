using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        //IsPostBack proveruva dali ova e prv pat shto se renderira
        //stranicata ili pak e rezultat na client postback
        //Koga go pritiskame kopceto ovaa promenliva se menuva vo true
        //so shto koga ke ja reloadneme stranicata vremeto ne se menuva
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                lblVreme1.Text = DateTime.Now.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblVreme2.Text = DateTime.Now.ToString();
        }
    }
}