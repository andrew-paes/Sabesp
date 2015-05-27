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
using Sabesp.Enumerators;
using System.Web.Services;
using System.Text;

public partial class interna_Default : BasePage
{
	/// <summary>
	/// 
	/// </summary>
	public string SiglaRegiao
	{
		get
		{
			if (!String.IsNullOrEmpty(Request.QueryString["sg"]))
			{
				return Convert.ToString(Request.QueryString["sg"]);
			}
			else
			{
				return string.Empty;
			}
		}
	}

	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
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
	/// <param name="siglaRegiao"></param>
	/// <returns></returns>
	[WebMethod]
	public static List<Municipio> BindMunicipios(string siglaRegiao)
	{
		List<Municipio> municipios = null;
		RegiaoService regiaoService = new RegiaoService();
		Regiao regiao = regiaoService.Carregar(new Regiao() { RegiaoId = GetIdRegiaoBySigla(siglaRegiao) });

		if (regiao != null)
		{
			municipios = regiaoService.GetMunicipios(regiao.RegiaoId);

			if (municipios == null)
			{
				municipios = new List<Municipio>();
			}
			else
			{
				//percorre os municipios adicionando em uma nova lista sem as propriedades que não estão sendo utilizadas como texto por exemplo
				List<Municipio> novaLista = new List<Municipio>();

				foreach (Municipio mun in municipios)
				{
					novaLista.Add(new Municipio() { MunicipioId = mun.MunicipioId, Nome = mun.Nome });
				}

				municipios = novaLista;
			}

			municipios.Insert(0, new Municipio() { MunicipioId = regiao.RegiaoId, Nome = regiao.NomeRegiao });
		}

		return municipios;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sigla"></param>
	/// <returns></returns>
	[WebMethod]
	public static int GetIdRegiaoBySigla(string sigla)
	{
		switch (sigla.ToUpper())
		{
			case "RB":
				return 5;
			case "RS":
				return 6;
			case "RA":
				return 7;
			case "RR":
				return 8;
			case "RG":
				return 9;
			case "RJ":
				return 10;
			case "RM":
				return 11;
			case "RN":
				return 12;
			case "RT":
				return 13;
			case "RV":
				return 14;
			case "LE":
				return 15;
			case "NO":
				return 16;
			case "OE":
				return 17;
			case "SU":
				return 18;
			default:
				return 0;

		}
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