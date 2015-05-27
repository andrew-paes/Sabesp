using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Sabesp.Enumerators;

public partial class controls_rodape : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	protected void LoadPage()
	{
		hlFAQ.NavigateUrl = String.Concat("~/fale-conosco/faq.aspx?secaoId=", MenuPrincipal.PerguntasFrequentes.GetHashCode());
	}
}
