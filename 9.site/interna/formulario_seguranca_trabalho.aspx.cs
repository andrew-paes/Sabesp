using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data;
using Sabesp.Data.Services;
using AG2.Sabesp.HotWords;
using System.Configuration;

public partial class interna_formulario_seguranca_trabalho : BasePage
{
	#region [ Properties ]

	/// <summary>
	/// 
	/// </summary>
	protected FormularioSegurancaTrabalhoService formularioSegurancaTrabalhoService;

	/// <summary>
	/// 
	/// </summary>
	protected FormularioSegurancaTrabalho formularioSegurancaTrabalhoBO;

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

		string strURL = "~/interna/formulario-resposta-erro.aspx?secaoId=1";

		try
		{
			this.Save();

			if (this.SendMail())
			{
				//this.ShowMessage(this.Success());
				strURL = "~/interna/formulario-resposta-confirmacao.aspx?secaoId=1";
			}
		}
		catch (Exception ex)
		{
			Session["ex"] = ex;
			//this.ShowMessage("Solicitação não enviada. Por favor tente mais tarde!");
		}

		Response.Redirect(strURL);
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected void FormToLoad()
	{
		formularioSegurancaTrabalhoBO = new FormularioSegurancaTrabalho();

		formularioSegurancaTrabalhoBO.DataHoraContato = DateTime.Now;

		// Carrega "Contato"
		if (!String.IsNullOrEmpty(txtNome.Text))
		{
			formularioSegurancaTrabalhoBO.Nome = txtNome.Text;
		}

		if (!String.IsNullOrEmpty(txtEmail.Text))
		{
			formularioSegurancaTrabalhoBO.Email = txtEmail.Text;
		}

		if (!String.IsNullOrEmpty(txtInstituicao.Text))
		{
			formularioSegurancaTrabalhoBO.Empresa = txtInstituicao.Text;
		}

		if (!String.IsNullOrEmpty(txtCep.Text))
		{
			formularioSegurancaTrabalhoBO.Cep = txtCep.Text.Replace(".", "").Replace("-", "");
		}

		formularioSegurancaTrabalhoBO.Estado = new Estado();
		formularioSegurancaTrabalhoBO.Estado.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);

		if (!String.IsNullOrEmpty(txtCidade.Text))
		{
			formularioSegurancaTrabalhoBO.Cidade = txtCidade.Text;
		}

		if (!String.IsNullOrEmpty(txtBairro.Text))
		{
			formularioSegurancaTrabalhoBO.Bairro = txtBairro.Text;
		}

		if (!String.IsNullOrEmpty(txtEndereco.Text))
		{
			formularioSegurancaTrabalhoBO.Endereco = txtEndereco.Text;
		}

		if (!String.IsNullOrEmpty(txtDuvida.Value))
		{
			formularioSegurancaTrabalhoBO.Duvida = txtDuvida.Value;
		}

		if (!String.IsNullOrEmpty(txtTelefone.Text))
		{
			string[] piecesTel = txtTelefone.Text.Split(new char[] { ')' });

			if (piecesTel[0] != null && piecesTel[1] != null)
			{
				formularioSegurancaTrabalhoBO.TelefoneDdd = piecesTel[0].Replace("(", "");
				formularioSegurancaTrabalhoBO.TelefoneNumero = piecesTel[1].Replace("-", "");
			}
		}

		formularioSegurancaTrabalhoBO.ReceberInformacaoSabesp = chkConteudoSabesp.Checked;
		formularioSegurancaTrabalhoBO.ReceberInformacaoEventos = chkInformacaoEvento.Checked;

		formularioSegurancaTrabalhoBO.Formulario = new Formulario();
		formularioSegurancaTrabalhoBO.Formulario.FormularioId = 3;
	}

	/// <summary>
	/// Inseri "Contato"
	/// </summary>
	protected void Save()
	{
		new FormularioSegurancaTrabalhoService().Inserir(formularioSegurancaTrabalhoBO);
	}

	/// <summary>
	/// 
	/// </summary>
	protected string Success()
	{
		string msg = "Solicitação enviada com sucesso!";

		txtNome.Text = String.Empty;
		txtEmail.Text = String.Empty;
		txtInstituicao.Text = String.Empty;
		txtCep.Text = String.Empty;
		ddlEstado.SelectedIndex = 0;
		txtCidade.Text = String.Empty;
		txtBairro.Text = String.Empty;
		txtEndereco.Text = String.Empty;
		txtTelefone.Text = String.Empty;
		txtDuvida.Value = String.Empty;
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
	/// Envia e-mail
	/// </summary>
	private bool SendMail()
	{
		bool flag = false;

		// Cabeçalho do e-mail
		Ag2.Net.Mail.MailMessage msg = new Ag2.Net.Mail.MailMessage();
		msg.PathTemplate = Server.MapPath("~/contents/email/FormularioSegurancaTrabalho.htm");
		msg.IsBodyHtml = true;
		msg.Subject = "Formulário de Segurança de Trabalho";
		msg.From = new System.Net.Mail.MailAddress(Convert.ToString(ConfigurationManager.AppSettings["emailFrom"]));
		msg.ReplyTo = new System.Net.Mail.MailAddress(txtEmail.Text);
		//msg.To.Add(new System.Net.Mail.MailAddress("emailDestino"));

		Formulario formularioBO = new Formulario();
		formularioBO.FormularioId = 3; // Define o Id de formulário para fazer pesquisa dos contato

		List<Contato> contatoBOIList = new List<Contato>();
		contatoBOIList = new ContatoService().Carregar(formularioBO);

		foreach (Contato contatoBOTemp in contatoBOIList)
		{
			msg.To.Add(new System.Net.Mail.MailAddress(contatoBOTemp.EmailContato, contatoBOTemp.NomeContato)); // Destinatários
		}

		// Variáveis do e-mail
		msg.Dictionary.Add("%pathSite%", ConfigurationManager.AppSettings["pathSite"].ToString());
		msg.Dictionary.Add("%assunto%", "Formulário de Segurança de Trabalho");
		msg.Dictionary.Add("%msg%", "Este é um e-mai do formulário de Segurança de Trabalho.");
		msg.Dictionary.Add("%dataEnvio%", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
		msg.Dictionary.Add("%mail%", txtEmail.Text);
		msg.Dictionary.Add("%nome%", txtNome.Text);
		msg.Dictionary.Add("%veiculo%", txtInstituicao.Text);
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
		msg.Dictionary.Add("%duvida%", txtDuvida.Value);
		msg.Dictionary.Add("%conteudoSabesp%", chkConteudoSabesp.Checked ? "Sim" : "Não");
		msg.Dictionary.Add("%informacaoEvento%", chkInformacaoEvento.Checked ? "Sim" : "Não");

		// Tenta enviar e-mail
		try
		{
			new Ag2.Net.Mail.SendMail(msg, false);

			flag = true; // Mensagem enviada
		}
		catch(Exception ex)
		{
			Session["ex"] = ex;
			flag = false; // Mensagem NÃO enviada
		}

		return flag;
	}

	#endregion

	#endregion
}