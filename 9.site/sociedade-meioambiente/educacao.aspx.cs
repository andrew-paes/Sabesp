using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class social_Ambiental_Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
        body.Attributes.Add("class", "interna");
		this.segundaColunaDinamica1.DataBind();
    }
}