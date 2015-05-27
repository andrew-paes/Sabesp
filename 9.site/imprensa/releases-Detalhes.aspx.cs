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
public partial class releases_Detalhes : BasePage
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
	}

	#endregion

	#region Methods

	/// <summary>
	/// Load the page
	/// </summary>
	protected void LoadPage()
	{
		//Get "release" by id
		ReleaseService releaseService = new ReleaseService();
		Release release = releaseService.CarregarToSite(RegistroId);

		// if exist "release" set details else redirect to list page
		if (release != null)
		{
			// Check "idioma"            
			ReleaseIdiomaService releaseIdiomaService = new ReleaseIdiomaService();
			// if no "idioma" redirect to list page
			ReleaseIdioma releaseIdioma = releaseIdiomaService.Carregar(new ReleaseIdioma() { Release = release, Idioma = Util.CurrentIdioma });

			if (releaseIdioma != null)
			{
				this.BindRelease(releaseIdioma.TituloRelease, releaseIdioma.TextoRelease, release.DataHoraPublicacao, release.Autor);

				this.BindTags(release.Conteudo.ConteudoId, Assuntos.Release);

				this.BindOutrosReleases();

				string strScript = "$(document).ready(function() {" +
												"try {" +
												"var pageTracker = _gat._getTracker('UA-17790992-1');" +
												"pageTracker._setDomainName('none');" +
												"pageTracker._setAllowLinker(true);" +
												"pageTracker._trackPageview('/Imprensa/Releases/Visualizou_Release/" + HttpUtility.UrlEncode(releaseIdioma.TituloRelease, Encoding.GetEncoding(28597)).Replace("+", "_") + "');" +
												"} catch (err) { }" +
											"});";

				Page.ClientScript.RegisterStartupScript(GetType(), "scrSetGoogleAnalytics", strScript, true);

				releaseGaleriaImagens1.DataBind();

				conteudoAvaliacao.SetAll(releaseIdioma.TituloRelease, Request.Url.AbsoluteUri);
				conteudoAvaliacao.UrlRSS = String.Concat("~/rss/rss-imprensa.aspx?idioma=", Util.CurrentIdiomaId);
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
	/// Redirect to list of releases
	/// </summary>
	protected void RedirectToList()
	{
		Response.Redirect("releases-Default.aspx");
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="titulo"></param>
	/// <param name="release"></param>
	/// <param name="data"></param>
	/// <param name="autor"></param>
	protected void BindRelease(string titulo, string release, DateTime data, string autor)
	{
		ltrTituloRelease.Text = titulo;
		lblAutor.Text = autor;
		ltrRelease.Text = release.ReplaceHtml();
		lblData.Text = data.ToString(Util.MaskDate);
	}

	/// <summary>
	/// Bind "release" tag list
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
	protected void BindOutrosReleases()
	{
		ReleaseService releaseService = new ReleaseService();
		List<Release> releases = new List<Release>();
		releases = (List<Release>)releaseService.CarregarOutros(9, RegistroId);
		releaseOutrosReleases.Releases = releases;
		releaseOutrosReleases.DataBind();
	}

	#endregion
}