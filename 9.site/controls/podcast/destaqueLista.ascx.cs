using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_podcasts_destaqueLista : SmartUserControl
{
	#region Properties

	/// <summary>
	/// DataSource of this control
	/// </summary>
	public List<Podcast> Podcasts { get; set; }

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

		if (this.Podcasts != null && this.Podcasts.Count > 0)
		{
			rptDestaques.DataSource = this.Podcasts;
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
			var hlTitulo = (HyperLink)e.Item.FindControl("hlTitulo");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");

			Podcast podcast = (Podcast)e.Item.DataItem;
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
			PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });
			if (podcastIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();
				if (podcastIdioma.ArquivoPodcast != null && podcastIdioma.ArquivoPodcast.ArquivoId > 0)
					podcastIdioma.ArquivoPodcast = arquivoService.Carregar(podcastIdioma.ArquivoPodcast);

				hlTitulo.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				ltrTitulo.Text = podcastIdioma.TituloPodcast;
				//recorta para resumir o texto

				lblChamada.Text = podcastIdioma.DescricaoPodcast.GenerateResume(85);

			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
