using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ag2.Manager.Module;
using Ag2.Manager.BusinessObject;
using Ag2.Manager.Helper;


public partial class content_manager : System.Web.UI.MasterPage
{
	MembershipUser user = null;

	protected void Page_Init(object sender, EventArgs e)
	{
		user = Membership.GetUser();

		CurrentSessions cs = new CurrentSessions();

		if (user == null || cs.Perfil == null || cs.Perfil.PerfilId == 0)
		{
			Response.Redirect("~/Default.aspx");
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//
		if (Request["ExibiMaster"] != null && !Request["ExibiMaster"].ToString().Equals(""))
		{
			hddExibiMaster.Value = Request["ExibiMaster"].ToString();
		}

		bool bolExibeMaster = hddExibiMaster.Value.ToUpper().Equals("TRUE");

		trLinha1.Visible = bolExibeMaster;
		tdCol1.Visible = bolExibeMaster;
		tdCol2.Visible = bolExibeMaster;

	}

	/// <summary>
	/// Efetua logout do manager
	/// </summary>
	protected void btnSair_Click(object sender, EventArgs e)
	{
		FormsAuthentication.SignOut();
		Session.Abandon();
		Response.Redirect("~/default.aspx");
	}
}
