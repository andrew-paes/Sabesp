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

public partial class content_module_municipio_municipio : SmartUserControl
{
	#region [ Properties ]

	protected Municipio municipioBO; // Ini Business Object to "municipio"
	protected MunicipioAba municipioAbaBO; // Ini Business Object to "municipioAba"

	protected MunicipioService municipioService; // Ini Service to "municipio"
	protected MunicipioAbaService municipioAbaService; // Ini Service to "municipioAba"

	protected MunicipioFH municipioFH; // Ini FilterHelper to "municipio"
	protected MunicipioAbaFH municipioAbaFH; // Ini FilterHelper to "municipioAba"

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

	List<int> AbasRemovidas
	{
		get
		{
			if (ViewState["AbasRemovidas"] == null)
			{
				ViewState["AbasRemovidas"] = new List<int>();
			}
			return (List<int>)ViewState["AbasRemovidas"];
		}
		set
		{
			ViewState["AbasRemovidas"] = value;
		}
	}

	#endregion

	#region [ Page Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
		this.DefineProperties();

		if (!IsPostBack)
		{
			this.InitGridView();

			if (this.IdRegistro > 0)
			{
				this.LoadProperties();
				this.LoadForm();

				if (Request.QueryString["showmessage"] != null && Convert.ToString(Request.QueryString["showmessage"]).Equals("1"))
				{
					Util.ShowMessage("Registro salvo com sucesso!");
				}
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
		this.DT.Columns.Add(new DataColumn("Titulo", typeof(string)));
		this.DT.Columns.Add(new DataColumn("Texto", typeof(string)));
        this.DT.Columns.Add(new DataColumn("Ativo", typeof(string)));

		this.DT.Columns.Add(new DataColumn("idGridView", typeof(int)));
		this.DT.Columns.Add(new DataColumn("idAbaDB", typeof(int)));
		this.BindGridView();
	}

	/// <summary>
	/// 
	/// </summary>
	private void BindGridView()
	{
		txtTituloAba.Text = string.Empty;
		htmTextoAba.Text = string.Empty;
        chbAtivo.Checked = false;
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
		if (!String.IsNullOrEmpty(txtTituloAba.Text))
		{
			DataRow drow = this.DT.NewRow();
			drow["Titulo"] = txtTituloAba.Text;
			drow["Texto"] = htmTextoAba.Text;
            drow["Ativo"] = (chbAtivo.Checked == true ? "Sim" : "Não");

			drow["idGridView"] = ++this.RowsCount;
			drow["idAbaDB"] = -1;
			this.DT.Rows.Add(drow);
		}
	}

	/// <summary>
	/// Add new row to Grid View
	/// </summary>
	private void AddRow(MunicipioAba entidadeParam)
	{
		DataRow drow = this.DT.NewRow();
		drow["Titulo"] = entidadeParam.TituloAba;
		drow["Texto"] = entidadeParam.TextoAba;
        drow["Ativo"] = (entidadeParam.Ativo==true ? "Sim":"Não") ;
		drow["idGridView"] = ++this.RowsCount;
		drow["idAbaDB"] = entidadeParam.MunicipioAbaId;
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
				if (!String.IsNullOrEmpty(txtTituloAba.Text))
				{
					DataRow drow = this.DT.NewRow();
					this.DT.Rows[i]["Titulo"] = txtTituloAba.Text;
					this.DT.Rows[i]["Texto"] = htmTextoAba.Text;
                    this.DT.Rows[i]["Ativo"] = (chbAtivo.Checked == true ? "Sim" : "Não");
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
		this.AbasRemovidas.Add(Convert.ToInt32(this.DT.Rows[e.RowIndex]["idAbaDB"]));
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
		txtTituloAba.Text = gdvTituloTextoLink.SelectedDataKey["Titulo"].ToString();
		htmTextoAba.Text = gdvTituloTextoLink.SelectedDataKey["Texto"].ToString();
        chbAtivo.Checked = (gdvTituloTextoLink.SelectedDataKey["Ativo"].ToString().Equals("Sim") ? true : false);
	}

	#endregion

	#region [ Properties and Form ]

	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		this.municipioBO = new Municipio(); // Instance Business Object to "municipio"
		this.municipioService = new MunicipioService(); // Instance Service to "municipio"
		this.municipioFH = new MunicipioFH(); // Instance Filter Helper to "municipio"

		this.municipioAbaBO = new MunicipioAba(); // Instance Business Object to "municipioAba"
		this.municipioAbaService = new MunicipioAbaService(); // Instance Service to "municipioAba"
		this.municipioAbaFH = new MunicipioAbaFH(); // Instance Filter Helper to "municipioAba"
	}

	/// <summary>
	/// Load all properties
	/// </summary>
	private void LoadProperties()
	{
		this.municipioBO.MunicipioId = Convert.ToInt32(IdRegistro);
		this.municipioBO = this.municipioService.Carregar(municipioBO); // Find "municipio" by ID and Add to BO

		this.municipioAbaFH.MunicipioId = Convert.ToString(this.municipioBO.MunicipioId);

		IList<MunicipioAba> munucipioAbaBOList = new List<MunicipioAba>();
		munucipioAbaBOList = municipioAbaService.RetornaTodos(0, 0, "", "ASC", this.municipioAbaFH);

		// verify if exist an "municipioAba" to this "municipio"
		if (munucipioAbaBOList != null && munucipioAbaBOList.Count > 0)
		{
			this.municipioBO.MunicipioAbas = new List<MunicipioAba>(); ;

			foreach (MunicipioAba munucipioAbaBOTemp in munucipioAbaBOList)
			{
				this.municipioBO.MunicipioAbas.Add(munucipioAbaBOTemp);
			}
		}
	}

	/// <summary>
	/// Get all BO and set on the form
	/// </summary>
	protected void LoadForm()
	{
		// verifica se os dados do "Controle" foram carregados
		if (this.municipioBO != null)
		{
			this.txtMunicipio.Text = this.municipioBO.Nome;
			this.uplField.FileName = this.municipioBO.Imagem;
			this.htmMunicipio.Text = this.municipioBO.Texto;

			// Verify exist data to "ControleIdioma"
			if (this.municipioBO.MunicipioAbas != null && this.municipioBO.MunicipioAbas.Count > 0)
			{
				foreach (MunicipioAba munucipioAbaBOTemp in this.municipioBO.MunicipioAbas)
				{
					this.AddRow(munucipioAbaBOTemp); // Add a new row to GridView
				}

				this.BindGridView();
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
			this.municipioBO.MunicipioId = Convert.ToInt32(IdRegistro);
		}

		this.municipioBO.Nome = this.txtMunicipio.Text;
		this.municipioBO.Imagem = this.uplField.FileName;
		this.municipioBO.Texto = this.htmMunicipio.Text;
		this.municipioBO.MunicipioAbas = new List<MunicipioAba>();

		for (int i = 0; i < this.DT.Rows.Count; i++)
		{
			municipioAbaBO = new MunicipioAba();
			DataRow drow = this.DT.NewRow();

			if (Convert.ToInt32(this.DT.Rows[i]["idAbaDB"]) > 0)
			{
				municipioAbaBO.MunicipioAbaId = Convert.ToInt32(this.DT.Rows[i]["idAbaDB"]);
			}
			municipioAbaBO.TituloAba = this.DT.Rows[i]["Titulo"].ToString();
			municipioAbaBO.TextoAba = this.DT.Rows[i]["Texto"].ToString();
            municipioAbaBO.Ativo = (this.DT.Rows[i]["Ativo"].ToString().Equals("Sim") ? true : false);
			this.municipioBO.MunicipioAbas.Add(municipioAbaBO);
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
			this.FormToLoad();

			// Verify if have any register in "Municipio" by "municipioId"
			if (this.municipioBO.MunicipioId > 0)
			{
				this.Update();
				Util.ShowMessage("Registro atualizado com sucesso!");
			}
			else
			{
				this.Save();

				Response.Redirect(String.Concat(Request.Url.AbsoluteUri, "&id=", municipioBO.MunicipioId, "&showmessage=1"));
			}

            this.InitGridView();
            this.LoadForm();				
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
	protected void Save()
	{
		// Insert "controleIdioma"
		this.municipioService.Inserir(this.municipioBO);

		SalvaGridView();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
        

		// Update "controleIdioma"
		this.municipioService.Atualizar(this.municipioBO);

		SalvaGridView();
	}

	/// <summary>
	/// 
	/// </summary>
	private void SalvaGridView()
	{
		if (this.municipioBO.MunicipioId > 0)
		{
			//exclui as abas
			foreach (int mAba in this.AbasRemovidas)
			{
				this.municipioAbaService.Excluir(new MunicipioAba() { MunicipioAbaId = mAba });
			}

			foreach (MunicipioAba munucipioAbaBOTemp in this.municipioBO.MunicipioAbas)
			{
				munucipioAbaBOTemp.Municipio = new Municipio();
				munucipioAbaBOTemp.Municipio.MunicipioId = this.municipioBO.MunicipioId;

				//atualiza se aba ja existir
				if (munucipioAbaBOTemp.MunicipioAbaId > 0)
				{
					this.municipioAbaService.Atualizar(munucipioAbaBOTemp);
				}
				else //insere se a aba nao existir
				{
					this.municipioAbaService.Inserir(munucipioAbaBOTemp);
				}
			}
		}
	}
	#endregion
}