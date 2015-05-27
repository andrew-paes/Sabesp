using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_noticias_ultimasNoticias : SmartUserControl
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
			rptNoticias.DataSource = this.Noticias;
			rptNoticias.DataBind();
			var li = (HtmlGenericControl)rptNoticias.Items[rptNoticias.Items.Count - 1].FindControl("li");
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

	protected void rptNoticias_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hlNoticia = (HyperLink)e.Item.FindControl("hlNoticia");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");

			Noticia noticia = (Noticia)e.Item.DataItem;
			NoticiaIdiomaService noticiaIdiomaService = new NoticiaIdiomaService();
			NoticiaIdioma noticiaIdioma = noticiaIdiomaService.Carregar(new NoticiaIdioma() { Noticia = noticia, Idioma = Util.CurrentIdioma });
			if (noticiaIdioma != null)
			{
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
