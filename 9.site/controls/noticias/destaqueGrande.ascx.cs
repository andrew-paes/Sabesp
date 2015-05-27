using System;
using System.Web;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.IO;
public partial class controls_noticias_destaqueGrande : SmartUserControl
{
	#region Properties

	private String _cssClass = "newsDestaque after";
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
	/// Id of object "Noticia" to try to load and bind controls
	/// </summary>
	public int NoticiaId { get; set; }

	/// <summary>
	/// Object noticia to bind controls
	/// </summary>
	public Noticia Noticia { get; set; }

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
		if (this.Noticia == null)
		{
			NoticiaService noticiaService = new NoticiaService();
			this.Noticia = noticiaService.Carregar(new Noticia() { Conteudo = new Conteudo(this.NoticiaId) });
		}

		//bind the control
		this.BindNoticia(this.Noticia);
	}

	/// <summary>
	/// Bind the control with values of Noticia
	/// </summary>
	/// <param name="noticia"></param>
	protected void BindNoticia(Noticia noticia)
	{
		if (noticia != null)
		{
			NoticiaIdiomaService noticiaIdiomaService = new NoticiaIdiomaService();
			NoticiaIdioma noticiaIdioma = noticiaIdiomaService.Carregar(new NoticiaIdioma() { Noticia = noticia, Idioma = Util.CurrentIdioma });
			if (noticiaIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();
				if (noticia.ArquivoThumbGrande != null && noticia.ArquivoThumbGrande.ArquivoId > 0)
				{
					noticia.ArquivoThumbGrande = arquivoService.Carregar(noticia.ArquivoThumbGrande);
				}

				if (noticia.ArquivoThumbGrande != null)
				{
					imgDestaque.ImageUrl = String.Concat("~/uploads/secao/", noticia.ArquivoThumbGrande.NomeArquivo);
				}
				else
				{
					divImgDestaque.Attributes.Add("style", "display:none");
				}

				hlTitulo.NavigateUrl = String.Concat("~/fique-por-dentro/noticias-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", noticia.Conteudo.ConteudoId);
				ltrTitulo.Text = noticiaIdioma.TituloNoticia;
				lblChamada.Text = noticiaIdioma.ChamadaNoticia.StripHTML().ReplaceHtml();
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
