using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Interfaces;
using System.Data;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using Sabesp.Enumerators;

public partial class categoriaFaq : SmartUserControl
{
	#region [ Properties ]


	#endregion

	#region [ Events ]

	/// <summary>
	/// Page Load Event
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptCategoria_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			FaqCategoria faqCategoria = (FaqCategoria)e.Item.DataItem;
			HyperLink hypAssunto = (HyperLink)e.Item.FindControl("hlComunicado");
			hypAssunto.Text = faqCategoria.FaqCategoriaIdiomas[0].NomeCategoria;
			hypAssunto.NavigateUrl = String.Concat("~/fale-conosco/faq.aspx?secaoId=", 134, "&cid=", faqCategoria.FaqCategoriaId);
		}
	}

	#endregion

	#region [ Methods ]
	
	public override void DataBind()
	{
		base.DataBind();

		rptCategoria.DataSource = this.BindCategorias();
		rptCategoria.DataBind();
	}

	/// <summary>
	/// 
	/// </summary>
	private List<FaqCategoria> BindCategorias()
	{
		string[] ordem = { "ordemCategoria" };
		string[] orderBy = { "ASC" };
		FaqCategoriaService faqCategoriaService = new FaqCategoriaService();
		List<FaqCategoria> faqCategorias = (List<FaqCategoria>)faqCategoriaService.CarregarTodos(0, 0, ordem, orderBy, null);
		List<FaqCategoria> faqCategoriasIdioma = null;

		if (faqCategorias != null)
		{
			faqCategoriasIdioma = new List<FaqCategoria>();
			FaqCategoriaIdiomaService faqCategoriaIdiomaService = new FaqCategoriaIdiomaService();
			for (int i = 0; i < faqCategorias.Count; i++)
			{
				FaqCategoria fc = faqCategorias[i];
				FaqCategoriaIdioma fci = faqCategoriaIdiomaService.Carregar(new FaqCategoriaIdioma() { FaqCategoria = fc, Idioma = Util.CurrentIdioma });

				if (fci != null)
				{
					fc.FaqCategoriaIdiomas = new List<FaqCategoriaIdioma>();
					fc.FaqCategoriaIdiomas.Add(fci);

					faqCategoriasIdioma.Add(fc);
				}
			}
		}

		return faqCategoriasIdioma;
	}

	#endregion

}
