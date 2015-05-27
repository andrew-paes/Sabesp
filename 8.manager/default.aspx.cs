using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ag2.Manager.BusinessObject;
using System.Reflection;

public partial class _default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		//MembershipCreateStatus status = new MembershipCreateStatus();
		//Membership.CreateUser("sistemas", "sistemas", "calleya@terra.com", "sempre", "teste", true, out status);

		//Membership.DeleteUser("sistemas");

		//Roles.CreateRole("Administrador");
		//Roles.AddUserToRole("sistemas", "Administrador");
		//string[] teste = Roles.GetAllRoles();

		//ProfileManager.DeleteProfile("sistemas");

		//ProfileCommon pc = (ProfileCommon)ProfileBase.Create("sistemas", true);
		//pc.Endereco.Cep = "teste calleya";
		//pc.Save();

		FormsAuthentication.SignOut();
		ltrBuild.Text = string.Concat(" - Versão ", Ag2.Manager.Helper.ConfigurationManager.Build);
	}

	protected void sendLogin_Click(object sender, ImageClickEventArgs e)
	{
		string userName = managerLogin.UserName.ToString();
		string userPassword = managerLogin.Password.ToString();

		User user = new User();
		UserStatus userStatus = user.Validate(userName, userPassword);

		if (userStatus != UserStatus.Valid)
		{
			Label FailureText = (Label)managerLogin.FindControl("FailureText");
			FailureText.Text = "Usuário ou senha incorretos";
		}
	}
}
