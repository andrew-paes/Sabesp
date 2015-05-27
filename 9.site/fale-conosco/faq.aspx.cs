using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using Sabesp.BO;
using System.Web.UI.HtmlControls;
using AG2.Sabesp.HotWords;
using Sabesp.FilterHelper;


public partial class atendimento_faq : BasePage
{

	#region Properties

	/// <summary>
	/// 
	/// </summary>
	public int CategoriaId
	{
		get
		{
			int _categoriaId = 0;
			if (Request.QueryString["cid"] != null)
			{
				try
				{
					_categoriaId = Convert.ToInt32(Request.QueryString["cid"]);
				}
				catch
				{
					_categoriaId = 0;
				}
			}
			return _categoriaId;
		}
	}

	#endregion

	#region [ Page Events ]

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.LoadPage();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptFAQ_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		this.FAQDataBound(sender, e);
	}

	#endregion

	#region [ Methods ]

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void FAQDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			FaqItem faq = (FaqItem)e.Item.DataItem;

			var ltlQuestion = (Literal)e.Item.FindControl("ltlQuestion");
			var ltlAnswer = (Literal)e.Item.FindControl("ltlAnswer");

			string cssClass = "menor";

			if (faq.FaqItemIdiomas[0].Pergunta.Length > 100)
			{
				cssClass = "maior";
			}

			ltlQuestion.Text = String.Format("<dt class=\"{0}\"><span class=\"{1}\">{2}</span></dt>", cssClass, cssClass, faq.FaqItemIdiomas[0].Pergunta);

			ltlAnswer.Text = WordsInjector.Hotword(faq.FaqItemIdiomas[0].Resposta).ReplaceHtml();
		}
	}

	/// <summary>
	/// Load Page 
	/// </summary>
	private void LoadPage()
	{
		faqCategoria1.DataBind();
		segundaColunaDinamica1.DataBind();

		// Bind FAQ
		this.BindFAQ();

	}


	/// <summary>
	/// Bind FAQ Itens
	/// </summary>
	private void BindFAQ()
	{
		FaqItemService faqItemService = new FaqItemService();
		string[] ordem = { "ordemItem" };
		string[] direction = { "ASC" };

		FaqItemFH filter = new FaqItemFH() { Ativo = "1" };
		if (this.CategoriaId > 0)
		{
			filter.FaqCategoriaId = this.CategoriaId.ToString();
		}
		else
		{
			filter.Destaque = "1";
		}

		List<FaqItem> faqItens = (List<FaqItem>)faqItemService.CarregarTodos(0, 0, ordem, direction, filter);
		List<FaqItem> faqItensOk = null;

		if (faqItens != null)
		{
			faqItensOk = new List<FaqItem>();
			FaqItemIdiomaService faqItemIdiomaService = new FaqItemIdiomaService();
			for (int i = 0; i < faqItens.Count; i++)
			{
				FaqItem faqItem = faqItens[i];
				FaqItemIdioma faqItemIdioma = faqItemIdiomaService.Carregar(new FaqItemIdioma() { FaqItem = faqItem, Idioma = Util.CurrentIdioma });
				if (faqItemIdioma != null)
				{
					faqItem.FaqItemIdiomas = new List<FaqItemIdioma>();
					faqItem.FaqItemIdiomas.Add(faqItemIdioma);
					faqItensOk.Add(faqItem);
				}
			}
		}

		this.rptFAQ.DataSource = faqItensOk;
		this.rptFAQ.DataBind();
	}

	#endregion
}