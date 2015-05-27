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

public partial class content_module_faq_faq : SmartUserControl
{
	#region [ Properties ]

	/// <summary>
	/// Business Object for "FaqItem" fields
	/// </summary>
	protected FaqItem entidadeFaqItem;
	/// <summary>
	/// Business Object for "FaqCategoria" fields
	/// </summary>
	protected FaqCategoria entidadeFaqCategoria;
	/// <summary>
	/// Business Object for "FaqCategoriaIdioma" fields
	/// </summary>
	protected FaqCategoriaIdioma entidadeFaqCategoriaIdioma;
	/// <summary>
	/// Business Object for "FaqItemIdioma" fields
	/// </summary>
	protected FaqItemIdioma entidadeFaqItemIdioma;
	/// <summary>
	///   Service for "faqItemService" 
	/// </summary>
	protected FaqItemService faqItemService;
	/// <summary>
	///   Service for "faqItemIdiomaService" 
	/// </summary>
	protected FaqItemIdiomaService faqItemIdiomaService;
	/// <summary>
	///   Service for "faqCategoriaService" 
	/// </summary>
	protected FaqCategoriaService faqCategoriaService;
	/// <summary>
	///   Service for "faqCategoriaIdiomaService" 
	/// </summary>
	protected FaqCategoriaIdiomaService faqCategoriaIdiomaService;
	/// <summary>
	///  Filter for "regiaoFH" to search BO for tags
	/// </summary>
	protected FaqItemFH faqItemFH;
	/// <summary>
	///  Filter for "faqItemIdiomaFH" to search BO for tags
	/// </summary>
	protected FaqItemIdiomaFH faqItemIdiomaFH;
	/// <summary>
	///  Filter for "faqCategoriaFH" to search BO for tags
	/// </summary>
	protected FaqCategoriaFH faqCategoriaFH;
	/// <summary>
	///  Filter for "faqCategoriaIdiomaFH" to search BO for tags
	/// </summary>
	protected FaqCategoriaIdiomaFH faqCategoriaIdiomaFH;

	#endregion

	#region [ Page Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
		this.DefineProperties();

		if (this.IdRegistro > 0)
		{
			if (!IsPostBack || this.IdiomaHasChanged)
			{
				this.LoadProperties();
				this.LoadForm();
			}
		}

