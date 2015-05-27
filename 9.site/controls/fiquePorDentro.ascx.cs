using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Interfaces;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;

public partial class fiquePorDentro : SmartUserControl
{
	#region Properties

	public int RegiaoId { get; set; }
	private int RepeatersVisible { get; set; }

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public override void DataBind()
	{
		base.DataBind();

		this.BindNoticias();
		this.BindComunicados();
		this.BindPodcasts();
		this.BindTvSabesp();
		this.BindEventos();
	}

	protected void rptNoticias_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var ltrData = (Literal)e.Item.FindControl("ltrData");
			var hlConteudo = (HyperLink)e.Item.FindControl("hlConteudo");

			Noticia noticia = (Noticia)e.Item.DataItem;

			NoticiaIdiomaService noticiaIdiomaService = new NoticiaIdiomaService();
			NoticiaIdioma noticiaIdioma = noticiaIdiomaService.Carregar(new NoticiaIdioma() { Noticia = noticia, Idioma = Util.CurrentIdioma });

			if (noticiaIdioma != null)
			{
				ltrData.Text = noticia.DataHoraPublicacao.Value.ToString("MM/yyyy");
				hlConteudo.Text = noticiaIdioma.TituloNoticia;
				hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/noticias-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", noticia.Conteudo.ConteudoId);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	protected void rptComunicados_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var ltrData = (Literal)e.Item.FindControl("ltrData");
			var hlConteudo = (HyperLink)e.Item.FindControl("hlConteudo");

			Comunicado comunicado = (Comunicado)e.Item.DataItem;

			ComunicadoIdiomaService comunicadoIdiomaService = new ComunicadoIdiomaService();
			ComunicadoIdioma comunicadoIdioma = comunicadoIdiomaService.Carregar(new ComunicadoIdioma() { Comunicado = comunicado, Idioma = Util.CurrentIdioma });

			if (comunicadoIdioma != null)
			{
				ltrData.Text = comunicado.DataHoraPublicacao.ToString("MM/yyyy");
				hlConteudo.Text = comunicadoIdioma.TituloComunicado;
				hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/comunicados-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", comunicado.Conteudo.ConteudoId);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	protected void rptPodcast_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var ltrData = (Literal)e.Item.FindControl("ltrData");
			var hlConteudo = (HyperLink)e.Item.FindControl("hlConteudo");

			Podcast podcast = (Podcast)e.Item.DataItem;

			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
			PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });

