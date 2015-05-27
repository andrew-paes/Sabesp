using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Enumerators;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;

public partial class fique_Default : BasePage
{
	#region [ Events ]

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadResources();
		this.BindDestaquesNoticia();
		this.BindDestaquesVideos();
		this.BindUltimasNoticias();
		this.BindPodcastsMaisRecentes();
		this.BindComunicados();
		segundaColunaDinamica1.DataBind();
	}

	#endregion

	#region [ Methods ]

	/// <summary>
	/// Load the resources based in current language
	/// </summary>
	protected void LoadResources()
	{
		hlTodasNoticias.NavigateUrl = String.Concat("Noticias-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
		hlTodasNoticias.Text = GetLocalResourceObject(hlTodasNoticias.ID).ToString();
		hlTodosVideos.NavigateUrl = String.Concat("tv-sabesp-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
		hlTodosVideos.Text = GetLocalResourceObject(hlTodosVideos.ID).ToString();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void BindDestaquesNoticia()
	{
		NoticiaService noticiaService = new NoticiaService();
		string[] dataExibicaoInicio = { "dataExibicaoInicio" };
		string[] orderBy = { "DESC" };

		List<Noticia> noticias = (List<Noticia>)noticiaService.RetornaTodosSite(5, dataExibicaoInicio, orderBy, new NoticiaFH() { DestaqueFiquePorDentro = "1" });

		if (noticias != null && noticias.Count > 0)
		{
			noticiaDestaqueGrande1.Noticia = noticias[0];
			noticiaDestaqueGrande1.DataBind();

			noticias.RemoveAt(0);
			noticiaDestaqueLista1.Noticias = noticias;
			noticiaDestaqueLista1.DataBind();
		}
		else
		{
			noticiaDestaqueGrande1.Visible = false;
			noticiaDestaqueLista1.Visible = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void BindUltimasNoticias()
	{
		NoticiaService noticiaService = new NoticiaService();
		List<Noticia> noticias = new List<Noticia>();
		noticias = (List<Noticia>)noticiaService.CarregarUltimasNoticias(6, new NoticiaFH() { DestaqueFiquePorDentro = "0" });

		noticiaUltimasNoticias.Noticias = noticias;
		noticiaUltimasNoticias.DataBind();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void BindDestaquesVideos()
	{
		VideoService videoService = new VideoService();
		string[] dataHoraPublicacao = { "dataHoraPublicacao" };
		string[] orderBy = { "DESC" };

		List<Video> videos = (List<Video>)videoService.RetornaTodosSite(0, dataHoraPublicacao, orderBy, new VideoFH() { DestaqueFiquePorDentro = "1" });

		if (videos != null && videos.Count > 0)
		{
			videoDestaqueGrande1.Video = videos[0];
			videoDestaqueGrande1.DataBind();

			videos.RemoveAt(0);
			videoDestaqueLista1.Videos = videos;
			videoDestaqueLista1.DataBind();
		}
		else
		{
			videoDestaqueGrande1.Visible = false;
			videoDestaqueLista1.Visible = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void BindPodcastsMaisRecentes()
	{
		//PodcastService podcastService = new PodcastService();
		//List<Podcast> podcasts = new List<Podcast>();
		//podcasts = (List<Podcast>)podcastService.CarregarMaisRecentes(3);

		//podcastMaisRecentes.Podcasts = podcasts;
		//podcastMaisRecentes.DataBind();

		PodcastService podcastService = new PodcastService();
		PodcastFH podcastFH = new PodcastFH();
		podcastFH.Ativo = "1";
		podcastFH.DestaqueHome = "1";
		int podcastTotal = 0;
		podcastTotal = podcastService.TotalRegistros(podcastFH);

		if (podcastTotal > 0)
		{
			podcastMaisRecentes.LoadPage();
		}
		else
		{
			podcastMaisRecentes.Visible = false;
		}
	}

	/// <summary>
	/// Get the data to bind the listview
	/// </summary>
	protected void BindComunicados()
	{
		ComunicadoService comunicadoService = new ComunicadoService();
		string[] dataExibicaoInicio = { "dataExibicaoInicio" };
		string[] orderBy = { "DESC" };

		List<Comunicado> comunicados = (List<Comunicado>)comunicadoService.RetornaTodosSite(2, 0, dataExibicaoInicio, orderBy, null);
		Comunicados.Comunicados = comunicados;
		Comunicados.DataBind();
	}

	#endregion
}