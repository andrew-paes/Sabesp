using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Enumerators;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;

public partial class eventos_Default : BasePage
{
    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadResources();
        this.BindDestaques();
        this.BindMaisVistos();
        this.BindProximos();
        boxZebrado.DataBind(Assuntos.Evento);
		segundaColunaDinamica1.DataBind();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Load the resources based in current language
    /// </summary>
    protected void LoadResources()
    {
        hlTodosEventos.NavigateUrl = String.Concat("Eventos-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
        hlTodosEventos.Text = GetLocalResourceObject(hlTodosEventos.ID).ToString();
    }

    protected void BindDestaques()
    {
        EventoService eventoService = new EventoService();
        string[] dataExibicaoInicio = { "dataHoraPublicacao" };
        string[] orderBy = { "DESC" };

        List<Evento> eventos = (List<Evento>)eventoService.RetornaTodosSite(5, dataExibicaoInicio, orderBy, new EventoFH() { DestaqueEventos = "1" });

        if (eventos != null && eventos.Count > 0)
        {
            eventoDestaqueGrande1.Evento = eventos[0];
            eventoDestaqueGrande1.DataBind();

            eventos.RemoveAt(0);
            eventoDestaqueLista1.Eventos = eventos;
            eventoDestaqueLista1.DataBind();
        }
        else
        {
            eventoDestaqueGrande1.Visible = false;
            eventoDestaqueLista1.Visible = false;
        }
    }
    protected void BindMaisVistos()
    {
        EventoService eventoService = new EventoService();
        List<Evento> eventos = new List<Evento>();
        eventos = (List<Evento>)eventoService.CarregarMaisVistos(3);
        eventoMaisVistos.Eventos = eventos;
        eventoMaisVistos.DataBind();
    }
    protected void BindProximos()
    {
        EventoService eventoService = new EventoService();
        List<Evento> eventos = new List<Evento>();
        eventos = (List<Evento>)eventoService.CarregarProxEventos(4);
        eventoProximos.Eventos = eventos;
        eventoProximos.DataBind();
    }
    #endregion
}