using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using Sabesp.FilterHelper;

public partial class noticias_Lista : BasePage
{

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindNoticias();
            this.BindMaisVistos();
            boxZebrado.DataBind(Assuntos.Noticia);
			segundaColunaDinamica1.DataBind();
        }
    }

    protected void lstNoticias_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

        if (IsPostBack)
        {
            BindNoticias();            
        }
    }

    /// <summary>
    /// Bind list view
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstNoticias_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        bool visible = false;
        using (var item = ((ListViewDataItem)e.Item))
        {
            if (item != null)
            {
                var noticia = (Noticia)item.DataItem;
                if (noticia != null)
                {
                    var hlNoticia = (HyperLink)item.FindControl("hlNoticia");
                    var lblData = (Label)item.FindControl("lblData");
                    var lblTitulo = (Label)item.FindControl("lblTitulo");
                    var lblTexto = (Label)item.FindControl("lblTexto");

                    NoticiaIdiomaService noticiaIdiomaService = new NoticiaIdiomaService();
                    //load the language
                    NoticiaIdioma noticiaIdioma = noticiaIdiomaService.Carregar(new NoticiaIdioma() { Noticia = noticia, Idioma = Util.CurrentIdioma });
                    //bind the controls
                    if (noticiaIdioma != null)
                    {
                        hlNoticia.NavigateUrl = String.Concat("Noticias-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", noticia.Conteudo.ConteudoId);
                        lblTitulo.Text = noticiaIdioma.TituloNoticia;
						lblTexto.Text = Server.HtmlDecode(noticiaIdioma.ChamadaNoticia.ReplaceHtml()).StripHTML();
                        lblData.Text = noticia.DataExibicaoInicio.Value.ToString(Util.MaskDate);
                        visible = true;
                    }
                }
            }
        }
        e.Item.Visible = visible;
    }

    #endregion 

    #region Methods

    /// <summary>
    /// Get the data to bind the listview
    /// </summary>
    protected void BindNoticias()
    {
        NoticiaService noticiaService = new NoticiaService();

        string[] dataExibicaoInicio = { "dataExibicaoInicio" };
        string[] orderBy = { "DESC" };
        List<Noticia> noticias = new List<Noticia>();
        if (TagId > 0)
        {
            noticias = (List<Noticia>)noticiaService.CarregarTagged(TagId);
        }
        else
        {
            noticias = (List<Noticia>)noticiaService.RetornaTodosSite(0, dataExibicaoInicio, orderBy, null);
        }
        lstNoticias.DataSource = noticias;
        lstNoticias.DataBind();

    }
    protected void BindMaisVistos()
    {
        NoticiaService noticiaService = new NoticiaService();
        List<Noticia> noticias = new List<Noticia>();
        noticias = (List<Noticia>)noticiaService.CarregarMaisVistos(3);
        noticiaMaisVistos.Noticias = noticias;
        noticiaMaisVistos.DataBind();
    }
    #endregion

}