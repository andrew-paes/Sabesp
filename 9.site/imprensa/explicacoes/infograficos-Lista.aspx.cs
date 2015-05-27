using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using Sabesp.Enumerators;


public partial class infograficos_Lista : BasePage
{
    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        this.BindInfograficos();

    }

    protected void rptInfograficos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            var imgDestaque = (Image)e.Item.FindControl("imgDestaque");
            var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");
            var hlInfografico = (HyperLink)e.Item.FindControl("hlInfografico");
            var lblDescricao = (Label)e.Item.FindControl("lblDescricao");
            var ltrAnimacao = (Literal)e.Item.FindControl("ltrAnimacao");
            ltrAnimacao.Text = Resources.Resource.ltrAnimacao.ToString();

            Infografico infografico = (Infografico)e.Item.DataItem;
            InfograficoIdiomaService infograficoIdiomaService = new InfograficoIdiomaService();
            InfograficoIdioma infograficoIdioma = infograficoIdiomaService.Carregar(new InfograficoIdioma() { Infografico = infografico, Idioma = Util.CurrentIdioma });
            if (infograficoIdioma != null)
            {
                ArquivoService arquivoService = new ArquivoService();

                if (infografico.ArquivoIdImagem != null && infografico.ArquivoIdImagem.ArquivoId > 0)
                {
                    infografico.ArquivoIdImagem = arquivoService.Carregar(infografico.ArquivoIdImagem);
                }
                if (infografico.ArquivoIdImagem != null)
                {
                    imgDestaque.ImageUrl = String.Concat("~/uploads/secao/", infografico.ArquivoIdImagem.NomeArquivo);
                }
                if (infograficoIdioma.ArquivoIdAnimacao != null && infograficoIdioma.ArquivoIdAnimacao.ArquivoId > 0)
                {
                    infograficoIdioma.ArquivoIdAnimacao = arquivoService.Carregar(infograficoIdioma.ArquivoIdAnimacao);
                }
                if (infograficoIdioma.ArquivoIdAnimacao != null)
                {
                    hlInfografico.NavigateUrl = String.Concat("~/contents/swf/", infograficoIdioma.ArquivoIdAnimacao.NomeArquivo, "?width=1200&amp;height=1000");
                }
                else
                {
                    hlInfografico.Attributes.Remove("rel");
                }
               
                //hlInfografico.NavigateUrl = String.Concat("~/imprensa/Infograficos-Detalhes.aspx?secaoId=", MenuPrincipal.Imprensa.GetHashCode(), "&id=", infografico.Conteudo.ConteudoId);
                ltrTitulo.Text = infograficoIdioma.Titulo;
                lblDescricao.Text = infograficoIdioma.Descricao.ReplaceHtml();

            }
            else
            {
                e.Item.Visible = false;
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get the data to bind the listview
    /// </summary>
    protected void BindInfograficos()
    {
        InfograficoService infograficoService = new InfograficoService();
        List<Infografico> infograficos = new List<Infografico>();

        infograficos = (List<Infografico>)infograficoService.RetornaTodosSite(0, null, null, null);

        rptInfograficos.DataSource = infograficos;
        rptInfograficos.DataBind();
		if (infograficos.Count > 0 && rptInfograficos.Items.Count > 0)
		{
			var li = (HtmlGenericControl)rptInfograficos.Items[rptInfograficos.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("class", "last");
			}
		}

    }
    #endregion
}