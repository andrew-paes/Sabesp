using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using System.Data;
using Ag2.Manager.Helper;

public partial class content_module_projetoEspecial_projetoEspecial : SmartUserControl
{
	#region [ Properties ]
	/// <summary>
	/// Business Object for "Produto" fields
	/// </summary>
	protected ProjetoEspecial entidadeProjetoEspecial;
	/// <summary>
	/// Business Object for "ProdutoIdioma" fields
	/// </summary>
	protected ProjetoEspecialIdioma entidadeProjetoEspecialIdioma;
	/// <summary>
	/// Business Object for "Arquivo" fields
	/// </summary>
	protected Arquivo entidadeArquivo;
	/// <summary>
	///   Service for "ProdutoService" 
	/// </summary>
	protected ProjetoEspecialService projetoEspecialService;
	/// <summary>
	///   Service for "ProdutoIdiomaService" 
	/// </summary>
	protected ProjetoEspecialIdiomaService projetoEspecialIdiomaService;
	/// <summary>
	///   Service for "ArquivoService" 
	/// </summary>
	protected ArquivoService arquivoService;
	/// <summary>
	///  Filter for "ProdutoFH" to search BO for tags
	/// </summary>
	protected ProjetoEspecialFH projetoEspecialFH;
	/// <summary>
	///  Filter for "ProdutoIdiomaFH" to search BO for tags
	/// </summary>
	protected ProjetoEspecialIdiomaFH projetoEspecialIdiomaFH;
	/// <summary>
	///  Filter for "ArquivoFH" to search BO for tags
	/// </summary>
	protected ArquivoFH arquivoFH;


	#endregion

	#region [ Page Events ]

