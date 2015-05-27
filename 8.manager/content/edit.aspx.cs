using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ag2.Manager.Module;
using Ag2.Manager.Helper;
using Ag2.Manager.WebUI;
using Ag2.Manager.BusinessObject;

public partial class content_edit : ManagerPage
{
	/// <summary>
	/// 
	/// </summary>
	private ManagerModule _activeModule;        //instancia do modulo ativo

	/// <summary>
	/// 
	/// </summary>
	private int _registerId;                    //ID do registro que será editado

	/// <summary>
	/// 
	/// </summary>
	private string moduleName = string.Empty;

	/// <summary>
	/// 
	/// </summary>
	public string LinkList { get; set; }

	/// <summary>
	/// 
	/// </summary>
	protected string ModuleName
	{
		get
		{
			if (!String.IsNullOrEmpty(Convert.ToString(Request.QueryString["md"])))
			{
				return Convert.ToString(Request.QueryString["md"]);
			}
			else
			{
				return string.Empty;
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="o"></param>
	/// <param name="e"></param>
	protected void Page_Init(object o, EventArgs e)
	{
		moduleName = Request.QueryString["md"]; // Monta caminho do modulo

		// Monta Url da listagem
		this.LinkList = "List.aspx";
		this.LinkList = string.Concat(this.LinkList, "?md=", moduleName);

		// Verificar se possui função de retorno de itens selecionados
		if (!String.IsNullOrEmpty(Request["FuncaoRetorno"]))
		{
			this.LinkList = string.Concat(this.LinkList, "&FuncaoRetorno=", Request["FuncaoRetorno"].ToString());
		}

		if (!String.IsNullOrEmpty(Request["ExibiMaster"]))
		{
			this.LinkList = string.Concat(this.LinkList, "&ExibiMaster=", Request["ExibiMaster"].ToString());
		}

		lnkListagem.NavigateUrl = this.LinkList;
		lnkListagem.Visible = (Request["ExibiBotaoList"] != "0");

		RegisterNavigator1.Visible = (Request["ExibiBotaoList"] != "0");
		RegisterNavigator1.ModuleName = moduleName;

		_activeModule = new ManagerModule(); // Instantica novo modulo 

		_activeModule.Load(this.ModuleName, (System.Reflection.Assembly)System.Web.Compilation.BuildManager.CodeAssemblies[0]); // Carrega modulo

		barraIdioma.Visible = _activeModule.ModuleStructure.Multilanguage; // Mostra ou não a barra de idioma

		lblModuleTitle.Text = _activeModule.ModuleStructure.Title; // Configura titulo do modulo

		_activeModule.CreateForm(); // Cria formulario

		_activeModule.ConfigureForm(); // CSarrega as definições do formulario

		if (!_activeModule.ModuleStructure.UseWorkflow)
		{
			phWorkflow.Visible = false;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (this.ModuleName.Equals("Usuario"))
		{
			return;
		}

		if (!IsPostBack)
		{
			// Captura ID que está sendo editado
			if (String.IsNullOrEmpty(Request.QueryString["id"]))
			{
				_registerId = 0;
			}
			else
			{
				_registerId = Util.GetRequestId();
			}

			ViewState["registerId"] = _registerId; // Salva ID no viewState

			_activeModule.RegisterID = _registerId; // Popula propriedade

			_activeModule.ExibeCamposIdioma("1");

			// Se é edição de registro carrega dados
			if (_registerId > 0)
			{
				_activeModule.FillForm();
			}
		}
		else
		{
			_registerId = (int)ViewState["registerId"]; // Resgata ID no viewState
		}

		_activeModule.RegisterID = _registerId; // Popula propriedade

		// Efetua configuração de permissões do formulario
		ManagerMenuItem menuItem = new ManagerMenu().SelectedItem;
		ConfigurePagePermission(menuItem);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		// Salva os dados do formulario     
		string msg = "";
		string fields = "";
		bool validForm = true;

		IList a = _activeModule.VerifyUniqueValues(); // VSerifica se existe valor no banco

		if (a.Count > 0)
		{
			((TextBox)fieldsHolder.Controls[0].FindControl(a[0].ToString())).BackColor = System.Drawing.Color.FromArgb(255, 153, 102);

			foreach (string campo in a)
			{
				if (!fields.Equals(""))
				{
					fields = fields + ",";
				}

				fields = fields + campo;
			}

			msg = "O Cadastro não pode ser realizado pois já existem outros cadastros com os mesmo valores.<br />Os campos assinalados precisam ter seu valor alterado.";
			Ag2.Manager.Helper.Util.ShowMessage(msg);
			validForm = false;
		}


		if (validForm)
		{
			if (_activeModule.SaveForm(StatusWorkflow1))
			{
				if (_registerId == 0)
				{
					_activeModule.ClearForm(); // Limpa campos do formulario

					msg = "Cadastro realizado com sucesso.";
				}
				else
				{
					msg = "Atualização realizada com sucesso.";
				}
			}
			else
			{
				msg = "Ocorreu um erro na gravação";
			}
		}

		Util.ShowMessage(msg);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="menuItem"></param>
	public void ConfigurePagePermission(ManagerMenuItem menuItem)
	{
		if (menuItem != null)
		{
			// Se o usuário pode ler
			if (menuItem.UserCanRead)
			{
				btnExecute.Visible = (menuItem.UserCanInsert); // Verifica se tem permissão de escrita
			}
			else
			{
				Response.Redirect("~/content/Default.aspx"); // Se não puder, redireciona para a página default
			}
		}
		else
		{
			FormsAuthentication.RedirectToLoginPage();
		}
	}
}