using System;
using System.Collections.Generic;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Sabesp.FilterHelper;

public partial class controls_topo : SmartUserControl
{
	#region Properties

	private Boolean? _isHome = null;
	private Boolean? _isFiquePorDentro = null;

	/// <summary>
	/// Gets if this actual page is the Home of website (session does haven't a SecaoPai)
	/// </summary>
	protected bool IsHome
	{
		get
		{
			if (this._isHome == null)
			{
				SecaoService secaoService = new SecaoService();
				Secao currentSecao = secaoService.Carregar(new Secao() { SecaoId = SecaoId });
				if (currentSecao != null && currentSecao.SecaoPai == null)
				{
					this._isHome = true;
				}
				else
				{
					this._isHome = false;
				}
			}

			return Convert.ToBoolean(this._isHome);
		}
	}

	/// <summary>
	/// Gets if this actual page is the Fique Por Dentro or if is one of your children
	/// </summary>
	protected bool IsFiquePorDentro
	{
		get
		{
			if (this._isFiquePorDentro == null)
			{
				SecaoService secaoService = new SecaoService();
				Secao _secao = secaoService.GetRoot(SecaoId);
				if (_secao != null && _secao.SecaoId == MenuPrincipal.FiquePorDentro.GetHashCode())
				{
					this._isFiquePorDentro = true;
				}
				else
				{
					this._isFiquePorDentro = false;
				}
			}
			return Convert.ToBoolean(this._isFiquePorDentro);
		}
	}

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	protected void LoadPage()
	{
		this.LoadResources();
		this.LoadComunicado();
	}

	/// <summary>
	/// Change the current language of site
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void lnkbtIdioma_Click(object sender, EventArgs e)
	{
		Cookie cookie = new Cookie();
		if (Util.CurrentIdiomaId == Idiomas.Portugues.GetHashCode())
		{
			//if the current language is Portuguese, set language to English
			cookie.IdiomaId = Idiomas.Ingles.GetHashCode();
		}
		else
		{
			//if the current language is English, set the language to Portuguese
			cookie.IdiomaId = Idiomas.Portugues.GetHashCode();
		}

		//Redirects to same page to certify that all data will be bound again
		Response.Redirect(Request.Url.AbsoluteUri, false);
	}

	#endregion

	#region Methods

	/// <summary>
	/// Bind the controls that use Resource Files
	/// </summary>
	protected void LoadResources()
	{
		hlSaibaMais.Text = GetLocalResourceObject(hlSaibaMais.ID).ToString();
		lnkbtIdioma.Text = GetLocalResourceObject(lnkbtIdioma.ID).ToString();
		hlFornecedores.Text = GetLocalResourceObject(hlFornecedores.ID).ToString();
		hlFornecedores.NavigateUrl = String.Concat("~/interna/Default.aspx?secaoId=", MenuPrincipal.Fornecedores.GetHashCode());
		hlInvestidores.Text = GetLocalResourceObject(hlInvestidores.ID).ToString();
		hlFaleConosco.Text = GetLocalResourceObject(hlFaleConosco.ID).ToString();
		hlFaleConosco.NavigateUrl = String.Concat("~/fale-conosco/Default.aspx?secaoId=", MenuPrincipal.FaleConosco.GetHashCode());
        hlAgenciaVirtual.NavigateUrl = "http://www2.sabesp.com.br/agvirtual2/asp/serv_rgi.asp";
	}

	/// <summary>
	/// Load the Comunicado based in current Secao
	/// </summary>
	protected void LoadComunicado()
	{
		ComunicadoService comunicadoService = new ComunicadoService();
		ComunicadoFH filter = new ComunicadoFH();

		if (this.IsHome)
		{
			filter.DestaqueHome = "1"; // Set 1 like true
		}
		else if (this.IsFiquePorDentro)
		{
			filter.DestaqueFiquePorDentro = "1"; // Set 1 like true
		}

		string[] dataExibicaoInicio = { "dataExibicaoInicio" };
		string[] orderBy = { "DESC" };

		IList<Comunicado> listaComunicado = comunicadoService.RetornaTodosSite(0, 0, dataExibicaoInicio, orderBy, filter);
		if (listaComunicado != null && listaComunicado.Count > 0)
		{
			ComunicadoIdiomaService comunicadoIdiomaService = new ComunicadoIdiomaService();
			//iterates agains listaComunicado to find one item with the current language
			foreach (Comunicado item in listaComunicado)
			{
				ComunicadoIdioma comunicadoIdioma = comunicadoIdiomaService.Carregar(new ComunicadoIdioma() { Comunicado = item, Idioma = Util.CurrentIdioma });
				//if this item has the current language
				if (comunicadoIdioma != null)
				{
					//bind the control with Comunicado title
					ltrComunicado.Text = comunicadoIdioma.TituloComunicado;
					//bin the control with the link to "Comunicado" detail
					hlSaibaMais.NavigateUrl = String.Concat("~/fique-por-dentro/comunicados-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", item.Conteudo.ConteudoId);
					//break the foreach because only the first will appear on site
					break;
				}
			}
			//if there no Comunicado with this language, hide the control
			if (String.IsNullOrEmpty(ltrComunicado.Text))
			{
				pnlComunicado.Visible = false;
			}
		}
		else
		{
			pnlComunicado.Visible = false;
		}
	}

	#endregion

}
