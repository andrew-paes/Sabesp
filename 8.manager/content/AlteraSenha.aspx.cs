using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ag2.Manager.Helper;

public partial class content_AlteraSenha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
    {
        System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();

        string senhaDB = user.GetPassword();

        if (!senhaDB.Equals(txtSenhaAtual.Text))
        {
            Util.ShowMessage("Senha atual incorreta.");
            return;
        }

        user.ChangePassword(txtSenhaAtual.Text, txtNovaSenha.Text);
        Util.ShowMessage("Senha alterada com sucesso.");
    }

    protected void LimpaForm()
    {
        txtConfirmacaoSenha.Text = "";
        txtNovaSenha.Text = "";
        txtSenhaAtual.Text = "";
    }
}
