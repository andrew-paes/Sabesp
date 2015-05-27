using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;
using System.IO;
using System.Configuration;

public partial class produtos_e_servicos_produto : BasePage
{
	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
		this.segundaColunaDinamica1.DataBind();
	}

	#endregion 

	#region Methods

	protected void LoadPage()
	{
		SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
		SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Secao = new Secao() { SecaoId = SecaoId }, Idioma = Util.CurrentIdioma });

		if (secaoIdioma != null && secaoIdioma.Ativo != null && secaoIdioma.Ativo.Value == true)
		{
			ltrTituloSecao.Text = secaoIdioma.Titulo;
		}

		ProdutoService produtoService = new ProdutoService();
		Produto produto = produtoService.Carregar(new Produto() { ProdutoId = RegistroId });

		if (produto != null)
		{
			ProdutoIdiomaService produtoIdiomaService = new ProdutoIdiomaService();
			ProdutoIdioma produtoIdioma = produtoIdiomaService.Carregar(new ProdutoIdioma() { Produto = produto, Idioma = Util.CurrentIdioma });

			if (produtoIdioma != null)
			{
				if (produto.ArquivoThumb != null)
				{
					ArquivoService arquivoService = new ArquivoService();
					produto.ArquivoThumb = arquivoService.Carregar(new Arquivo() { ArquivoId = produto.ArquivoThumb.ArquivoId });

					if (produto.ArquivoThumb != null)
					{
						imgProduto.ImageUrl = String.Concat("~/uploads/secao/", produto.ArquivoThumb.NomeArquivo);
					}
					else
					{
						imgProduto.Visible = false;
					}
				}
				ltrTituloProduto.Text = produtoIdioma.TituloProduto;
				ltrTextoProduto.Text = produtoIdioma.TextoProduto.ReplaceHtml();

				ProdutoImagemService produtoImagemService = new ProdutoImagemService();
				string[] orderColumn = { "ordem" };
				string[] orderDirection = { "ASC" };
				galeriaProduto1.Fotos = (List<ProdutoImagem>)produtoImagemService.RetornaTodos(0, 0, orderColumn, orderDirection, new ProdutoImagemFH() { ProdutoId = produto.ProdutoId.ToString() });
				galeriaProduto1.DataBind();
			}
		}
	}

	#endregion
}