	protected void Page_Init(object sender, EventArgs e)
	{
		this.DefineProperties();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (this.IdRegistro > 0)
		{
			if (!IsPostBack || this.IdiomaHasChanged)
			{
				this.LoadForm();
			}
		}
	}

	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		this.Execute();
	}

	#endregion

	#region [ Methods ]

	/// <summary>
	/// Configure and bind page controls 
	/// </summary>
	private void LoadForm()
	{
		this.LoadProperties();
		this.SetDetails();

	}
	/// <summary>
	/// 
	/// </summary>
	private void SetDetails()
	{
		if (this.entidadeProjetoEspecial != null
			&& this.entidadeProjetoEspecial != null
			&& this.entidadeProjetoEspecial.ProjetoEspecialIdiomas != null
			&& this.entidadeProjetoEspecial.ProjetoEspecialIdiomas.Count > 0)
		{
			if (this.entidadeProjetoEspecial.ProjetoEspecialIdiomas.Count > 0)
			{
				if (this.entidadeProjetoEspecial.ProjetoEspecialIdiomas[0] != null)
				{
					this.txtTituloProjeto.Text = this.entidadeProjetoEspecial.ProjetoEspecialIdiomas[0].TituloProjeto.ToString();
					this.txtChamada.Text = this.entidadeProjetoEspecial.ProjetoEspecialIdiomas[0].ChamadaProjeto.ToString();
				}
			}

			this.chkAtivo.Checked = this.entidadeProjetoEspecial.Ativo;
			this.txtUrl.Text = this.entidadeProjetoEspecial.Url;
		}
	}

	private void Execute()
	{
		if (Page.IsValid)
		{
			this.FormToLoad();

			int cont = 0;
			if (this.IdRegistro > 0)
			{
				this.projetoEspecialIdiomaFH = new ProjetoEspecialIdiomaFH();
				this.projetoEspecialIdiomaFH.IdiomaId = this.IdiomaId.ToString();
				this.projetoEspecialIdiomaFH.ProjetoEspecialId = this.IdRegistro.ToString();
				cont = new ProjetoEspecialIdiomaService().TotalRegistros(this.projetoEspecialIdiomaFH);
			}

			try
			{
				if (this.entidadeProjetoEspecial != null && this.entidadeProjetoEspecial.ProjetoEspecialId > 0)
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
					Response.Redirect(String.Concat("~/content/edit.aspx?md=projetoespecial&id=", this.entidadeProjetoEspecial.ProjetoEspecialId.ToString(), "&lg=", this.IdiomaId, "&wid="));
				}
			}
			catch
			{
				Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde");
			}
		}
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected void FormToLoad()
	{

		#region [ Projeto Especial ]

		this.entidadeProjetoEspecial.Ativo = this.chkAtivo.Checked;
		this.entidadeProjetoEspecial.Url = this.txtUrl.Text;

		#endregion

		#region [ Projeto Especial Idioma ]

		// Carrega "ProjetoEspecialIdioma"
		if (!String.IsNullOrEmpty(this.txtTituloProjeto.Text))
		{
			this.entidadeProjetoEspecialIdioma.TituloProjeto = this.txtTituloProjeto.Text;
		}

		// Chamada do Projeto Especial
		if (!String.IsNullOrEmpty(this.txtChamada.Text))
		{
			this.entidadeProjetoEspecialIdioma.ChamadaProjeto = this.txtChamada.Text;
		}


		#endregion

		this.entidadeProjetoEspecialIdioma.Idioma.IdiomaId = this.IdiomaId;

		if (this.IdRegistro > 0)
		{
			this.entidadeProjetoEspecial.ProjetoEspecialId = Convert.ToInt32(this.IdRegistro);
			this.entidadeProjetoEspecialIdioma.ProjetoEspecial.ProjetoEspecialId = Convert.ToInt32(this.IdRegistro);
		}
	}


	/// <summary>
	/// 
	/// </summary>
	protected void Save()
	{
		if (this.entidadeProjetoEspecial != null)
		{
			this.addListArquivo();
			// Save "Produto"
			new ProjetoEspecialService().Inserir(entidadeProjetoEspecial);

			if (this.entidadeProjetoEspecial != null && this.entidadeProjetoEspecial.ProjetoEspecialId > 0)
			{
				this.SaveIdioma();
			}
		}
	}

	protected void SaveIdioma()
	{
		this.entidadeProjetoEspecialIdioma.ProjetoEspecial.ProjetoEspecialId = this.entidadeProjetoEspecial.ProjetoEspecialId;

		try
		{
			// Save "ProdutoIdioma"
			new ProjetoEspecialIdiomaService().Inserir(this.entidadeProjetoEspecialIdioma);

		}
		catch
		{
			new ProjetoEspecialService().Excluir(entidadeProjetoEspecial);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
		this.addListArquivo();

		// Update "projetoEspecial"
		this.projetoEspecialService.Atualizar(this.entidadeProjetoEspecial);

		this.UpdateIdioma();
	}

	protected void UpdateIdioma()
	{
		// Update "projetoEspecialidioma"
		this.projetoEspecialIdiomaService.Atualizar(this.entidadeProjetoEspecialIdioma);
	}

	/// <summary>
	/// Clear the form
	/// </summary>
	protected void ClearForm()
	{
		this.txtTituloProjeto.Text = string.Empty;

		this.txtUrl.Text = string.Empty;

		this.chkAtivo.Checked = false;
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
			this.entidadeProjetoEspecial.ArquivoThumbId = new Arquivo();
			this.entidadeProjetoEspecial.ArquivoThumbId.ArquivoId = arquivoId;
			break;
		}
	}


	private void LoadProperties()
	{
		// Ini "Produto"
		this.entidadeProjetoEspecial = new ProjetoEspecial();

		// Ini and define "ProdutoIdioma"
		this.entidadeProjetoEspecialIdioma = new ProjetoEspecialIdioma();
		entidadeProjetoEspecialIdioma.ProjetoEspecial = this.entidadeProjetoEspecial;
		this.entidadeProjetoEspecialIdioma.Idioma = new Idioma();
		this.entidadeProjetoEspecialIdioma.Idioma.IdiomaId = this.IdiomaId;

		// Ini service to find "Produto"
		this.projetoEspecialService = new ProjetoEspecialService();
		this.entidadeProjetoEspecial.ProjetoEspecialId = Convert.ToInt32(IdRegistro);
		this.entidadeProjetoEspecial = this.projetoEspecialService.Carregar(entidadeProjetoEspecial);

		// Ini service to find "ProdutoIdioma"
		this.projetoEspecialIdiomaService = new ProjetoEspecialIdiomaService();

		this.entidadeProjetoEspecial.ProjetoEspecialIdiomas = new List<ProjetoEspecialIdioma>();

		// Add "ProdutoIdioma"
		this.entidadeProjetoEspecialIdioma = this.projetoEspecialIdiomaService.Carregar(this.entidadeProjetoEspecialIdioma);
		this.entidadeProjetoEspecial.ProjetoEspecialIdiomas.Add(this.entidadeProjetoEspecialIdioma);

		//Arquivo Thumb
		#region Arquivo Thumb

		if (entidadeProjetoEspecial.ArquivoThumbId != null)
		{
			DataTable dtGrande = new DataTable();
			dtGrande.Columns.Add(new DataColumn("arquivoId", typeof(int)));
			dtGrande.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));

			DataRow drGrande = dtGrande.NewRow();
			Arquivo entidadeArquivo = new Arquivo();

			entidadeArquivo = new ArquivoService().Carregar(entidadeProjetoEspecial.ArquivoThumbId);
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
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{

		// Ini service to "ProjetoEspecial"
		entidadeProjetoEspecial = new ProjetoEspecial();

		// Ini service to "ProjetoEspecialIdioma"
		entidadeProjetoEspecialIdioma = new ProjetoEspecialIdioma();
		entidadeProjetoEspecialIdioma.ProjetoEspecial = new ProjetoEspecial();
		entidadeProjetoEspecialIdioma.Idioma = new Idioma();

		// Ini service to "Arquivo"
		entidadeArquivo = new Arquivo();
		entidadeArquivo.ProdutoImagens = new List<ProdutoImagem>();

		projetoEspecialService = new ProjetoEspecialService();
		projetoEspecialIdiomaService = new ProjetoEspecialIdiomaService();

	}


	#endregion

}
