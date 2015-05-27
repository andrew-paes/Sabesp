using System;
using System.Web;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.IO;
public partial class controls_produtos_destaqueGrande : SmartUserControl
{
	#region Properties

	private String _cssClass = "newsDestaque";
	/// <summary>
	/// Gets or sets the CssClass of Panel (div)
	/// </summary>
	public String CssClass
	{
		get
		{
			return this._cssClass;
		}
		set
		{
			this._cssClass = value;
		}
	}

	/// <summary>
	/// Id of object "Produto" to try to load and bind controls
	/// </summary>
	public int ProdutoId { get; set; }

	/// <summary>
	/// Object produto to bind controls
	/// </summary>
	public Produto Produto { get; set; }

	public int ImageWidth { get; set; }

	public int ImageHeight { get; set; }

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.ConfigureControls();
	}

	/// <summary>
	/// configure the properties of this control and your children
	/// </summary>
	protected void ConfigureControls()
	{
		pnlDestaque.CssClass = this.CssClass;

		if (this.ImageWidth > 0)
		{
			imgDestaque.Width = this.ImageWidth;
		}

		if (this.ImageHeight > 0)
		{
			imgDestaque.Height = this.ImageHeight;
		}
	}

	public override void DataBind()
	{
		base.DataBind();

		//if the object is null, try to load
		if (this.Produto == null)
		{
			ProdutoService produtoService = new ProdutoService();
			this.Produto = produtoService.Carregar(new Produto() { ProdutoId = this.ProdutoId });
		}

		//bind the control
		this.BindProduto(this.Produto);
	}

	/// <summary>
	/// Bind the control with values of Produto
	/// </summary>
	/// <param name="produto"></param>
	protected void BindProduto(Produto produto)
	{
		if (produto != null)
		{
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
					divImgDestaque.Attributes.Add("style", "display:none");
				}
				hlTitulo.NavigateUrl = String.Concat("~/produtos-e-servicos/produto.aspx?secaoId=", Util.GetSecaoIdByProductType(produto.ProdutoTipo.ProdutoTipoId), "&id=", produto.ProdutoId);
				ltrTitulo.Text = produtoIdioma.TituloProduto;
                lblChamada.Text = produtoIdioma.ChamadaProduto.StripHTML().ReplaceHtml();
			}
		}
		else
		{
			//if object is null then, hide the control
			this.Visible = false;
		}
	}

	#endregion
}
