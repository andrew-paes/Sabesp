using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;

public partial class _Default : BasePage
{
	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadResources();
		List<Noticia> noticiasDeDestaque = this.BindDestaquesNoticia();
		//this.BindUltimasNoticias(noticiasDeDestaque);
		this.BindUltimosReleasesHome();
		this.BindDestaquesVideos();
		this.BindPodcastsMaisRecentes();
        this.BindSolucoesAmbientais();
		segundaColunaDinamica1.DataBind();
	}

	#endregion

	#region Methods

	/// <summary>
	/// Load the resources based in current language
	/// </summary>
	protected void LoadResources()
	{
		HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
		body.Attributes.Add("class", "home");

		hlTodasNoticias.NavigateUrl = String.Concat("fique-por-dentro/Noticias-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
		hlTodasNoticias.Text = GetLocalResourceObject(hlTodasNoticias.ID).ToString();

		hlTodosVideos.NavigateUrl = String.Concat("fique-por-dentro/tv-sabesp-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
		hlTodosVideos.Text = GetLocalResourceObject(hlTodosVideos.ID).ToString();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	protected List<Noticia> BindDestaquesNoticia()
	{
		NoticiaService noticiaService = new NoticiaService();
		string[] dataExibicaoInicio = { "dataExibicaoInicio" };
		string[] orderBy = { "DESC" };

		List<Noticia> noticias = (List<Noticia>)noticiaService.RetornaTodosSite(5, dataExibicaoInicio, orderBy, new NoticiaFH() { DestaqueHome = "1" });

        List<Noticia> noticiasRetorno = new List<Noticia>();

	    foreach (var noticia in noticias)
	    {
	        noticiasRetorno.Add(noticia);
	    }

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

        return noticiasRetorno;
	}

	/*
	/// <summary>
	/// 
	/// </summary>
	/// <param name="noticiasJaExibidas"></param>
	protected void BindUltimasNoticias(List<Noticia> noticiasJaExibidas)
	{
		NoticiaService noticiaService = new NoticiaService();
		List<Noticia> noticias = new List<Noticia>();
		

        noticias = (List<Noticia>)noticiaService.CarregarUltimasNoticias(4, noticiasJaExibidas);

		noticiaUltimasNoticias.Noticias = noticias;
		noticiaUltimasNoticias.DataBind();
	}
	*/

	/// <summary>
	/// 
	/// </summary>
	/// <param name="noticiasJaExibidas"></param>
	protected void BindUltimosReleasesHome()
	{
		ReleaseService releaseService = new ReleaseService();
		string[] dataExibicaoInicio = { "dataHoraPublicacao" };
		string[] orderBy = { "DESC" };
		ReleaseFH releaseFH = new ReleaseFH();
		releaseFH.DestaqueHome = "1";
		releaseFH.IdiomaId = Util.CurrentIdiomaId.ToString();

		List<Release> releaseBOList = (List<Release>)releaseService.CarregarTodosSite(5, dataExibicaoInicio, orderBy, releaseFH);

		releaseUltimosReleasesHome.Releases = releaseBOList;
		releaseUltimosReleasesHome.DataBind();
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
	/// 
	/// </summary>
	protected void BindDestaquesVideos()
	{
		VideoService videoService = new VideoService();
		string[] dataHoraPublicacao = { "dataHoraPublicacao" };
		string[] orderBy = { "DESC" };

		List<Video> videos = (List<Video>)videoService.RetornaTodosSite(0, dataHoraPublicacao, orderBy, new VideoFH() { DestaqueHome = "1" });

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
    protected void BindSolucoesAmbientais()
    {
        SolucaoAmbientalIdiomaService solucaoService = new SolucaoAmbientalIdiomaService();
        destaqueProduto1.solucaoAmbiental = solucaoService.Carregar(new SolucaoAmbientalIdioma() { Idioma = Util.CurrentIdioma });
        destaqueProduto1.DataBind();
    }

	#endregion
}