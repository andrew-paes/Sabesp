using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using System.Web.UI.HtmlControls;
using AG2.Sabesp.HotWords;
using System.Text;

public partial class controls_abas_boxAbas : SmartUserControl
{
	/// <summary>
	/// 
	/// </summary>
	private string PathSecao;

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		
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

		/*
		string strScript = "$(document).ready(function() {" +
															"$(\"div[id$='pnlDivAba']\").find(\"a\").click(function() {" +
																"try {" +
																	"var pageTracker = _gat._getTracker('UA-17790992-1');" +
																	"pageTracker._setDomainName('none');" +
																	"pageTracker._setAllowLinker(true);" +
																	"pageTracker._trackPageview('" + PathSecao + "/' + $(this).text().replace(' ','_'));" +
																	"} catch (err) { }" +
															"});" +
														"});";
		*/

		string strScript = "$(document).ready(function() {" +
															"$(\"div[id$='pnlDivAba']\").find(\"a\").click(function() {" +
																"try {" +
																	"var tituloLinkAba = $(this).text().trim();" +
																	"if(tituloLinkAba != null && tituloLinkAba != ''){" +
																		"tituloLinkAba = replaceSpecialChars(tituloLinkAba);" +
																		"tituloLinkAba = tituloLinkAba.substr(0,60);" +
																		"var pageTracker = _gat._getTracker('UA-17790992-1');" +
																		"pageTracker._setCustomVar(1, 'LINK', tituloLinkAba, 3);" +
																		"pageTracker._setDomainName('none');" +
																		"pageTracker._setAllowLinker(true);" +
																		"pageTracker._trackPageview(pathURL);" +
																	"}" +
																"} catch (err) { }" +
															"});" +
														"});";

		Page.ClientScript.RegisterStartupScript(GetType(), "scrSetGoogleAnalyticsAbaLink", strScript, true);
	}

	/// <summary>
	/// 
	/// </summary>
	public override void DataBind()
	{
		base.DataBind();

		List<Secao> secoes = this.GetSecoesAbas(SecaoId);

		if (secoes != null && secoes.Count > 0)
		{
			this.DefinePathSecao();

			rptAbas.DataSource = secoes;
			rptAbas.DataBind();

			rptTituloAbas.DataSource = secoes;
			rptTituloAbas.DataBind();
		}
		else
		{
			this.Visible = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptTituloAbas_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var liTitulo = (HtmlGenericControl)e.Item.FindControl("liTitulo");
			var ltrAba = (Literal)e.Item.FindControl("ltrAba");

			Secao secao = (Secao)e.Item.DataItem;
			string strTitulo = secao.SecaoIdiomas[0].Titulo;

			ltrAba.Text = String.Concat("<strong><a onclick=\"javascript: AbaClickGA('", PathSecao, "/", HttpUtility.UrlEncode(strTitulo, Encoding.GetEncoding(28597)).Replace("+", "_"), "');\" href=\"", "#", ((Panel)rptAbas.Items[e.Item.ItemIndex].FindControl("pnlAba")).ClientID, "\">", strTitulo, "</a><span><!-- --></span></strong>");

			if (e.Item.ItemIndex == 0)
			{
				liTitulo.Attributes.Add("class", "on");
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptAbas_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var ltrTexto = (Literal)e.Item.FindControl("ltrTexto");
			var pnlAba = (Panel)e.Item.FindControl("pnlAba");
			var pnlDivAba = (Panel)e.Item.FindControl("pnlDivAba");

			Secao secao = (Secao)e.Item.DataItem;
			ltrTexto.Text = WordsInjector.Hotword(secao.SecaoIdiomas[0].Texto).ReplaceHtml();

			if (e.Item.ItemIndex == 0)
			{
				pnlAba.CssClass = String.Concat(pnlAba.CssClass, " ", "on");
			}

			int height = this.GetHeigthDivAba();
			pnlDivAba.Attributes.Add("style", String.Concat("min-height:", height, "px; _height:", height, "px;"));
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	private int GetHeigthDivAba()
	{
		List<Secao> secoes = (List<Secao>)rptAbas.DataSource;

		return (secoes.Count * 47) - 11;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="secaoid"></param>
	/// <returns></returns>
	protected List<Secao> GetSecoesAbas(int secaoid)
	{
		SecaoService secaoService = new SecaoService();
		List<Secao> secoes = secaoService.CarregarFilhos(secaoid, false);
		List<Secao> secoesAbas = new List<Secao>();

		if (secoes != null)
		{
			SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();

			foreach (Secao secao in secoes)
			{
				SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Idioma = Util.CurrentIdioma, Secao = secao });
				if (secaoIdioma != null && secaoIdioma.Ativo != null && secaoIdioma.Ativo.Value == true)
				{
					Secao secaoOk = secao;
					secaoOk.SecaoIdiomas = new List<SecaoIdioma>();
					secaoOk.SecaoIdiomas.Add(secaoIdioma);
					secoesAbas.Add(secaoOk);
				}
			}
		}

		return secoesAbas;
	}
}
