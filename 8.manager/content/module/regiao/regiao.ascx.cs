using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using Ag2.Manager.Helper;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

public partial class content_module_regiao_regiao : SmartUserControl
{
	#region [ Properties ]

	public Database db = DatabaseFactory.CreateDatabase();

	/// <summary>
	/// Business Object for "Regiao" fields
	/// </summary>
	protected Regiao entidadeRegiao;
	/// <summary>
	/// Business Object for "Municipio" fields
	/// </summary>
	protected Municipio entidadeMunicipio;
	/// <summary>
	///   Service for "Regiao" 
	/// </summary>
	protected RegiaoService regiaoService;
	/// <summary>
	///   Service for "MunicipioService" 
	/// </summary>
	protected MunicipioService municipioService;
	/// <summary>
	///  Filter for "regiaoFH" to search BO for tags
	/// </summary>
	protected RegiaoFH regiaoFH;
	/// <summary>
	///  Filter for "MunicipioFH" to search BO for tags
	/// </summary>
	protected MunicipioFH municipioFH;
	/// <summary>
	/// List to keep all checked "municipios" to be inserted
	/// </summary>
	protected IList<Municipio> entidadeMunicipioList;

	#endregion

	#region [ Page Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
		//Initialize properties n services
		this.DefineProperties();

		if (!Page.IsPostBack)
		{
			this.CarregarMunicipio();
		}

