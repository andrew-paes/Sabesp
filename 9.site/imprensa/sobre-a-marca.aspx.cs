using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;

public partial class sobre_a_marca : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
		body.Attributes.Add("class", "interna");
        this.LoadDescrSessao();
    }
    private void LoadDescrSessao()
    {
        Secao entidadeSecao = new Secao();
        entidadeSecao.SecaoId = SecaoId;
        entidadeSecao = new SecaoService().Carregar(entidadeSecao);

        SecaoIdioma entidadeSecaoIdioma = new SecaoIdioma();
        entidadeSecaoIdioma.Secao = new Secao();
        entidadeSecaoIdioma.Secao = entidadeSecao;
        entidadeSecaoIdioma.Idioma = new Idioma();
        entidadeSecaoIdioma.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId; ;
        entidadeSecaoIdioma = new SecaoIdiomaService().Carregar(entidadeSecaoIdioma);
        this.ltrTitulo.Text = entidadeSecaoIdioma.Titulo;
        this.ltrDescricao.Text = entidadeSecaoIdioma.Texto.ReplaceHtml(); 
    }
}