using System;
using System.Web;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Text;

public partial class fique_por_dentro_comunicados_Detalhes : BasePage
{
	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		/************************************************
		Remover a linha abaixo quando habilitar a nova página
		/************************************************/
		//Response.Redirect("http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=2&proj=AgenciaNoticias&pub=T&nome=ListaMaterias&db=&nivel=COMUNICADOS&pagina=1");


		if (RegistroId == 0)
		{
			this.RedirectToList();
		}
		else
		{
			this.LoadPage();
		}

		segundaColunaDinamica1.DataBind();
	}

	#endregion

	#region Methods

	/// <summary>
	/// Load "Comunicado" details
	/// </summary>
	protected void LoadPage()
	{
		// Get by Id
		ComunicadoService comunicadoService = new ComunicadoService();
		Comunicado comunicado = comunicadoService.CarregarToSite(RegistroId);

		// If exsit show details else redirect to list
		if (comunicado != null)
		{
			// Check selected "idioma"
			ComunicadoIdiomaService comunicadoIdiomaService = new ComunicadoIdiomaService();
			ComunicadoIdioma comunicadoIdioma = comunicadoIdiomaService.Carregar(new ComunicadoIdioma() { Comunicado = comunicado, Idioma = Util.CurrentIdioma });

			// If no "idioma" redirect to list (bad register)
			if (comunicadoIdioma != null)
			{
				this.AddHits(this.RegistroId);

				this.BindComunicado(comunicadoIdioma.TituloComunicado, comunicadoIdioma.TextoComunicado, comunicado.DataExibicaoInicio.Value);

				this.BindTags(comunicado.Conteudo.ConteudoId, Assuntos.Comunicado);

				conteudoRelacionado1.ContentDataBind(RegistroId);

				string strScript = "$(document).ready(function() {" +
												"try {" +
												"var pageTracker = _gat._getTracker('UA-17790992-1');" +
												"pageTracker._setDomainName('none');" +
												"pageTracker._setAllowLinker(true);" +
												"pageTracker._trackPageview('/Fique_por_Dentro/Comunicados/Visualizou_Comunicados/" + HttpUtility.UrlEncode(comunicadoIdioma.TituloComunicado, Encoding.GetEncoding(28597)).Replace("+", "_") + "');" +
												"} catch (err) { }" +
											"});";

				Page.ClientScript.RegisterStartupScript(GetType(), "scrSetGoogleAnalytics", strScript, true);

				boxZebrado.DataBind(Assuntos.Comunicado);
			}
			else
			{
				this.RedirectToList();
			}
		}
		else
		{
			this.RedirectToList();
		}
	}


	/// <summary>
	/// Rediretct to list page
	/// </summary>
	protected void RedirectToList()
	{
		Response.Redirect("comunicados-Default.aspx");
	}

	/// <summary>
	/// Bind details
	/// </summary>
	/// <param name="titulo">set titulo</param>
	/// <param name="comunicado">set comunicado</param>
	/// <param name="data">set comunicado date</param>
	protected void BindComunicado(string titulo, string comunicado, DateTime data)
	{
		this.ltrTituloComunicado.Text = titulo;
		this.ltrComunicado.Text = comunicado.ReplaceHtml();
		this.lblData.Text = String.Concat(data.ToString(Util.MaskDate), " às ", data.ToString("HH:mm"));
		conteudoAvaliacao.SetAll(titulo, Request.Url.AbsoluteUri);
		conteudoAvaliacao.HideRSS = true;
	}

	/// <summary>
	/// Bind "comunicado" tags
	/// </summary>
	/// <param name="conteudoId"></param>
	protected void BindTags(int conteudoId, Assuntos assunto)
	{
		this.tags1.ConteudoId = conteudoId;
		this.tags1.currentAssunto = assunto;
		this.tags1.DataBind();
	}

	#endregion
}