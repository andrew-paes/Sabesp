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

public partial class content_module_tituloLinkZebrado_tituloLinkZebrado : SmartUserControl
{
	#region [ Properties ]

	protected Controle entidadeControle; // Ini Business Object to "controle"
	protected ControleIdioma entidadeControleIdioma; // Ini Business Object to "controleIdioma"
	protected ControleIdiomaDado entidadeControleIdiomaDado; // Ini Business Object to "controleIdiomaDado"

	protected ControleService controleService; // Ini Service to "controle"
	protected ControleIdiomaService controleIdiomaService; // Ini Service to "controleIdioma"
	protected ControleIdiomaDadoService controleIdiomaDadoService; // Ini Service to "controleIdiomaDado"

	protected ControleFH controleFH; // Ini FilterHelper to "controle"
	protected ControleIdiomaFH controleIdiomaFH; // Ini FilterHelper to "controleIdioma"
	protected ControleIdiomaDadoFH controleIdiomaDadoFH; // Ini FilterHelper to "controleIdiomaDado"

	public DataTable DT
	{
		get
		{
			return (DataTable)ViewState["dt"];
		}
		set
		{
			ViewState["dt"] = value;
		}
	}

	public int RowsCount
	{
		get
		{
			if (ViewState["RowsCount"] == null)
			{
				ViewState["RowsCount"] = 0;
			}
			return (int)ViewState["RowsCount"];
		}
		set
		{
			ViewState["RowsCount"] = value;
		}
	}

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

	#region [ GriView ]
	/// <summary>
	/// 
	/// </summary>
	private void InitGridView()
	{
		this.DT = new DataTable();
		this.DT.Columns.Add(new DataColumn("Subtitulo", typeof(string)));
		this.DT.Columns.Add(new DataColumn("Texto", typeof(string)));
		this.DT.Columns.Add(new DataColumn("Link", typeof(string)));
		this.DT.Columns.Add(new DataColumn("Janela", typeof(string)));
		this.DT.Columns.Add(new DataColumn("idGridView", typeof(int)));

		this.BindGridView();
	}

