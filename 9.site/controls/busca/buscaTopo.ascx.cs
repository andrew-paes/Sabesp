using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_busca_buscaTopo : SmartUserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.LoadResources();
		}
	}

	protected void LoadResources()
	{
		ltrBusca.Text = Convert.ToString(GetLocalResourceObject(ltrBusca.ID));
		txtBusca.Text = Convert.ToString(GetLocalResourceObject(txtBusca.ID));
		txtBusca.ToolTip = Convert.ToString(GetLocalResourceObject(txtBusca.ID));
	}

	protected void btnBusca_Click(object sender, ImageClickEventArgs e)
	{
		if (!String.IsNullOrEmpty(txtBusca.Text) && !String.Compare(txtBusca.Text, Convert.ToString(GetLocalResourceObject(txtBusca.ID)), StringComparison.InvariantCultureIgnoreCase).Equals(0))
		{
			Session["TermoBuscado"] = txtBusca.Text;
			Response.Redirect(String.Concat("~/interna/resultado-busca.aspx", "?q=", txtBusca.Text));
		}
	}
}