		if (!IsPostBack)
		{
			LoadddlCategorias();
		}
	}

	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		this.Execute();
	}

	#endregion

	#region [ Methods ]

	#region Properties And Form
	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		// Ini service to "Faq"
		entidadeFaqCategoria = new FaqCategoria();
		entidadeFaqItem = new FaqItem();
		faqCategoriaFH = new FaqCategoriaFH();
		entidadeFaqItem.FaqCategoria = new FaqCategoria();

		// Ini service to "FaqIdioma"
		entidadeFaqCategoriaIdioma = new FaqCategoriaIdioma();
		entidadeFaqCategoriaIdioma.FaqCategoria = new FaqCategoria();
		entidadeFaqCategoriaIdioma.Idioma = new Idioma();
		entidadeFaqItemIdioma = new FaqItemIdioma();
		faqCategoriaIdiomaFH = new FaqCategoriaIdiomaFH();

		faqCategoriaService = new FaqCategoriaService();
		faqCategoriaIdiomaService = new FaqCategoriaIdiomaService();
		faqItemIdiomaService = new FaqItemIdiomaService();
		faqItemService = new FaqItemService();
	}

	/// <summary>
	/// Load all properties
	/// </summary>
	private void LoadProperties()
	{
		// Ini "Faq"
		entidadeFaqItem = new FaqItem();
		entidadeFaqItem.FaqItemId = Convert.ToInt32(IdRegistro);

		// Ini and define "FaqIdioma"
		entidadeFaqItemIdioma = new FaqItemIdioma();
		entidadeFaqItemIdioma.FaqItem = new FaqItem();
		entidadeFaqItemIdioma.FaqItem.FaqItemId = Convert.ToInt32(IdRegistro);
		entidadeFaqItemIdioma.Idioma = new Idioma();
		entidadeFaqItemIdioma.Idioma.IdiomaId = this.IdiomaId;

		// Ini service to find "Faq"
		faqItemService = new FaqItemService();
		entidadeFaqItem = faqItemService.Carregar(entidadeFaqItem);

		// Ini service to find "FaqIdioma"
		faqItemIdiomaService = new FaqItemIdiomaService();
		entidadeFaqItem.FaqItemIdiomas = new List<FaqItemIdioma>();

		// Add "FaqIdioma"
		entidadeFaqItem.FaqItemIdiomas.Add(faqItemIdiomaService.Carregar(entidadeFaqItemIdioma));
	}

	protected void ClearForm()
	{
		txtOrdem.Text = string.Empty;
		txtPergunta.Text = string.Empty;
		txtResposta.Text = string.Empty;

		chbAtivo.Checked = false;
		chkDestaque.Checked = false;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		if (entidadeFaqItem != null
			&& entidadeFaqItemIdioma != null)
		{
			if (entidadeFaqItem.FaqItemIdiomas[0] != null)
			{
				txtPergunta.Text = entidadeFaqItem.FaqItemIdiomas[0].Pergunta.ToString();
				txtResposta.Text = entidadeFaqItem.FaqItemIdiomas[0].Resposta.ToString();
			}

			txtOrdem.Text = entidadeFaqItem.OrdemItem.ToString();
			chbAtivo.Checked = entidadeFaqItem.Ativo;
			chkDestaque.Checked = entidadeFaqItem.Destaque;
		}

		LoadddlCategorias();
		ddlcategoria.SelectedIndex = ddlcategoria.Items.IndexOf(ddlcategoria.Items.FindByValue(entidadeFaqItem.FaqCategoria.FaqCategoriaId.ToString()));
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected void FormToLoad()
	{
		// Carrega "FaqCategoria e FaqcategoriaIdioma"
		if (!String.IsNullOrEmpty(txtPergunta.Text))
			entidadeFaqItemIdioma.Pergunta = txtPergunta.Text;

		if (!String.IsNullOrEmpty(txtResposta.Text))
			entidadeFaqItemIdioma.Resposta = txtResposta.Text;

		if (!String.IsNullOrEmpty(txtOrdem.Text))
			entidadeFaqItem.OrdemItem = Convert.ToInt32(txtOrdem.Text);

		entidadeFaqItem.Ativo = chbAtivo.Checked;
		entidadeFaqItem.Destaque = chkDestaque.Checked;

		entidadeFaqItemIdioma.Idioma = new Idioma();
		entidadeFaqItemIdioma.Idioma.IdiomaId = this.IdiomaId;

		if (ddlcategoria.SelectedValue != "0")
		{
			entidadeFaqItem.FaqCategoria.FaqCategoriaId = Convert.ToInt32(ddlcategoria.SelectedValue);
		}

		if (IdRegistro > 0)
		{
			entidadeFaqItemIdioma.FaqItem = new FaqItem();

			entidadeFaqItem.FaqItemId = Convert.ToInt32(IdRegistro);
			entidadeFaqItemIdioma.FaqItem.FaqItemId = entidadeFaqItem.FaqItemId;
		}
	}

	/// <summary>
	/// Load Categorias
	/// </summary>
	protected void LoadddlCategorias()
	{
		// Search allcategories by language "idiomaId"
		FaqCategoriaIdiomaFH faqCategoriaIdiomaFH = new FaqCategoriaIdiomaFH();
		faqCategoriaIdiomaFH.IdiomaId = Convert.ToString(this.IdiomaId);
		IList<FaqCategoriaIdioma> entidadeFaqCategoriaIdiomaList = new List<FaqCategoriaIdioma>();
		entidadeFaqCategoriaIdiomaList = new FaqCategoriaIdiomaService().RetornaTodos(0, 0, "", "", faqCategoriaIdiomaFH);


		ddlcategoria.DataSource = entidadeFaqCategoriaIdiomaList;
		ddlcategoria.DataTextField = "nomeCategoria";
		ddlcategoria.DataValueField = "faqCategoriaId";
		ddlcategoria.DataBind();
	} 
	#endregion

	/// <summary>
	/// 
	/// </summary>
	private void Execute()
	{
		if (!String.IsNullOrEmpty(txtPergunta.Text.Trim()) && !String.IsNullOrEmpty(txtResposta.Text.Trim()))
		{
			this.FormToLoad();

			int cont = 0;
			if (this.IdRegistro > 0)
			{
				faqItemIdiomaFH = new FaqItemIdiomaFH();
				faqItemIdiomaFH.IdiomaId = this.IdiomaId.ToString();
				faqItemIdiomaFH.FaqItemId = this.IdRegistro.ToString();
				cont = new FaqItemIdiomaService().TotalRegistros(faqItemIdiomaFH);
			}

			if (entidadeFaqItem != null && entidadeFaqItem.FaqItemId > 0 && cont > 0)
			{
				try
				{
					this.Update();
					Util.ShowMessage("Registro alterado com sucesso!");
				}
				catch
				{
					Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde");
				}
			}
			else
			{
				this.Save();
				Util.ShowMessage("Registro salvo com sucesso!");
			}
		}
		else
		{
			Util.ShowMessage("Deve ser inserido uma pergunta e uma resposta.");
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Save()
	{
		entidadeFaqItemIdioma.FaqItem = new FaqItem();

		if (this.IdRegistro == 0)
		{
			// Save "FaqCategoria"
			faqItemService.Inserir(entidadeFaqItem);

			entidadeFaqItemIdioma.FaqItem.FaqItemId = entidadeFaqItem.FaqItemId;
		}
		else
		{
			entidadeFaqItemIdioma.FaqItem.FaqItemId = Convert.ToInt32(this.IdRegistro);
		}

		entidadeFaqItemIdioma.FaqItem.FaqCategoria = new FaqCategoria();
		entidadeFaqItemIdioma.FaqItem.FaqCategoria.FaqCategoriaId = Convert.ToInt32(ddlcategoria.SelectedValue);

		// Save "FaqCategoriaIdioma"
		faqItemIdiomaService.Inserir(entidadeFaqItemIdioma);

		Response.Redirect("../content/edit.aspx?md=faq&id=" + entidadeFaqItem.FaqItemId.ToString() + "&lg=" + this.IdiomaId + "&wid=");
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
		entidadeFaqItemIdioma.FaqItem.FaqCategoria = new FaqCategoria();
		entidadeFaqItemIdioma.FaqItem.FaqCategoria.FaqCategoriaId = Convert.ToInt32(ddlcategoria.SelectedValue);

		// Update "Faq"
		faqItemService.Atualizar(entidadeFaqItem);

		// Update "FaqIdioma"
		faqItemIdiomaService.Atualizar(entidadeFaqItemIdioma);
	}

	#endregion
}
