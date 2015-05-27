using System;
using System.Web;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.IO;
public partial class controls_eventos_destaqueGrande : SmartUserControl
{
	#region Properties

	private String _cssClass = "newsDestaque";
	/// <summary>
	/// Gets or sets the CssClass of Panel (div)
	/// </summary>
	public String CssClass
	{
		get
		{
			return this._cssClass;
		}
		set
		{
			this._cssClass = value;
		}
	}

	/// <summary>
	/// Id of object "Evento" to try to load and bind controls
	/// </summary>
	public int EventoId { get; set; }

	/// <summary>
	/// Object evento to bind controls
	/// </summary>
	public Evento Evento { get; set; }

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.ConfigureControls();
	}

	/// <summary>
	/// configure the properties of this control and your children
	/// </summary>
	protected void ConfigureControls()
	{
		pnlDestaque.CssClass = this.CssClass;
	}

	public override void DataBind()
	{
		base.DataBind();

		//if the object is null, try to load
		if (this.Evento == null)
		{
			EventoService eventoService = new EventoService();
			this.Evento = eventoService.Carregar(new Evento() { Conteudo = new Conteudo(this.EventoId) });
		}

		//bind the control
		this.BindEvento(this.Evento);
	}

	/// <summary>
	/// Bind the control with values of Evento
	/// </summary>
	/// <param name="evento"></param>
	protected void BindEvento(Evento evento)
	{
		if (evento != null)
		{
			EventoIdiomaService eventoIdiomaService = new EventoIdiomaService();
			EventoIdioma eventoIdioma = eventoIdiomaService.Carregar(new EventoIdioma() { Evento = evento, Idioma = Util.CurrentIdioma });
			if (eventoIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();
				if (evento.ArquivoThumbGrande != null && evento.ArquivoThumbGrande.ArquivoId > 0)
					evento.ArquivoThumbGrande = arquivoService.Carregar(evento.ArquivoThumbGrande);

				if (evento.ArquivoThumbGrande != null && File.Exists(String.Concat("~/uploads/secao/", evento.ArquivoThumbGrande.NomeArquivo)))
				{
					imgDestaque.ImageUrl = String.Concat("~/uploads/secao/", evento.ArquivoThumbGrande.NomeArquivo);
				}
				else
				{
					divImgDestaque.Attributes.Add("style", "display:none");
				}
				hlTitulo.NavigateUrl = String.Concat("~/fique-por-dentro/eventos-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", evento.Conteudo.ConteudoId);
				ltrTitulo.Text = eventoIdioma.NomeEvento;
                lblChamada.Text = eventoIdioma.ChamadaEvento.StripHTML().ReplaceHtml();
			}
		}
		else
		{
			//if object is null then, hide the control
			this.Visible = false;
		}
	}

	#endregion
}
