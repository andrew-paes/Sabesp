using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.Enumerators;
using System.Text;

public partial class eventos_Detalhes : BasePage
{
	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
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
	/// Load the page
	/// </summary>
	protected void LoadPage()
	{
		EventoService eventoService = new EventoService();
		Evento evento = eventoService.CarregarToSite(RegistroId);
		if (evento != null)
		{
			this.AddHits(RegistroId);
			EventoIdiomaService eventoIdiomaService = new EventoIdiomaService();
			EventoIdioma eventoIdioma = eventoIdiomaService.Carregar(new EventoIdioma() { Evento = evento, Idioma = Util.CurrentIdioma });
			if (eventoIdioma != null)
			{
				this.BindEvento(eventoIdioma.NomeEvento, eventoIdioma.DescricaoEvento, evento.DataHoraPublicacao.Value, evento.Local);
				this.BindFotos(RegistroId);
				this.BindTags(evento.Conteudo.ConteudoId, Assuntos.Evento);
				this.BindMaisVistos();
				conteudoRelacionado1.ContentDataBind(RegistroId);
				boxZebrado.DataBind(Assuntos.Evento);

				string strScript = "$(document).ready(function() {" +
												"try {" +
												"var pageTracker = _gat._getTracker('UA-17790992-1');" +
												"pageTracker._setDomainName('none');" +
												"pageTracker._setAllowLinker(true);" +
												"pageTracker._trackPageview('/Fique_por_Dentro/Eventos/Visualizou_Evento/" + HttpUtility.UrlEncode(eventoIdioma.NomeEvento, Encoding.GetEncoding(28597)).Replace("+", "_") + "');" +
												"} catch (err) { }" +
											"});";

				Page.ClientScript.RegisterStartupScript(GetType(), "scrSetGoogleAnalytics", strScript, true);
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
	/// Redirect to list of eventos
	/// </summary>
	protected void RedirectToList()
	{
		Response.Redirect("eventos-Default.aspx");
	}

	/// <summary>
	/// Bind the information about "Evento"
	/// </summary>
	/// <param name="titulo"></param>
	/// <param name="evento"></param>
	/// <param name="data"></param>
	protected void BindEvento(string titulo, string evento, DateTime data, string local)
	{
		ltrTituloEvento.Text = titulo;
		lblLocal.Text = local;
		ltrEvento.Text = evento.ReplaceHtml();

		if (data.Hour != 0)
			lblData.Text = String.Concat(data.ToString(Util.MaskDate), " às ", data.ToString("HH:mm"));
		else
			lblData.Text = data.ToString(Util.MaskDate);

		conteudoAvaliacao.SetAll(titulo, Request.Url.AbsoluteUri);
		conteudoAvaliacao.UrlRSS = String.Concat("~/rss/rss-evento.aspx?idioma=", Util.CurrentIdiomaId);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="conteudoId"></param>
	/// <param name="assunto"></param>
	protected void BindTags(int conteudoId, Assuntos assunto)
	{
		this.tags1.ConteudoId = conteudoId;
		this.tags1.currentAssunto = assunto;
		this.tags1.DataBind();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="eventoId"></param>
	protected void BindFotos(int eventoId)
	{

		EventoFotoService eventoFotoService = new EventoFotoService();
		List<EventoFoto> eventoFotos = new List<EventoFoto>();
		eventoFotos = (List<EventoFoto>)eventoFotoService.CarregarFotos(eventoId);

		eventoGaleriaImagens1.Fotos = eventoFotos;
		eventoGaleriaImagens1.DataBind();

	}

	/// <summary>
	/// 
	/// </summary>
	protected void BindMaisVistos()
	{
		EventoService eventoService = new EventoService();
		List<Evento> eventos = new List<Evento>();
		eventos = (List<Evento>)eventoService.CarregarMaisVistos(3);
		eventoMaisVistos.Eventos = eventos;
		eventoMaisVistos.DataBind();
	}

	#endregion
}