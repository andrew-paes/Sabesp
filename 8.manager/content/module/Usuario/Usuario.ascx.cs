using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Ag2.Manager.Helper;
using Ag2.Manager.DAL;
using Ag2.Manager.BusinessObject;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

public partial class content_module_Usuario_Usuario : System.Web.UI.UserControl
{
    Database db = DatabaseFactory.CreateDatabase();
    private string _id = string.Empty;
    IPerfilDAL perfilado = (IPerfilDAL)Util.GetADO("PerfilADO", (System.Reflection.Assembly)System.Web.Compilation.BuildManager.CodeAssemblies[0]);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            _id = Request.QueryString["id"].ToString();

            if (!string.IsNullOrEmpty(_id))
                phSenha.Visible = false;
            else
                phSenha.Visible = true;
        }

        if (!IsPostBack)
        {
            PopulaPerfil();
            FormLoad();
        }
    }

    protected void FormLoad()
    {
        if (!string.IsNullOrEmpty(_id))
        {
            txtUsuario.Enabled = false;

            MembershipUser user = Membership.GetUser(new Guid(_id));

            Perfil perfil = perfilado.GetPerfilByUser(user);

            txtUsuario.Text = user.UserName;
            txtEmail.Text = user.Email;
            cmbPerfil.SelectedValue = perfil.PerfilId.ToString();
            chkBloqueado.Checked = !user.IsApproved;
        }
    }

    protected void PopulaPerfil()
    {
        cmbPerfil.DataSource = perfilado.GetAllPerfil();
        cmbPerfil.DataValueField = "perfilId";
        cmbPerfil.DataTextField = "name";
        cmbPerfil.DataBind();

        cmbPerfil.Items.Insert(0, new ListItem("Selecione...", ""));
    }

    protected void btnExecute_Click(object sender, EventArgs e)
    {
        MembershipUser user = null;
        Perfil perfil = new Perfil();

        if (!string.IsNullOrEmpty(_id))
        {
            user = Membership.GetUser(new Guid(_id));
            user.Email = txtEmail.Text;
            user.IsApproved = !chkBloqueado.Checked;

            try
            {
                Membership.UpdateUser(user);
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message);

                return;
            }

            perfilado.DeleteUserPerfil(user);
            
            perfil.PerfilId = Convert.ToInt32(cmbPerfil.SelectedValue);

            perfilado.InsertUserPerfil(user, perfil);

            Util.ShowUpdateMessage();
        }
        else
        {
            MembershipCreateStatus status = new MembershipCreateStatus();
            user = Membership.CreateUser(txtUsuario.Text, txtSenha.Text, txtEmail.Text, "senha", "senha", true, out status);

            if (status == MembershipCreateStatus.Success)
            {
                perfil.PerfilId = Convert.ToInt32(cmbPerfil.SelectedValue);
                perfilado.InsertUserPerfil(user, perfil);

                Util.ShowInsertMessage();
                LimpaForm();
            }
            else if (status == MembershipCreateStatus.InvalidPassword)
            {
                Util.ShowMessage(string.Format("A senha deve ter no mínimo {0}", Membership.Provider.MinRequiredPasswordLength.ToString()));
            }
            else if (status == MembershipCreateStatus.InvalidEmail)
            {
                Util.ShowMessage("E-mail inválido");
            }
            else if (status == MembershipCreateStatus.DuplicateEmail)
            {
                Util.ShowMessage("E-mail já existente na base de dados");
            }
            else if (status == MembershipCreateStatus.DuplicateUserName)
            {
                Util.ShowMessage("Usuário já existente na base de dados");
            }
        }

    }

    protected void LimpaForm()
    {
        txtEmail.Text = "";
        txtUsuario.Text = "";
        chkBloqueado.Checked = false;
    }

}
