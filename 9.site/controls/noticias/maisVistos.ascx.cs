using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.IO;
public partial class controls_noticias_maisVistos : SmartUserControl
{
	#region Properties

	/// <summary>
	/// DataSource of this control
	/// </summary>
	public List<Noticia> Noticias { get; set; }

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		var ltrMaisVistos = (Literal)this.FindControl("ltrMaisVistos");
		ltrMaisVistos.Text = Resources.Resource.ltrMaisVistos.ToString();

	}
	/// <summary>
	/// Bind the repeater control
	/// </summary>
	public override void DataBind()
	{
		base.DataBind();

		if (this.Noticias != null && this.Noticias.Count > 0)
		{
			rptMaisVistos.DataSource = this.Noticias;
			rptMaisVistos.DataBind();
			var li = (HtmlGenericControl)rptMaisVistos.Items[rptMaisVistos.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("class", "last");
			}
		}
		else
		{
			this.Visible = false;
		}
	}

	protected void rptMaisVistos_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var mImage1 = (Image)e.Item.FindControl("mImage1");
			var hlNoticia = (HyperLink)e.Item.FindControl("hlNoticia");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");
			var lblQtdVisualizacoes = (Label)e.Item.FindControl("lblQtdVisualizacoes");

			Noticia noticia = (Noticia)e.Item.DataItem;
			NoticiaIdiomaService noticiaIdiomaService = new NoticiaIdiomaService();
			NoticiaIdioma noticiaIdioma = noticiaIdiomaService.Carregar(new NoticiaIdioma() { Noticia = noticia, Idioma = Util.CurrentIdioma });
			if (noticiaIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();
				if (noticia.ArquivoThumbGrande != null && noticia.ArquivoThumbGrande.ArquivoId > 0)
				{
					noticia.ArquivoThumbGrande = arquivoService.Carregar(noticia.ArquivoThumbGrande);
				}
				if (noticia.ArquivoThumbGrande != null)
				{
					mImage1.ImageUrl = String.Concat("~/uploads/secao/", noticia.ArquivoThumbGrande.NomeArquivo);
				}
				else
				{
					mImage1.Attributes.Add("style", "display:none");
				}

				ConteudoHits conteudoHits = new ConteudoHits();
				ConteudoHitsService conteudoHitsService = new ConteudoHitsService();
				conteudoHits = conteudoHitsService.CarregarToSite(noticia.Conteudo.ConteudoId);

				lblQtdVisualizacoes.Text = conteudoHits.Hits.ToString() + Resources.Resource.lblQtdVisualizacoes.ToString();
				hlNoticia.NavigateUrl = String.Concat("~/fique-por-dentro/Noticias-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", noticia.Conteudo.ConteudoId);
				lblChamada.Text = noticiaIdioma.TituloNoticia;
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
