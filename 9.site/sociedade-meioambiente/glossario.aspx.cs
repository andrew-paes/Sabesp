using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Script.Services;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;

[WebService]
public partial class social_e_ambiental_glossario : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
        body.Attributes.Add("class", "interna");

		this.segundaColunaDinamica1.DataBind();

        if (!IsPostBack)
        {
            this.LoadDescrSessao();
            if (Request.QueryString["palavra"] != null)
            {
                this.DataBind(Request.QueryString["palavra"].Substring(0, 1).ToUpper());
            }
            else
            {
                this.DataBind("A");
            }
        }
    }
    /// <summary>
    /// Bind the repeater control
    /// </summary>
    public void DataBind(string Letra)
    {
        string[] palavra = { "palavra" };
        string[] orderBy = { "ASC" };

        GlossarioIdiomaService glossarioIdiomaService = new GlossarioIdiomaService();
        List<GlossarioIdioma> glossarioIdiomas = (List<GlossarioIdioma>)glossarioIdiomaService.CarregarTodos(0, 0, palavra, orderBy, new GlossarioIdiomaFH() { Palavra = Letra, IdiomaId = Util.CurrentIdioma.IdiomaId.ToString() });
        LinkButton lbtLetter = (LinkButton)Util.FindControlRecursive(this, Letra);
        lbtLetter.Attributes.Add("class", "atv");
        this.hdnLetterAtu.Value = Letra;
        this.rptGlossario.DataSource = glossarioIdiomas;
        this.rptGlossario.DataBind();
    }
    private void LoadDescrSessao()
    {
        Secao entidadeSecao = new Secao();
        entidadeSecao.SecaoId = SecaoId;
        entidadeSecao = new SecaoService().Carregar(entidadeSecao);

        SecaoIdioma entidadeSecaoIdioma = new SecaoIdioma();
        entidadeSecaoIdioma.Secao = new Secao();
        entidadeSecaoIdioma.Secao = entidadeSecao;
        entidadeSecaoIdioma.Idioma = new Idioma();
        entidadeSecaoIdioma.Idioma.IdiomaId = 1;
        entidadeSecaoIdioma = new SecaoIdiomaService().Carregar(entidadeSecaoIdioma);
        this.ltrGlossario.Text = entidadeSecaoIdioma.Titulo;
        this.ltrDescrGlossario.Text = entidadeSecaoIdioma.Texto;
    }
    public void populaLista(List<GlossarioIdioma> glossarioIdiomas)
    {
        this.rptGlossario.DataSource = glossarioIdiomas;
        this.rptGlossario.DataBind();
    
    }
    protected void rptGlossario_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            var ltrPalavra = (Literal)e.Item.FindControl("ltrPalavra");
            var ltrDescricao = (Literal)e.Item.FindControl("ltrDescricao");

            GlossarioIdioma glossarioIdioma = (GlossarioIdioma)e.Item.DataItem;
            if (glossarioIdioma != null)
            {
                ltrPalavra.Text = glossarioIdioma.Palavra.ReplaceHtml();
                ltrDescricao.Text = glossarioIdioma.Descricao.ReplaceHtml();
            }
            else
            {
                e.Item.Visible = false;
            }
        }
    }
    public void ChangeLetter(object sender, EventArgs e)
    {
        string[] palavra = { "palavra" };
        string[] orderBy = { "ASC" };
        LinkButton lbtLetter = (LinkButton)sender;
        //troca classe do botão anterior para carrigir a aba
        
        LinkButton lbtLetterAnt = (LinkButton)Util.FindControlRecursive(this,this.hdnLetterAtu.Value.ToString());
        lbtLetterAnt.Attributes.Remove("class");        

        //atualiza a aba e o hidden
        lbtLetter.Attributes.Add("class", "atv");
        this.hdnLetterAtu.Value = lbtLetter.ID;
        GlossarioIdiomaService glossarioIdiomaService = new GlossarioIdiomaService();
        List<GlossarioIdioma> glossarioIdiomas = (List<GlossarioIdioma>)glossarioIdiomaService.CarregarTodos(0, 0, palavra, orderBy, new GlossarioIdiomaFH() { Palavra = lbtLetter.ID, IdiomaId = Util.CurrentIdioma.IdiomaId.ToString() });        
        this.rptGlossario.DataSource = glossarioIdiomas;
        this.rptGlossario.DataBind();

    }
}
