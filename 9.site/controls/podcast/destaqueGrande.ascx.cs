using System;
using System.Web;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;

public partial class controls_podcasts_destaqueGrande : SmartUserControl
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
    /// Id of object "Podcast" to try to load and bind controls
    /// </summary>
    public int PodcastId { get; set; }

    /// <summary>
    /// Object podcast to bind controls
    /// </summary>
    public Podcast Podcast { get; set; }

    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// configure the properties of this control and your children
    /// </summary>

    public override void DataBind()
    {
        base.DataBind();

        //if the object is null, try to load
        if (this.Podcast == null)
        {
            PodcastService podcastService = new PodcastService();
            this.Podcast = podcastService.Carregar(new Podcast() { Conteudo = new Conteudo(this.PodcastId) });
        }

        //bind the control
        this.BindPodcast(this.Podcast);
    }

    /// <summary>
    /// Bind the control with values of Podcast
    /// </summary>
    /// <param name="podcast"></param>
    protected void BindPodcast(Podcast podcast)
    {
        if (podcast != null)
        {
            PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
            PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });
            if (podcastIdioma != null)
            {
                ArquivoService arquivoService = new ArquivoService();
                if (podcastIdioma.ArquivoPodcast != null && podcastIdioma.ArquivoPodcast.ArquivoId > 0)
                    podcastIdioma.ArquivoPodcast = arquivoService.Carregar(podcastIdioma.ArquivoPodcast);

				hlTitulo.NavigateUrl = String.Concat("~/fique-por-dentro/podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
                ltrTitulo.Text = podcastIdioma.TituloPodcast;
                lblChamada.Text = podcastIdioma.DescricaoPodcast.StripHTML().ReplaceHtml();
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
