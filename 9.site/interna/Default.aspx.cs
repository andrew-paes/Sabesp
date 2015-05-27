using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data;
using Sabesp.Data.Services;
using AG2.Sabesp.HotWords;
using System.Text;

public partial class interna_Default : BasePage
{
	/// <summary>
	/// 
	/// </summary>
	private string PathSecao;

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	#endregion

	#region Methods

	/// <summary>
	/// 
	/// </summary>
	private void LoadPage()
	{
		this.DefinePathSecao();

		bool loaded = false;
		SecaoService secaoService = new SecaoService();
		Secao secao = secaoService.Carregar(new Secao() { SecaoId = SecaoId });
		if (secao != null)
		{
			SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
			SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Ativo = true, Secao = secao, Idioma = Util.CurrentIdioma });

			if (secaoIdioma != null)
			{
				ltlTitulo.Text = secaoIdioma.Titulo;
				ltlTituloMenu.Text = secaoIdioma.TituloMenu;
				if (!string.IsNullOrEmpty(secaoIdioma.TituloArquivos))
				{
					imgSecao.ImageUrl = ResolveUrl(String.Concat("~/uploads/secao/", secaoIdioma.TituloArquivos));
				}
				else
				{
					imgSecao.Visible = false;
				}
				ltrContent.Text = WordsInjector.Hotword(secaoIdioma.Texto).ReplaceHtml();

				primeiraColunaDinamica1.DataBind();
				segundaColunaDinamica1.DataBind();
				boxAbas1.DataBind();

				loaded = true;
			}
		}

		if (!loaded)
		{
			this.RedirectToHome();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	private void DefinePathSecao()
	{
		List<Secao> caminho = new SecaoService().ObterCaminho(new Secao() { SecaoId = SecaoId }, Util.CurrentIdioma);

		Secao sec;

		PathSecao = "";

		for (int a = caminho.Count; a > 0; a--)
		{
			sec = caminho[a - 1];

			if (sec.SecaoPai != null && sec.SecaoPai.SecaoId != 0)
			{
				PathSecao = String.Concat(PathSecao, "/", HttpUtility.UrlEncode(sec.SecaoIdiomas[0].Titulo, Encoding.GetEncoding(28597)).Replace("+", "_"));
			}
		}

		if (PathSecao == "")
		{
			PathSecao = "/Home";
		}

		//_setCustomVar()
		//_setCustomVar(index, name, value, opt_scope) 
		//Sets a custom variable with the supplied name, value, and scope for the variable. There is a 
		//64-byte character limit for the name and value combined. 

		//pageTracker._setCustomVar(
		//    1,                   // This custom var is set to slot #1
		//    "Section",           // The top-level name for your online content categories
		//    "Life & Style",      // Sets the value of "Section" to "Life & Style" for this particular aricle
		//    3                    // Sets the scope to page-level
		//);

		/*
		string strScript = "$(document).ready(function() {" +
															"$(\"div[id$='boxMasterContent']\").find(\"a\").click(function() {" +
																"try {" +
																	"var tituloLinkContent = $(this).text().replace(' ','_').replace(':','_').replace(';','_');" +
																	"if(tituloLinkContent != null && tituloLinkContent != tituloLinkContent){" +
																	"var pageTracker = _gat._getTracker('UA-17790992-1');" +
																	"pageTracker._setDomainName('none');" +
																	"pageTracker._setAllowLinker(true);" +
																	"pageTracker._trackPageview('" + PathSecao + "/' + tituloLinkContent);" +
																	"}" +
																	"} catch (err) { }" +
															"});" +
														"});";
		*/

		string strScript = "var pathURL = '';" + // Usada em /abas/boxAbas.cs
							"$(document).ready(function() {" +
															"$(\"div[id$='boxMasterContent']\").find(\"a\").click(function() {" +
																"try {" +
																	"var tituloLinkContent = $(this).text().trim();" +
																	"if(tituloLinkContent != null && tituloLinkContent != ''){" +
																		"tituloLinkContent = replaceSpecialChars(tituloLinkContent);" +
																		"tituloLinkContent = tituloLinkContent.substr(0,60);" +
																		"var pageTracker = _gat._getTracker('UA-17790992-1');" +
																		"pageTracker._setCustomVar(1, 'LINK', tituloLinkContent, 3);" +
																		"pageTracker._setDomainName('none');" +
																		"pageTracker._setAllowLinker(true);" +
																		"pageTracker._trackPageview('" + PathSecao + "');" +
																	"}" +
																"} catch (err) { }" +
															"});" +
														"});";

		Page.ClientScript.RegisterStartupScript(GetType(), "scrSetGoogleAnalyticsContentLink", strScript, true);
	}

	/// <summary>
	/// 
	/// </summary>
	protected void RedirectToHome()
	{
		Response.Redirect("~/", false);
	}

	#endregion
}