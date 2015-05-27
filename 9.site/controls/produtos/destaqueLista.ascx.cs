using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class controls_produtos_destaqueLista : SmartUserControl
{
	#region Properties

	/// <summary>
	/// DataSource of this control
	/// </summary>
	public List<Produto> Produtos { get; set; }

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

		if (this.Produtos != null && this.Produtos.Count > 0)
		{
			rptDestaques.DataSource = this.Produtos;
			rptDestaques.DataBind();
            var li = (HtmlGenericControl)rptDestaques.Items[rptDestaques.Items.Count - 1].FindControl("li");
            if (li != null)
            {
                li.Attributes.Add("style", "display:none");
            }

		}
		else
		{
			this.Visible = false;
		}
	}

	protected void rptDestaques_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var imgDestaque = (Image)e.Item.FindControl("imgDestaque");
			var hlTitulo = (HyperLink)e.Item.FindControl("hlTitulo");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");
            var divImg = (HtmlGenericControl)e.Item.FindControl("divImg");

			Produto produto = (Produto)e.Item.DataItem;
			ProdutoIdiomaService produtoIdiomaService = new ProdutoIdiomaService();
			ProdutoIdioma produtoIdioma = produtoIdiomaService.Carregar(new ProdutoIdioma() { Produto = produto, Idioma = Util.CurrentIdioma });
			if (produtoIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();
				if (produto.ArquivoThumb != null && produto.ArquivoThumb.ArquivoId > 0)
                {
					produto.ArquivoThumb = arquivoService.Carregar(produto.ArquivoThumb);
                }
				if (produto.ArquivoThumb != null)
				{
					imgDestaque.ImageUrl = String.Concat("~/uploads/secao/", produto.ArquivoThumb.NomeArquivo);
				}
                else
                {
					divImg.Visible = false;
                }
				hlTitulo.NavigateUrl = String.Concat("~/produtos-e-servicos/produto.aspx?secaoId=", Util.GetSecaoIdByProductType(produto.ProdutoTipo.ProdutoTipoId), "&id=", produto.ProdutoId);
				ltrTitulo.Text = produtoIdioma.TituloProduto;
                lblChamada.Text = produtoIdioma.ChamadaProduto.StripHTML().ReplaceHtml();
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
