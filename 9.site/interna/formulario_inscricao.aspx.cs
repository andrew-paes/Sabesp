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
using Sabesp.FilterHelper;
using System.Configuration;

public partial class interna_formulario_inscricao : BasePage
{
	#region [ Properties ]

	/// <summary>
	/// 
	/// </summary>
	protected FormularioCursoVazamentoService formularioCursoVazamentoService;

	/// <summary>
	/// 
	/// </summary>
	protected FormularioCursoVazamento formularioCursoVazamentoBO;

	/// <summary>
	/// 
	/// </summary>
	protected EstadoService estadoService;

	/// <summary>
	/// 
	/// </summary>
	protected Estado estadoBO;

	/// <summary>
	/// 
	/// </summary>
	protected EscolaridadeService escolaridadeService;

	/// <summary>
	/// 
	/// </summary>
	protected Escolaridade escolaridadeBO;

	/// <summary>
	/// 
	/// </summary>
	protected HorarioPreferenciaService horarioPreferenciaService;

	/// <summary>
	/// 
	/// </summary>
	protected HorarioPreferencia horarioPreferenciaBO;

	/// <summary>
	/// 
	/// </summary>
	protected IndicacaoService indicacaoService;

	/// <summary>
	/// 
	/// </summary>
	protected Indicacao indicacaoBO;

	/// <summary>
	/// 
	/// </summary>
	protected LocalCursoService localCursoService;

	/// <summary>
	/// 
	/// </summary>
	protected LocalCurso localCursoBO;

	/// <summary>
	/// 
	/// </summary>
	protected TipoImovelService tipoImovelService;

	/// <summary>
	/// 
	/// </summary>
	protected TipoImovel ipoImovelBO;

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

		escolaridadeService = new EscolaridadeService();
		rdoEscolaridade.DataSource = escolaridadeService.RetornaTodos();
		rdoEscolaridade.DataTextField = "nomeEscolaridade";
		rdoEscolaridade.DataValueField = "escolaridadeId";
		rdoEscolaridade.DataBind();

		tipoImovelService = new TipoImovelService();
		rdoImovel.DataSource = tipoImovelService.RetornaTodos();
		rdoImovel.DataTextField = "tipo";
		rdoImovel.DataValueField = "tipoImovelId";
		rdoImovel.DataBind();

		indicacaoService = new IndicacaoService();
		rdoVeiculo.DataSource = indicacaoService.RetornaTodos();
		rdoVeiculo.DataTextField = "meio";
		rdoVeiculo.DataValueField = "indicacaoId";
		rdoVeiculo.DataBind();

		LocalCursoFH localCursoFH = new LocalCursoFH();
		localCursoFH.Ativo = "1";
		localCursoService = new LocalCursoService();
		rdoLocal.DataSource = localCursoService.CarregarTodos(0, 0, null, null, localCursoFH);
		rdoLocal.DataTextField = "local";
		rdoLocal.DataValueField = "localCursoId";
		rdoLocal.DataBind();

