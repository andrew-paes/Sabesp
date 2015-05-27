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
using System.Web.UI.HtmlControls;

public partial class fale_Conosco_FaleConoscoOld : BasePage
{
	#region Atributos
	RegiaoService regiaoService = new RegiaoService();
	FaleConoscoService faleConoscoService = new FaleConoscoService();
	string IdOutrasRegioes = "2000";
	#endregion

	#region Eventos

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			populaRegiao();
			populaAssunto();
			populaEstado();
			populaCidade();
			this.primeiraColunaDinamica1.DataBind();
		}
	}

	protected void btnSend_click(object sender, ImageClickEventArgs e)
	{
		this.SaveMessage();
	}

	protected void SaveMessage()
	{
		FaleConoscoMensagem mensagem = new FaleConoscoMensagem();
		mensagem.Nome = txtNome.Text;
		mensagem.Mensagem = tbMensagem.Text;
		try
		{
			mensagem.TelefoneDDD = Convert.ToInt32(txtDDD.Text);
		}
		catch
		{
			mensagem.TelefoneDDD = 0;
		}

		try
		{
			mensagem.FaleConoscoAssunto = new FaleConoscoAssunto();
			mensagem.FaleConoscoAssunto.FaleConoscoAssuntoId = Convert.ToInt32(ddlAssunto.SelectedValue);
		}
		catch
		{
			mensagem.FaleConoscoAssunto = null;
		}

		if (!String.IsNullOrEmpty(ddlRegiao.SelectedValue) && !ddlRegiao.SelectedValue.Equals("0") && !ddlRegiao.SelectedValue.Equals(IdOutrasRegioes))
		{
			mensagem.Regiao = new Regiao() { RegiaoId = Convert.ToInt32(ddlRegiao.SelectedValue) };
		}

		if (!String.IsNullOrEmpty(ddlEstado.SelectedValue) && !ddlEstado.SelectedValue.Equals("0"))
		{
			mensagem.Estado = new Estado() { EstadoId = Convert.ToInt32(ddlEstado.SelectedValue) };
		}
	
		if (!String.IsNullOrEmpty(ddlCidade.SelectedValue) && !ddlCidade.SelectedValue.Equals("0"))
		{
			mensagem.Cidade = new Cidade() { CidadeId = Convert.ToInt32(ddlCidade.SelectedValue) };
		}

		mensagem.Email = txtEmail.Text;
		mensagem.Atendido = false;
		faleConoscoService.Inserir(mensagem);

		this.ClearForm();

		phMensagemEnviada.Visible = true;
	}

	protected void ClearForm()
	{
		txtNome.Text = string.Empty;
		txtEmail.Text = string.Empty;
		txtDDD.Text = string.Empty;
		txtNumero.Text = string.Empty;
		ltrRegiaoSelected.Text = string.Empty;
		ddlRegiao.SelectedIndex = -1;
		ddlAssunto.SelectedIndex = -1;
		tbMensagem.Text = string.Empty;
		panelEstado.Visible = false;
	}

	protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
	{
		populaCidade();
		ltrEstadoSelected.Text = String.Concat("<var class=\"value\">", ((DropDownList)sender).SelectedItem.ToString(), "</var>");
		ltrCidadeSelected.Text = String.Concat("<var class=\"value\">", Convert.ToString(GetLocalResourceObject("EscolhaSuaCidade")), "</var>");
	}

	protected void ddlRegiao_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlRegiao.SelectedValue == IdOutrasRegioes)
		{
			panelEstado.Visible = true;
		}
		else
		{
			ddlEstado.SelectedIndex = 0;
			ddlCidade.SelectedIndex = 0;
			panelEstado.Visible = false;
		}

		ltrRegiaoSelected.Text = String.Concat("<var class=\"value\">", ((DropDownList)sender).SelectedItem.ToString(), "</var>");
		ltrEstadoSelected.Text = String.Concat("<var class=\"value\">", Convert.ToString(GetLocalResourceObject("EscolhaSeuEstado")), "</var>");
		ltrCidadeSelected.Text = String.Concat("<var class=\"value\">", Convert.ToString(GetLocalResourceObject("EscolhaSuaCidade")), "</var>");
	}

	protected void ddlCidade_SelectedIndexChanged(object sender, EventArgs e)
	{
		ltrCidadeSelected.Text = String.Concat("<var class=\"value\">", ((DropDownList)sender).SelectedItem.ToString(), "</var>");
	}

	#endregion

	#region Métodos

	protected void populaRegiao()
	{
		ddlRegiao.DataSource = regiaoService.RetornaTodos();
		ddlRegiao.DataTextField = "NomeRegiao";
		ddlRegiao.DataValueField = "RegiaoId";
		ddlRegiao.DataBind();
		ddlRegiao.Items.Insert(0, new ListItem(Convert.ToString(GetLocalResourceObject("EscolhaSuaRegiao")), "0"));
		ddlRegiao.Items.Add(new ListItem(Convert.ToString(GetLocalResourceObject("OutrosEstados")), IdOutrasRegioes));
	}

	protected void populaAssunto()
	{
		ddlAssunto.DataSource = faleConoscoService.ListarAssuntos();
		ddlAssunto.DataTextField = "Assunto";
		ddlAssunto.DataValueField = "FaleConoscoAssuntoId";
		ddlAssunto.DataBind();
		ddlAssunto.Items.Insert(0, new ListItem(Convert.ToString(GetLocalResourceObject("EscolhaOAssunto")), "0"));
	}

	protected void populaEstado()
	{
		ddlEstado.DataSource = faleConoscoService.ListarEstados();
		ddlEstado.DataTextField = "NomeEstado";
		ddlEstado.DataValueField = "EstadoId";
		ddlEstado.DataBind();
		ddlEstado.Items.Insert(0, new ListItem(Convert.ToString(GetLocalResourceObject("EscolhaSeuEstado")), "0"));
		ddlEstado.SelectedIndex = 0;
	}

	protected void populaCidade()
	{
		ddlCidade.Items.Clear();
		if (!string.IsNullOrEmpty(ddlEstado.SelectedValue) && ddlEstado.SelectedValue != "0")
		{
			ddlCidade.DataSource = faleConoscoService.ListarCidades(new Estado(Convert.ToInt32(ddlEstado.SelectedValue)));
			ddlCidade.DataTextField = "NomeCidade";
			ddlCidade.DataValueField = "cidadeId";
			ddlCidade.DataBind();
		}
		ddlCidade.Items.Insert(0, new ListItem(Convert.ToString(GetLocalResourceObject("EscolhaSuaCidade")), "0"));
		ddlCidade.SelectedIndex = 0;
	}

	#endregion


}