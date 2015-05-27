using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class resultado_busca_negativo : BasePage
{
	#region Properties

	public string TermoBuscado
	{
		get
		{
			return Convert.ToString(ViewState["TermoBuscado"]);
		}
		set
		{
			ViewState["TermoBuscado"] = value;
		}
	}

	#endregion

    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			this.LoadPage();
			this.LoadProperties();
		}
    }

	protected void LoadPage()
	{
		HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
		body.Attributes.Add("class", "interna");
	}

	protected void LoadProperties()
	{
		//se contém um termo buscado (pelo topo)
		if (Session["TermoBuscado"] != null)
		{
			//armazena na viewstate
			this.TermoBuscado = Convert.ToString(Session["TermoBuscado"]);
			//limpa a sessão
			Session.Remove("TermoBuscado");
		}
		else if (Request.QueryString["search"] != null)
		{
			this.TermoBuscado = Convert.ToString(Request.QueryString["search"]);
		}
	}
}
