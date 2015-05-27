using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;

public partial class content_module_relacionamento_relacionamento : System.Web.UI.UserControl
{
    Database db = DatabaseFactory.CreateDatabase();
    private int _id = 0;

    public int idRel { get; set; }

    public void dataBind()
    {
        MostrarRelacionamentos();
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            _id = Convert.ToInt32(Request.QueryString["id"]);
        }
        else
        {
            _id = idRel;
        }

        //Carrega dados do Formulario
        if (_id != null)
        {
            _id = Convert.ToInt32(Request.QueryString["id"]);

            if (Request.QueryString["msg"] == "OK")
                Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Registro atualizado com sucesso.\",\"false\");</script>");
            if (Request.QueryString["msg"] == "OKi")
                Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Registro inserido com sucesso.\",\"false\");</script>");



            if (!IsPostBack)
            {

                MontaComboDadosConteudo();
                MontaComboTipoConteudo();
                MostrarRelacionamentos();
            }
        }
    }

    private void MontaComboDadosConteudo()
    {

        Database db = DatabaseFactory.CreateDatabase();
        string sql = @"SELECT tipo FROM conteudo 
                       JOIN conteudoTipo ON  conteudoTipo.conteudoTipoId = conteudo.conteudoTipoId
                       WHERE conteudoId = @conteudoId
                        ";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, _id);
        DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

        if (dt.Rows.Count > 0)
        {
            lblTipo.Text = dt.Rows[0][0].ToString();
            //lblNome.Text = dt.Rows[0][1].ToString();

        }
    }

    private void MontaComboTipoConteudo()
    {
        Database db = DatabaseFactory.CreateDatabase();
        //// Dados do segmento
        string sql = @"select conteudoTipoId, tipo from conteudotipo";
        DbCommand dataProc = db.GetSqlStringCommand(sql);
        DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

        ddlTipoConteudo.DataSource = dt;
        ddlTipoConteudo.DataTextField = "tipo";
        ddlTipoConteudo.DataValueField = "conteudoTipoId";
        ddlTipoConteudo.DataBind();

        ddlTipoConteudo.Items.Insert(0, new ListItem(":: Selecione ::", ""));
    }

    protected void ddlTipoConteudo_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Tipos de Paineis
        if (ddlTipoConteudo.SelectedValue == "1")
        {
            pnComunicado.Visible = false;
            pnPodcast.Visible = false;
            pnVideo.Visible = false;
            pnEvento.Visible = false;
            pnNoticia.Visible = true;

        }
        if (ddlTipoConteudo.SelectedValue == "2")
        {
            pnComunicado.Visible = false;
            pnPodcast.Visible = false;
            pnVideo.Visible = false;
            pnEvento.Visible = true;
            pnNoticia.Visible = false;
        }

        if (ddlTipoConteudo.SelectedValue == "3")
        {
            pnComunicado.Visible = true;
            pnPodcast.Visible = false;
            pnVideo.Visible = false;
            pnEvento.Visible = false;
            pnNoticia.Visible = false;
        }
        if (ddlTipoConteudo.SelectedValue == "4")
        {
            pnComunicado.Visible = false;
            pnPodcast.Visible = false;
            pnVideo.Visible = true;
            pnEvento.Visible = false;
            pnNoticia.Visible = false;
        }
        if (ddlTipoConteudo.SelectedValue == "5")
        {
            pnComunicado.Visible = false;
            pnPodcast.Visible = true;
            pnVideo.Visible = false;
            pnEvento.Visible = false;
            pnNoticia.Visible = false;
        }
        #endregion
    }

    #region Video
    protected void btnBuscaVideo_Click(object sender, EventArgs e)
    {

        //Busca dos Artigos sem conteúdo relacionado ao Conteúdo que esta sendo editado ou inserido.
        Database db = DatabaseFactory.CreateDatabase();
        string sql = @"SELECT Video.videoId, Video.ativo, Video.destaqueHome, Video.destaqueVideos
		                        , Video.destaqueFiquePorDentro, Video.dataHoraPublicacao, Video.urlYoutube, Video.autor
		                        , VideoIdioma.idiomaId, VideoIdioma.tituloVideo, VideoIdioma.descricaoVideo
                        FROM dbo.Video inner join dbo.VideoIdioma ON VideoIdioma.VideoId = dbo.Video.VideoId
                        WHERE 
	                        Video.VideoId NOT IN 
		                        (SELECT conteudoIdRelacionado as VideoId 
		                         FROM conteudoRelacionado 
		                         WHERE conteudoIdPai = @conteudoId)
				                        AND VideoIdioma.tituloVideo like @tituloVideo
                        ";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@tituloVideo", DbType.String, String.Concat("%", txtSearchVideo.Text.ToString(), "%"));
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, _id);
        DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

        grdVideo.DataSource = dt;
        grdVideo.DataBind();
    }

    protected void btnGravarVideo_Click(object sender, EventArgs e)
    {

        //Verifica Conteúdos selecionados
        List<int> register = new List<int>();

        foreach (GridViewRow row in grdVideo.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelect")).Checked)
            {
                register.Add(int.Parse(grdVideo.DataKeys[row.RowIndex].Value.ToString()));
            }
        }

        if (register.Count > 0)
        {
            //Insere relacionamento ao Conteúdo que esta sendo Editado ou Inserido.
            try
            {
                foreach (var item in register)
                {
                    //Gravar relacionamento
                    DbCommand dataProc = db.GetStoredProcCommand("conteudoRelacionadoInsert");
                    db.AddInParameter(dataProc, "@conteudoIdPai", DbType.Int32, _id);
                    db.AddInParameter(dataProc, "@conteudoIdRelacionado", DbType.Int32, Convert.ToInt32(item));
                    db.ExecuteNonQuery(dataProc);
                    //Page.RegisterStartupScript("scrStatusMessage", "<script>setStatusMessage(\"FEITO!!\",\"true\");</script>");
                    Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Conteúdo Relacionado com sucesso.\",\"false\");</script>");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("alert('" + ex.Message + "');");
                Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Não foi possivel Relacionar este Conteúdo.\",\"false\");</script>");
            }

            MostrarRelacionamentos();
            ddlTipoConteudo.SelectedIndex = 0;
        }
    }
    #endregion

    #region Podcast
    protected void btnBuscaPodcast_Click(object sender, EventArgs e)
    {

        Database db = DatabaseFactory.CreateDatabase();
        string sql = @"SELECT Podcast.podcastId, Podcast.ativo, Podcast.dataHoraPublicacao, Podcast.destaqueHome
		                        , Podcast.destaqueFiquePorDentro, Podcast.destaquePodcasts, Podcast.autor
		                        , PodcastIdioma.idiomaId, PodcastIdioma.tituloPodcast, PodcastIdioma.descricaoPodcast
		                        , PodcastIdioma.arquivoIdPodcast
                        FROM dbo.Podcast inner join dbo.PodcastIdioma ON PodcastIdioma.podcastId = dbo.Podcast.podcastId
                        WHERE 
	                        Podcast.podcastId NOT IN 
		                        (SELECT conteudoIdRelacionado as podcastId 
		                         FROM conteudoRelacionado 
		                         WHERE conteudoIdPai = @conteudoId)
				                        AND PodcastIdioma.tituloPodcast like @tituloPodcast
                        ";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@tituloPodcast", DbType.String, String.Concat("%", txtSearchPodcast.Text.ToString(), "%"));
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, _id);
        DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

        grdPodcast.DataSource = dt;
        grdPodcast.DataBind();
    }

    protected void btnGravarPodcast_Click(object sender, EventArgs e)
    {

        //Verifica Conteúdos selecionados
        List<int> register = new List<int>();

        foreach (GridViewRow row in grdPodcast.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelect")).Checked)
            {
                register.Add(int.Parse(grdPodcast.DataKeys[row.RowIndex].Value.ToString()));
            }
        }

        if (register.Count > 0)
        {
            //Insere relacionamento ao Conteúdo que esta sendo Editado ou Inserido.
            try
            {
                foreach (var item in register)
                {
                    //Gravar relacionamento
                    DbCommand dataProc = db.GetStoredProcCommand("conteudoRelacionadoInsert");
                    db.AddInParameter(dataProc, "@conteudoIdPai", DbType.Int32, _id);
                    db.AddInParameter(dataProc, "@conteudoIdRelacionado", DbType.Int32, Convert.ToInt32(item));
                    db.ExecuteNonQuery(dataProc);
                    //Page.RegisterStartupScript("scrStatusMessage", "<script>setStatusMessage(\"FEITO!!\",\"true\");</script>");
                    Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Conteúdo Relacionado com sucesso.\",\"false\");</script>");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("alert('" + ex.Message + "');");
                Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Não foi possivel Relacionar este Conteúdo.\",\"false\");</script>");
            }

            MostrarRelacionamentos();

            ddlTipoConteudo.SelectedIndex = 0;

        }
    }
    #endregion

    #region Comunicado
    protected void btnBuscaComunicado_Click(object sender, EventArgs e)
    {

        Database db = DatabaseFactory.CreateDatabase();
        string sql = @"SELECT Comunicado.comunicadoId, Comunicado.ativo, Comunicado.destaqueHome, Comunicado.destaqueFiquePorDentro
		                        , Comunicado.dataHoraPublicacao, Comunicado.dataExibicaoInicio, Comunicado.dataExibicaoFim
		                        , ComunicadoIdioma.idiomaId, ComunicadoIdioma.tituloComunicado, ComunicadoIdioma.textoComunicado
                        FROM dbo.Comunicado inner join dbo.ComunicadoIdioma ON ComunicadoIdioma.comunicadoId = dbo.Comunicado.comunicadoId
                        WHERE 
	                        Comunicado.comunicadoId NOT IN 
		                        (SELECT conteudoIdRelacionado as comunicadoId 
		                         FROM conteudoRelacionado 
		                         WHERE conteudoIdPai = @conteudoId)
				                        AND ComunicadoIdioma.titulocomunicado like @tituloComunicado
                        ";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@tituloComunicado", DbType.String, String.Concat("%", txtSearchComunicado.Text.ToString(), "%"));
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, _id);
        DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

        grdComunicado.DataSource = dt;
        grdComunicado.DataBind();
    }

    protected void btnGravarComunicado_Click(object sender, EventArgs e)
    {

        //Verifica Conteúdos selecionados
        List<int> register = new List<int>();

        foreach (GridViewRow row in grdComunicado.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelect")).Checked)
            {
                register.Add(int.Parse(grdComunicado.DataKeys[row.RowIndex].Value.ToString()));
            }
        }

        if (register.Count > 0)
        {
            //Insere relacionamento ao Conteúdo que esta sendo Editado ou Inserido.
            try
            {
                foreach (var item in register)
                {
                    //Gravar relacionamento
                    DbCommand dataProc = db.GetStoredProcCommand("conteudoRelacionadoInsert");
                    db.AddInParameter(dataProc, "@conteudoIdPai", DbType.Int32, _id);
                    db.AddInParameter(dataProc, "@conteudoIdRelacionado", DbType.Int32, Convert.ToInt32(item));
                    db.ExecuteNonQuery(dataProc);
                    //Page.RegisterStartupScript("scrStatusMessage", "<script>setStatusMessage(\"FEITO!!\",\"true\");</script>");
                    Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Conteúdo Relacionado com sucesso.\",\"false\");</script>");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("alert('" + ex.Message + "');");
                Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Não foi possivel Relacionar este Conteúdo.\",\"false\");</script>");
            }

            MostrarRelacionamentos();

            ddlTipoConteudo.SelectedIndex = 0;

        }
    }
    #endregion

    #region Evento
    protected void btnBuscaEvento_Click(object sender, EventArgs e)
    {

        Database db = DatabaseFactory.CreateDatabase();
        string sql = @"SELECT Evento.eventoId, Evento.ativo, Evento.dataHoraPublicacao, Evento.dataHoraEventoInicio
		                    , Evento.dataHoraEventoFim, Evento.arquivoIdThumbGrande, Evento.arquivoIdThumbMedio
		                    , Evento.destaqueEventos, Evento.local, Evento.destaqueFiquePorDentro
		                    , EventoIdioma.idiomaId, EventoIdioma.nomeEvento, EventoIdioma.descricaoEvento, EventoIdioma.chamadaEvento	
                        FROM dbo.Evento inner join dbo.EventoIdioma ON EventoIdioma.eventoId = dbo.Evento.eventoId
                        WHERE 
	                        Evento.eventoId NOT IN 
		                        (SELECT conteudoIdRelacionado as eventoId 
		                         FROM conteudoRelacionado 
		                         WHERE conteudoIdPai = @conteudoId)
				            AND EventoIdioma.nomeEvento like @nomeEvento
                            AND Evento.Ativo = 1
                        ";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@nomeEvento", DbType.String, String.Concat("%", txtSearchEvento.Text.ToString(), "%"));
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, _id);
        DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

        grdEvento.DataSource = dt;
        grdEvento.DataBind();
    }

    protected void btnGravarEvento_Click(object sender, EventArgs e)
    {

        //Verifica Conteúdos selecionados
        List<int> register = new List<int>();

        foreach (GridViewRow row in grdEvento.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelect")).Checked)
            {
                register.Add(int.Parse(grdEvento.DataKeys[row.RowIndex].Value.ToString()));
            }
        }

        if (register.Count > 0)
        {
            //Insere relacionamento ao Conteúdo que esta sendo Editado ou Inserido.
            try
            {
                foreach (var item in register)
                {
                    //Gravar relacionamento
                    DbCommand dataProc = db.GetStoredProcCommand("conteudoRelacionadoInsert");
                    db.AddInParameter(dataProc, "@conteudoIdPai", DbType.Int32, _id);
                    db.AddInParameter(dataProc, "@conteudoIdRelacionado", DbType.Int32, Convert.ToInt32(item));
                    db.ExecuteNonQuery(dataProc);
                    //Page.RegisterStartupScript("scrStatusMessage", "<script>setStatusMessage(\"FEITO!!\",\"true\");</script>");
                    Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Conteúdo Relacionado com sucesso.\",\"false\");</script>");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("alert('" + ex.Message + "');");
                Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Não foi possivel Relacionar este Conteúdo.\",\"false\");</script>");
            }

            MostrarRelacionamentos();

            ddlTipoConteudo.SelectedIndex = 0;

        }
    }
    #endregion

    #region Noticia
    protected void btnBuscaNoticia_Click(object sender, EventArgs e)
    {

        Database db = DatabaseFactory.CreateDatabase();
        string sql = @"SELECT noticia.noticiaId, noticia.ativa, noticia.autor, noticia.destaqueHome, noticia.destaqueNoticias
		                    , noticia.destaqueFiquePorDentro, noticia.fonte, noticia.fonteUrl, noticia.dataHoraPublicacao
		                    , noticia.dataExibicaoInicio, noticia.dataExibicaoFim, noticia.arquivoIdThumbGrande
		                    , noticia.arquivoIdThumbMedio, NoticiaIdioma.tituloNoticia
                    FROM 
	                    noticia inner join dbo.NoticiaIdioma On NoticiaIdioma.noticiaId = noticia.noticiaId
                    WHERE 
	                    Noticia.noticiaId NOT IN 
		                    (SELECT conteudoIdRelacionado as noticiaId 
		                     FROM conteudoRelacionado 
		                     WHERE conteudoIdPai = @conteudoId)
			                       AND tituloNoticia like @titulo
                        ";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@titulo", DbType.String, String.Concat("%", txtsearchNoticia.Text.ToString(), "%"));
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, _id);
        DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

        grdNoticia.DataSource = dt;
        grdNoticia.DataBind();
    }

    protected void btnGravarNoticia_Click(object sender, EventArgs e)
    {

        //Verifica Conteúdos selecionados
        List<int> register = new List<int>();

        foreach (GridViewRow row in grdNoticia.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelect")).Checked)
            {
                register.Add(int.Parse(grdNoticia.DataKeys[row.RowIndex].Value.ToString()));
            }
        }

        if (register.Count > 0)
        {
            //Insere relacionamento ao Conteúdo que esta sendo Editado ou Inserido.
            try
            {
                foreach (var item in register)
                {
                    //Gravar relacionamento
                    DbCommand dataProc = db.GetStoredProcCommand("conteudoRelacionadoInsert");
                    db.AddInParameter(dataProc, "@conteudoIdPai", DbType.Int32, _id);
                    db.AddInParameter(dataProc, "@conteudoIdRelacionado", DbType.Int32, Convert.ToInt32(item));
                    db.ExecuteNonQuery(dataProc);
                    //Page.RegisterStartupScript("scrStatusMessage", "<script>setStatusMessage(\"FEITO!!\",\"true\");</script>");
                    Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Conteúdo Relacionado com sucesso.\",\"false\");</script>");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("alert('" + ex.Message + "');");
                Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Não foi possivel Relacionar este Conteúdo.\",\"false\");</script>");
            }

            MostrarRelacionamentos();

            ddlTipoConteudo.SelectedIndex = 0;

        }
    }
    #endregion

    #region Release
    protected void btnBuscaRelease_Click(object sender, EventArgs e)
    {

        Database db = DatabaseFactory.CreateDatabase();
        string sql = @"SELECT release.noticiaId, release.ativa, release.autor, 
                        release.dataHoraPublicacao, ReleaseIdioma.tituloNoticia
                    FROM 
	                    release inner join dbo.ReleaseIdioma On ReleaseIdioma.releaseId = release.releaseId
                    WHERE 
	                    release.releaseId NOT IN 
		                    (SELECT conteudoIdRelacionado as releaseId 
		                     FROM conteudoRelacionado 
		                     WHERE conteudoIdPai = @conteudoId)
			                       AND tituloRelease like @titulo
                        ";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@titulo", DbType.String, String.Concat("%", txtsearchRelease.Text.ToString(), "%"));
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, _id);
        DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

        grdRelease.DataSource = dt;
        grdRelease.DataBind();
    }

    protected void btnGravarRelease_Click(object sender, EventArgs e)
    {

        //Verifica Conteúdos selecionados
        List<int> register = new List<int>();

        foreach (GridViewRow row in grdNoticia.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelect")).Checked)
            {
                register.Add(int.Parse(grdRelease.DataKeys[row.RowIndex].Value.ToString()));
            }
        }

        if (register.Count > 0)
        {
            //Insere relacionamento ao Conteúdo que esta sendo Editado ou Inserido.
            try
            {
                foreach (var item in register)
                {
                    //Gravar relacionamento
                    DbCommand dataProc = db.GetStoredProcCommand("conteudoRelacionadoInsert");
                    db.AddInParameter(dataProc, "@conteudoIdPai", DbType.Int32, _id);
                    db.AddInParameter(dataProc, "@conteudoIdRelacionado", DbType.Int32, Convert.ToInt32(item));
                    db.ExecuteNonQuery(dataProc);
                    //Page.RegisterStartupScript("scrStatusMessage", "<script>setStatusMessage(\"FEITO!!\",\"true\");</script>");
                    Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Conteúdo Relacionado com sucesso.\",\"false\");</script>");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("alert('" + ex.Message + "');");
                Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Não foi possivel Relacionar este Conteúdo.\",\"false\");</script>");
            }

            MostrarRelacionamentos();

            ddlTipoConteudo.SelectedIndex = 0;

        }
    }
    #endregion

    #region Itens Relacionados
    protected void btnExcluirRelacionamento_Click(object sender, EventArgs e)
    {
        List<int> register = new List<int>();

        foreach (GridViewRow row in grdRelacionado.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelect")).Checked)
            {
                register.Add(int.Parse(grdRelacionado.DataKeys[row.RowIndex].Value.ToString()));
            }
        }

        if (register.Count > 0)
        {
            //Exclui relacionamento ao Conteúdo que esta sendo Editado ou Inserido.
            try
            {
                foreach (var item in register)
                {
                    //Gravar relacionamento
                    DbCommand dataProc = db.GetStoredProcCommand("conteudoRelacionadoDelete");
                    db.AddInParameter(dataProc, "@conteudoIdPai", DbType.Int32, _id);
                    db.AddInParameter(dataProc, "@conteudoIdRelacionado", DbType.Int32, Convert.ToInt32(item));
                    db.ExecuteNonQuery(dataProc);
                    DbCommand dataProcR = db.GetStoredProcCommand("conteudoRelacionadoDelete");
                    db.AddInParameter(dataProcR, "@conteudoIdPai", DbType.Int32, Convert.ToInt32(item));
                    db.AddInParameter(dataProcR, "@conteudoIdRelacionado", DbType.Int32, _id);
                    db.ExecuteNonQuery(dataProcR);
                    Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Relacionamento excluído com sucesso.\",\"false\");</script>");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("alert('" + ex.Message + "');");
                Page.ClientScript.RegisterStartupScript(GetType(), "scrStatusMessage", "<script>setStatusMessage(\"Não foi possivel remover.\",\"false\");</script>");
            }

            MostrarRelacionamentos();
        }
    }

    private void MostrarRelacionamentos()
    {
        Database db = DatabaseFactory.CreateDatabase();

        string sql = @"SELECT 
                             conteudoId, tipo
	                        , tituloComunicado, tituloVideo, tituloPodcast, nomeEvento, tituloNoticia
                        FROM Conteudo
	                        JOIN ConteudoTipo ON ConteudoTipo.conteudoTipoId = Conteudo.ConteudoTipoId
	                        LEFT Join dbo.Comunicado ON Comunicado.comunicadoId = Conteudo.conteudoId
	                        LEFT JOIN dbo.ComunicadoIdioma ON ComunicadoIdioma.comunicadoId = Comunicado.comunicadoId
	                        LEFT Join dbo.Video ON Video.videoId = Conteudo.conteudoId
	                        LEFT JOIN dbo.VideoIdioma ON VideoIdioma.VideoId = Video.VideoId
	                        LEFT Join dbo.Podcast ON Podcast.podcastId = Conteudo.conteudoId
	                        LEFT JOIN dbo.PodcastIdioma ON PodcastIdioma.podcastId = Podcast.podcastId
	                        LEFT Join dbo.Evento ON Evento.eventoId = Conteudo.conteudoId
	                        LEFT JOIN dbo.EventoIdioma ON EventoIdioma.eventoId = Evento.eventoId
	                        LEFT Join dbo.Noticia ON Noticia.noticiaId = Conteudo.conteudoId
	                        LEFT JOIN dbo.NoticiaIdioma ON NoticiaIdioma.noticiaId = Noticia.noticiaId
                        WHERE conteudoId IN 
                        (
                            SELECT conteudoIdRelacionado as conteudoId FROM viewConteudoRelacionadoLista WHERE conteudoIdPai = @conteudoId
                        )
                        ORDER BY tipo
                    ";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, _id);
        DataTable dt = db.ExecuteDataSet(dataProc).Tables[0];

        grdRelacionado.DataSource = dt;
        grdRelacionado.DataBind();

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label lblTit = (Label)grdRelacionado.Rows[i].FindControl("lblTit");

                if (dt.Rows[i]["tituloComunicado"] != null && dt.Rows[i]["tituloComunicado"].ToString() != "")
                {
                    lblTit.Text = dt.Rows[i]["tituloComunicado"].ToString();
                }

                else if (dt.Rows[i]["tituloVideo"] != null && dt.Rows[i]["tituloVideo"].ToString() != "")
                {
                    lblTit.Text = dt.Rows[i]["tituloVideo"].ToString();
                }

                else if (dt.Rows[i]["tituloPodcast"] != null && dt.Rows[i]["tituloPodcast"].ToString() != "")
                {
                    lblTit.Text = dt.Rows[i]["tituloPodcast"].ToString();
                }

                else if (dt.Rows[i]["nomeEvento"] != null && dt.Rows[i]["nomeEvento"].ToString() != "")
                {
                    lblTit.Text = dt.Rows[i]["nomeEvento"].ToString();
                }

                else if (dt.Rows[i]["tituloNoticia"] != null && dt.Rows[i]["tituloNoticia"].ToString() != "")
                {
                    lblTit.Text = dt.Rows[i]["tituloNoticia"].ToString();
                }

                else
                {
                    lblTit.Text = "";
                }
            }
        }

        pnRelacionados.Visible = true;

        if (dt.Rows.Count < 1)
        {
            pnRelacionados.Visible = false;
            lblVazio.Visible = true;
        }
        else
            lblVazio.Visible = false;

        if (pnComunicado.Visible == true)
            btnBuscaComunicado_Click(null, null);
        if (pnEvento.Visible == true)
            btnBuscaEvento_Click(null, null);
        if (pnNoticia.Visible == true)
            btnBuscaNoticia_Click(null, null);
        if (pnPodcast.Visible == true)
            btnBuscaPodcast_Click(null, null);
        if (pnVideo.Visible == true)
            btnBuscaVideo_Click(null, null);
        if (pnRelacionar.Visible == true)
            btnExcluirRelacionamento_Click(null, null);
    }
    #endregion

    protected void grdGeral_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;

        if (e.Row.Cells[0].FindControl("chkAllVideo") != null)
        {
            ((CheckBox)e.Row.Cells[0].FindControl("chkAllVideo")).Attributes.Add("onclick", string.Concat("javascript:SelectAllCheckboxesGrid(this, '" + grdVideo.ClientID.ToString() + "');"));
        }
        else if (e.Row.Cells[0].FindControl("chkAllPodcast") != null)
        {
            ((CheckBox)e.Row.Cells[0].FindControl("chkAllPodcast")).Attributes.Add("onclick", string.Concat("javascript:SelectAllCheckboxesGrid(this, '" + grdPodcast.ClientID.ToString() + "');"));
        }
        else if (e.Row.Cells[0].FindControl("chkAllComunicado") != null)
        {
            ((CheckBox)e.Row.Cells[0].FindControl("chkAllComunicado")).Attributes.Add("onclick", string.Concat("javascript:SelectAllCheckboxesGrid(this, '" + grdComunicado.ClientID.ToString() + "');"));
        }
        else if (e.Row.Cells[0].FindControl("chkAllEvento") != null)
        {
            ((CheckBox)e.Row.Cells[0].FindControl("chkAllEvento")).Attributes.Add("onclick", string.Concat("javascript:SelectAllCheckboxesGrid(this, '" + grdEvento.ClientID.ToString() + "');"));
        }
        else if (e.Row.Cells[0].FindControl("chkAllNoticia") != null)
        {
            ((CheckBox)e.Row.Cells[0].FindControl("chkAllNoticia")).Attributes.Add("onclick", string.Concat("javascript:SelectAllCheckboxesGrid(this, '" + grdNoticia.ClientID.ToString() + "');"));
        }
        else if (e.Row.Cells[0].FindControl("chkAllRelacionado") != null)
        {
            ((CheckBox)e.Row.Cells[0].FindControl("chkAllRelacionado")).Attributes.Add("onclick", string.Concat("javascript:SelectAllCheckboxesGrid(this, '" + grdRelacionado.ClientID.ToString() + "');"));
        }

    }

    protected void grdRelacionado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());

        switch (e.CommandName)
        {
            case "detalhe":
                Response.Redirect("../content/edit.aspx?md=relacionamento&id=" + this.grdRelacionado.DataKeys[Id].Value);
                break;
        }
    }
}
