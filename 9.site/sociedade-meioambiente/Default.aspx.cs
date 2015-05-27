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

public partial class social_Ambiental_Default : BasePage
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

		this.BindFirst();
		this.BindSecond();
		this.BindThird();
		this.BindFourth();
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

		ltlTitulo.Text = secaoIdiomaBO.Titulo;

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
		this.secaoBO.SecaoId = 73; // Programas
		this.secaoService = new SecaoService();
		this.secaoBO = secaoService.Carregar(this.secaoBO);
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao = this.secaoBO;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = this.secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		this.ltlBoxFirst.Text = this.secaoIdiomaBO.Titulo;

		List<Secao> secaoFilhos = new List<Secao>();
		secaoFilhos = secaoService.CarregarFilhos(this.secaoBO.SecaoId, true);

		if (secaoFilhos != null && secaoFilhos.Count > 0)
		{
			this.BindFirstItem(secaoFilhos);

			secaoFilhos.RemoveAt(0);

			this.RepeatFirstDataBind(secaoFilhos);
		}
		else
		{
			this.secaoBO.SecaoIdiomas = new List<SecaoIdioma>();
			this.secaoBO.SecaoIdiomas.Add(this.secaoIdiomaBO);

			List<Secao> secaoUnica = new List<Secao>();
			secaoUnica.Add(this.secaoBO);
			this.BindFirstItem(secaoUnica);
		}
	}

	private void BindFirstItem(List<Secao> secaoFilhos)
	{
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao.SecaoId = secaoFilhos[0].SecaoId;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;

		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		string strTitulo = this.secaoIdiomaBO.Titulo;
		string strTexto = this.secaoIdiomaBO.Texto.GenerateResume(300);

		secaoFilhos[0].Modelo = new ModeloService().Carregar(secaoFilhos[0].Modelo);
		this.hplFirstItem.Text = String.Concat("<strong>", strTitulo, "</strong><span>", strTexto, "</span>");
		this.hplFirstItem.NavigateUrl = String.Concat(secaoFilhos[0].Modelo.Arquivo, "?secaoId=", secaoFilhos[0].SecaoId);

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
		this.secaoBO = new Secao();
		this.secaoBO.SecaoId = 92; // Compromisso
		this.secaoService = new SecaoService();
		this.secaoBO = secaoService.Carregar(this.secaoBO);
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao = this.secaoBO;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = this.secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		this.ltlBoxSecond.Text = this.secaoIdiomaBO.Titulo;

		List<Secao> secaoFilhos = new List<Secao>();
		secaoFilhos = secaoService.CarregarFilhos(this.secaoBO.SecaoId, true);

		if (secaoFilhos != null && secaoFilhos.Count > 0)
		{
			this.BindSecondItem(secaoFilhos);

			secaoFilhos.RemoveAt(0);

			this.RepeatSecondDataBind(secaoFilhos);
		}
		else
		{
			this.secaoBO.SecaoIdiomas = new List<SecaoIdioma>();
			this.secaoBO.SecaoIdiomas.Add(this.secaoIdiomaBO);

			List<Secao> secaoUnica = new List<Secao>();
			secaoUnica.Add(this.secaoBO);
			this.BindSecondItem(secaoUnica);
		}
	}

	private void BindSecondItem(List<Secao> secaoFilhos)
	{
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao.SecaoId = secaoFilhos[0].SecaoId;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;

		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		string strTitulo = this.secaoIdiomaBO.Titulo;
		string strTexto = this.secaoIdiomaBO.Texto.GenerateResume(300);

		secaoFilhos[0].Modelo = new ModeloService().Carregar(secaoFilhos[0].Modelo);
		this.hplSecondItem.Text = String.Concat("<strong>", strTitulo, "</strong><span>", strTexto, "</span>");
		this.hplSecondItem.NavigateUrl = String.Concat(secaoFilhos[0].Modelo.Arquivo, "?secaoId=", secaoFilhos[0].SecaoId);

		string imgURL = "~/contents/img/FAKE_newsDest.jpg";

		if (!String.IsNullOrEmpty(this.secaoIdiomaBO.TituloArquivos))
		{
			imgURL = String.Concat("~/uploads/secao/", this.secaoIdiomaBO.TituloArquivos);
		}

		this.imgSecondItem.ImageUrl = ResolveUrl(imgURL);
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
			hplRptItensSecond.Text = String.Concat("<strong>", strTitulo, "</strong><br /><span>", strTexto, "</span>");
			hplRptItensSecond.NavigateUrl = String.Concat(secao.Modelo.Arquivo, "?secaoId=", secao.SecaoId);

			string imgURL = "~/contents/img/FAKE_mananciais.jpg";

			if (!String.IsNullOrEmpty(this.secaoIdiomaBO.TituloArquivos))
			{
				imgURL = String.Concat("~/uploads/secao/", this.secaoIdiomaBO.TituloArquivos);
			}

			imgRptItensSecond.ImageUrl = ResolveUrl(imgURL);
		}
	}

	#endregion

	#region [ Third Box ]

	/// <summary>
	/// 
	/// </summary>
	private void BindThird()
	{
		this.secaoBO = new Secao();
		this.secaoBO.SecaoId = 95; // Educação
		this.secaoService = new SecaoService();
		this.secaoBO = secaoService.Carregar(this.secaoBO);
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao = this.secaoBO;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = this.secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		this.ltlBoxThird.Text = this.secaoIdiomaBO.Titulo;

		List<Secao> secaoFilhos = new List<Secao>();
		secaoFilhos = secaoService.CarregarFilhos(this.secaoBO.SecaoId, true);

		if (secaoFilhos != null && secaoFilhos.Count > 0)
		{
			this.BindThirdItem(secaoFilhos);

			secaoFilhos.RemoveAt(0);

			this.RepeatThirdDataBind(secaoFilhos);
		}
		else
		{
			this.secaoBO.SecaoIdiomas = new List<SecaoIdioma>();
			this.secaoBO.SecaoIdiomas.Add(this.secaoIdiomaBO);

			List<Secao> secaoUnica = new List<Secao>();
			secaoUnica.Add(this.secaoBO);
			this.BindThirdItem(secaoUnica);
		}
	}

	private void BindThirdItem(List<Secao> secaoFilhos)
	{
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao.SecaoId = secaoFilhos[0].SecaoId;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;

		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		string strTitulo = this.secaoIdiomaBO.Titulo;
		string strTexto = this.secaoIdiomaBO.Texto.GenerateResume(300);

		secaoFilhos[0].Modelo = new ModeloService().Carregar(secaoFilhos[0].Modelo);
		this.hplThirdItem.Text = String.Concat("<strong>", strTitulo, "</strong><span>", strTexto, "</span>");
		this.hplThirdItem.NavigateUrl = String.Concat(secaoFilhos[0].Modelo.Arquivo, "?secaoId=", secaoFilhos[0].SecaoId);

		string imgURL = "~/contents/img/FAKE_educacao.jpg";

		if (!String.IsNullOrEmpty(this.secaoIdiomaBO.TituloArquivos))
		{
			imgURL = String.Concat("~/uploads/secao/", this.secaoIdiomaBO.TituloArquivos);
		}

		this.imgThirdItem.ImageUrl = ResolveUrl(imgURL);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="secaoFilhos"></param>
	private void RepeatThirdDataBind(List<Secao> secaoFilhos)
	{
		rptThird.DataSource = secaoFilhos;
		rptThird.DataBind();
	}

	protected void rptThird_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		// Get Conteudo
		Secao secao = (Secao)e.Item.DataItem;

		// Verify if has value
		if (secao != null)
		{
			// Set controls
			Image imgRptItensThird = (Image)e.Item.FindControl("imgRptItensThird");
			HyperLink hplRptItensThird = (HyperLink)e.Item.FindControl("hplRptItensThird");

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
			hplRptItensThird.Text = String.Concat("<strong>", strTitulo, "</strong><br /><span>", strTexto, "</span>");
			hplRptItensThird.NavigateUrl = String.Concat(secao.Modelo.Arquivo, "?secaoId=", secao.SecaoId);

			string imgURL = "~/contents/img/FAKE_coleta.jpg";

			if (!String.IsNullOrEmpty(this.secaoIdiomaBO.TituloArquivos))
			{
				imgURL = String.Concat("~/uploads/secao/", this.secaoIdiomaBO.TituloArquivos);
			}

			imgRptItensThird.ImageUrl = ResolveUrl(imgURL);
		}
	}

	#endregion

	#region [ Fourth Box ]

	/// <summary>
	/// 
	/// </summary>
	private void BindFourth()
	{
		this.secaoBO = new Secao();
		this.secaoBO.SecaoId = 76; // Uso racional da água
		this.secaoService = new SecaoService();
		this.secaoBO = secaoService.Carregar(this.secaoBO);
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao = this.secaoBO;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = this.secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		if (this.secaoIdiomaBO != null)
		{
			this.ltlBoxFourth.Text = this.secaoIdiomaBO.Titulo;
		}

		List<Secao> secaoFilhos = new List<Secao>();
		secaoFilhos = secaoService.CarregarFilhos(this.secaoBO.SecaoId, true);

		if (secaoFilhos != null && secaoFilhos.Count > 0)
		{
			this.BindFourthItem(secaoFilhos);

			secaoFilhos.RemoveAt(0);

			this.RepeatFourthDataBind(secaoFilhos);
		}
		else
		{
			this.secaoBO.SecaoIdiomas = new List<SecaoIdioma>();
			this.secaoBO.SecaoIdiomas.Add(this.secaoIdiomaBO);

			List<Secao> secaoUnica = new List<Secao>();
			secaoUnica.Add(this.secaoBO);
			this.BindFourthItem(secaoUnica);
		}
	}

	private void BindFourthItem(List<Secao> secaoFilhos)
	{
		this.secaoIdiomaBO = new SecaoIdioma();
		this.secaoIdiomaBO.Secao = new Secao();
		this.secaoIdiomaBO.Secao.SecaoId = secaoFilhos[0].SecaoId;
		this.secaoIdiomaBO.Idioma = new Idioma();
		this.secaoIdiomaBO.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;

		this.secaoIdiomaService = new SecaoIdiomaService();
		this.secaoIdiomaBO = secaoIdiomaService.Carregar(this.secaoIdiomaBO);

		string strTitulo = this.secaoIdiomaBO.Titulo;
		string strTexto = this.secaoIdiomaBO.Texto.GenerateResume(300);

		secaoFilhos[0].Modelo = new ModeloService().Carregar(secaoFilhos[0].Modelo);
		this.hplFourthItem.Text = String.Concat("<strong>", strTitulo, "</strong><span>", strTexto, "</span>");
		this.hplFourthItem.NavigateUrl = String.Concat(secaoFilhos[0].Modelo.Arquivo, "?secaoId=", secaoFilhos[0].SecaoId);

		string imgURL = "~/contents/img/FAKE_transparencia.jpg";

		if (!String.IsNullOrEmpty(this.secaoIdiomaBO.TituloArquivos))
		{
			imgURL = String.Concat("~/uploads/secao/", this.secaoIdiomaBO.TituloArquivos);
		}

		this.imgFourthItem.ImageUrl = ResolveUrl(imgURL);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="secaoFilhos"></param>
	private void RepeatFourthDataBind(List<Secao> secaoFilhos)
	{
		rptFourth.DataSource = secaoFilhos;
		rptFourth.DataBind();
	}

	protected void rptFourth_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		// Get Conteudo
		Secao secao = (Secao)e.Item.DataItem;

		// Verify if has value
		if (secao != null)
		{
			// Set controls
			Image imgRptItensFourth = (Image)e.Item.FindControl("imgRptItensFourth");
			HyperLink hplRptItensFourth = (HyperLink)e.Item.FindControl("hplRptItensFourth");

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
			hplRptItensFourth.Text = String.Concat("<strong>", strTitulo, "</strong><br /><span>", strTexto, "</span>");
			hplRptItensFourth.NavigateUrl = String.Concat(secao.Modelo.Arquivo, "?secaoId=", secao.SecaoId);

			string imgURL = "~/contents/img/FAKE_coleta.jpg";

			if (!String.IsNullOrEmpty(this.secaoIdiomaBO.TituloArquivos))
			{
				imgURL = String.Concat("~/uploads/secao/", this.secaoIdiomaBO.TituloArquivos);
			}

			imgRptItensFourth.ImageUrl = ResolveUrl(imgURL);
		}
	}

	#endregion
}