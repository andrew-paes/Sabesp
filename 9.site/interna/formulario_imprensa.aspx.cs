using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AG2.Sabesp.HotWords;
using Sabesp.BO;
using Sabesp.Data;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using System.Configuration;

public partial class interna_formulario_imprensa : BasePage
{
	#region [ Properties ]

	/// <summary>
	/// 
	/// </summary>
	protected FormularioImprensaService formularioImprensaService;

	/// <summary>
	/// 
	/// </summary>
	protected FormularioImprensa formularioImprensaBO;

	/// <summary>
	/// 
	/// </summary>
	protected EstadoService estadoService;

	/// <summary>
	/// 
	/// </summary>
	protected Estado estadoBO;

	#endregion

	#region [ Page Events ]

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.LoadForm();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnSolicitar_Click(object sender, ImageClickEventArgs e)
	{
		this.Execute();
	}

	#endregion

	#region [ Methods ]

	#region [ Form ]

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		estadoService = new EstadoService();

		ddlEstado.DataSource = estadoService.RetornaTodos();
		ddlEstado.DataTextField = "uf";
		ddlEstado.DataValueField = "estadoId";
		ddlEstado.DataBind();
		ddlEstado.Items.Insert(0, "");
	}

	#endregion

	#region [ Execute ]

	/// <summary>
	/// 
	/// </summary>
	private void Execute()
	{
		this.FormToLoad(); // Carrega os objetos para poder salvar ou alterar

		string strURL = "~/interna/formulario-resposta-erro.aspx";

		try
		{
			this.Save();

			if (this.SendMail())
			{
				//this.ShowMessage(this.Success());
				strURL = "~/interna/formulario-resposta-confirmacao.aspx";
			}
		}
		catch
		{
			//this.ShowMessage("Solicitação não enviada. Por favor tente mais tarde!");
		}
		finally
		{
			Response.Redirect(strURL);
		}
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected void FormToLoad()
	{
		formularioImprensaBO = new FormularioImprensa();

		formularioImprensaBO.DataHoraContato = DateTime.Now;

		// Carrega "Contato"
		if (!String.IsNullOrEmpty(txtNome.Text))
		{
			formularioImprensaBO.Nome = txtNome.Text;
		}

		if (!String.IsNullOrEmpty(txtEmail.Text))
		{
			formularioImprensaBO.Email = txtEmail.Text;
		}

		if (!String.IsNullOrEmpty(txtVeiculo.Text))
		{
			formularioImprensaBO.Empresa = txtVeiculo.Text;
		}

		if (!String.IsNullOrEmpty(txtCep.Text))
		{
			formularioImprensaBO.Cep = txtCep.Text.Replace(".", "").Replace("-", "");
		}

		formularioImprensaBO.Estado = new Estado();
		if (!String.IsNullOrEmpty(ddlEstado.SelectedValue))
		{
			formularioImprensaBO.Estado.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);
		}

		if (!String.IsNullOrEmpty(txtCidade.Text))
		{
			formularioImprensaBO.Cidade = txtCidade.Text;
		}

		if (!String.IsNullOrEmpty(txtBairro.Text))
		{
			formularioImprensaBO.Bairro = txtBairro.Text;
		}

		if (!String.IsNullOrEmpty(txtEndereco.Text))
		{
			formularioImprensaBO.Endereco = txtEndereco.Text;
		}

		if (!String.IsNullOrEmpty(txtTelefone.Text))
		{
			string[] piecesTel = txtTelefone.Text.Split(new char[] { ')' });

			if (piecesTel[0] != null && piecesTel[1] != null)
			{
				formularioImprensaBO.TelefoneDDD = piecesTel[0].Replace("(", "");
				formularioImprensaBO.TelefoneNumero = piecesTel[1].Replace("-", "");
			}
		}

		formularioImprensaBO.ReceberInformacaoSabesp = chkConteudoSabesp.Checked;
		formularioImprensaBO.ReceberInformacaoEventos = chkInformacaoEvento.Checked;

		formularioImprensaBO.Formulario = new Formulario();
		formularioImprensaBO.Formulario.FormularioId = 1;
	}

	/// <summary>
	/// 
	/// </summary>
	protected string Success()
	{
		string msg = "Solicitação enviada com sucesso!";

		txtNome.Text = String.Empty;
		txtEmail.Text = String.Empty;
		txtVeiculo.Text = String.Empty;
		txtCep.Text = String.Empty;
		ddlEstado.SelectedIndex = 0;
		txtCidade.Text = String.Empty;
		txtBairro.Text = String.Empty;
		txtEndereco.Text = String.Empty;
		txtTelefone.Text = String.Empty;
		chkConteudoSabesp.Checked = false;
		chkInformacaoEvento.Checked = false;

		return msg;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="msg"></param>
	protected void ShowMessage(string msg)
	{
		ltrMensagem.Visible = true;
		ltrMensagem.Text = msg;
	}

	/// <summary>
	/// Inseri "Contato"
	/// </summary>
	protected void Save()
	{
		new FormularioImprensaService().Inserir(formularioImprensaBO);
	}

	/// <summary>
	/// Envia e-mail
	/// </summary>
	private bool SendMail()
	{
		bool flag = false;

		// Cabeçalho do e-mail
		Ag2.Net.Mail.MailMessage msg = new Ag2.Net.Mail.MailMessage();
		msg.PathTemplate = Server.MapPath("~/contents/email/FormularioImprensa.htm");
		msg.IsBodyHtml = true;
		msg.Subject = "Formulário de Imprensa";
		msg.From = new System.Net.Mail.MailAddress(Convert.ToString(ConfigurationManager.AppSettings["emailFrom"]));
		msg.ReplyTo = new System.Net.Mail.MailAddress(txtEmail.Text);
		//msg.To.Add(new System.Net.Mail.MailAddress("teste@ag2.com.br"));

		Formulario formularioBO = new Formulario();
		formularioBO.FormularioId = 1; // Define o Id de formulário para fazer pesquisa dos contato

		List<Contato> contatoBOIList = new List<Contato>();
		contatoBOIList = new ContatoService().Carregar(formularioBO);

		foreach (Contato contatoBOTemp in contatoBOIList)
		{
			msg.To.Add(new System.Net.Mail.MailAddress(contatoBOTemp.EmailContato, contatoBOTemp.NomeContato)); // Destinatários
		}

		// Variáveis do e-mail
		msg.Dictionary.Add("%pathSite%", ConfigurationManager.AppSettings["pathSite"].ToString());
		msg.Dictionary.Add("%assunto%", "Formulário de Imprensa");
		msg.Dictionary.Add("%msg%", "Este é um e-mai do formulário de Imprensa.");
		msg.Dictionary.Add("%dataEnvio%", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
		msg.Dictionary.Add("%mail%", txtEmail.Text);
		msg.Dictionary.Add("%nome%", txtNome.Text);
		msg.Dictionary.Add("%veiculo%", txtVeiculo.Text);
		msg.Dictionary.Add("%cep%", txtCep.Text);

		if (!String.IsNullOrEmpty(ddlEstado.SelectedValue))
		{
			Estado estadoBO = new Estado();
			estadoBO.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);

			estadoBO = new EstadoService().Carregar(estadoBO);
			msg.Dictionary.Add("%estado%", estadoBO.NomeEstado);
		}
		else
		{
			msg.Dictionary.Add("%estado%", "");
		}

		msg.Dictionary.Add("%cidade%", txtCidade.Text);
		msg.Dictionary.Add("%bairro%", txtBairro.Text);
		msg.Dictionary.Add("%endereco%", txtEndereco.Text);
		msg.Dictionary.Add("%telefone%", txtTelefone.Text);
		msg.Dictionary.Add("%conteudoSabesp%", chkConteudoSabesp.Checked ? "Sim" : "Não");
		msg.Dictionary.Add("%informacaoEvento%", chkInformacaoEvento.Checked ? "Sim" : "Não");

		// Tenta enviar e-mail
		try
		{
			new Ag2.Net.Mail.SendMail(msg, false);
			
			flag = true; // Mensagem enviada
		}
		catch
		{
			flag = false; // Mensagem NÃO enviada
		}

		return flag;
	}

	#endregion

	#endregion
}