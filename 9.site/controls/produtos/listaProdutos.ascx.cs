using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class controls_produtos_listaProdutos : SmartUserControl
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
			var hlTitulo = (HyperLink)e.Item.FindControl("hlTitulo");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");

			Produto produto = (Produto)e.Item.DataItem;
			ProdutoIdiomaService produtoIdiomaService = new ProdutoIdiomaService();
			ProdutoIdioma produtoIdioma = produtoIdiomaService.Carregar(new ProdutoIdioma() { Produto = produto, Idioma = Util.CurrentIdioma });
			if (produtoIdioma != null)
			{
				hlTitulo.NavigateUrl = String.Concat("~/produtos-e-servicos/produto.aspx?secaoId=", Util.GetSecaoIdByProductType(produto.ProdutoTipo.ProdutoTipoId), "&id=", produto.ProdutoId);
				ltrTitulo.Text = produtoIdioma.TituloProduto;
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