			if (podcastIdioma != null)
			{
				ltrData.Text = podcast.DataHoraPublicacao.ToString("MM/yyyy");
				hlConteudo.Text = podcastIdioma.TituloPodcast;
				hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	protected void rptTvSabesp_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var ltrData = (Literal)e.Item.FindControl("ltrData");
			var hlConteudo = (HyperLink)e.Item.FindControl("hlConteudo");

			Video video = (Video)e.Item.DataItem;

			VideoIdiomaService videoIdiomaService = new VideoIdiomaService();
			VideoIdioma videoIdioma = videoIdiomaService.Carregar(new VideoIdioma() { Video = video, Idioma = Util.CurrentIdioma });

			if (videoIdioma != null)
			{
				ltrData.Text = video.DataHoraPublicacao.ToString("MM/yyyy");
				hlConteudo.Text = videoIdioma.TituloVideo;
				hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/tv-sabesp-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", video.Conteudo.ConteudoId);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	protected void rptEventos_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var ltrData = (Literal)e.Item.FindControl("ltrData");
			var hlConteudo = (HyperLink)e.Item.FindControl("hlConteudo");

			Evento evento = (Evento)e.Item.DataItem;

			EventoIdiomaService eventoIdiomaService = new EventoIdiomaService();
			EventoIdioma eventoIdioma = eventoIdiomaService.Carregar(new EventoIdioma() { Evento = evento, Idioma = Util.CurrentIdioma });

			if (eventoIdioma != null)
			{
				ltrData.Text = evento.DataHoraPublicacao.Value.ToString("MM/yyyy");
				hlConteudo.Text = eventoIdioma.NomeEvento;
				hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/eventos-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", evento.Conteudo.ConteudoId);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion

	#region Methods

	private List<Noticia> GetNoticias()
	{
		NoticiaService noticiaService = new NoticiaService();
		List<Noticia> noticias = noticiaService.CarregarPorRegiao(4, this.RegiaoId);

		return noticias;
	}

	private List<Comunicado> GetComunicados()
	{
		ComunicadoService comunicadoService = new ComunicadoService();
		List<Comunicado> comunicados = comunicadoService.CarregarPorRegiao(4, this.RegiaoId);

		return comunicados;
	}

	private List<Video> GetTvSabesp()
	{
		VideoService videoService = new VideoService();
		List<Video> videos = videoService.CarregarPorRegiao(4, this.RegiaoId);

		return videos;
	}

	private List<Podcast> GetPodcasts()
	{
		PodcastService podcastService = new PodcastService();
		List<Podcast> podcasts = podcastService.CarregarPorRegiao(4, this.RegiaoId);

		return podcasts;
	}

	private List<Evento> GetEventos()
	{
		EventoService eventoService = new EventoService();
		List<Evento> eventos = eventoService.CarregarPorRegiao(4, this.RegiaoId);

		return eventos;
	}

	private void BindNoticias()
	{
		rptNoticias.DataSource = this.GetNoticias();
		rptNoticias.DataBind();

		liNoticias.Visible = this.HasVisibleItems(rptNoticias);
		this.RepeatersVisible += rptNoticias.Visible ? 1 : 0;

		if (this.RepeatersVisible % 2 == 0)
		{
			liNoticias.Attributes.Add("class", "alt");
		}
	}

	private void BindComunicados()
	{
		rptComunicados.DataSource = this.GetComunicados();
		rptComunicados.DataBind();

		liComunicados.Visible = this.HasVisibleItems(rptComunicados);
		this.RepeatersVisible += liComunicados.Visible ? 1 : 0;

		if (this.RepeatersVisible % 2 == 0)
		{
			liComunicados.Attributes.Add("class", "alt");
		}
	}

	private void BindTvSabesp()
	{
		rptTvSabesp.DataSource = this.GetTvSabesp();
		rptTvSabesp.DataBind();

		liTvSabesp.Visible = this.HasVisibleItems(rptTvSabesp);
		this.RepeatersVisible += rptTvSabesp.Visible ? 1 : 0;

		if (this.RepeatersVisible % 2 == 0)
		{
			liTvSabesp.Attributes.Add("class", "alt");
		}
	}

	private void BindPodcasts()
	{
		rptPodcast.DataSource = this.GetPodcasts();
		rptPodcast.DataBind();

		liPodcasts.Visible = this.HasVisibleItems(rptPodcast);
		this.RepeatersVisible += rptPodcast.Visible ? 1 : 0;

		if (this.RepeatersVisible % 2 == 0)
		{
			liPodcasts.Attributes.Add("class", "alt");
		}
	}

	private void BindEventos()
	{
		rptEventos.DataSource = this.GetEventos();
		rptEventos.DataBind();

		liEventos.Visible = this.HasVisibleItems(rptEventos);
		this.RepeatersVisible += rptEventos.Visible ? 1 : 0;

		if (this.RepeatersVisible % 2 == 0)
		{
			liEventos.Attributes.Add("class", "alt");
		}
	}

	/// <summary>
	/// Check if the repeater has visible items
	/// </summary>
	/// <param name="rpt"></param>
	/// <returns></returns>
	private bool HasVisibleItems(Repeater rpt)
	{
		bool hasVisibleItens = false;
		if (rpt != null)
		{
			foreach (RepeaterItem rptItem in rpt.Items)
			{
				if (rptItem.Visible && (rptItem.ItemType == ListItemType.Item || rptItem.ItemType == ListItemType.AlternatingItem))
				{
					hasVisibleItens = true;
					break;
				}
			}
		}

		return hasVisibleItens;
	}

	#endregion
}
