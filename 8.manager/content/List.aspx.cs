using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Reflection;
using Ag2.Manager.Module;
using Ag2.Manager.Module.Info;
using Ag2.Manager.BusinessObject;
using Ag2.Manager.WebUI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

public partial class content_List : ManagerPage
{
	//nome do modulo requisitado
	string _moduleName;
	bool _filterData;
	bool _showFilterBox;
	ManagerModule activeModule;
	Database db = DatabaseFactory.CreateDatabase();
	Ag2.Manager.Helper.CurrentSessions cs = new Ag2.Manager.Helper.CurrentSessions();
	OptionsController optionscontroller = new OptionsController();
	public string LinkEdicao { get; set; }

	protected void Page_Init(object sender, EventArgs e)
	{
		//monta caminho do modulo
		_moduleName = Request.QueryString["md"];

		//Instancia gerenciador de modulos
		activeModule = new ManagerModule();

		//carrega modulo
		activeModule.Load(_moduleName, (Assembly)System.Web.Compilation.BuildManager.CodeAssemblies[0]);

		this.LinkEdicao = "edit.aspx";
		
		string strLinkEdicao = string.Concat(this.LinkEdicao, "?md=", _moduleName);

		//Verificar se possui função de retorno de itens selecionados
		if (!String.IsNullOrEmpty(Request["FuncaoRetorno"]))
		{
			btnRetornarSelecionados.Visible = true;
			strLinkEdicao = string.Concat(strLinkEdicao, "&FuncaoRetorno=", Request["FuncaoRetorno"].ToString());
		}

		if (!String.IsNullOrEmpty(Request["ExibiMaster"]))
		{
			strLinkEdicao = string.Concat(strLinkEdicao, "&ExibiMaster=", Request["ExibiMaster"].ToString());
		}

		lnkNewRegister.NavigateUrl = strLinkEdicao;

		if (activeModule.ModuleStructure.HasListforms)
		{
			activeModule.CarregaListform();
			return;
		}

		//Mostra ou não a barra de idioma
		barraIdioma.Visible = activeModule.ModuleStructure.Multilanguage;

		//verifica se o modulo em questão possui filtros 
		if (activeModule.ModuleStructure.HasFilters)
		{

			//monta filtros          
			for (int i = 0; i < activeModule.ModuleStructure.Filters.Count; i++)
			{
				//adiciona titulo
				HtmlGenericControl divFilter = new HtmlGenericControl("div");
				divFilter.Attributes.Add("class", "filter");
				divFilter.InnerHtml = string.Concat(activeModule.ModuleStructure.Filters[i].Label, "<br />");

				//cria controle
				Control filterControl = CreateFilterControl(activeModule.ModuleStructure.Filters[i]);
				if (filterControl != null)
					divFilter.Controls.Add(filterControl);

				//adiciona controle
				boxFilter.Controls.Add(divFilter);
			}

			//configura botão de filtro
			btnFilter.OnClientClick = string.Format("filterBox('{0}')", IsFilterData.ClientID);
		}
		else
		{
			//remove botão de filtro
			showFilter.Visible = false;
		}

		if (activeModule.ModuleStructure.Options.Count > 0)
		{
			cmbOptions.DataSource = activeModule.ModuleStructure.Options;
			cmbOptions.DataValueField = "QuerySection";
			cmbOptions.DataTextField = "Name";
			cmbOptions.DataBind();
			cmbOptions.Items.Insert(0, new ListItem("Selecione...", ""));
			phOptions.Visible = true;
		}
		else
		{
			phOptions.Visible = false;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		Ag2.Manager.Helper.CurrentSessions cs = new Ag2.Manager.Helper.CurrentSessions();
		cs.ActiveManagerModule = activeModule;

		if (activeModule.ModuleStructure.HasListforms)
		{
			return;
		}

		btnExcluir.Click += new EventHandler(btnExcluir_Click);
		btnExcluir.Attributes.Add("OnClick", "return confirm('Deseja realmente apagar este(s) registro(s)?');");

		//verifica se o box de filtro está sendo exibido
		_showFilterBox = IsShwoFilterBox.Value.Equals("S");
		tableFilter.Style["display"] = _showFilterBox ? "block" : "none";


		//verifica se estra filtrando dados
		_filterData = IsFilterData.Value.Equals("S");

		//verifica configuração de filtros
		if (_filterData)
		{
			//popula filtros com valores
			LoadFilters();

			//verifica se tem dados filtrados
			if (!IsDataFiltered())
			{
				tableFilter.Style["display"] = "none";
				IsFilterData.Value = "N";
				showFilter.ImageUrl = "~/img/btn_aplicar_filtro.gif";
				IsShwoFilterBox.Value = "N";
			}
			else
			{
				tableFilter.Style["display"] = "block";
				showFilter.ImageUrl = "~/img/btn_aplicar_filtro_des.gif";
				IsShwoFilterBox.Value = "S";
			}
		}

		//carrega dados para o datagrid
		DataSet ds = activeModule.GetData();

		DataTable moduleData = ds.Tables[0];

		if (activeModule.ModuleStructure.Multilanguage)
		{
			//LISTA DE IDIOMAS
			managerContent.Idiomas = ds.Tables[1];
		}

		if (!_moduleName.Equals("usuario", StringComparison.OrdinalIgnoreCase))
		{
			if (moduleData.Rows.Count > 0)
			{
				List<Int32> registers = new List<Int32>();
				foreach (DataRow dr in moduleData.Rows)
				{
					registers.Add(Convert.ToInt32(dr[0].ToString()));
				}
				cs.RegisterNavigatorSet(_moduleName, registers);
			}
			else
			{
				cs.RegisterNavigatorSet(_moduleName, null);
			}
		}

		//SETA A CLASSE DO MODULO CORRENTE
		managerContent.ManagerModule = activeModule;

		//se nao for PostBack configura GridView
		if (!IsPostBack)
		{
			//Configura titulo do modulo            
			lblModuleTitle.Text = activeModule.ModuleStructure.Title;

			//configura datagrid
			ConfigureList(managerContent, activeModule.ModuleStructure);

			//configura colunas do datagrid
			managerContent.CreateListColumns();
		}

		pagingBottom.RowsCount = moduleData.Rows.Count;
		managerContent.DataSource = moduleData;
		managerContent.DataBind();

		//efetua configuração de permissões do formulario
		ManagerMenuItem menuItem = new ManagerMenu().SelectedItem;
		ConfigurePagePermission(menuItem);

	}

	void btnExcluir_Click(object sender, EventArgs e)
	{
		List<string> registerDelete = new List<string>();

		foreach (GridViewRow row in managerContent.Rows)
		{
			if (((CheckBox)row.FindControl("chkSelect")).Checked)
				registerDelete.Add(managerContent.DataKeys[row.RowIndex].Value.ToString());
		}

		if (registerDelete.Count > 0)
		{
			ICollection<DeleteRegisterInfo> deleteInfo = activeModule.DeleteData(registerDelete);
			//verifica se tem
			if (deleteInfo.Count > 0)
			{
				IEnumerator<DeleteRegisterInfo> IEn = deleteInfo.GetEnumerator();
				IEn.MoveNext();
				//Page.RegisterStartupScript("scrStatusMessage", "<script>setStatusMessage(\"" + IEn.Current.ErrorMessage + "\",\"true\");</script>");
				Ag2.Manager.Helper.Util.ShowMessage(IEn.Current.ErrorMessage);
			}

			DataTable moduleData = activeModule.GetData().Tables[0];
			managerContent.DataSource = moduleData;
			managerContent.DataBind();
			pagingBottom.RowsCount = moduleData.Rows.Count;
			pagingBottom.showNavigationButtons();
		}
	}

	protected void btnRetornarSelecionados_Click(object sender, EventArgs e)
	{
		List<string> registrosSelecionados = new List<string>();
		BuscaRegistrosSelecionados(registrosSelecionados);


		string strValores = string.Join(",", registrosSelecionados.ToArray());
		string strScript = string.Format("parent.{0}('{1}');", Request["FuncaoRetorno"], strValores);
		ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FuncaoRetorno", strScript, true);

	}

	private void BuscaRegistrosSelecionados(List<string> registrosSelecionados)
	{
		foreach (GridViewRow row in managerContent.Rows)
		{
			if (((CheckBox)row.FindControl("chkSelect")).Checked)
				registrosSelecionados.Add(managerContent.DataKeys[row.RowIndex].Value.ToString());
		}
	}

	public override void VerifyRenderingInServerForm(Control control)
	{
		return;
	}

	protected Control CreateFilterControl(ManagerModuleField filter)
	{
		Control filterControl = null;
		switch (filter.Type)
		{
			case ManagerModuleFieldType.Text:
				filterControl = new TextBox();
				((TextBox)filterControl).ID = string.Concat("filter", filter.Name);

				if (!((ManagerModuleFieldText)filter).InputMask.Equals(string.Empty))
					((TextBox)filterControl).CssClass = string.Format("frmborder {0}", ((ManagerModuleFieldText)filter).InputMask);
				else
					((TextBox)filterControl).CssClass = "frmborder";

				((TextBox)filterControl).Width = 160;
				break;

			case ManagerModuleFieldType.Upload:
				filterControl = new TextBox();
				((TextBox)filterControl).ID = string.Concat("filter", filter.Name);
				((TextBox)filterControl).CssClass = "frmborder";
				((TextBox)filterControl).Width = 160;
				break;

			case ManagerModuleFieldType.ListBox:
				filterControl = new ListBox();
				((ListBox)filterControl).ID = string.Concat("filter", filter.Name);
				((ListBox)filterControl).CssClass = "frmborder";
				((ListBox)filterControl).SelectionMode = ListSelectionMode.Single;
				((ListBox)filterControl).Rows = 1;
				((ListBox)filterControl).DataTextField = ((ManagerModuleFieldListBox)filter).DataTextField;
				((ListBox)filterControl).DataValueField = ((ManagerModuleFieldListBox)filter).DataValueField;

				if (((ManagerModuleFieldListBox)filter).TriggerField == null)
				{
					((ListBox)filterControl).DataSource = activeModule.GetComboData((ManagerModuleFieldListBox)filter);
					((ListBox)filterControl).DataBind();
				}
				((ListBox)filterControl).Items.Insert(0, new ListItem(":: Todos ::", ""));

				if (!((ManagerModuleFieldListBox)filter).FilterListBox.Equals(""))
				{
					((ListBox)filterControl).AutoPostBack = true;
					((ListBox)filterControl).SelectedIndexChanged += new EventHandler(this.ListBoxFilterEvent2);
				}
				break;

			case ManagerModuleFieldType.CheckBox:
				filterControl = new ListBox();
				((ListBox)filterControl).ID = string.Concat("filter", filter.Name);
				((ListBox)filterControl).CssClass = "frmborder";
				((ListBox)filterControl).SelectionMode = ListSelectionMode.Single;
				((ListBox)filterControl).Rows = 1;
				((ListBox)filterControl).Items.Add(new ListItem(":: todos ::", ""));
				((ListBox)filterControl).Items.Add(new ListItem("Sim", "1"));
				((ListBox)filterControl).Items.Add(new ListItem("Não", "0"));
				break;

			case ManagerModuleFieldType.Date:
				filterControl = new DateField();
				((DateField)filterControl).ID = string.Concat("filter", filter.Name);
				((DateField)filterControl).CssClass = "dateField frmborder";
				((DateField)filterControl).Attributes.Add("style", "margin-right: 3px;");
				((DateField)filterControl).Width = 70;
				break;

		}


		return filterControl;
	}

	protected void ConfigureList(GridViewEditable grid, ManagerModuleStructure module)
	{
		grid.AllowSorting = module.AllowPaging;
		grid.AllowPaging = module.AllowPaging;

		//Escode linha de paginacao do GridView
		grid.PagerSettings.Visible = false;

		//Define a quantidade de registros por pagina
		grid.PageSize = module.PageSize;
	}

	protected void managerContent_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			string strKeyName = ((System.Web.UI.WebControls.GridView)(sender)).DataKeyNames[0];
			string strKey = ((System.Data.DataRowView)(e.Row.DataItem)).Row[strKeyName].ToString();
			string strKeyWorkflowName = "workflowId";
			string strKeyWorkflow = string.Empty;

			//se utilizar workflow tentar pegar o id do workflow
			if (activeModule.ModuleStructure.UseWorkflow)
			{
				try
				{
					strKeyWorkflow = ((System.Data.DataRowView)(e.Row.DataItem)).Row[strKeyWorkflowName].ToString();
				}
				catch
				{
					strKeyWorkflow = string.Empty;
				}
			}

			try
			{
				if (_moduleName.ToLower().Equals("usuario"))
				{
					if (e.Row.Cells[1].Text == Membership.GetUser().UserName.ToString())
					{
						((CheckBox)e.Row.Cells[0].Controls[1]).Visible = false;
					}
				}
				if (_moduleName.ToLower().Equals("userperfil"))
				{
					if (e.Row.Cells[1].Text == cs.Perfil.Name)
					{
						((CheckBox)e.Row.Cells[0].Controls[1]).Visible = false;
					}
				}
			}
			catch (Exception)
			{
				//throw;
			}

			e.Row.Attributes.Add("onMouseOver", "this.style.backgroundColor='#FFCE9D';this.style.cursor='pointer';");
			e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=''");

			string strLinkEdicao = "";

			//Verificar se possui função de retorno de itens selecionados
			if (!String.IsNullOrEmpty(Request["FuncaoRetorno"]))
			{
				btnRetornarSelecionados.Visible = true;
				strLinkEdicao = string.Concat(strLinkEdicao, "&FuncaoRetorno=", Request["FuncaoRetorno"].ToString());
			}

			if (!String.IsNullOrEmpty(Request["ExibiMaster"]))
			{
				strLinkEdicao = string.Concat(strLinkEdicao, "&ExibiMaster=", Request["ExibiMaster"].ToString());
			}

			for (int i = 1; i < e.Row.Cells.Count; i++)
			{
				if (managerContent.EditIndex != e.Row.RowIndex)
				{
					string redirect = string.Empty;

					redirect = string.Format("~/content/{0}?md={1}&id={2}&wid={3}{4}", this.LinkEdicao, _moduleName, strKey, strKeyWorkflow, strLinkEdicao);

					if (activeModule.ModuleStructure.Multilanguage)
					{
						redirect = string.Format("~/content/{0}?md={1}&id={2}&lg={3}&wid={4}{5}", this.LinkEdicao, _moduleName, strKey, cs.CurrentIdioma.IdiomaId.ToString(), strKeyWorkflow, strLinkEdicao);

						if (!i.Equals(e.Row.Cells.Count - 1))
						{
							e.Row.Cells[i].Attributes.Add("onclick", string.Format("window.location.href='{0}'", ResolveUrl(redirect)));
						}
						else
						{
							e.Row.Cells[i].Attributes.Add("style", "cursor: default;");
						}

					}
					else
					{
						e.Row.Cells[i].Attributes.Add("onclick", string.Format("window.location.href='{0}'", ResolveUrl(redirect)));
					}

				}
			}
		}
	}

	protected void btnAction_Click(object sender, ImageClickEventArgs e)
	{

		//List<string> registerDelete = new List<string>();

		//foreach (GridViewRow row in managerContent.Rows)
		//{
		//    if (((CheckBox)row.FindControl("chkSelect")).Checked)
		//        registerDelete.Add(managerContent.DataKeys[row.RowIndex].Value.ToString());
		//}

		//if (registerDelete.Count > 0)
		//{
		//    ICollection<DeleteRegisterInfo> deleteInfo = activeModule.DeleteData(registerDelete);
		//    //verifica se tem
		//    if (deleteInfo.Count > 0)
		//    {
		//        IEnumerator<DeleteRegisterInfo> IEn = deleteInfo.GetEnumerator();
		//        IEn.MoveNext();
		//        //Page.RegisterStartupScript("scrStatusMessage", "<script>setStatusMessage(\"" + IEn.Current.ErrorMessage + "\",\"true\");</script>");
		//        Ag2.Manager.Helper.Util.ShowMessage(IEn.Current.ErrorMessage);
		//    }

		//    DataTable moduleData = activeModule.GetData().Tables[0];
		//    managerContent.DataSource = moduleData;
		//    managerContent.DataBind();
		//    pagingBottom.RowsCount = moduleData.Rows.Count;
		//    pagingBottom.showNavigationButtons();
		//}

	}

	protected void btnFilter_Click(object sender, EventArgs e)
	{
		managerContent.DataBind();
		pagingBottom.showNavigationButtons();
	}

	protected void btnExecOptions_Click(object sender, EventArgs e)
	{
		if (cmbOptions.SelectedIndex > 0)
		{
			foreach (Query query in activeModule.ModuleStructure.Queries)
			{
				if (cmbOptions.SelectedValue.Equals(query.Section))
				{
					optionscontroller.Export(query, _moduleName, cmbOptions.SelectedItem);
					break;
				}
			}
		}
	}

	protected void LoadFilters()
	{
		foreach (ManagerModuleField field in activeModule.ModuleStructure.Filters)
		{
			//procura pelo controle
			Control filter = boxFilter.FindControl(string.Concat("filter", field.Name));

			//verifica se achou o controle
			if (filter != null)
			{
				//verifica tipo do filtro
				switch (field.Type)
				{
					case ManagerModuleFieldType.Text:
						field.FilterValue = filter != null ? ((TextBox)filter).Text : "";
						break;

					case ManagerModuleFieldType.Date:
						field.FilterValue = filter != null ? ((DateField)filter).Text : "";
						break;

					case ManagerModuleFieldType.CheckBox:
					case ManagerModuleFieldType.ListBox:
						field.FilterValue = filter != null ? ((ListBox)filter).SelectedValue : "";
						break;
				}
			}
		}

		cs.CurrentFilters = activeModule.ModuleStructure.Filters;
	}

	public bool IsDataFiltered()
	{
		bool dataFiltered = false;

		foreach (ManagerModuleField filter in activeModule.ModuleStructure.Filters)
		{
			if (!filter.FilterValue.Equals(""))
			{
				dataFiltered = true;
				break;
			}
		}

		return dataFiltered;
	}

	public void ListBoxFilterEvent2(object sender, EventArgs e)
	{

		//pega ID do combo que disparou o evento
		string senderName = ((ListBox)sender).ID.Substring(6);


		//procura combo na coleção
		int fieldIndex = activeModule.FindFieldIndexByName(senderName);

		//verifica se o objeto foi encontrado na coleção
		if (fieldIndex >= 0)
		{
			//pega valor selecionado no combo
			string selectedValue = ((ListBox)sender).SelectedValue;

			//verifica que objeto ele estará filtrando
			string targetName = ((ManagerModuleFieldListBox)activeModule.ModuleStructure.Fields[fieldIndex]).FilterListBox;

			//garente que a propriedade foi preenchida
			if (!targetName.Equals(""))
			{

				//pega campo que será utilizado para filtro da consulta
				string filterField = ((ManagerModuleFieldListBox)activeModule.ModuleStructure.Fields[fieldIndex]).FilterByField;

				//procura na coleção campo que será alvo do filtro
				fieldIndex = activeModule.FindFieldIndexByName(targetName);

				//
				ListBox targetListBox = (ListBox)boxFilter.FindControl("filter" + targetName);  //activeModule.FindControlByID("filter"+targetName);

				if (targetListBox != null)
				{
					targetListBox.DataSource = activeModule.GetComboData((ManagerModuleFieldListBox)activeModule.ModuleStructure.Fields[fieldIndex], filterField, selectedValue);
					targetListBox.DataBind();
					targetListBox.Items.Insert(0, (new ListItem(":: Todos ::", "")));
				}

			}
		}

	}

	public void ConfigurePagePermission(ManagerMenuItem menuItem)
	{
		if (menuItem != null)
		{
			//se o usuário pode ler
			if (menuItem.UserCanRead)
			{
				//verifica se tem permissão de escrita
				lnkNewRegister.Visible = (menuItem.UserCanInsert);

				//verifica se tem permissão para exclusão
				if (!menuItem.UserCanDelete)
				{
					managerContent.Columns[0].Visible = false;
				}
			}
			else
			{
				//se não puder, redireciona para a página default
				Response.Redirect("~/content/Default.aspx");
			}
		}
		else
		{
			FormsAuthentication.RedirectToLoginPage();
		}
	}
}
