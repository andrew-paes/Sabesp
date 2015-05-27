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

public partial class content_module_controleSessao_controleSessao : SmartUserControl
{
	#region [ Properties ]

	/// <summary>
	/// ///   Service for "ContatoService" 
	/// </summary>
	protected ContatoService contatoService;
	/// <summary>
	///  Filter for "ContatoFH"
	/// </summary>
	protected ContatoFH contatoFH;
	/// <summary>
	/// Business Object for "Contato" fields
	/// </summary>
	protected Contato contatoBO;
	/// <summary>
	/// Service for "FormularioService" 
	/// </summary>
	protected FormularioService formularioService;
	/// <summary>
	///  Filter for "FormularioFH"
	/// </summary>
	protected FormularioFH formularioFH;
	/// <summary>
	/// Business Object for "Formulario" fields
	/// </summary>
	protected Formulario formularioBO;
	/// <summary>
	/// List of "Formulario"
	/// </summary>
	protected IList<Formulario> formularioBOList;

	#endregion

	#region [ Page Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
		//Initialize properties n services
		this.DefineProperties();

		if (!Page.IsPostBack)
		{
			LoadCheckBox();
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

	#region Properties and Form
	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		// Ini service to "Contato"
		contatoBO = new Contato();

		// Ini service to "Formulario"
		formularioBO = new Formulario();
	}

	/// <summary>
	/// Load all properties
	/// </summary>
	private void LoadProperties()
	{
		// Ini service to find and add "Regiao"
		contatoBO = new Contato();

		if (IdRegistro > 0)
		{
			contatoBO.ContatoId = Convert.ToInt32(IdRegistro);
			contatoBO = new ContatoService().Carregar(contatoBO);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		if (contatoBO != null && contatoBO.ContatoId > 0)
		{
			txtNome.Text = contatoBO.NomeContato;
			txtEmail.Text = contatoBO.EmailContato;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void ClearForm()
	{
		txtNome.Text = String.Empty;
		txtEmail.Text = String.Empty;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadCheckBox()
	{
		formularioBO = new Formulario();

		FormularioFH formularioFH = new FormularioFH();
		formularioFH.Ativo = "1";

		formularioService = new FormularioService();
		chbFormulario.DataSource = formularioService.RetornaTodos(0, 0, null, null, formularioFH);
		chbFormulario.DataTextField = "nomeFormulario";
		chbFormulario.DataValueField = "formularioId";
		chbFormulario.DataBind();

		if (this.IdRegistro != 0 || this.IdRegistro != null)
		{
			for (int i = 0; i < chbFormulario.Items.Count; i++)
			{
				int cont = new FormularioService().TotalRegistrosRelacionado(Convert.ToInt32(this.IdRegistro), Convert.ToInt32(chbFormulario.Items[i].Value));

				if (cont > 0)
				{
					chbFormulario.Items[i].Selected = true;
				}
				else
				{
					chbFormulario.Items[i].Selected = false;
				}
			}
		}
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected void FormToLoad()
	{
		contatoBO = new Contato();

		// Carrega "Contato"
		if (!String.IsNullOrEmpty(txtNome.Text))
		{
			contatoBO.NomeContato = txtNome.Text;
		}

		if (!String.IsNullOrEmpty(txtEmail.Text))
		{
			contatoBO.EmailContato = txtEmail.Text;
		}

		formularioBOList = new List<Formulario>();

		for (int i = 0; i < chbFormulario.Items.Count; i++)
		{
			formularioBO = new Formulario();

			if (chbFormulario.Items[i].Selected)
			{
				formularioBO.FormularioId = Convert.ToInt32(chbFormulario.Items[i].Value);
				formularioBOList.Add(formularioBO);
			}
		}

		if (IdRegistro > 0)
		{
			contatoBO.ContatoId = Convert.ToInt32(IdRegistro);
		}
	}

	#endregion

	#region Execute, Save and Update

	/// <summary>
	/// 
	/// </summary>
	private void Execute()
	{
		// Carrega os objetos para poder salvar ou alterar
		this.FormToLoad();

		try
		{
			if (contatoBO != null && contatoBO.ContatoId > 0)
			{
				this.Atualizar();
				Util.ShowMessage("Registro alterado com sucesso!");
			}
			else
			{
				this.Inserir();
				Util.ShowMessage("Registro salvo com sucesso!");
			}

			Response.Redirect("../content/edit.aspx?md=contato&id=" + this.contatoBO.ContatoId.ToString() + "&lg=" + this.IdiomaId + "&wid=");

		}
		catch
		{
			Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde!");
		}
	}

	/// <summary>
	/// Inseri "Contato"
	/// </summary>
	protected void Inserir()
	{
		new ContatoService().Inserir(contatoBO);

		InserirRelacionado();
	}

	/// <summary>
	/// Atualiza "Contato"
	/// </summary>
	protected void Atualizar()
	{
		new ContatoService().Atualizar(contatoBO);

		new FormularioService().ExcluirRelacionado(contatoBO.ContatoId); //Exclui o relacionamento entre Contato e Formulario para inserir atualizado

		InserirRelacionado();
	}

	/// <summary>
	/// Salva "FormularioContato"
	/// </summary>
	private void InserirRelacionado()
	{
		if (contatoBO != null && contatoBO.ContatoId > 0 && formularioBOList != null && formularioBOList.Count > 0)
		{
			for (int i = 0; i < formularioBOList.Count; i++)
			{
				new FormularioService().InserirRelacionado(contatoBO.ContatoId, Convert.ToInt32(formularioBOList[i].FormularioId));
			}
		}
	}

	#endregion

	#endregion
}
