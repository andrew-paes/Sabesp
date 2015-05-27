using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Interfaces;
using System.Data;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using Sabesp.Enumerators;

public partial class tagsAssuntos : SmartUserControl
{
    #region [ Properties ]

    


    private Assuntos currentTipo { get; set; }
    #endregion

    #region [ Constructors ]
    /// <summary>
    /// Box Zebrado
    /// </summary>
    public tagsAssuntos() { }

    #endregion

    #region [ Events ]

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
                
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptTags_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Tag tag = (Tag)e.Item.DataItem;
        HyperLink hypAssunto = (HyperLink)e.Item.FindControl("hlComunicado");
        hypAssunto.Text = tag.Palavra;

        switch (currentTipo)
        {
            case Assuntos.Noticia:
                hypAssunto.NavigateUrl = String.Concat("../fique-por-dentro/Noticias-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(),"&tagId=", tag.TagId);
                break;

            case Assuntos.Comunicado:
                hypAssunto.NavigateUrl = String.Concat("../fique-por-dentro/Comunicados-Default.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                break;

            case Assuntos.Evento:
                hypAssunto.NavigateUrl = String.Concat("../fique-por-dentro/Eventos-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                break;

            //case Assuntos.faq:
            //    this.rptTags.DataSource = this.BindFaq();
            //    break;
            case Assuntos.Podcast:
                hypAssunto.NavigateUrl = String.Concat("../fique-por-dentro/Podcasts-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                break;
            case Assuntos.Video:
                hypAssunto.NavigateUrl = String.Concat("../fique-por-dentro/tv-sabesp-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                break;

        }
    }

    #endregion

    #region [ Methods ]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tipo"></param>
    public void DataBind(Assuntos tipo)
    {
        var ltrAssuntos = (Literal)this.FindControl("ltrAssuntos");
        List<Tag> assuntos = new List<Tag>();
        ltrAssuntos.Text = GetLocalResourceObject(ltrAssuntos.ID).ToString();
        this.currentTipo = tipo;
        switch (tipo)
        {
            case Assuntos.Noticia:
                assuntos = this.BindNoticias();
                break;

            case Assuntos.Comunicado:
                assuntos = this.BindComunicados();
                break;

            case Assuntos.Evento:
                assuntos = this.BindEventos();
                break;

            case Assuntos.Podcast:
                assuntos = this.BindPodcasts();
                break;
            case Assuntos.Video:
                assuntos = this.BindVideos();
                break;

        }
        if (assuntos != null && assuntos.Count > 0)
        {
            this.rptTags.DataSource = assuntos;
            this.rptTags.DataBind();
        }
        else
        {
            this.Visible = false;
        }
        

    }
    /// <summary>
    /// 
    /// </summary>
    private void BindFAQ()
    { 

    }

    private void populaListaTags(ref List<Tag> tags, List<ConteudoTag> conteudoTags)
    {
        if (conteudoTags != null)
        {
            List<Tag> Tags = new List<Tag>();
            TagService tagService = new TagService();
            foreach (ConteudoTag conteudoTag in conteudoTags)
            {
                tags.Add(tagService.Carregar(conteudoTag.Tag));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private List<Tag> BindNoticias()
    {
        TagService service = new TagService();
        List<Tag> tags = service.CarregarTagsDeNoticias(new Idioma() { IdiomaId = 1 });

        return tags != null && tags.Count > 0 ? tags : null;
    }

    /// <summary>
    /// 
    /// </summary>
    private List<Tag> BindEventos()
    {
        TagService service = new TagService();
        List<Tag> tags = service.CarregarTagsDeEventos(new Idioma() { IdiomaId = 1 });

        return tags != null && tags.Count > 0 ? tags : null;
    }
    /// <summary>
    /// 
    /// </summary>
    private List<Tag> BindComunicados()
    {
        TagService service = new TagService();
        List<Tag> tags = service.CarregarTagsDeComunicados(new Idioma() { IdiomaId = 1 });

        return tags != null && tags.Count > 0 ? tags : null;
    }

    /// <summary>
    /// 
    /// </summary>
    private List<Tag> BindPodcasts()
    {
        TagService service = new TagService();
        List<Tag> tags = service.CarregarTagsDePodcasts(new Idioma() { IdiomaId = 1 });

        return tags != null && tags.Count > 0 ? tags : null;
    }

    /// <summary>
    /// 
    /// </summary>
    private List<Tag> BindVideos()
    {
        TagService service = new TagService();
        List<Tag> tags = service.CarregarTagsDeVideos(new Idioma() { IdiomaId = 1 });

        return tags != null && tags.Count > 0 ? tags : null;
    } 

    #endregion

}
