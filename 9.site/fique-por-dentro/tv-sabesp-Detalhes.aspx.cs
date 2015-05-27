using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.Enumerators;
using System.Text;

public partial class fique_por_dentro_tv_sabesp_Detalhes : BasePage
{
	#region Events

	/// <summary>
	/// Page Load Event
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		// If no id redirect to list page
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
		//Get "video" by id
		VideoService videoService = new VideoService();
		Video video = videoService.CarregarToSite(RegistroId);

		// if exist "video" set details else redirect to list page
		if (video != null)
		{
			// Check "idioma"            
			VideoIdiomaService videoIdiomaService = new VideoIdiomaService();
			// if no "idioma" redirect to list page
			VideoIdioma videoIdioma = videoIdiomaService.Carregar(new VideoIdioma() { Video = video, Idioma = Util.CurrentIdioma });
			if (videoIdioma != null)
			{
				//TODO verify if will be here
				//this.AddHits(this.RegistroId);

				this.BindVideo(videoIdioma.TituloVideo, videoIdioma.DescricaoVideo, video.UrlYoutube, video.DataHoraPublicacao, video.Autor);

				this.BindTags(video.Conteudo.ConteudoId, Assuntos.Video);
				this.BindMaisVistos();
				conteudoRelacionado1.ContentDataBind(this.RegistroId);
				boxZebrado.DataBind(Assuntos.Video);

				string strScript = "$(document).ready(function() {" +
												"try {" +
												"var pageTracker = _gat._getTracker('UA-17790992-1');" +
												"pageTracker._setDomainName('none');" +
												"pageTracker._setAllowLinker(true);" +
												"pageTracker._trackPageview('/Fique_por_Dentro/TV_Sabesp/Clicou_em_Video/" + HttpUtility.UrlEncode(videoIdioma.TituloVideo, Encoding.GetEncoding(28597)).Replace("+", "_") + "');" +
												"} catch (err) { }" +
											"});";

				//strScript = "$(document).ready(function() {" +
				//                                        "alert('Buuu')" +
				//                                    "});";

				Page.ClientScript.RegisterStartupScript(GetType(), "scrSetGoogleAnalytics", strScript, true);
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
	/// Redirect to list of videos
	/// </summary>
	protected void RedirectToList()
	{
		Response.Redirect("tv-sabesp-Default.aspx");
	}

	/// <summary>
	/// Bind the information about "Video"
	/// </summary>
	/// <param name="titulo"></param>
	/// <param name="urlVideo"></param>
	/// <param name="data"></param>
	protected void BindVideo(string titulo, string descricao, string urlVideo, DateTime data, string autor)
	{
		ltrTitulo.Text = titulo;
		lblAutor.Text = autor;
		ltrVideo.Text = RedesSociais.YouTube.BuildYoutubeHtmlString(600, 337, urlVideo, RegistroId);
		ltrDescricao.Text = descricao.ReplaceHtml();
		lblData.Text = String.Concat(data.ToString(Util.MaskDate), " às ", data.ToString("HH:mm"));
		conteudoAvaliacao.SetAll(titulo, Request.Url.AbsoluteUri);
		conteudoAvaliacao.UrlRSS = "http://gdata.youtube.com/feeds/base/users/saneamentosabesp/uploads";
	}

	/// <summary>
	/// Bind "video" tag list
	/// </summary>
	/// <param name="conteudoId"></param>
	protected void BindTags(int conteudoId, Assuntos assunto)
	{
		this.tags1.ConteudoId = conteudoId;
		this.tags1.currentAssunto = assunto;
		this.tags1.DataBind();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void BindMaisVistos()
	{
		VideoService videoService = new VideoService();
		List<Video> videos = new List<Video>();
		videos = (List<Video>)videoService.CarregarMaisVistos(3);
		videoMaisVistos.Videos = videos;
		videoMaisVistos.DataBind();
	}

	#endregion
}
