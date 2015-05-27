using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Ag2.Manager.Helper;
using Sabesp.Data;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;
using Ag2.Manager.WebUI;

public partial class content_module_produto_produto : SmartUserControl
{
	#region [ Properties ]

	/// <summary>
	/// Business Object for "Produto" fields
	/// </summary>
	protected Produto entidadeProduto;
	/// <summary>
	/// Business Object for "ProdutoIdioma" fields
	/// </summary>
	protected ProdutoIdioma entidadeProdutoIdioma;
	/// <summary>
	/// Business Object for "Arquivo" fields
	/// </summary>
	protected Arquivo entidadeArquivo;
	/// <summary>
	/// Business Object for "Produto Imagem" fields
	/// </summary>
	protected ProdutoImagem entidadeProdutoImagem;
	/// <summary>
	/// Business Object for "Tag" fields
	/// </summary>
	protected Tag entidadeTag;
	/// <summary>
	/// Business Object for "Região" fields
	/// </summary>
	protected Regiao entidadeRegiao;
	/// <summary>
	///   Service for "ProdutoService" 
	/// </summary>
	protected ProdutoService produtoService;
	/// <summary>
	///   Service for "ProdutoIdiomaService" 
	/// </summary>
	protected ProdutoIdiomaService produtoIdiomaService;
	/// <summary>
	///   Service for "ArquivoService" 
	/// </summary>
	protected ArquivoService arquivoService;
	/// <summary>
	///   Service for "ProdutoImagemService" 
	/// </summary>
	protected ProdutoImagemService produtoImagemService;
	/// <summary>
	///   Service for "ConteudoService" 
	/// </summary>
	protected ConteudoService conteudoService;
	/// <summary>
	///   Service for "TagService" 
	/// </summary>
	protected TagService tagService;
	/// <summary>
	///   Service for "ConteudoTagService" 
	/// </summary>
	protected ConteudoTagService conteudoTagService;
	/// <summary>
	///   Service for "RegiaoService" 
	/// </summary>
	protected RegiaoService regiaoService;

	/// <summary>
	///  Filter for "ConteudoTagFH" to search BO for tags
	/// </summary>
	/// 

	protected ConteudoTagFH conteudoTagFH;
	/// <summary>
	///  Filter for "ProdutoImagemFH" to search BO for tags
	/// </summary>
	protected ProdutoImagemFH produtoImagemFH;
	/// <summary>
	///  Filter for "ProdutoFH" to search BO for tags
	/// </summary>
	protected ProdutoFH produtoFH;
	/// <summary>
	///  Filter for "ProdutoIdiomaFH" to search BO for tags
	/// </summary>
	protected ProdutoIdiomaFH produtoIdiomaFH;
	/// <summary>
	///  Filter for "ArquivoFH" to search BO for tags
	/// </summary>
	protected ArquivoFH arquivoFH;
	/// <summary>
	///  Filter for "RegiaoFH" to search BO for tags
	/// </summary>
	protected RegiaoFH regiaoFH;

	#endregion

	#region [ Page Events ]

	protected void Page_Init(object sender, EventArgs e)
	{
		this.DefineProperties();
		sfArquivo.DataKeyValue = Convert.ToString(this.IdRegistro);
		this.BindSubformArquivo();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			LoadddlTipo();
		}

