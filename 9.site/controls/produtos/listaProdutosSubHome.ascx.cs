using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.Enumerators;
using Sabesp.FilterHelper;
using System.IO;

public partial class controls_produtos_listaProdutosSubHome : SmartUserControl
{
	#region [ Properties ]


	#endregion

	#region [ Events ]
	/// <summary>
	/// 
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
	protected void rptContent_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hypTexto = (HyperLink)e.Item.FindControl("hypTexto");
			var ltlTexto = (Literal)e.Item.FindControl("ltlTexto");
			var imgEmpresa = (Image)e.Item.FindControl("imgEmpresa");
			var lblTitulo = (Label)e.Item.FindControl("lblTitulo");

			var produto = (Produto)e.Item.DataItem;
			ProdutoIdiomaService produtoIdiomaService = new ProdutoIdiomaService();
			ProdutoIdioma produtoIdioma = produtoIdiomaService.Carregar(new ProdutoIdioma() { Produto = produto, Idioma = Util.CurrentIdioma });

			if (produtoIdioma != null)
			{
				hypTexto.NavigateUrl = String.Concat("~/produtos-e-servicos/produto.aspx?secaoId=", SecaoId, "&id=", produto.ProdutoId);

                ltlTexto.Text = produtoIdioma.ChamadaProduto.StripHTML().ReplaceHtml();

				if (produtoIdioma.Produto.ArquivoThumb != null)
				{
					ArquivoService arquivoService = new ArquivoService();
					produto.ArquivoThumb = arquivoService.Carregar(new Arquivo() { ArquivoId = produto.ArquivoThumb.ArquivoId });

					if (produto.ArquivoThumb != null)
					{
						imgEmpresa.ImageUrl = String.Concat("~/uploads/secao/", produto.ArquivoThumb.NomeArquivo);
					}
					else
					{
						imgEmpresa.Visible = false;
					}
				}

				lblTitulo.Text = produtoIdioma.TituloProduto;
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	/// <summary>
	/// Bind products by type
	/// </summary>
	/// <param name="tipoProdutoId"></param>
	public override void DataBind()
	{
		Produtos? produtoTipo = null;

		switch (SecaoId)
		{
			case 128:
				produtoTipo = Produtos.Empresas;
				break;
			case 129:
				produtoTipo = Produtos.MicroEmpresas;
				break;
			case 130:
				produtoTipo = Produtos.MunicipiosEEstados;
				break;
			case 131:
				produtoTipo = Produtos.ConsultoriaInternacional;
				break;
			case 132:
				produtoTipo = Produtos.ConsultoriaSustentavel;
				break;
			case 133:
				produtoTipo = Produtos.Condominios;
				break;
			default:
				break;
		}

		if (produtoTipo != null)
		{
			this.BindProdutos(produtoTipo.Value);
		}
	}

	#endregion

	#region [ Methods ]

	protected void BindProdutos(Produtos produtoTipo)
	{
		string[] orderColumn = { "produtoId" };
		string[] orderDirection = { "ASC" };

		ProdutoService produtoService = new ProdutoService();
		List<Produto> produtos = (List<Produto>)produtoService.CarregarTodos(0, 0, orderColumn, orderDirection, new ProdutoFH() { Ativo = "1", ProdutoTipoId = produtoTipo.GetHashCode().ToString() });
		
		this.rptContent.DataSource = produtos;
		this.rptContent.DataBind();
	}

	#endregion



}
