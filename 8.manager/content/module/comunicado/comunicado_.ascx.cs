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

public partial class content_module_comunicado_comunicado : SmartUserControl
{
    protected Conteudo conteudo;
    protected Comunicado entidadeComunicado;
    protected ComunicadoIdioma entidadeComunicadoIdioma;
    protected Tag entidadeTag;
    protected ConteudoTag entidadeConteudoTag;
    protected ComunicadoService comunicadoService;
    protected ComunicadoIdiomaService comunicadoIdiomaService;
    protected TagService tagService;
    protected ConteudoTagService conteudoTagService;
    protected ConteudoTagFH conteudoTagFH;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.DefineProperties();

        if (this.IdRegistro > 0)
        {
            if (!IsPostBack || this.IdiomaHasChanged)
            {
                this.LoadProperties();
                this.LoadForm();

                pnlRelacionado.Visible = true;
            }
        }
        else
        {
            pnlRelacionado.Visible = false;
        }
    }

    /// <summary>
    /// Clear the form
    /// </summary>
    protected void ClearForm()
    {
        txtTitulo.Text = string.Empty;
        txtdtFim.Text = string.Empty;
        txtdtInicio.Text = string.Empty;
        txtdtPublicacao.Text = string.Empty;
        txtTags.Text = string.Empty;
        txtTitulo.Text = string.Empty;

        //chbAtivo.SelectedValue = "0";
        //chbDestaqueFique.SelectedValue = "0";
        //chbDestaqueHome.SelectedValue = "0";
    }

    /// <summary>
    /// Define all services to all properties
    /// </summary>
    private void DefineProperties()
    {
        // Ini service to "conteudo"
        conteudo = new Conteudo();
        conteudo.Comunicado = new Comunicado();
        conteudo.Comunicado.ComunicadoIdiomas = new List<ComunicadoIdioma>();
        conteudo.ConteudoTipo = new ConteudoTipo();
        conteudo.Tages = new List<Tag>();
        //conteudo.Comunicado.ComunicadoIdiomas[0].Idioma.IdiomaId = this.IdiomaId;

        // Ini service to "tag"
        entidadeTag = new Tag();

        // Ini service to "comunicado"
        entidadeComunicado = new Comunicado();
        entidadeComunicado.Conteudo = new Conteudo();
        entidadeComunicado.ComunicadoIdiomas = new List<ComunicadoIdioma>();
        entidadeComunicadoIdioma = new ComunicadoIdioma();
        entidadeComunicadoIdioma.Comunicado = new Comunicado();
        entidadeComunicadoIdioma.Comunicado.Conteudo = new Conteudo();
        entidadeComunicadoIdioma.Idioma = new Idioma();
        entidadeComunicadoIdioma.Idioma.IdiomaId = this.IdiomaId;
        entidadeConteudoTag = new ConteudoTag();

        comunicadoService = new ComunicadoService();
        comunicadoIdiomaService = new ComunicadoIdiomaService();
        conteudoTagService = new ConteudoTagService();
        conteudoTagFH = new ConteudoTagFH();
    }

    /// <summary>
    /// Load all properties
    /// </summary>
    private void LoadProperties()
    {
        // Find and add "conteudo"        
        conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
        conteudo = new ConteudoService().Carregar(conteudo);

        entidadeComunicado.Conteudo.ConteudoId = conteudo.ConteudoId; // Ini "comunicado"
        entidadeComunicadoIdioma.Comunicado.Conteudo.ConteudoId = conteudo.ConteudoId; // Define "comunicadoIdioma"
        entidadeComunicado = comunicadoService.Carregar(entidadeComunicado); // Find "comunicado"

        entidadeComunicado.ComunicadoIdiomas = new List<ComunicadoIdioma>();
        entidadeComunicado.ComunicadoIdiomas.Add(comunicadoIdiomaService.Carregar(entidadeComunicadoIdioma)); // Add "comunicadoIdioma"

        conteudo.Comunicado = entidadeComunicado; // Add "comunicado" to "conteudo"        
        conteudo.Comunicado = new ComunicadoService().Carregar(entidadeComunicado); // Add "comunicadoIdioma" to "comunicado"
        conteudo.Comunicado.ComunicadoIdiomas = entidadeComunicado.ComunicadoIdiomas;

        conteudo.Tages = new List<Tag>();

        // Search all "ConteudoTag" by ID of "Conteudo"
        IList<ConteudoTag> conteudoTagList = new List<ConteudoTag>();
        conteudoTagFH.ConteudoId = Convert.ToString(conteudo.ConteudoId);
        conteudoTagList = new ConteudoTagService().RetornaTodos(0, 0, "palavra", "ASC", conteudoTagFH);

        foreach (ConteudoTag conteudoTag in conteudoTagList)
        {
            entidadeTag = new Tag();
            entidadeTag = new TagService().Carregar(conteudoTag.Tag.TagId);
            if (entidadeTag != null)
            {
                conteudo.Tages.Add(entidadeTag);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected void LoadForm()
    {
        this.ClearForm();

        if (conteudo != null
            && conteudo.Comunicado != null
            && conteudo.Comunicado.ComunicadoIdiomas != null
            && conteudo.Comunicado.ComunicadoIdiomas.Count > 0)
        {
            txtTitulo.Text = conteudo.Comunicado.ComunicadoIdiomas[0].TituloComunicado.ToString();
            txtComunicado.Text = conteudo.Comunicado.ComunicadoIdiomas[0].TextoComunicado.ToString();
            txtdtPublicacao.Text = entidadeComunicado.DataHoraPublicacao.ToString("dd/MM/yyyy hh:mm:ss");

            if (entidadeComunicado.DataExibicaoInicio != null)
            {
                txtdtInicio.Text = Convert.ToDateTime(entidadeComunicado.DataExibicaoInicio).ToString("dd/MM/yyyy hh:mm:ss");
            }

            if (entidadeComunicado.DataExibicaoFim != null)
            {
                txtdtFim.Text = Convert.ToDateTime(entidadeComunicado.DataExibicaoFim).ToString("dd/MM/yyyy hh:mm:ss");
            }

            if (conteudo.Tages != null && conteudo.Tages.Count > 0)
            {
                string strTag = string.Empty;

                string[] parts = new string[conteudo.Tages.Count];
                int i = 0;

                foreach (Tag tag in conteudo.Tages)
                {
                    if (!String.IsNullOrEmpty(tag.Palavra))
                    {
                        parts[i] = tag.Palavra;
                        i++;
                    }
                }

                strTag = String.Join(", ", parts) + ".";

                txtTags.Text = strTag;
            }

            chbAtivo.Checked = entidadeComunicado.Ativo;
            chbDestaqueFique.Checked = entidadeComunicado.DestaqueFiquePorDentro;
            chbDestaqueHome.Checked = entidadeComunicado.DestaqueHome;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExecute_Click(object sender, ImageClickEventArgs e)
    {
        this.FormToLoad();

        if (conteudo != null && conteudo.ConteudoId > 0)
        {
            try
            {
                if ((conteudo.Comunicado.ComunicadoIdiomas[0].TextoComunicado == null) || (conteudo.Comunicado.ComunicadoIdiomas[0].TituloComunicado == null)
                    || (conteudo.Comunicado.ComunicadoIdiomas[0].Comunicado.DataExibicaoFim == null) || (conteudo.Comunicado.ComunicadoIdiomas[0].Comunicado.DataExibicaoFim == null))
                {
                    if (String.IsNullOrEmpty(txtTitulo.Text))
                        rfvTitulo.Text = "Campo obrigatório";
                    else
                        rfvTitulo.Text = string.Empty;

                    if (String.IsNullOrEmpty(txtdtInicio.Text))
                        rfvDtInicio.Text = "Campo obrigatório";
                    else
                        rfvDtInicio.Text = string.Empty;

                    if (String.IsNullOrEmpty(txtdtFim.Text))
                        rfvDtFim.Text = "Campo obrigatório";
                    else
                        rfvDtFim.Text = string.Empty;
                }
                else
                {
                    if (Convert.ToDateTime(txtdtInicio.Text) <= Convert.ToDateTime(txtdtFim.Text))
                    {
                        rfvTitulo.Text = string.Empty;
                        this.Update();
                        Util.ShowMessage("Registro alterado com sucesso!");
                    }
                    else
                    {
                        Util.ShowMessage("Registro não pode ser salvo verifique os campos data, data inicio menos que data fim!");
                    }
                }
            }
            catch
            {
                Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde");
            }
        }
        else
        {
            try
            {
                if ((conteudo.Comunicado.ComunicadoIdiomas[0].TextoComunicado == null) || (conteudo.Comunicado.ComunicadoIdiomas[0].TituloComunicado == null)
                    || (conteudo.Comunicado.ComunicadoIdiomas[0].Comunicado.DataExibicaoFim == null) || (conteudo.Comunicado.ComunicadoIdiomas[0].Comunicado.DataExibicaoFim == null))
                {                    
                    if (String.IsNullOrEmpty(txtTitulo.Text))
                        rfvTitulo.Text = "Campo obrigatório";
                    else
                        rfvTitulo.Text = string.Empty;

                    if (String.IsNullOrEmpty(txtdtInicio.Text))
                        rfvDtInicio.Text = "Campo obrigatório";
                    else
                        rfvDtInicio.Text = string.Empty;

                    if (String.IsNullOrEmpty(txtdtFim.Text))
                        rfvDtFim.Text = "Campo obrigatório";
                    else
                        rfvDtFim.Text = string.Empty;
                }
                else
                {
                    if (Convert.ToDateTime(txtdtInicio.Text) <= Convert.ToDateTime(txtdtFim.Text))
                    {
                        rfvTitulo.Text = string.Empty;

                        this.Save();
                        Util.ShowMessage("Registro cadastrado com sucesso!");
                    }
                    else
                    {
                        Util.ShowMessage("Registro não pode ser salvo verifique os campos data, data inicio menos que data fim.!");
                    }
                }
            }
            catch
            {
                Util.ShowMessage("Registro não foi salvo. Por favor tente mais tarde");
            }
        }

        if ((conteudo.Comunicado.ComunicadoIdiomas[0].TextoComunicado != null) && (conteudo.Comunicado.ComunicadoIdiomas[0].TituloComunicado != null)
            && (conteudo.Comunicado.ComunicadoIdiomas[0].Comunicado.DataExibicaoFim != null) && (conteudo.Comunicado.ComunicadoIdiomas[0].Comunicado.DataExibicaoFim != null))
        {
            this.SaveWorkflow(); // Update "conteudo"
        }
    }

    /// <summary>
    /// Pass all prop from the form to service properties
    /// </summary>
    private void FormToLoad()
    {
        if (!String.IsNullOrEmpty(txtdtPublicacao.Text))
        {
            entidadeComunicadoIdioma.Comunicado.DataHoraPublicacao = Convert.ToDateTime(txtdtPublicacao.Text);
        }
        else
        {
            entidadeComunicado.DataHoraPublicacao = DateTime.Now;
        }
        
        if (!String.IsNullOrEmpty(txtdtInicio.Text))
        {
            entidadeComunicadoIdioma.Comunicado.DataExibicaoInicio = Convert.ToDateTime(txtdtInicio.Text);
            rfvDtInicio.Text = string.Empty;
        }
        else
        {
            entidadeComunicadoIdioma.Comunicado.DataExibicaoInicio = null;
            rfvDtInicio.Text = "Campo obrigatório";
        }

        if (!String.IsNullOrEmpty(txtdtFim.Text))
        {
            entidadeComunicadoIdioma.Comunicado.DataExibicaoFim = Convert.ToDateTime(txtdtFim.Text);
            rfvDtFim.Text = string.Empty;
        }
        else
        {
            entidadeComunicadoIdioma.Comunicado.DataExibicaoFim = null;
            rfvDtFim.Text = "Campo obrigatório";
        }

        entidadeComunicadoIdioma.Comunicado.Ativo = chbAtivo.Checked;
        entidadeComunicadoIdioma.Comunicado.DestaqueFiquePorDentro = chbDestaqueFique.Checked;
        entidadeComunicadoIdioma.Comunicado.DestaqueHome = chbDestaqueFique.Checked;
        
        if (IdRegistro > 0)
        {
            conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
            entidadeComunicado.Conteudo.ConteudoId = conteudo.ConteudoId;
            entidadeComunicadoIdioma.Comunicado.Conteudo.ConteudoId = conteudo.ConteudoId;
        }

        entidadeComunicadoIdioma.TituloComunicado = txtTitulo.Text;
        entidadeComunicadoIdioma.TextoComunicado = txtComunicado.Text;

        entidadeComunicado.ComunicadoIdiomas.Add(entidadeComunicadoIdioma);

        conteudo.Comunicado = entidadeComunicado;

        if (!String.IsNullOrEmpty(Convert.ToString(txtTags)))
        {
            string[] tags = new string[] { };
            tags = txtTags.Text.Split(',');
            foreach (string tag in tags)
            {
                entidadeTag = new Tag();
                entidadeTag.Palavra = tag.Trim().Replace(".", "");
                entidadeTag.Idioma = new Idioma();
                entidadeTag.Idioma.IdiomaId = this.IdiomaId;

                conteudo.Tages.Add(entidadeTag);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected void Save()
    {
        conteudo.ConteudoTipo.ConteudoTipoId = 3;
        conteudo.DataHoraCadastro = DateTime.Now;
        new ConteudoService().Inserir(conteudo);

        if (conteudo != null && conteudo.ConteudoId > 0)
        {
            conteudo.Comunicado.Conteudo.ConteudoId = conteudo.ConteudoId;

            conteudo.Comunicado.ComunicadoIdiomas[0].Comunicado.Conteudo.ConteudoId = conteudo.ConteudoId;

            try
            {
                new ComunicadoService().Inserir(conteudo.Comunicado);
                new ComunicadoIdiomaService().Inserir(conteudo.Comunicado.ComunicadoIdiomas[0]);

                // Insert the Tag
                new TagService().Relacionar(conteudo);
            }
            catch
            {
                new ConteudoService().Excluir(conteudo);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected void Update()
    {
        // Update "comunicado"
        comunicadoService.Atualizar(entidadeComunicadoIdioma.Comunicado);

        // Update "comunicadoIdioma"
        comunicadoIdiomaService.Atualizar(conteudo.Comunicado.ComunicadoIdiomas[0]);

        // Insert the Tag
        new TagService().Relacionar(conteudo);
    }

    /// <summary>
    /// 
    /// </summary>
    private void SaveWorkflow()
    {
        if (conteudo != null && conteudo.ConteudoId > 0)
        {
            int wId = WorkflowUtil.SaveWorkflow(this.IdWorkflow, StatusWorkflow1, conteudo.ConteudoId, txtTitulo.Text, this.ModuleName, "Conteudo");

            if (wId > 0)
            {
                if (this.IdRegistro > 0)
                {
                    Util.ShowUpdateMessage();
                    this.LoadProperties();
                    this.LoadForm();
                    StatusWorkflow1.DataBind();
                }
                else
                {
                    Util.ShowInsertMessage();
                    Response.Redirect(String.Concat("editWorkflow.aspx?md=", this.ModuleName, "&id=", conteudo.ConteudoId, "&wid=", wId), false);
                }
            }
            else
            {
                Util.ShowMessage("Erro ao associar workflow");
            }
        }
    }
}