		// check if new register
		if (this.IdRegistro > 0)
		{
			if (!IsPostBack)
			{
				this.LoadProperties();
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

	#region [ Use Properties ]
	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		// Ini service to "Regiao"
		entidadeRegiao = new Regiao();
		entidadeRegiao.Municipio = new List<Municipio>();

		// Ini service to "Municipio"
		entidadeMunicipio = new Municipio();

		regiaoService = new RegiaoService();
		municipioService = new MunicipioService();
	}

	/// <summary>
	/// Load all properties
	/// </summary>
	private void LoadProperties()
	{
		// Ini service to find and add "Regiao"
		entidadeRegiao = new Regiao();
		if (IdRegistro > 0)
		{
			entidadeRegiao.RegiaoId = Convert.ToInt32(IdRegistro);
		}
		entidadeRegiao = new RegiaoService().Carregar(entidadeRegiao);
	}

	#endregion

	#region Form

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		if (entidadeRegiao != null && entidadeRegiao.RegiaoId > 0)
		{
			txtTitulo.Text = entidadeRegiao.NomeRegiao;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void ClearForm()
	{
		txtTitulo.Text = string.Empty;
	}

	/// <summary>
	/// Lista todos os itens que não estão na lista de destino
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ddlPesquisaMunicipio_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!String.IsNullOrEmpty(ddlPesquisaMunicipio.SelectedValue))
		{
			//// Dados do segmento
			string sql = string.Format(@"SELECT 
                                            *
                                    FROM 
                                            Municipio 
                                    WHERE 
		                                    nome LIKE '{0}%'
                                    ORDER BY 
                                            nome", ddlPesquisaMunicipio.SelectedValue);
			DbCommand dataProc = db.GetSqlStringCommand(sql);
			//db.AddInParameter(dataProc, "@nome", DbType.String, ddlPesquisaMunicipio.SelectedValue);
			DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

			if (dt.Rows.Count > 0)
			{
				lstOrigem.DataSource = dt;
				lstOrigem.DataValueField = "municipioId";
				lstOrigem.DataTextField = "nome";
				lstOrigem.DataBind();
			}

			RemoverOrigem();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnAdicionar_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < lstOrigem.Items.Count; i++)
		{
			if (lstOrigem.Items[i].Selected)
			{
				ListItem lstItem = new ListItem();

				lstItem.Value = lstOrigem.Items[i].Value;
				lstItem.Text = lstOrigem.Items[i].Text;

				lstDestino.Items.Add(lstItem);
			}
		}

		ReordenarDestino();
		RemoverOrigem();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnAdicionarT_Click(object sender, EventArgs e)
	{
		foreach (ListItem lst in lstOrigem.Items)
		{
			lstDestino.Items.Add(lst);
		}
		lstOrigem.Items.Clear();

		ReordenarDestino();
	}

	/// <summary>
	/// Remove da lista de destino os itens selecionados
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnRemover_Click(object sender, EventArgs e)
	{
		List<ListItem> items = new List<ListItem>();

		for (int i = 0; i < lstDestino.Items.Count; i++)
		{
			if (lstDestino.Items[i].Selected)
			{
				items.Add(new ListItem(lstDestino.Items[i].Text, lstDestino.Items[i].Value));
			}
		}

		foreach (ListItem item in items)
		{
			lstDestino.Items.Remove(item);
		}

		lstDestino.SelectedIndex = -1;

		ddlPesquisaMunicipio_SelectedIndexChanged(sender, e);

		lblSelecionadas.Text = "Selecionados (" + Convert.ToString(lstDestino.Items.Count) + " cursos)";
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnRemoverT_Click(object sender, EventArgs e)
	{
		lstDestino.Items.Clear();

		ddlPesquisaMunicipio_SelectedIndexChanged(sender, e);
	}

	/// <summary>
	/// Reordena por ordem do nome dos municipios na lista de destino a cada nova inserção
	/// </summary>
	protected void ReordenarDestino()
	{
		string municipioId = "0";

		for (int i = 0; i < lstDestino.Items.Count; i++)
		{
			municipioId += "," + lstDestino.Items[i].Value;
		}

		// Dados do municipio
		string sql = string.Format(@"SELECT 
                                            *
                                    FROM 
                                            Municipio 
                                    WHERE 
		                                    municipioId IN ({0})
                                    ORDER BY 
                                            nome", municipioId);
		DbCommand dataProc = db.GetSqlStringCommand(sql);
		//db.AddInParameter(dataProc, "@municipioId", DbType.String, municipioId);
		DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

		if (dt.Rows.Count > 0)
		{
			lblSelecionadas.Text = "Selecionados (" + Convert.ToString(dt.Rows.Count) + " municípios)";

			lstDestino.DataSource = dt;
			lstDestino.DataValueField = "municipioId";
			lstDestino.DataTextField = "nome";
			lstDestino.DataBind();
		}
	}

	/// <summary>
	/// Remove da lista de origem todo os itens que estão na lista de destino
	/// </summary>
	protected void RemoverOrigem()
	{
		for (int i = 0; i < lstDestino.Items.Count; i++)
		{
			ListItem lstItem = new ListItem();

			lstItem.Value = lstDestino.Items[i].Value;
			lstItem.Text = lstDestino.Items[i].Text;

			lstOrigem.Items.Remove(lstItem);
		}

		//lstOrigem.Items.Remove(lstOrigem.SelectedItem);
		lstDestino.SelectedIndex = -1;
		lstOrigem.SelectedIndex = -1;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void CarregarMunicipio()
	{
		string sql = @"SELECT 
                                Municipio.municipioId
		                        , Municipio.nome
                        FROM 
                                Municipio 
								INNER JOIN RegiaoMunicipio ON RegiaoMunicipio.municipioId = Municipio.municipioId
		                        INNER JOIN Regiao ON Regiao.regiaoId = RegiaoMunicipio.regiaoId
						WHERE 
								Regiao.regiaoId = @regiaoId
                        ORDER BY 
                                Municipio.nome";
		DbCommand dataProc = db.GetSqlStringCommand(sql);
		db.AddInParameter(dataProc, "@regiaoId", DbType.String, IdRegistro);
		DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

		if (dt.Rows.Count > 0)
		{
			lblSelecionadas.Text = "Selecionados (" + Convert.ToString(dt.Rows.Count) + " municípios)";

			lstDestino.DataSource = dt;
			lstDestino.DataValueField = "municipioId";
			lstDestino.DataTextField = "nome";
			lstDestino.DataBind();
		}
	}

	#endregion

	#region Execute, Save and Update

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected void FormToLoad()
	{
		entidadeRegiao = new Regiao();

		// Carrega "Região"
		if (!String.IsNullOrEmpty(txtTitulo.Text))
		{
			entidadeRegiao.NomeRegiao = txtTitulo.Text;
		}

		entidadeMunicipioList = new List<Municipio>();

		for (int i = 0; i < lstDestino.Items.Count; i++)
		{
			entidadeMunicipio = new Municipio();

			entidadeMunicipio.MunicipioId = Convert.ToInt32(lstDestino.Items[i].Value);
			entidadeMunicipioList.Add(entidadeMunicipio);
		}

		if (IdRegistro > 0)
		{
			entidadeRegiao.RegiaoId = Convert.ToInt32(IdRegistro);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	private void Execute()
	{
		// Carrega os objetos para poder salvar ou alterar
		this.FormToLoad();

		if (entidadeMunicipioList != null && entidadeMunicipioList.Count > 0)
		{
			try
			{
				if (entidadeRegiao != null && entidadeRegiao.RegiaoId > 0)
				{
					if (entidadeRegiao.NomeRegiao != null)
					{
						this.Update();
						Util.ShowMessage("Registro alterado com sucesso!");
					}
				}
				else
				{
					this.Save();
					Util.ShowMessage("Registro salvo com sucesso!");
				}

				Response.Redirect("../content/edit.aspx?md=regiao&id=" + this.entidadeRegiao.RegiaoId.ToString() + "&lg=" + this.IdiomaId + "&wid=");

			}
			catch
			{
				Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde!");
			}
		}
		else
		{
			Util.ShowMessage("Deve ser relacionado pelo menos um município.");
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Save()
	{
		// Save "Regiao"
		new RegiaoService().Inserir(entidadeRegiao);

		if (entidadeRegiao != null && entidadeRegiao.RegiaoId > 0 && entidadeMunicipioList != null && entidadeMunicipioList.Count > 0)
		{
			// Save "RegiaoMunicipio"
			for (int i = 0; i < entidadeMunicipioList.Count; i++)
			{
				new RegiaoService().InserirRelacionado(entidadeRegiao, Convert.ToInt32(entidadeMunicipioList[i].MunicipioId));
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
		// Update "Regiao"
		regiaoService.Atualizar(entidadeRegiao);

		regiaoService.ExcluirRelacionado(entidadeRegiao.RegiaoId); //Exclui o relacionamento entre Municipio e Regiao para inserir atualizado

		if (entidadeRegiao != null && entidadeRegiao.RegiaoId > 0 && entidadeMunicipioList != null && entidadeMunicipioList.Count > 0)
		{
			// Save "RegiaoMunicipio"
			for (int i = 0; i < entidadeMunicipioList.Count; i++)
			{
				new RegiaoService().InserirRelacionado(entidadeRegiao, Convert.ToInt32(entidadeMunicipioList[i].MunicipioId));
			}
		}
	}

	#endregion

	#endregion
}
