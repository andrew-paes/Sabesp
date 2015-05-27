using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_bancoAudio_maisRecente : SmartUserControl
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
			var hlTodosPodcasts = (HyperLink)this.FindControl("hlTodosPodcasts");
			hlTodosPodcasts.NavigateUrl = String.Concat("~/fique-por-dentro/banco-de-audio-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
			hlTodosPodcasts.Text = Resources.Resource.hlTodosPodcasts.ToString();

			var hlPodcastDestaque = (HyperLink)this.FindControl("hlPodcastDestaque");
			var ltrMaisRecentes = (Literal)this.FindControl("ltrMaisRecentes");

			ltrMaisRecentes.Text = Resources.Resource.ltrMaisRecentes.ToString();

			Podcast podcast = (Podcast)Podcasts[0];
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
			PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });

			if (podcastIdioma != null)
			{
				hlPodcastDestaque.NavigateUrl = String.Concat("~/fique-por-dentro/banco-de-audio-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				hlPodcastDestaque.Text = podcastIdioma.TituloPodcast.ReplaceHtml();
			}
			Podcasts.RemoveAt(0);
		}
		else
		{
			this.Visible = false;
		}

		if (this.Podcasts != null && this.Podcasts.Count > 0)
		{
			rptPodcasts.DataSource = this.Podcasts;
			rptPodcasts.DataBind();
			var li = (HtmlGenericControl)rptPodcasts.Items[rptPodcasts.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("class", "last");
			}
		}
	}

	protected void rptPodcasts_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hlPodcast = (HyperLink)e.Item.FindControl("hlPodcast");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");
			var lblDescricao = (Label)e.Item.FindControl("lblDescricao");

			Podcast podcast = (Podcast)e.Item.DataItem;
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
			PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });
			if (podcastIdioma != null)
			{
				hlPodcast.NavigateUrl = String.Concat("~/fique-por-dentro/banco-de-audio-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				ltrTitulo.Text = podcastIdioma.TituloPodcast.ReplaceHtml();
				//recorta para resumir o texto
				lblDescricao.Text = podcastIdioma.DescricaoPodcast.GenerateResume(85);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
