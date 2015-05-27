using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using AG2.Sabesp.HotWords;

public partial class saneamento_esgoto : BasePage
{
	#region [ Properties ]

	protected Secao secaoBO; // Ini Business Object to "secao"
	protected SecaoIdioma secaoIdiomaBO; // Ini Business Object to "secaoIdioma"

	protected SecaoService secaoService; // Ini Service to "secao"
	protected SecaoIdiomaService secaoIdiomaService; // Ini Service to "secaoIdioma"

	protected SecaoFH secaoFH; // Ini FilterHelper to "secao"

	#endregion

	#region [ Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
		BindPage();
	}

	#endregion

	#region [ Page Methods ]

	/// <summary>
	/// 
	/// </summary>
	protected void BindPage()
	{
		SetPage();

		this.BindFirstItem();
		this.BindFirst();
		this.BindSecond();
	}

	/// <summary>
	/// 
	/// </summary>
	private void SetPage()
	{
		HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
		body.Attributes.Add("class", "interna");

		this.secaoBO = new Secao();
		this.secaoBO.SecaoId = SecaoId;
		this.secaoBO = new SecaoService().Carregar(secaoBO);

		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao = this.secaoBO;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
		this.secaoIdiomaBO = new SecaoIdiomaService().Carregar(this.secaoIdiomaBO);

		//ltlTitulo.Text = secaoIdiomaBO.Titulo;

		segundaColunaDinamica1.DataBind();
	}

	#endregion

	#region [ First Box ]

	/// <summary>
	/// 
	/// </summary>
	private void BindFirst()
	{
		this.secaoBO = new Secao();
		this.secaoBO.SecaoId = 49; // ETE
		this.secaoService = new SecaoService();
		this.secaoBO = secaoService.Carregar(this.secaoBO);
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao = this.secaoBO;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = this.secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		//this.ltlBoxFirst.Text = this.secaoIdiomaBO.Titulo;

		List<Secao> secaoFilhos = new List<Secao>();
		secaoFilhos = secaoService.CarregarFilhos(this.secaoBO.SecaoId, true);

		if (secaoFilhos != null && secaoFilhos.Count > 0)
		{
			this.RepeatFirstDataBind(secaoFilhos);
		}
	}

	private void BindFirstItem()
	{
		this.secaoBO = new Secao();
		this.secaoBO.SecaoId = 50; // Coleta
		this.secaoService = new SecaoService();
		this.secaoBO = secaoService.Carregar(this.secaoBO);
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao = this.secaoBO;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = this.secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		string strTitulo = this.secaoIdiomaBO.Titulo;
		string strTexto = this.secaoIdiomaBO.Texto.GenerateResume(300);

		secaoBO.Modelo = new ModeloService().Carregar(secaoBO.Modelo);
		this.hplFirstItem.Text = String.Concat("<strong>", strTitulo, "</strong><span>", strTexto, "</span>");
		this.hplFirstItem.NavigateUrl = String.Concat(secaoBO.Modelo.Arquivo, "?secaoId=", secaoBO.SecaoId);

		string imgURL = "~/contents/img/FAKE_newsDest.jpg";

		if (!String.IsNullOrEmpty(this.secaoIdiomaBO.TituloArquivos))
		{
			imgURL = String.Concat("~/uploads/secao/", this.secaoIdiomaBO.TituloArquivos);
		}

		this.imgFirstItem.ImageUrl = ResolveUrl(imgURL);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="secaoFilhos"></param>
	private void RepeatFirstDataBind(List<Secao> secaoFilhos)
	{
		rptFirst.DataSource = secaoFilhos;
		rptFirst.DataBind();
	}

	protected void rptFirst_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		// Get Conteudo
		Secao secao = (Secao)e.Item.DataItem;

		// Verify if has value
		if (secao != null)
		{
			// Set controls
			Image imgRptItensFirst = (Image)e.Item.FindControl("imgRptItensFirst");
			HyperLink hplRptItensFirst = (HyperLink)e.Item.FindControl("hplRptItensFirst");

			this.secaoIdiomaBO = new SecaoIdioma();
			this.secaoIdiomaBO.Secao = new Secao();
			this.secaoIdiomaBO.Secao.SecaoId = secao.SecaoId;
			this.secaoIdiomaBO.Idioma = new Idioma();
			this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;

			secaoIdiomaService = new SecaoIdiomaService();
			this.secaoIdiomaBO = secaoIdiomaService.Carregar(this.secaoIdiomaBO);

			string strTitulo = this.secaoIdiomaBO.Titulo;
			string strTexto = this.secaoIdiomaBO.Texto.GenerateResume(100);

			secao.Modelo = new ModeloService().Carregar(secao.Modelo);
			hplRptItensFirst.Text = String.Concat("<strong>", strTitulo, "</strong><br /><span>", strTexto, "</span>");
			hplRptItensFirst.NavigateUrl = String.Concat(secao.Modelo.Arquivo, "?secaoId=", secao.SecaoId);

			string imgURL = "~/contents/img/FAKE_mananciais.jpg";

			if (!String.IsNullOrEmpty(this.secaoIdiomaBO.TituloArquivos))
			{
				imgURL = String.Concat("~/uploads/secao/", this.secaoIdiomaBO.TituloArquivos);
			}

			imgRptItensFirst.ImageUrl = ResolveUrl(imgURL);
		}
	}

	#endregion

	#region [ Second Box ]

	/// <summary>
	/// 
	/// </summary>
	private void BindSecond()
	{
        try
        {
            this.secaoBO = new Secao();
            this.secaoBO.SecaoId = 49; // Processo de Tratamento de Esgoto
            this.secaoService = new SecaoService();
            this.secaoBO = secaoService.Carregar(this.secaoBO);
            this.secaoIdiomaBO = new SecaoIdioma();
            this.secaoIdiomaBO.Secao = new Secao();
            this.secaoIdiomaBO.Secao = this.secaoBO;
            this.secaoIdiomaBO.Idioma = new Idioma();
            this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
            this.secaoIdiomaService = new SecaoIdiomaService();
            this.secaoIdiomaBO = this.secaoIdiomaService.Carregar(this.secaoIdiomaBO);

            //this.ltlBoxSecond.Text = this.secaoIdiomaBO.Titulo;

            List<Secao> secaoFilhos = new List<Secao>();
            secaoFilhos = secaoService.CarregarFilhos(this.secaoBO.SecaoId, true);

            if (secaoFilhos != null && secaoFilhos.Count > 0)
            {
                this.RepeatSecondDataBind(secaoFilhos);
            }
        }
        catch
        {
        
        }
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="secaoFilhos"></param>
	private void RepeatSecondDataBind(List<Secao> secaoFilhos)
	{
		rptSecond.DataSource = secaoFilhos;
		rptSecond.DataBind();
	}

	protected void rptSecond_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		// Get Conteudo
		Secao secao = (Secao)e.Item.DataItem;

		// Verify if has value
		if (secao != null)
		{
			// Set controls
			Image imgRptItensSecond = (Image)e.Item.FindControl("imgRptItensSecond");
			HyperLink hplRptItensSecond = (HyperLink)e.Item.FindControl("hplRptItensSecond");
			Literal ltlRptItensSecond = (Literal)e.Item.FindControl("ltlRptItensSecond");

			this.secaoIdiomaBO = new SecaoIdioma();
			this.secaoIdiomaBO.Secao = new Secao();
			this.secaoIdiomaBO.Secao.SecaoId = secao.SecaoId;
			this.secaoIdiomaBO.Idioma = new Idioma();
			this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;

			secaoIdiomaService = new SecaoIdiomaService();
			this.secaoIdiomaBO = secaoIdiomaService.Carregar(this.secaoIdiomaBO);

			string strTitulo = this.secaoIdiomaBO.Titulo;
			string strTexto = this.secaoIdiomaBO.Texto.GenerateResume(100);

			secao.Modelo = new ModeloService().Carregar(secao.Modelo);
			hplRptItensSecond.Text = strTexto;
			hplRptItensSecond.NavigateUrl = String.Concat(secao.Modelo.Arquivo, "?secaoId=", secao.SecaoId);
			hplRptItensSecond.CssClass = "lkBoxGray";

			ltlRptItensSecond.Text = strTitulo;

			string imgURL = "~/contents/img/img-atendimento.jpg";

			if (!String.IsNullOrEmpty(this.secaoIdiomaBO.TituloArquivos))
			{
				imgURL = String.Concat("~/uploads/secao/", this.secaoIdiomaBO.TituloArquivos);
			}

			imgRptItensSecond.ImageUrl = ResolveUrl(imgURL);
		}
	}

	#endregion
}