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

public partial class interna_Default2 : BasePage
{
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

				//primeiraColunaDinamica1.DataBind();
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

	protected void RedirectToHome()
	{
		Response.Redirect("~/", false);
	}

	#endregion
}