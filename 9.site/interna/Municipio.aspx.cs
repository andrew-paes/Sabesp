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

public partial class interna_Municipio : BasePage
{
	#region Properties

	public int RegiaoId { get; set; }

	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
		if (this.RegistroId > 0)
		{
			this.LoadPage();
		}
		else
		{

		}

		segundaColunaDinamica1.DataBind();
	}

	/// <summary>
	/// 
	/// </summary>
	private void LoadPage()
	{
		MunicipioService municipioService = new MunicipioService();
		Municipio municipio = new Municipio() { MunicipioId = this.RegistroId };
		municipio = municipioService.Carregar(municipio);
		if (municipio != null)
		{
			SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
			SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Secao = new Secao() { SecaoId = SecaoId }, Idioma = Util.CurrentIdioma });

			if (secaoIdioma != null && secaoIdioma.Ativo != null && secaoIdioma.Ativo.Value == true)
			{
				ltlTitulo.Text = secaoIdioma.Titulo;
			}

			ltlTituloMenu.Text = municipio.Nome;
			if (!string.IsNullOrEmpty(municipio.Imagem))
			{
				imgSecao.ImageUrl = ResolveUrl(String.Concat("~/uploads/municipio/", municipio.Imagem));
			}
			else
			{
				imgSecao.Visible = false;
			}
			ltrContent.Text = WordsInjector.Hotword(municipio.Texto).ReplaceHtml();

			RegiaoService regiaoService = new RegiaoService();
			List<Regiao> regioes = regiaoService.CarregarPorMunicipio(municipio.MunicipioId);
			if (regioes != null && regioes.Count > 0)
			{
				fiquePorDentro1.RegiaoId = regioes[0].RegiaoId;
				fiquePorDentro1.DataBind();
			}
			else
			{
				fiquePorDentro1.Visible = false;
			}
		}

		//atendimento1.DataBind();
		//redeSociais1.DataBind();
		boxAbasMunicipio1.DataBind();
	}
}