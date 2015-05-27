using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.BO;
using System.Web.UI.HtmlControls;
using Sabesp.Data.Services;
using System.Text;

public partial class controls_GoogleAnalytics : SmartUserControl
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadPage()
	{
		try
		{
			this.LoadGoogleAnalytics();
		}
		catch
		{
			this.Visible = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadGoogleAnalytics()
	{
		List<Secao> caminho = new SecaoService().ObterCaminho(new Secao() { SecaoId = SecaoId }, Util.CurrentIdioma);

		Secao sec;

		string pathSecao = "";

		for (int a = caminho.Count; a > 0; a--)
		{
			sec = caminho[a - 1];

			if (sec.SecaoPai != null && sec.SecaoPai.SecaoId != 0)
			{
				pathSecao = String.Concat(pathSecao, "/", HttpUtility.UrlEncode(sec.SecaoIdiomas[0].Titulo, Encoding.GetEncoding(28597)).Replace("+", "_"));
			}
		}

		if (pathSecao == "")
		{
			pathSecao = "/Home";
		}

		string strScript = "$(document).ready(function() {" +
												"try {" +
												"var pageTracker = _gat._getTracker('UA-17790992-1');" +
												"pageTracker._setDomainName('none');" +
												"pageTracker._setAllowLinker(true);" +
												"pageTracker._trackPageview('" + pathSecao + "');" +
												"} catch (err) { }" +
											"});";

		Page.ClientScript.RegisterStartupScript(GetType(), "scrSetGoogleAnalytics", strScript, true);
	}
}