	/// <summary>
	/// 
	/// </summary>
	private void BindGridView()
	{
		txtSubtitulo.Text = string.Empty;
		txtTexto.Text = string.Empty;
		txtLink.Text = string.Empty;
		ddlTarget.SelectedIndex = 0;

		gdvTituloTextoLink.DataSource = this.DT;
		gdvTituloTextoLink.DataBind();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnIncluir_Click(object sender, ImageClickEventArgs e)
	{
		if (this.DT != null)
		{
			// Verify if have a row selected
			if (!String.IsNullOrEmpty(hddIdGridView.Value) && Convert.ToInt32(hddIdGridView.Value) > 0)
			{
				this.EditRow();
			}
			else
			{
				this.AddRow();
			}

			this.BindGridView();
		}
	}

	/// <summary>
	/// Add new row to Grid View
	/// </summary>
	private void AddRow()
	{
		if (!String.IsNullOrEmpty(txtTexto.Text))
		{
			DataRow drow = this.DT.NewRow();
			drow["Subtitulo"] = txtSubtitulo.Text;
			drow["Texto"] = txtTexto.Text;
			drow["Link"] = txtLink.Text;
			drow["Janela"] = ddlTarget.SelectedValue;
			drow["idGridView"] = ++this.RowsCount;
			this.DT.Rows.Add(drow);
		}
	}

	/// <summary>
	/// Add new row to Grid View
	/// </summary>
	private void AddRow(ControleIdiomaDado entidadeParam)
	{
		DataRow drow = this.DT.NewRow();
		drow["Subtitulo"] = entidadeParam.Subtitulo;
		drow["Texto"] = entidadeParam.TextoChamada;
		drow["Link"] = entidadeParam.Link;
		drow["Janela"] = entidadeParam.Target;
		drow["idGridView"] = ++this.RowsCount;
		this.DT.Rows.Add(drow);
	}

	/// <summary>
	/// 
	/// </summary>
	private void EditRow()
	{
		for (int i = 0; i < this.DT.Rows.Count; i++)
		{
			if (Convert.ToString(this.DT.Rows[i]["idGridView"]).Equals(hddIdGridView.Value))
			{
				if (!String.IsNullOrEmpty(txtTexto.Text))
				{
					DataRow drow = this.DT.NewRow();
					this.DT.Rows[i]["Subtitulo"] = txtSubtitulo.Text;
					this.DT.Rows[i]["Texto"] = txtTexto.Text;
					this.DT.Rows[i]["Link"] = txtLink.Text;
					this.DT.Rows[i]["Janela"] = ddlTarget.SelectedValue;
					
					hddIdGridView.Value = "0";
					gdvTituloTextoLink.SelectedIndex = -1;
				}
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void gdvTituloTextoLink_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.DT.Rows.RemoveAt(e.RowIndex);
		gdvTituloTextoLink.DataSource = this.DT;
		gdvTituloTextoLink.DataBind();
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void gdvTituloTextoLink_SelectedIndexChanged(object sender, EventArgs e)
	{
		hddIdGridView.Value = gdvTituloTextoLink.SelectedValue.ToString();
		txtSubtitulo.Text = gdvTituloTextoLink.SelectedDataKey["Subtitulo"].ToString();
		txtTexto.Text = gdvTituloTextoLink.SelectedDataKey["Texto"].ToString();
		txtLink.Text = gdvTituloTextoLink.SelectedDataKey["Link"].ToString();

		if (!String.IsNullOrEmpty(gdvTituloTextoLink.SelectedDataKey["Janela"].ToString()))
		{
			switch (gdvTituloTextoLink.SelectedDataKey["Janela"].ToString())
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

	#endregion

	#region [ Properties and Form ]

	/// <summary>
	/// Clear the form
	/// </summary>
	protected void ClearForm()
	{
		//txtTitulo.Text = string.Empty;
	}

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

		// verify if exist an "controleIdioma" to this "controle"
		if (entidadeControleIdiomaList != null && entidadeControleIdiomaList.Count > 0)
		{
			this.entidadeControleIdioma = entidadeControleIdiomaList[0];

			// Instance FH to search and return a list of "controleIdiomaDado"
			this.controleIdiomaDadoFH = new ControleIdiomaDadoFH();
			this.controleIdiomaDadoFH.ControleIdiomaId = Convert.ToString(entidadeControleIdioma.ControleIdiomaId);
			IList<ControleIdiomaDado> entidadeControleIdiomaDadoList = new List<ControleIdiomaDado>();
			this.controleIdiomaDadoService = new ControleIdiomaDadoService();
			entidadeControleIdiomaDadoList = this.controleIdiomaDadoService.RetornaTodos(0, 0, "", "", controleIdiomaDadoFH); // Search and instance a list of "controleIdiomaDado"

			// Verify if exist a list of "controleIdiomaDado"
			if (entidadeControleIdiomaDadoList != null && entidadeControleIdiomaDadoList.Count > 0)
			{
				this.entidadeControleIdioma.ControleIdiomaDados = new List<ControleIdiomaDado>();

				foreach (ControleIdiomaDado entidadeControleIdiomaDadoTemp in entidadeControleIdiomaDadoList)
				{
					this.entidadeControleIdioma.ControleIdiomaDados.Add(entidadeControleIdiomaDadoTemp);
				}
			}
		}
	}

	/// <summary>
	/// Get all BO and set on the form
	/// </summary>
	protected void LoadForm()
	{
		this.ClearForm();

		this.InitGridView();

		// verifica se os dados do "Controle" foram carregados
		if (this.entidadeControle != null)
		{
			this.txtNomeControle.Text = this.entidadeControle.Nome;

			// Verify exist data to "ControleIdioma"
			if (this.entidadeControleIdioma != null)
			{
				this.txtTitulo.Text = this.entidadeControleIdioma.Titulo;

				// Verify exist a list of "ControleIdiomaDado"
				if (this.entidadeControleIdioma.ControleIdiomaDados != null && this.entidadeControleIdioma.ControleIdiomaDados.Count > 0)
				{
					foreach (ControleIdiomaDado entidadeControleIdiomaDadoTemp in this.entidadeControleIdioma.ControleIdiomaDados)
					{
						this.AddRow(entidadeControleIdiomaDadoTemp); // Add a new row to GridView
					}

					this.BindGridView();
				}
			}
		}
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	private void FormToLoad()
	{
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
			this.entidadeControleIdioma.ControleIdiomaDados = new List<ControleIdiomaDado>();

			for (int i = 0; i < this.DT.Rows.Count; i++)
			{
				entidadeControleIdiomaDado = new ControleIdiomaDado();
				DataRow drow = this.DT.NewRow();

				entidadeControleIdiomaDado.Subtitulo = this.DT.Rows[i]["Subtitulo"].ToString();
				entidadeControleIdiomaDado.TextoChamada = this.DT.Rows[i]["Texto"].ToString();
				entidadeControleIdiomaDado.Link = this.DT.Rows[i]["Link"].ToString();
				entidadeControleIdiomaDado.Target = this.DT.Rows[i]["Janela"].ToString();

				this.entidadeControleIdioma.ControleIdiomaDados.Add(entidadeControleIdiomaDado);
			}
		}
	}

	#endregion

	#region [ Execute, Save and Update ]

	/// <summary>
	/// Execute transaction to insert or save "Sessao"
	/// </summary>
	private void Execute()
	{
		try
		{
			if (this.DT != null && this.DT.Rows.Count > 0)
			{
				this.FormToLoad();

				// Verify if have any register in "ControleIdioma" by "controleId" and "idiomaId" in "ControleIdioma"
				if (ControleIdiomaExiste())
				{
					this.Update();
					this.LoadForm();
					Util.ShowMessage("Registro atualizado com sucesso!");
				}
				else
				{
					this.Save();
					Util.ShowMessage("Registro salvo com sucesso!");
				}

				this.SaveWorkflow(); // Update "controleIdioma"
			}
			else
			{
				Util.ShowMessage("Deve ser incluido pelo menos um item na lista!");
			}
		}
		catch (Exception e)
		{
			string execption = string.Empty;
			Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde! Erro: " + e.ToString());
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
	protected void Save()
	{
		// Insert "controleIdioma"
		this.controleIdiomaService.Inserir(this.entidadeControleIdioma);

		SalvaControleIdiomaDado();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
		// Update "controleIdioma"
		this.controleIdiomaService.Atualizar(this.entidadeControleIdioma);

		SalvaControleIdiomaDado();
	}

	/// <summary>
	/// 
	/// </summary>
	private void SalvaControleIdiomaDado()
	{
		if (this.entidadeControleIdioma != null && this.entidadeControleIdioma.ControleIdiomaId > 0)
		{
			// Delete all "controleIdiomaDado"
			this.controleIdiomaDadoService.ExcluirRelacionados(this.entidadeControleIdioma);

			foreach (ControleIdiomaDado entidadeControleIdiomaDadoTemp in this.entidadeControleIdioma.ControleIdiomaDados)
			{
				entidadeControleIdiomaDadoTemp.ControleIdioma = new ControleIdioma();
				entidadeControleIdiomaDadoTemp.ControleIdioma = entidadeControleIdioma;

				this.controleIdiomaDadoService.Inserir(entidadeControleIdiomaDadoTemp);
			}
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