		horarioPreferenciaService = new HorarioPreferenciaService();
		rdoHorario.DataSource = horarioPreferenciaService.RetornaTodos();
		rdoHorario.DataTextField = "horario";
		rdoHorario.DataValueField = "horarioPreferenciaId";
		rdoHorario.DataBind();
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
			//this.ShowMessage("Solicitação não enviada. Por favor tente mais tarde!" + ex.ToString());
		}

		Response.Redirect(strURL);
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected void FormToLoad()
	{
		formularioCursoVazamentoBO = new FormularioCursoVazamento();

		formularioCursoVazamentoBO.DataHoraContato = DateTime.Now;

		// Carrega "Contato"
		if (!String.IsNullOrEmpty(txtNome.Text))
		{
			formularioCursoVazamentoBO.Nome = txtNome.Text;
		}

		if (!String.IsNullOrEmpty(txtEmail.Text))
		{
			formularioCursoVazamentoBO.Email = txtEmail.Text;
		}

		if (!String.IsNullOrEmpty(txtCep.Text))
		{
			formularioCursoVazamentoBO.Cep = txtCep.Text.Replace(".", "").Replace("-", "");
		}

		formularioCursoVazamentoBO.Estado = new Estado();
		if (!String.IsNullOrEmpty(ddlEstado.SelectedValue))
		{
			formularioCursoVazamentoBO.Estado.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);
		}

		if (!String.IsNullOrEmpty(txtCidade.Text))
		{
			formularioCursoVazamentoBO.Cidade = txtCidade.Text;
		}

		if (!String.IsNullOrEmpty(txtBairro.Text))
		{
			formularioCursoVazamentoBO.Bairro = txtBairro.Text;
		}

		if (!String.IsNullOrEmpty(txtEndereco.Text))
		{
			formularioCursoVazamentoBO.Endereco = txtEndereco.Text;
		}

		if (!String.IsNullOrEmpty(txtTelefone.Text))
		{
			string[] piecesTel = txtTelefone.Text.Split(new char[] { ')' });

			if (piecesTel[0] != null && piecesTel[1] != null)
			{
				formularioCursoVazamentoBO.TelefoneDDD = piecesTel[0].Replace("(", "");
				formularioCursoVazamentoBO.TelefoneNumero = piecesTel[1].Replace("-", "");
			}
		}

		if (!String.IsNullOrEmpty(rdoEscolaridade.SelectedValue))
		{
			formularioCursoVazamentoBO.Escolaridade = new Escolaridade();
			formularioCursoVazamentoBO.Escolaridade.EscolaridadeId = Convert.ToInt32(rdoEscolaridade.SelectedValue);

			if (rdoEscolaridade.SelectedValue == rdoEscolaridade.Items[rdoEscolaridade.Items.Count - 1].Value && !String.IsNullOrEmpty(txtEscolaridadeOutros.Text))
			{
				formularioCursoVazamentoBO.EscolaridadeOutro = txtEscolaridadeOutros.Text;
			}
		}

		if (!String.IsNullOrEmpty(rdoImovel.SelectedValue))
		{
			formularioCursoVazamentoBO.TipoImovel = new TipoImovel();
			formularioCursoVazamentoBO.TipoImovel.TipoImovelId = Convert.ToInt32(rdoImovel.SelectedValue);

			if (rdoImovel.SelectedValue == rdoImovel.Items[rdoImovel.Items.Count - 1].Value && !String.IsNullOrEmpty(txtImovelOutros.Text))
			{
				formularioCursoVazamentoBO.TipoImovelOutro = txtImovelOutros.Text;
			}
		}

		if (!String.IsNullOrEmpty(rdoVeiculo.SelectedValue))
		{
			formularioCursoVazamentoBO.Indicacao = new Indicacao();
			formularioCursoVazamentoBO.Indicacao.IndicacaoId = Convert.ToInt32(rdoVeiculo.SelectedValue);

			if (rdoVeiculo.SelectedValue == rdoVeiculo.Items[rdoVeiculo.Items.Count - 1].Value && !String.IsNullOrEmpty(txtVeiculoOutros.Text))
			{
				formularioCursoVazamentoBO.IndicacaoOutro = txtVeiculoOutros.Text;
			}
		}

		if (!String.IsNullOrEmpty(rdoLocal.SelectedValue))
		{
			formularioCursoVazamentoBO.LocalCurso = new LocalCurso();
			formularioCursoVazamentoBO.LocalCurso.LocalCursoId = Convert.ToInt32(rdoLocal.SelectedValue);
		}

		if (!String.IsNullOrEmpty(rdoHorario.SelectedValue))
		{
			formularioCursoVazamentoBO.HorarioPreferencia = new HorarioPreferencia();
			formularioCursoVazamentoBO.HorarioPreferencia.HorarioPreferenciaId = Convert.ToInt32(rdoHorario.SelectedValue);
		}

		formularioCursoVazamentoBO.Formulario = new Formulario();
		formularioCursoVazamentoBO.Formulario.FormularioId = 6;
	}

	/// <summary>
	/// 
	/// </summary>
	protected string Success()
	{
		string msg = "Solicitação enviada com sucesso!";

		txtNome.Text = String.Empty;
		txtEmail.Text = String.Empty;
		txtCep.Text = String.Empty;
		ddlEstado.SelectedIndex = 0;
		txtCidade.Text = String.Empty;
		txtBairro.Text = String.Empty;
		txtEndereco.Text = String.Empty;
		txtTelefone.Text = String.Empty;
		//chkConteudoSabesp.Checked = false;
		//chkInformacaoEvento.Checked = false;

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
		new FormularioCursoVazamentoService().Inserir(formularioCursoVazamentoBO);
	}

	/// <summary>
	/// Envia e-mail
	/// </summary>
	private bool SendMail()
	{
		bool flag = false;

		// Cabeçalho do e-mail
		Ag2.Net.Mail.MailMessage msg = new Ag2.Net.Mail.MailMessage();
		msg.PathTemplate = Server.MapPath("~/contents/email/FormularioInscricao.htm");
		msg.IsBodyHtml = true;
		msg.Subject = "Formulário de Inscrição";
		msg.From = new System.Net.Mail.MailAddress(Convert.ToString(ConfigurationManager.AppSettings["emailFrom"]));
		msg.ReplyTo = new System.Net.Mail.MailAddress(txtEmail.Text);

		/*
		Formulario formularioBO = new Formulario();
		formularioBO.FormularioId = 6; // Define o Id de formulário para fazer pesquisa dos contato

		List<Contato> contatoBOIList = new List<Contato>();
		contatoBOIList = new ContatoService().Carregar(formularioBO);

		foreach (Contato contatoBOTemp in contatoBOIList)
		{
			msg.To.Add(new System.Net.Mail.MailAddress(contatoBOTemp.EmailContato, contatoBOTemp.NomeContato)); // Destinatários
		}
		*/

		LocalCurso localCursoBO = new LocalCurso();
		localCursoBO.LocalCursoId = Convert.ToInt32(this.rdoLocal.SelectedValue);
		localCursoBO = new LocalCursoService().Carregar(localCursoBO);

		if (localCursoBO != null && localCursoBO.LocalCursoId > 0)
		{
			msg.To.Add(new System.Net.Mail.MailAddress(localCursoBO.Email, localCursoBO.Local)); // Destinatários
		}
		else
		{
			msg.To.Add(new System.Net.Mail.MailAddress("sabesp@sabesp.com.br", "SABESP")); // Destinatários
		}

		// Variáveis do e-mail
		msg.Dictionary.Add("%pathSite%", ConfigurationManager.AppSettings["pathSite"].ToString());
		msg.Dictionary.Add("%assunto%", "Formulário de Inscrição");
		msg.Dictionary.Add("%msg%", "Este é um e-mai do formulário de Inscrição.");
		msg.Dictionary.Add("%dataEnvio%", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
		msg.Dictionary.Add("%mail%", txtEmail.Text);
		msg.Dictionary.Add("%nome%", txtNome.Text);
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

		string cidade = txtCidade.Text;
		string bairro = txtBairro.Text;
		string endereco = txtEndereco.Text;
		string telefone = txtTelefone.Text;
		string escolaridade = rdoEscolaridade.SelectedItem.Text;
		string escolaridadeOutros = txtEscolaridadeOutros.Text;
		string tipoImovel = rdoImovel.SelectedItem.Text;
		string tipoImovelOutros = txtImovelOutros.Text;
		string veiculo = rdoVeiculo.SelectedItem.Text;
		string veiculoOutros = txtVeiculoOutros.Text;
		string preferenciaCurso = rdoLocal.SelectedItem.Text;
		string preferenciaHorario = rdoHorario.SelectedItem.Text;


		msg.Dictionary.Add("%cidade%", cidade);
		msg.Dictionary.Add("%bairro%", bairro);
		msg.Dictionary.Add("%endereco%", endereco);
		msg.Dictionary.Add("%telefone%", telefone);
		msg.Dictionary.Add("%escolaridade%", escolaridade);
		msg.Dictionary.Add("%escolaridadeOutros%", escolaridadeOutros);
		msg.Dictionary.Add("%tipoImovel%", tipoImovel);
		msg.Dictionary.Add("%tipoImovelOutros%", tipoImovelOutros);
		msg.Dictionary.Add("%veiculo%", veiculo);
		msg.Dictionary.Add("%veiculoOutros%", veiculoOutros);
		msg.Dictionary.Add("%preferenciaCurso%", preferenciaCurso);
		msg.Dictionary.Add("%preferenciaHorario%", preferenciaHorario);

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