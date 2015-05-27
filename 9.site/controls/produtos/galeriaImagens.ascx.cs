using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using Sabesp.BO;

public partial class controls_produtos_galeriaImagens : SmartUserControl
{

	#region Properties

	/// <summary>
	/// DataSource of this control
	/// </summary>
	public List<ProdutoImagem> Fotos { get; set; }

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{

	}
	/// <summary>
	/// Bind the repeater control
	/// </summary>
	public override void DataBind()
	{
		base.DataBind();

		if (this.Fotos != null && this.Fotos.Count > 0)
		{
			rptImagens.DataSource = this.Fotos;
			rptImagens.DataBind();
		}
		else
		{
			this.Visible = false;
		}
	}

	protected void rptImagens_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			ProdutoImagem produtoImagem = (ProdutoImagem)e.Item.DataItem;
			if (produtoImagem != null)
			{
				var imgDestaque = (Image)e.Item.FindControl("imgDestaque");
				var hlGaleria = (HyperLink)e.Item.FindControl("hlGaleria");

				ArquivoService arquivoService = new ArquivoService();
				if (produtoImagem.Arquivo != null && produtoImagem.Arquivo.ArquivoId > 0)
					produtoImagem.Arquivo = arquivoService.Carregar(produtoImagem.Arquivo);

				if (produtoImagem.Arquivo != null)
				{
					imgDestaque.ImageUrl = String.Concat("~/uploads/produto/galeria/", produtoImagem.Arquivo.NomeArquivo);
					hlGaleria.NavigateUrl = String.Concat("~/uploads/produto/galeria/", produtoImagem.Arquivo.NomeArquivo);
				}
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	} 

	#endregion

}
