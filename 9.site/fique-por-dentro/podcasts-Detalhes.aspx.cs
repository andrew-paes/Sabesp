using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.Enumerators;
using System.Text;

public partial class podcasts_Detalhes : BasePage
{
	#region Properties

	/// <summary>
	/// 
	/// </summary>
	public string urlFlash { get; set; }

	#endregion

	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		/************************************************
		Remover a linha abaixo quando habilitar a nova página
		/************************************************/
		//Response.Redirect("http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=2&temp2=3&proj=AgenciaNoticias&pub=T&nome=podcast_teste&db=&nivel=&contini=0&pagina=1");


		if (RegistroId == 0)
		{
			this.RedirectToList();
		}
		else
		{
			this.LoadPage();
		}

		segundaColunaDinamica1.DataBind();
	}

	#endregion

	#region Methods

	/// <summary>
	/// Load the page
	/// </summary>
	protected void LoadPage()
	{
		PodcastService podcastService = new PodcastService();
		Podcast podcast = podcastService.CarregarToSite(RegistroId);

		if (podcast != null)
		{
			this.AddHits(RegistroId);
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
			PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });
			
			if (podcastIdioma != null)
			{
				PodcastCategoriaIdiomaService podcastCategoriaIdiomaService = new PodcastCategoriaIdiomaService();

				PodcastCategoriaIdioma entidadePodcastCategoriaIdioma = new PodcastCategoriaIdioma();
				entidadePodcastCategoriaIdioma.PodcastCategoria = new PodcastCategoria();
				entidadePodcastCategoriaIdioma.PodcastCategoria.PodcastCategoriaId = podcast.PodcastCategoria.PodcastCategoriaId;
				entidadePodcastCategoriaIdioma.Idioma = Util.CurrentIdioma;
				entidadePodcastCategoriaIdioma = podcastCategoriaIdiomaService.Carregar(entidadePodcastCategoriaIdioma);

				if (entidadePodcastCategoriaIdioma != null)
				{
					this.ltrPodcastCategoria.Text = entidadePodcastCategoriaIdioma.Descricao.ReplaceHtml();
				}
				else
				{
					this.ltrPodcastCategoria.Text = "Boletim Semanal";
				}

				this.BindPodcast(podcastIdioma.TituloPodcast, podcastIdioma.DescricaoPodcast, podcast.DataHoraPublicacao, podcast.Autor);
				this.BindTags(podcast.Conteudo.ConteudoId, Assuntos.Podcast);
				this.BindMaisVistos();
				conteudoRelacionado1.ContentDataBind(RegistroId);
				boxZebrado.DataBind(Assuntos.Podcast);

				string strScript = "$(document).ready(function() {" +
												"try {" +
												"var pageTracker = _gat._getTracker('UA-17790992-1');" +
												"pageTracker._setDomainName('none');" +
												"pageTracker._setAllowLinker(true);" +
												"pageTracker._trackPageview('/Fique_por_Dentro/Podcast/Visualizou_Podcast/" + HttpUtility.UrlEncode(podcastIdioma.TituloPodcast, Encoding.GetEncoding(28597)).Replace("+", "_") + "');" +
												"} catch (err) { }" +
											"});";

				Page.ClientScript.RegisterStartupScript(GetType(), "scrSetGoogleAnalytics", strScript, true);

				MontalUrlFlash(podcastIdioma);
			}
			else
			{
				this.RedirectToList();
			}
		}
		else
		{
			this.RedirectToList();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="podcastIdioma"></param>
	private void MontalUrlFlash(PodcastIdioma podcastIdioma)
	{
		string urlSiteMasterPage = Request.Url.ToString();
		string rawUrlSiteMasterPage = Convert.ToString(Request.RawUrl);
		string diretorioRaizSite = urlSiteMasterPage.Replace(rawUrlSiteMasterPage, "");

		Arquivo arquivoBO = new Arquivo();
		arquivoBO.ArquivoId = podcastIdioma.ArquivoPodcast.ArquivoId;
		arquivoBO = new ArquivoService().Carregar(arquivoBO);

		string urlMedia = ResolveUrl("~/Uploads/secao/" + arquivoBO.NomeArquivo);
		string urlMediaAbsoluth = String.Concat(diretorioRaizSite, urlMedia);

		urlFlash = String.Concat("../contents/swf/playerPODCAST.swf?podcastURL=", urlMediaAbsoluth);
	}

	/// <summary>
	/// Redirect to list of podcasts
	/// </summary>
	protected void RedirectToList()
	{
		Response.Redirect("podcasts-Default.aspx");
	}

	/// <summary>
	/// Bind the information about "Podcast"
	/// </summary>
	/// <param name="titulo"></param>
	/// <param name="podcast"></param>
	/// <param name="data"></param>
	protected void BindPodcast(string titulo, string podcast, DateTime data, string autor)
	{
		ltrTituloPodcast.Text = titulo;
		lblLocal.Text = autor;
		ltrPodcast.Text = podcast.ReplaceHtml();
		lblData.Text = String.Concat(data.ToString(Util.MaskDate), " às ", data.ToString("HH:mm"));
		conteudoAvaliacao.SetAll(titulo, Request.Url.AbsoluteUri);
		conteudoAvaliacao.UrlRSS = String.Concat("~/rss/rss-podcast.aspx?idioma=", Util.CurrentIdiomaId);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="conteudoId"></param>
	/// <param name="assunto"></param>
	protected void BindTags(int conteudoId, Assuntos assunto)
	{
		tags1.ConteudoId = conteudoId;
		tags1.currentAssunto = assunto;
		tags1.DataBind();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void BindMaisVistos()
	{
		PodcastService podcastService = new PodcastService();
		List<Podcast> podcasts = new List<Podcast>();
		podcasts = (List<Podcast>)podcastService.CarregarMaisVistos(3);
		podcastMaisVistos.Podcasts = podcasts;
		podcastMaisVistos.DataBind();
	}

	#endregion
}