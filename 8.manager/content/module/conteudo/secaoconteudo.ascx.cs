using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common ;

using Ag2.Manager.ADO.MSSql;

public partial class content_module_secaoConteudo_secaoConteudo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaArvoreSecoes(0);
        }

    }

    private void CarregaArvoreSecoes(int perfil)
    {
        tvwSecoes.DataNodoId = "secaoId";
        tvwSecoes.DataNodoIdPai = "secaoIdPai";
        tvwSecoes.DataNodoTitulo = "titulo";

        secaoConteudo secoes = new secaoConteudo();

        tvwSecoes.DataSource = secoes.CarregaSecoes().Tables[0];
        tvwSecoes.DataBind();

    }

    

}
