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
using System.Web.UI.HtmlControls;

public partial class fale_Conosco_Default : BasePage
{
	#region Atributos
	RegiaoService regiaoService = new RegiaoService();
	string IdOutrasRegioes = "2000";
	public string OptionSelectedId { get; set; }
	#endregion

	#region Eventos

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.LoadPage();
			//populaRegiao();
			this.primeiraColunaDinamica1.DataBind();
		}
	}

	protected void LoadPage()
	{
		SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
		SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Secao = new Secao() { SecaoId = SecaoId }, Idioma = Util.CurrentIdioma });

		if (secaoIdioma != null)
		{
			ltrTitulo.Text = secaoIdioma.Titulo;
			ltrDescricao.Text = secaoIdioma.Texto.ReplaceHtml();
		}
	}

	protected void ddlRegiao_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.OptionSelectedId = ddlRegiao.SelectedValue;
		ltrRegiaoSelected.Text = String.Concat("<var class=\"value\">", ((DropDownList)sender).SelectedItem.ToString(), "</var>");
		switch (this.OptionSelectedId)
		{
			case "23":
				lblDescricaoRegiao.Text = "Atende à Zona Norte da Capital e aos municípios da Grande São Paulo ao norte da Capital";
				break;
			case "24":
				lblDescricaoRegiao.Text = "Atende à Zona Oeste da Capital e aos municípios da Grande São Paulo à oeste da Capital.";
				break;
			case "25":
				lblDescricaoRegiao.Text = "Atende à Zona Leste da Capital e aos municípios da Grande São Paulo à leste da Capital.";
				break;
			case "26":
				lblDescricaoRegiao.Text = "Atende à Zona Sul da Capital e aos municípios da Grande São Paulo ao sul da Capital.";
				break;
			case "27":
				lblDescricaoRegiao.Text = "Atende à Zona Central da Capital.";
				break;
			case "28":
				lblDescricaoRegiao.Text = "Atende aos municípios do Interior e Litoral.";
				break;
			default:
				lblDescricaoRegiao.Text = string.Empty;
				break;
		}
	}
	#endregion

	#region Métodos

	protected void populaRegiao()
	{
		ddlRegiao.DataSource = regiaoService.RetornaTodos();
		ddlRegiao.DataTextField = "NomeRegiao";
		ddlRegiao.DataValueField = "RegiaoId";
		ddlRegiao.DataBind();
		ddlRegiao.Items.Insert(0, new ListItem(Convert.ToString(GetLocalResourceObject("EscolhaSuaRegiao")), "0"));
		ddlRegiao.Items.Add(new ListItem(Convert.ToString(GetLocalResourceObject("OutrosEstados")), IdOutrasRegioes));
	}

	#endregion


}