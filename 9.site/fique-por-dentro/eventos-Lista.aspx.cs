using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using Sabesp.FilterHelper;

public partial class eventos_Lista : BasePage
{

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindEventos();
            this.BindMaisVistos();
            boxZebrado.DataBind(Assuntos.Evento);
			segundaColunaDinamica1.DataBind();
        }
    }

    protected void lstEventos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

        if (IsPostBack)
        {
            BindEventos();
        }
    }

    /// <summary>
    /// Bind list view
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstEventos_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        bool visible = false;
        using (var item = ((ListViewDataItem)e.Item))
        {
            if (item != null)
            {
                var evento = (Evento)item.DataItem;
                if (evento != null)
                {
                    var hlEvento = (HyperLink)item.FindControl("hlEvento");
                    var lblData = (Label)item.FindControl("lblData");
                    var lblTitulo = (Label)item.FindControl("lblTitulo");
                    var lblTexto = (Label)item.FindControl("lblTexto");

                    EventoIdiomaService eventoIdiomaService = new EventoIdiomaService();
                    //load the language
                    EventoIdioma eventoIdioma = eventoIdiomaService.Carregar(new EventoIdioma() { Evento = evento, Idioma = Util.CurrentIdioma });
                    //bind the controls
                    if (eventoIdioma != null)
                    {
                        hlEvento.NavigateUrl = String.Concat("Eventos-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", evento.Conteudo.ConteudoId);
                        lblTitulo.Text = eventoIdioma.NomeEvento;
                        lblTexto.Text = eventoIdioma.ChamadaEvento.StripHTML().ReplaceHtml();
                        lblData.Text = evento.DataHoraPublicacao.Value.ToString(Util.MaskDate);
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
    protected void BindEventos()
    {
        EventoService eventoService = new EventoService();

        EventoFH filter = new EventoFH();
        ////dataHoraPublicacao <= NOW
        //filter.DataHoraPublicacaoPeriodoFinal = DateTime.Now.ToString("yyyy/MM/dd");

        ////dataExibicaoFim >= NOW
        //filter.DataHoraEventoFimPeriodoFinal = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

        string[] dataExibicaoInicio = { "dataHoraPublicacao" };
        string[] orderBy = { "DESC" };
        List<Evento> eventos = new List<Evento>();

        if (TagId > 0)
        {
            eventos = (List<Evento>)eventoService.CarregarTagged(TagId);
        }
        else
        {
            eventos = (List<Evento>)eventoService.RetornaTodosSite(0, dataExibicaoInicio, orderBy, filter);
        }

        
        lstEventos.DataSource = eventos;
        lstEventos.DataBind();
    }
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