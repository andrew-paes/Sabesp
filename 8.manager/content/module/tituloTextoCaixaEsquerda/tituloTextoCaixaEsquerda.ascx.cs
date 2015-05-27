using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Ag2.Manager.Helper;
using Sabesp.BO;
using Sabesp.Data;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using System.Xml;

public partial class content_module_tituloTextoCaixaEsquerda_tituloTextoCaixaEsquerda : SmartUserControl
{
	#region [ Properties ]

	protected Controle entidadeControle; // Ini Business Object to "controle"
	protected ControleIdioma entidadeControleIdioma; // Ini Business Object to "controleIdioma"
	protected ControleIdiomaDado entidadeControleIdiomaDado;

	protected ControleService controleService; // Ini Service to "controle"
	protected ControleIdiomaService controleIdiomaService; // Ini Service to "controleIdioma"
	protected ControleIdiomaDadoService controleIdiomaDadoService;

	protected ControleFH controleFH; // Ini FilterHelper to "controle"
	protected ControleIdiomaFH controleIdiomaFH; // Ini FilterHelper to "controleIdioma"
	protected ControleIdiomaDadoFH controleIdiomaDadoFH;

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
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		this.Execute();
	}

	#endregion

	#region [ Properties and Form ]

	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		this.entidadeControle = new Controle(); // Instance Business Object to "controle"
		this.controleService = new ControleService(); // Instance Service to "controle"
		this.controleFH = new ControleFH(); // Instance Filter Helper to "controle"

		this.entidadeControleIdioma = new ControleIdioma(); // Instance Business Object to "controleIdioma"
		this.controleIdiomaService = new ControleIdiomaService(); // Instance Service to "controleIdioma"
		this.controleIdiomaFH = new ControleIdiomaFH(); // Instance Filter Helper to "controleIdioma"

		this.entidadeControleIdiomaDado = new ControleIdiomaDado(); // Instance Business Object to "controleIdiomaDado"
		this.controleIdiomaDadoService = new ControleIdiomaDadoService(); // Instance Service to "controleIdiomaDado"
		this.controleIdiomaDadoFH = new ControleIdiomaDadoFH(); // Instance Filter Helper to "controleIdiomaDado"
	}

	/// <summary>
	/// Load all properties
	/// </summary>
	private void LoadProperties()
	{
		this.entidadeControle.ControleId = Convert.ToInt32(IdRegistro);
		this.entidadeControle = this.controleService.Carregar(entidadeControle); // Find "conteudo" by ID and Add to BO

		this.controleIdiomaFH.ControleId = Convert.ToString(this.entidadeControle.ControleId);
		this.controleIdiomaFH.IdiomaId = Convert.ToString(this.IdiomaId);

		IList<ControleIdioma> entidadeControleIdiomaList = new List<ControleIdioma>();
		entidadeControleIdiomaList = controleIdiomaService.RetornaTodos(0, 0, "", "ASC", this.controleIdiomaFH);

		if (entidadeControleIdiomaList != null && entidadeControleIdiomaList.Count > 0)
		{
			this.entidadeControleIdioma = entidadeControleIdiomaList[0];

			if (this.entidadeControleIdioma != null)
			{
				this.controleIdiomaDadoFH = new ControleIdiomaDadoFH();
				this.controleIdiomaDadoFH.ControleIdiomaId = Convert.ToString(entidadeControleIdioma.ControleIdiomaId);
				IList<ControleIdiomaDado> entidadeControleIdiomaDadoList = new List<ControleIdiomaDado>();
				this.controleIdiomaDadoService = new ControleIdiomaDadoService();
				entidadeControleIdiomaDadoList = this.controleIdiomaDadoService.RetornaTodos(0, 0, "", "", controleIdiomaDadoFH);

				if (entidadeControleIdiomaDadoList != null && entidadeControleIdiomaDadoList.Count > 0)
				{
					this.entidadeControleIdiomaDado = entidadeControleIdiomaDadoList[0];
				}
			}
		}
	}

	/// <summary>
	/// Clear the form
	/// </summary>
	protected void ClearForm()
	{
		//txtTitulo.Text = string.Empty;
	}

	/// <summary>
	/// Get all BO and set on the form
	/// </summary>
	protected void LoadForm()
	{
		this.ClearForm();

		// verifica se os dados do "Controle" foram carregados
		if (this.entidadeControle != null)
		{
			this.txtNomeControle.Text = this.entidadeControle.Nome;

			// Verifica se os dados do "ControleIdioma"
			if (this.entidadeControleIdioma != null)
			{
				this.txtTitulo.Text = this.entidadeControleIdioma.Titulo;

				if (this.entidadeControleIdiomaDado != null)
				{
					this.txtLink.Text = this.entidadeControleIdiomaDado.Link;
					this.htmConteudo.Text = this.entidadeControleIdiomaDado.TextoChamada;

					switch (this.entidadeControleIdiomaDado.Target)
					{
						case "_parent":
							ddlTarget.SelectedIndex = 1;
							break;
						case "_blank":
							ddlTarget.SelectedIndex = 2;
							break;
						default:
							ddlTarget.SelectedIndex = 0;
							break;
					}
				}
			}
		}
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	private bool FormToLoad()
	{
		bool isValid = false;

		// Verify if "Controle" exist
		if (IdRegistro > 0)
		{
			this.entidadeControle.ControleId = Convert.ToInt32(IdRegistro);

			this.entidadeControleIdioma = new ControleIdioma();
			this.entidadeControleIdioma.Controle = new Controle();
			this.entidadeControleIdioma.Controle = this.entidadeControle; // Load "Controle" into "ControleIdioma" BO
			this.entidadeControleIdioma.Idioma = new Idioma();
			this.entidadeControleIdioma.Idioma.IdiomaId = this.IdiomaId;
			this.entidadeControleIdioma.Titulo = txtTitulo.Text;

			this.entidadeControleIdiomaDado.Link = this.txtLink.Text;
			this.entidadeControleIdiomaDado.Target = this.ddlTarget.SelectedValue;
			this.entidadeControleIdiomaDado.TextoChamada = this.htmConteudo.Text;

			isValid = true;
		}

		return isValid;
	}

	#endregion

	#region [ Execute, Save and Update ]

	/// <summary>
	/// Execute transaction to insert or save "Sessao"
	/// </summary>
	private void Execute()
	{
		if (this.FormToLoad())
		{
			try
			{
				// Verify if have any register in "ControleIdioma" by "controleId" and "idiomaId" in "ControleIdioma"
				if (ControleIdiomaExiste())
				{
					this.Update();
					Util.ShowMessage("Registro atualizado com sucesso!");
				}
				else
				{
					this.Save();
					Util.ShowMessage("Registro salvo com sucesso!");
				}

				this.SaveWorkflow(); // Update "controleIdioma"
			}
			catch (Exception e)
			{
				string execption = string.Empty;
				Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde! Erro: " + e.ToString());
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	private bool ControleIdiomaExiste()
	{
		bool exist = false;

		// The FH was instanced in DefineProperties()
		this.controleIdiomaFH.IdiomaId = Convert.ToString(this.entidadeControleIdioma.Idioma.IdiomaId); // Load ID language to FH
		this.controleIdiomaFH.ControleId = Convert.ToString(this.entidadeControle.ControleId); // Load "controleId" to FH
		IList<ControleIdioma> entidadeControleIdiomaList = new List<ControleIdioma>();
		controleIdiomaService = new ControleIdiomaService();
		entidadeControleIdiomaList = controleIdiomaService.RetornaTodos(0, 0, "", "ASC", this.controleIdiomaFH);

		if (entidadeControleIdiomaList != null && entidadeControleIdiomaList.Count > 0)
		{
			this.entidadeControleIdioma.ControleIdiomaId = entidadeControleIdiomaList[0].ControleIdiomaId; // Set the "controleIdiomaId"
			exist = true;
		}

		return exist;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	private bool ControleIdiomaDadoExiste()
	{
		bool exist = false;

		this.entidadeControleIdiomaDado.ControleIdioma = new ControleIdioma();
		this.entidadeControleIdiomaDado.ControleIdioma = this.entidadeControleIdioma;

		this.controleIdiomaDadoFH.ControleIdiomaId = Convert.ToString(this.entidadeControleIdiomaDado.ControleIdioma.ControleIdiomaId);
		this.controleIdiomaDadoService = new ControleIdiomaDadoService();
		IList<ControleIdiomaDado> entidadeControleIdiomaDadoList = new List<ControleIdiomaDado>();
		entidadeControleIdiomaDadoList = controleIdiomaDadoService.RetornaTodos(0, 0, "", "ASC", this.controleIdiomaDadoFH);

		if (entidadeControleIdiomaDadoList != null && entidadeControleIdiomaDadoList.Count > 0)
		{
			this.entidadeControleIdiomaDado.ControleIdiomaDadoId = entidadeControleIdiomaDadoList[0].ControleIdiomaDadoId;
			exist = true;
		}

		return exist;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
		// Update "controleIdioma"
		this.controleIdiomaService.Atualizar(this.entidadeControleIdioma);

		SalvaAtualizaControleIdiomaDado();
	}

	protected void Save()
	{
		this.controleIdiomaService.Inserir(this.entidadeControleIdioma);

		if (this.entidadeControleIdioma != null && this.entidadeControleIdioma.ControleIdiomaId > 0)
		{
			this.entidadeControleIdiomaDado.ControleIdioma = new ControleIdioma();
			this.entidadeControleIdiomaDado.ControleIdioma.ControleIdiomaId = this.entidadeControleIdioma.ControleIdiomaId;
			this.SalvaAtualizaControleIdiomaDado();
		}
	}

	private void SalvaAtualizaControleIdiomaDado()
	{
		// Verify if exist "ControleIdiomaDado" by "controleIdiomaId"
		if (ControleIdiomaDadoExiste())
		{
			this.controleIdiomaDadoService.Atualizar(this.entidadeControleIdiomaDado);
		}
		else
		{
			this.controleIdiomaDadoService.Inserir(this.entidadeControleIdiomaDado);
		}
	}

	private void SaveWorkflow()
	{
		if (this.entidadeControleIdioma != null && this.entidadeControleIdioma.ControleIdiomaId > 0)
		{
			int wId = WorkflowUtil.SaveWorkflow(this.IdWorkflow
												, StatusWorkflow1
												, this.entidadeControleIdioma.ControleIdiomaId
												, this.txtTitulo.Text
												, this.ModuleName, "ControleIdioma");

			if (wId > 0)
			{
				if (this.IdRegistro > 0)
				{
					Util.ShowUpdateMessage();
					this.LoadProperties();
					this.LoadForm();
					this.StatusWorkflow1.DataBind();
				}
				else
				{
					Util.ShowInsertMessage();
					Response.Redirect(String.Concat("edit.aspx?md="
													, this.ModuleName
													, "&id="
													, this.entidadeControleIdioma.ControleIdiomaId
													, "&wid="
													, wId), false);
				}
			}
			else
			{
				Util.ShowMessage("Erro ao associar workflow");
			}
		}
	}

	#endregion
}