		if (this.IdRegistro > 0)
		{
			sfArquivo.Visible = true;
			if (!IsPostBack || this.IdiomaHasChanged)
			{
				this.LoadProperties();
				this.LoadForm();
			}
		}
		else
		{
			sfArquivo.Visible = false;
		}
	}


	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		if (Page.IsValid)
		{
			this.FormToLoad();

			int cont = 0;
			if (this.IdRegistro > 0)
			{
				produtoIdiomaFH = new ProdutoIdiomaFH();
				produtoIdiomaFH.IdiomaId = this.IdiomaId.ToString();
				produtoIdiomaFH.ProdutoId = this.IdRegistro.ToString();
				cont = new ProdutoIdiomaService().TotalRegistros(produtoIdiomaFH);
			}

			try
			{
				if (entidadeProduto != null && entidadeProduto.ProdutoId > 0)
				{
					if (cont > 0)
					{
						this.Update();
					}
					else
					{
						this.Update();
						this.SaveIdioma();
					}
					Util.ShowMessage("Registro alterado com sucesso!");
				}
				else
				{
					this.Save();
					Util.ShowMessage("Registro salvo com sucesso!");
					Response.Redirect("~/content/edit.aspx?md=produto&id=" + this.entidadeProduto.ProdutoId.ToString() + "&lg=" + this.IdiomaId + "&wid=");
				}
			}
			catch
			{
				Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde");
			}
		}
	}
	protected void sfArquivo_Excluir(object sender, Ag2.Manager.WebUI.SubFormEventArgs e)
	{
		if (e.listIDs != null)
		{
			foreach (string sid in e.listIDs)
			{

				ProdutoImagemService produtoImagemService = new ProdutoImagemService();
				ProdutoImagem ni = produtoImagemService.Carregar(new ProdutoImagem() { ProdutoImagemId = Convert.ToInt32(sid) });
				if (ni != null)
				{
					produtoImagemService.Excluir(ni);
				}
			}
		}

		this.BindSubformArquivo();
	}

	#endregion

	#region [ Methods ]

	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		// Ini service to "Produto"
		entidadeProduto = new Produto();

		// Ini service to "ProdutoIdioma"
		entidadeProdutoIdioma = new ProdutoIdioma();
		entidadeProdutoIdioma.Produto = new Produto();
		entidadeProdutoIdioma.Idioma = new Idioma();

		// Ini service to "ProdutoImagem"
		entidadeProdutoImagem = new ProdutoImagem();
		entidadeProdutoImagem.Produto = new Produto();
		entidadeProdutoImagem.Produto.ProdutoIdiomas = new List<ProdutoIdioma>();
		produtoImagemFH = new ProdutoImagemFH();

		// Ini service to "Arquivo"
		entidadeArquivo = new Arquivo();
		entidadeArquivo.ProdutoImagens = new List<ProdutoImagem>();
		entidadeProduto.ArquivoThumb = new Arquivo();

		// Ini service to "tag"
		entidadeTag = new Tag();
		conteudoTagService = new ConteudoTagService();
		conteudoTagFH = new ConteudoTagFH();

		produtoService = new ProdutoService();
		produtoIdiomaService = new ProdutoIdiomaService();
		conteudoService = new ConteudoService();
	}

	/// <summary>
	/// Load all properties
	/// </summary>
	private void LoadProperties()
	{
		// Ini "Produto"
		entidadeProduto = new Produto();

		// Ini and define "ProdutoIdioma"
		entidadeProdutoIdioma = new ProdutoIdioma();
		entidadeProdutoIdioma.Produto = entidadeProduto;
		entidadeProdutoIdioma.Idioma = new Idioma();
		entidadeProdutoIdioma.Idioma.IdiomaId = this.IdiomaId;


		#region ProdutoImagem

		this.BindSubformArquivo();

		#endregion

		// Ini service to find "Produto"
		produtoService = new ProdutoService();
		entidadeProduto.ProdutoId = Convert.ToInt32(IdRegistro);
		entidadeProduto = produtoService.Carregar(entidadeProduto);

		// Ini service to find "ProdutoIdioma"
		produtoIdiomaService = new ProdutoIdiomaService();
		entidadeProduto.ProdutoIdiomas = new List<ProdutoIdioma>();

		// Add "ProdutoIdioma"
		entidadeProdutoIdioma = produtoIdiomaService.Carregar(entidadeProdutoIdioma);
		entidadeProduto.ProdutoIdiomas.Add(entidadeProdutoIdioma);

		//Arquivo Thumb
		#region Arquivo Thumb
		if (entidadeProduto.ArquivoThumb != null)
		{
			DataTable dtGrande = new DataTable();
			dtGrande.Columns.Add(new DataColumn("arquivoId", typeof(int)));
			dtGrande.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));

			DataRow drGrande = dtGrande.NewRow();
			Arquivo entidadeArquivo = new Arquivo();

			entidadeArquivo = new ArquivoService().Carregar(entidadeProduto.ArquivoThumb);
			drGrande["arquivoId"] = entidadeArquivo.ArquivoId;
			drGrande["NomeArquivo"] = entidadeArquivo.NomeArquivo;

			dtGrande.Rows.Add(drGrande);

			if (dtGrande.Rows.Count > 0)
			{
				sfThumb.DataKeyValue = Convert.ToString(this.IdRegistro);
				sfThumb.DataSource = dtGrande;
				sfThumb.DataBind();
			}
		}
		#endregion

	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		if (entidadeProduto != null
			&& entidadeProduto != null
			&& entidadeProduto.ProdutoIdiomas != null
			&& entidadeProduto.ProdutoIdiomas.Count > 0)
		{
			if (entidadeProduto.ProdutoIdiomas.Count > 0)
			{
				if (entidadeProduto.ProdutoIdiomas[0] != null)
				{
					txtTituloProduto.Text = entidadeProduto.ProdutoIdiomas[0].TituloProduto;
					txtDescricao.Text = entidadeProduto.ProdutoIdiomas[0].TextoProduto;
					txtChamada.Text = entidadeProduto.ProdutoIdiomas[0].ChamadaProduto;
				}
			}

			chkDestaque.Checked = entidadeProduto.DestaqueProdutos;
			chkAtivo.Checked = entidadeProduto.Ativo;

			if (ddlTipo.Items.FindByValue(entidadeProduto.ProdutoTipo.ProdutoTipoId.ToString()) != null)
			{
				ddlTipo.SelectedValue = entidadeProduto.ProdutoTipo.ProdutoTipoId.ToString();
			}
		}

		//        LoadddlTipo();
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected void FormToLoad()
	{
		// Carrega "Produto"
		if (ddlTipo.SelectedValue != "0")
		{
			entidadeProduto.ProdutoTipo = new ProdutoTipo();
			entidadeProduto.ProdutoTipo.ProdutoTipoId = Convert.ToInt32(ddlTipo.SelectedValue);
		}
		//entidadeProduto.ProdutoTipo = new ProdutoTipo();
		//entidadeProduto.ProdutoTipo.ProdutoTipoId = 1;

		entidadeProduto.Ativo = chkAtivo.Checked;
		entidadeProduto.DestaqueProdutos = chkDestaque.Checked;


		// Carrega "ProdutoIdioma"
		if (!String.IsNullOrEmpty(txtTituloProduto.Text))
		{
			entidadeProdutoIdioma.TituloProduto = txtTituloProduto.Text;
		}

		// Chamada do Produto
		if (!String.IsNullOrEmpty(txtChamada.Text))
		{
			entidadeProdutoIdioma.ChamadaProduto = txtChamada.Text;
		}
		if (!String.IsNullOrEmpty(txtDescricao.Text))
		{
			entidadeProdutoIdioma.TextoProduto = txtDescricao.Text;
		}

		entidadeProdutoIdioma.Idioma.IdiomaId = this.IdiomaId;

		if (IdRegistro > 0)
		{
			entidadeProduto.ProdutoId = Convert.ToInt32(IdRegistro);
			entidadeProdutoIdioma.Produto.ProdutoId = Convert.ToInt32(IdRegistro);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Save()
	{
		if (entidadeProduto != null)
		{
			// Save "Produto"
			new ProdutoService().Inserir(entidadeProduto);

			if (entidadeProduto != null && entidadeProduto.ProdutoId > 0)
			{
				this.SaveIdioma();
			}
		}
	}

	protected void SaveIdioma()
	{
		entidadeProdutoIdioma.Produto.ProdutoId = entidadeProduto.ProdutoId;

		try
		{
			// Save "ProdutoIdioma"
			new ProdutoIdiomaService().Inserir(entidadeProdutoIdioma);
		}
		catch
		{
			new ProdutoService().Excluir(entidadeProduto);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
		// add "ProdutoImagem" and "Thumb Médio and Grande"
		addListArquivo();

		// Update "Produto"
		produtoService.Atualizar(entidadeProduto);

		this.UpdateIdioma();
	}

	protected void UpdateIdioma()
	{
		// Update "ProdutoIdioma"
		produtoIdiomaService.Atualizar(entidadeProdutoIdioma);
	}

	/// <summary>
	/// 
	/// </summary>
	protected void addListArquivo()
	{
		// arquivoThum
		List<Int32> lstArquivoIdThumb = sfThumb.BuscaPKs();
		foreach (int arquivoId in lstArquivoIdThumb)
		{
			entidadeProduto.ArquivoThumb = new Arquivo();
			entidadeProduto.ArquivoThumb.ArquivoId = arquivoId;
			break;
		}
	}

	/// <summary>
	/// Clear the form
	/// </summary>
	protected void ClearForm()
	{
		txtTituloProduto.Text = string.Empty;

		txtDescricao.Text = string.Empty;
		ddlTipo.Items.Clear();
		chkDestaque.Checked = false;
		chkAtivo.Checked = false;

		sfArquivo.ClearItens();
	}

	/// <summary>
	/// Load Categorias
	/// </summary>
	protected void LoadddlTipo()
	{
		// Search allcategories by language "idiomaId"
		ProdutoTipoIdiomaFH produtoTipoIdiomaFH = new ProdutoTipoIdiomaFH();
		produtoTipoIdiomaFH.IdiomaId = "1";
		IList<ProdutoTipoIdioma> entidadeProdutoTipoIdiomaList = new List<ProdutoTipoIdioma>();
		entidadeProdutoTipoIdiomaList = new ProdutoTipoIdiomaService().CarregarTodos(0, 0, null, null, produtoTipoIdiomaFH);

		ddlTipo.DataSource = entidadeProdutoTipoIdiomaList;
		ddlTipo.DataTextField = "tituloProdutoTipo";
		ddlTipo.DataValueField = "ProdutoTipoId";
		ddlTipo.DataBind();

		ddlTipo.Items.Insert(0, (new ListItem("::Selecione um Tipo::", "")));
	}

	protected void BindSubformArquivo()
	{
		// Search all news by "produtoId"
		produtoImagemFH = new ProdutoImagemFH();
		produtoImagemFH.ProdutoId = this.IdRegistro.ToString();
		IList<ProdutoImagem> entidadeProdutoImagemList = new List<ProdutoImagem>();
		entidadeProdutoImagemList = new ProdutoImagemService().RetornaTodos(0, 0, null, null, produtoImagemFH);

		DataTable dt = new DataTable();
		dt.Columns.Add(new DataColumn("arquivoId", typeof(int)));
		dt.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));
		for (int img = 0; img < entidadeProdutoImagemList.Count; img++)
		{
			DataRow dr = dt.NewRow();
			Arquivo entidadeArquivo = new Arquivo();
			entidadeArquivo = new ArquivoService().Carregar(entidadeProdutoImagemList[img].Arquivo);
			dr["arquivoId"] = entidadeProdutoImagemList[img].ProdutoImagemId;
			dr["NomeArquivo"] = entidadeArquivo.NomeArquivo;

			dt.Rows.Add(dr);
		}


		sfArquivo.DataSource = dt;
		sfArquivo.DataBind();
		sfArquivo.DataKeyValue = this.IdRegistro.ToString();
	}

	#endregion

}
