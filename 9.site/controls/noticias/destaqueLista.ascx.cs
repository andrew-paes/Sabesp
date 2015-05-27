using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class controls_noticias_destaqueLista : SmartUserControl
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

	}

	/// <summary>
	/// Bind the repeater control
	/// </summary>
	public override void DataBind()
	{
		base.DataBind();

		if (this.Noticias != null && this.Noticias.Count > 0)
		{
			rptDestaques.DataSource = this.Noticias;
			rptDestaques.DataBind();
			var li = (HtmlGenericControl)rptDestaques.Items[rptDestaques.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("style", "display:none");
			}

		}
		else
		{
			this.Visible = false;
		}
	}

	protected void rptDestaques_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var imgDestaque = (Image)e.Item.FindControl("imgDestaque");
			var hlTitulo = (HyperLink)e.Item.FindControl("hlTitulo");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");
			var divImg = (HtmlGenericControl)e.Item.FindControl("divImg");

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
					imgDestaque.ImageUrl = String.Concat("~/uploads/secao/", noticia.ArquivoThumbGrande.NomeArquivo);
				}
				else
				{
					divImg.Attributes.Add("style", "display:none");
				}
				hlTitulo.NavigateUrl = String.Concat("~/fique-por-dentro/Noticias-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", noticia.Conteudo.ConteudoId);
				ltrTitulo.Text = noticiaIdioma.TituloNoticia;
				lblChamada.Text = noticiaIdioma.ChamadaNoticia.GenerateResume(150);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
