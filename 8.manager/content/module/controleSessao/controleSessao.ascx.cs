using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Ag2.Manager.Helper;
using Sabesp.BO;
using Sabesp.Data;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;

public partial class content_module_controleSessao_controleSessao : SmartUserControl
{
    protected Secao entidadeSecao; // Ini Business Object to "secao"
    protected SecaoIdioma entidadeSecaoIdioma; // Ini Business Object to "secaoIdioma"
    protected Controle entidadeControle; // Ini Business Object to "controle"
    protected ControleSessao entidadeControleSessao;
    protected IList<Controle> entidadeControleList;

    protected SecaoService secaoService; // Ini Service to "secao"
    protected SecaoIdiomaService secaoIdiomaService; // Ini Service to "secaoIdioma"
    protected ControleService controleService; // Ini Service to "controle"
    protected ControleSessaoService controleSessaoService;

    protected SecaoFH secaoFH; // Ini FilterHelper to "secao"
    protected SecaoIdiomaFH secaoIdiomaFH; // Ini FilterHelper to "secaoIdioma"
    protected ControleFH controleFH;
    protected ControleSessaoFH controleSessaoFH;

    protected List<ControleSessao> entidadeControleSessaoList;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.DefineProperties();

        if (this.IdRegistro > 0)
        {
            if (!IsPostBack || this.IdiomaHasChanged)
            {
                this.LoadProperties();
                this.LoadForm();
            }
        }
    }

    /// <summary>
    /// Clear the form
    /// </summary>
    protected void ClearForm()
    {
        //txtTitulo.Text = string.Empty;
    }

    /// <summary>
    /// Define all services to all properties
    /// </summary>
    private void DefineProperties()
    {
        this.entidadeSecao = new Secao(); // Instance Business Object to "secao"
        this.secaoService = new SecaoService(); // Instance Service to "secao"
        this.secaoFH = new SecaoFH(); // Instance Filter Helper to "secao"

        this.entidadeSecaoIdioma = new SecaoIdioma(); // Instance Business Object to "secaoIdioma"
        this.secaoIdiomaService = new SecaoIdiomaService(); // Instance Service to "secaoIdioma"
        this.secaoIdiomaFH = new SecaoIdiomaFH(); // Instance Filter Helper to "secaoIdioma"

        this.entidadeControle = new Controle(); // Instance Business Object to "controle"
        this.controleService = new ControleService(); // Instance Service to "controle"
        this.controleFH = new ControleFH(); // Instance Filter Helper to "controle"
    }

    /// <summary>
    /// Load all properties
    /// </summary>
    private void LoadProperties()
    {
        this.entidadeSecao.SecaoId = Convert.ToInt32(IdRegistro);
        this.entidadeSecao = this.secaoService.Carregar(entidadeSecao); // Find "conteudo" by ID and Add to BO

        if (entidadeSecao != null)
        {
            this.entidadeSecao.SecaoIdiomas = new List<SecaoIdioma>();

            this.entidadeSecaoIdioma.Secao = new Secao();
            this.entidadeSecaoIdioma.Secao.SecaoId = this.entidadeSecao.SecaoId;
            this.entidadeSecaoIdioma.Idioma = new Idioma();
            this.entidadeSecaoIdioma.Idioma.IdiomaId = this.IdiomaId;
            this.entidadeSecaoIdioma = this.secaoIdiomaService.Carregar(entidadeSecaoIdioma);

            if (this.entidadeSecaoIdioma != null)
            {
                this.entidadeSecao.SecaoIdiomas.Add(entidadeSecaoIdioma);
            }
        }

        entidadeControleList = new List<Controle>();
        entidadeControleList = controleService.RetornaTodos();
    }

    /// <summary>
    /// Get all BO and set on the form
    /// </summary>
    protected void LoadForm()
    {
        this.ClearForm();

        if (this.entidadeSecao != null)
        {
            this.txtSecao.Text = this.entidadeSecao.SecaoIdiomas[0].Titulo;
        }

        if (this.entidadeControleList != null)
        {
            this.rptControle.DataSource = this.entidadeControleList;
            this.rptControle.DataBind();
        }
    }

    protected void rptControle_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        this.BindRepeaterControl(sender, e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    private void BindRepeaterControl(object sender, RepeaterItemEventArgs e)
    {
        var dr = (Controle)e.Item.DataItem;

        // Get Controls
        var chkControle = (CheckBox)e.Item.FindControl("chkControle");
        var ddlControle = (DropDownList)e.Item.FindControl("ddlControle");
        var ddlControlePosicao = (DropDownList)e.Item.FindControl("ddlControlePosicao");
        var ltlControle = (Literal)e.Item.FindControl("ltlControle");

        chkControle.Attributes.Add("ControleId", Convert.ToString(dr.ControleId));
        ltlControle.Text = dr.Nome;

        controleSessaoFH = new ControleSessaoFH();
        controleSessaoFH.ControleId = Convert.ToString(dr.ControleId);
        controleSessaoFH.SecaoId = entidadeSecao.SecaoId.ToString();
        controleSessaoService = new ControleSessaoService();
        IList<ControleSessao> entidadeControleSessaoIList = controleSessaoService.RetornaTodos(0, 0, "", "ASC", controleSessaoFH);

        if (entidadeControleSessaoIList != null && entidadeControleSessaoIList.Count > 0)
        {
            chkControle.Checked = true;
            ddlControle.SelectedValue = entidadeControleSessaoIList[0].Coluna.ToString();
            ddlControlePosicao.SelectedValue = entidadeControleSessaoIList[0].Posicao.ToString();
        }
    }

    /// <summary>
    /// Pass all prop from the form to service properties
    /// </summary>
    private bool FormToLoad()
    {
        bool isValid = false;
        this.entidadeSecao.SecaoId = Convert.ToInt32(IdRegistro);

        if (IdRegistro > 0)
        {
            this.entidadeControleSessaoList = new List<ControleSessao>();

            // Foreach item into repeater check to save boxsessioncontrols 
            foreach (RepeaterItem item in this.rptControle.Items)
            {
                // Get itens from repeater
                CheckBox chkControle = (CheckBox)item.FindControl("chkControle");

                if (chkControle.Checked)
                {
                    this.entidadeControleSessao = new ControleSessao();

                    DropDownList ddlControle = (DropDownList)item.FindControl("ddlControle");
                    int coluna = 0;
                    coluna = Convert.ToInt32(ddlControle.SelectedValue);

                    DropDownList ddlControlePosicao = (DropDownList)item.FindControl("ddlControlePosicao");
                    int posicao = 0;
                    posicao = Convert.ToInt32(ddlControlePosicao.SelectedValue);

                    if (coluna > 0)
                    {
                        if (!String.IsNullOrEmpty(chkControle.Attributes["ControleId"]))
                        {
                            this.entidadeControleSessao.Controle = new Controle();
                            this.entidadeControleSessao.Controle.ControleId = Convert.ToInt32(chkControle.Attributes["ControleId"]);
                            this.entidadeControleSessao.SecaoId = entidadeSecao.SecaoId;
                            this.entidadeControleSessao.Coluna = coluna;
                            this.entidadeControleSessao.Posicao = posicao;
                            entidadeControleSessaoList.Add(entidadeControleSessao);
                        }

                        isValid = true;
                    }
                    else
                    {
                        Util.ShowMessage("Selecione uma coluna para o controle marcado!");
                    }
                }
            }
        }

        return isValid;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExecute_Click(object sender, ImageClickEventArgs e)
    {
        if (this.FormToLoad())
        {
            this.Execute();
        }
    }

    /// <summary>
    /// Execute transaction to insert or save "Sessao"
    /// </summary>
    private void Execute()
    {
        try
        {
            if (entidadeControleSessaoList != null)
            {
                this.Update();
                Util.ShowMessage("Registro atualizado com sucesso.");
            }
        }
        catch
        {
            Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde");
        }

    }

    /// <summary>
    /// Update the "secao" with yours "controleSessao"
    /// </summary>
    protected void Update()
    {
        controleSessaoService = new ControleSessaoService();
        if (this.entidadeSecao != null)
        {
            this.controleSessaoService.Excluir(this.entidadeSecao); // Exclude all registers in "ControleSessao" by SecaoId
        }

        // Verify if exist a list of "controleSessao" that must be cretated in FormToLoad()
        if (entidadeControleSessaoList != null)
        {
            // Foreach entidadeControleSessaoList to insert a "controleSessao"
            foreach (ControleSessao entidadeControleSessaoTemp in this.entidadeControleSessaoList)
            {
                new ControleSessaoService().Inserir(entidadeControleSessaoTemp); // Insert a "controleSessao"
            }
        }
    }
}