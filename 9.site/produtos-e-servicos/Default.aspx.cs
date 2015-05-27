using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using Sabesp.BO;
using Sabesp.Enumerators;

public partial class produtos_Servicos_Default : BasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	protected void LoadPage()
	{
		HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
		body.Attributes.Add("class", "interna");

		this.LoadResources();
		this.BindDestaquesEmpresas();
		this.BindDestaquesCondominios();
		this.BindDestaquesMunicipios();
		this.BindConsultorias();
		this.segundaColunaDinamica1.DataBind();
	}

	protected void LoadResources()
	{
		hlTodosProdutos1.Text = GetLocalResourceObject("hlTodosProdutos").ToString();
		hlTodosProdutos2.Text = GetLocalResourceObject("hlTodosProdutos").ToString();
		hlTodosProdutos3.Text = GetLocalResourceObject("hlTodosProdutos").ToString();
	}

	protected void BindDestaquesEmpresas()
	{
		ProdutoService produtoService = new ProdutoService();
		string[] orderColumn = { "produtoId" };
		string[] orderBy = { "DESC" };

		List<Produto> produtos = (List<Produto>)produtoService.CarregarTodos(5, 1, orderColumn, orderBy, new ProdutoFH() { Ativo = "1", DestaqueProdutos = "1", ProdutoTipoId = Produtos.Empresas.GetHashCode().ToString() });

		if (produtos != null && produtos.Count > 0)
		{
			produtoDestaqueGrande1.Produto = produtos[0];
			produtoDestaqueGrande1.DataBind();

			produtos.RemoveAt(0);
			produtoDestaqueLista1.Produtos = produtos;
			produtoDestaqueLista1.DataBind();
		}
		else
		{
			produtoDestaqueGrande1.Visible = false;
			produtoDestaqueLista1.Visible = false;
		}

		hlTodosProdutos1.NavigateUrl = "~/produtos-e-servicos/Empresas.aspx?secaoId=128";
	}

	protected void BindDestaquesCondominios()
	{
		ProdutoService produtoService = new ProdutoService();
		string[] orderColumn = { "produtoId" };
		string[] orderBy = { "DESC" };

		List<Produto> produtos = (List<Produto>)produtoService.CarregarTodos(5, 1, orderColumn, orderBy, new ProdutoFH() { Ativo = "1", DestaqueProdutos = "1", ProdutoTipoId = Produtos.Condominios.GetHashCode().ToString() });

		if (produtos != null && produtos.Count > 0)
		{
			produtoDestaqueLista2.Produtos = produtos;
			produtoDestaqueLista2.DataBind();
		}
		else
		{
			produtoDestaqueLista2.Visible = false;
		}

		hlTodosProdutos2.NavigateUrl = "~/produtos-e-servicos/condominios.aspx?secaoId=133";
	}

	protected void BindDestaquesMunicipios()
	{
		ProdutoService produtoService = new ProdutoService();
		string[] orderColumn = { "produtoId" };
		string[] orderBy = { "DESC" };

		List<Produto> produtos = (List<Produto>)produtoService.CarregarTodos(5, 1, orderColumn, orderBy, new ProdutoFH() { Ativo = "1", DestaqueProdutos = "1", ProdutoTipoId = Produtos.MunicipiosEEstados.GetHashCode().ToString() });

		if (produtos != null && produtos.Count > 0)
		{
			produtoDestaqueGrande2.Produto = produtos[0];
			produtoDestaqueGrande2.DataBind();
			produtos.RemoveAt(0);

			produtoDestaqueLista3.Produtos = produtos;
			produtoDestaqueLista3.DataBind();
		}
		else
		{
			produtoDestaqueLista3.Visible = false;
		}

		hlTodosProdutos3.NavigateUrl = "~/produtos-e-servicos/municipio-estado.aspx?secaoId=130";
	}

	protected void BindConsultorias()
	{
		ProdutoService produtoService = new ProdutoService();
		string[] orderColumn = { "produtoId" };
		string[] orderBy = { "DESC" };

		List<Produto> produtosConsultoriaInternacional = (List<Produto>)produtoService.CarregarTodos(2, 1, orderColumn, orderBy, new ProdutoFH() { Ativo = "1", DestaqueProdutos = "1", ProdutoTipoId = Produtos.ConsultoriaInternacional.GetHashCode().ToString() });
		List<Produto> produtosConsultoriaSustentavel = (List<Produto>)produtoService.CarregarTodos(2, 1, orderColumn, orderBy, new ProdutoFH() { Ativo = "1", DestaqueProdutos = "1", ProdutoTipoId = Produtos.ConsultoriaSustentavel.GetHashCode().ToString() });
		List<Produto> produtos = new List<Produto>();

		if (produtosConsultoriaInternacional != null && produtosConsultoriaInternacional.Count > 0)
		{
			foreach (Produto prod in produtosConsultoriaInternacional)
			{
				produtos.Add(prod);
			}
		}

		if(produtosConsultoriaSustentavel != null && produtosConsultoriaSustentavel.Count > 0)
		{
			foreach (Produto prod in produtosConsultoriaSustentavel)
			{
				produtos.Add(prod);
			}
		}

		if(produtos.Count > 0)
		{
			produtoLista1.Produtos = produtos;
			produtoLista1.DataBind();
		}
		else
		{
			produtoDestaqueLista3.Visible = false;
		}

		hlTodosProdutos3.NavigateUrl = "~/produtos-e-servicos/municipio-estado.aspx?secaoId=130";
	}
}