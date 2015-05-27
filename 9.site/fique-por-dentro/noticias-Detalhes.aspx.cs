using System;
using System.Collections.Generic;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Text;
using System.Web;

public partial class noticias_Detalhes : BasePage, INoticiaDetalhe
{
	#region INoticiaDetalhe Members

	/// <summary>
	/// 
	/// </summary>
	public string NoticiaId { get; set; }

	/// <summary>
	/// 
	/// </summary>
	public string NoticiaName { get; set; }

	/// <summary>
	/// 
	/// </summary>
	public string NoticiaSecaoId { get; set; }

	/// <summary>
	/// 
	/// </summary>
	public int ConteudoId
	{
		get
		{
			if (RegistroId > 0)
			{
				return RegistroId;
			}
			else
			{
				return Convert.ToInt32(NoticiaId);
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int ConteudoSecaoId
	{
		get
		{
			if (SecaoId > 0)
			{
				return SecaoId;
			}
			else
			{
				return Convert.ToInt32(NoticiaSecaoId);
			}
		}
	}

	#endregion

	#region Events

	/// <summary>
	/// Page Load Event
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		// If no id redirect to list page
		if (ConteudoId == 0)
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
		//Get "noticia" by id
		NoticiaService noticiaService = new NoticiaService();
		Noticia noticia = noticiaService.CarregarToSite(ConteudoId);

		// if exist "noticia" set details else redirect to list page
		if (noticia != null)
		{
			// Check "idioma"            
			NoticiaIdiomaService noticiaIdiomaService = new NoticiaIdiomaService();
			// if no "idioma" redirect to list page
			NoticiaIdioma noticiaIdioma = noticiaIdiomaService.Carregar(new NoticiaIdioma() { Noticia = noticia, Idioma = Util.CurrentIdioma });

			if (noticiaIdioma != null)
			{
				this.AddHits(ConteudoId);

				this.BindNoticia(noticiaIdioma.TituloNoticia, noticiaIdioma.TextoNoticia, noticia.DataExibicaoInicio.Value, noticia.Autor);

				this.BindTags(noticia.Conteudo.ConteudoId, Assuntos.Noticia);

				this.BindMaisVistos();

				this.BindContentRelated(noticia.Conteudo.ConteudoId);

				noticiaGaleriaImagens1.ConteudoId = this.ConteudoId;
				noticiaGaleriaImagens1.ConteudoSecaoId = this.ConteudoSecaoId;
				noticiaGaleriaImagens1.DataBind();

				boxZebrado.DataBind(Assuntos.Noticia);

				string strScript = "$(document).ready(function() {" +
												"try {" +
												"var pageTracker = _gat._getTracker('UA-17790992-1');" +
												"pageTracker._setDomainName('none');" +
												"pageTracker._setAllowLinker(true);" +
												"pageTracker._trackPageview('/Fique_por_Dentro/Noticias/Visualizou_Noticia/" + HttpUtility.UrlEncode(noticiaIdioma.TituloNoticia, Encoding.GetEncoding(28597)).Replace("+", "_") + "');" +
												"} catch (err) { }" +
											"});";

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
	/// Redirect to list of noticias
	/// </summary>
	protected void RedirectToList()
	{
		Response.Redirect("noticias-Default.aspx");
	}

	/// <summary>
	/// Bind Related Content
	/// </summary>
	/// <param name="noticiaId">content Id</param>
	private void BindContentRelated(int noticiaId)
	{
		this.noticiaConteudoRelacionado.ContentDataBind(noticiaId);
	}

	/// <summary>
	/// Bind the information about "Noticia"
	/// </summary>
	/// <param name="titulo"></param>
	/// <param name="noticia"></param>
	/// <param name="data"></param>
	protected void BindNoticia(string titulo, string noticia, DateTime data, string autor)
	{
		ltrTituloNoticia.Text = titulo;
		lblAutor.Text = autor;
		ltrNoticia.Text = noticia.ReplaceHtml();
		lblData.Text = String.Concat(data.ToString(Util.MaskDate), " às ", data.ToString("HH:mm"));
		conteudoAvaliacao.SetAll(titulo, Request.Url.AbsoluteUri);
		conteudoAvaliacao.UrlRSS = String.Concat("~/rss/rss-noticia.aspx?idioma=", Util.CurrentIdiomaId);
	}

	/// <summary>
	/// Bind "noticia" tag list
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
		NoticiaService noticiaService = new NoticiaService();
		List<Noticia> noticias = new List<Noticia>();
		noticias = (List<Noticia>)noticiaService.CarregarMaisVistos(3);
		noticiaMaisVistos.Noticias = noticias;
		noticiaMaisVistos.DataBind();
	}

	#endregion

	#region IHttpHandler Members

	/// <summary>
	/// 
	/// </summary>
	bool System.Web.IHttpHandler.IsReusable
	{
		get { throw new NotImplementedException(); }
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="context"></param>
	void System.Web.IHttpHandler.ProcessRequest(System.Web.HttpContext context)
	{
		throw new NotImplementedException();
	}

	#endregion
}