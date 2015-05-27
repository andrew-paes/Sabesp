using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;
using Sabesp.Enumerators;

public partial class controls_tags_listaTags : SmartUserControl
{
    #region Properties

    /// <summary>
    /// page that will be list all the content with the specified tag
    /// </summary>
    private string _hrefTag = "search.aspx?tag={0}";

    /// <summary>
    /// template of link to render the tag link
    /// </summary>
    private string _templateTag = "<a href=\"{0}\" class=\"{1}\">{2}</a>";

    /// <summary>
    /// Property that set the Css Class of link tag
    /// </summary>
    public String CssClass { get; set; }

    /// <summary>
    /// Id of content to bind the list of tags
    /// </summary>
    public int ConteudoId { get; set; }

    public Assuntos currentAssunto { get; set; }

    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void DataBind()
    {
        base.DataBind();

        this.ConfigureControl();
        this.BindTags();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Configure the initial values of this control
    /// </summary>
    private void ConfigureControl()
    {
        ltrTags.Text = string.Empty;
    }

    /// <summary>
    /// Bind the tags
    /// </summary>
    private void BindTags()
    {
        ConteudoTagService conteudoTagService = new ConteudoTagService();
        List<ConteudoTag> lCTags = (List<ConteudoTag>)conteudoTagService.RetornaTodos(0, 0, string.Empty, string.Empty, new ConteudoTagFH() { ConteudoId = this.ConteudoId.ToString() });

        if (lCTags != null)
        {
            TagService tagService = new TagService();

            foreach (ConteudoTag cTag in lCTags)
            {
                Tag tag = tagService.Carregar(cTag.Tag);
                if (tag != null)
                {
                    switch (currentAssunto)
                    {
                        case Assuntos.Noticia:
                            _hrefTag = String.Concat("../fique-por-dentro/Noticias-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                            break;

                        case Assuntos.Comunicado:
                            _hrefTag = String.Concat("../fique-por-dentro/Comunicados-Default.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                            break;

                        case Assuntos.Evento:
                            _hrefTag = String.Concat("../fique-por-dentro/Eventos-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                            break;

                        case Assuntos.Podcast:
                            _hrefTag = String.Concat("../fique-por-dentro/Podcasts-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                            break;
                        case Assuntos.Video:
                            _hrefTag = String.Concat("../fique-por-dentro/tv-sabesp-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                            break;
                        case Assuntos.Release:
                            _hrefTag = String.Concat("../imprensa/releases-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&tagId=", tag.TagId);
                            break;

                    }
                    if (!String.IsNullOrEmpty(ltrTags.Text))
                    {
                        ltrTags.Text = String.Concat(ltrTags.Text, ", ", String.Format(_templateTag, String.Format(_hrefTag, tag.Palavra), this.CssClass, tag.Palavra));
                    }
                    else
                    {
                        ltrTags.Text = String.Format(_templateTag, String.Format(_hrefTag, tag.Palavra), this.CssClass, tag.Palavra);
                    }
                }
            }
        }

        //if there's no tags, hide de control
        if (String.IsNullOrEmpty(ltrTags.Text))
        {
            this.Visible = false;
        }
    }

    #endregion
}
