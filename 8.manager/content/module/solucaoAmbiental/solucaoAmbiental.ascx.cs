using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Ag2.Manager.Helper;
using Sabesp.Data;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;

public partial class content_module_solucaoAmbiental_solucaoAmbiental : SmartUserControl
{
	#region [ Page Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
        if (!IsPostBack)
        {
            if (this.IdRegistro > 0)
            {
                this.BindIdiomas();
            }
            else
            {
                this.BindIdiomasNaoCadastrados();
            }
        }
		if (this.IdRegistro > 0)
		{
			if (!IsPostBack)
			{
				this.LoadForm();
			}
		}
	}

	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		this.Execute();
	}

	#endregion

	#region [ Methods ]

	#region Properties And Form

	protected void ClearForm()
	{
		this.txtTituloPrincipal.Text = string.Empty;
        this.txtTituloChamada1.Text = string.Empty;
		this.txtTextoChamada1.Text = string.Empty;
        this.txtLink1.Text = string.Empty;
        this.txtTituloChamada2.Text = string.Empty;
        this.txtTextoChamada2.Text = string.Empty;
        this.txtLink2.Text = string.Empty;
        this.txtTituloChamada3.Text = string.Empty;
        this.txtTextoChamada3.Text = string.Empty;
        this.txtLink3.Text = string.Empty;
        this.txtLinkImagem.Text = string.Empty;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{        
        if (IdRegistro != null && IdRegistro > 0)
		{
            SolucaoAmbientalIdiomaService solucaoAmbientalIdiomaService = new SolucaoAmbientalIdiomaService();
            SolucaoAmbientalIdioma solucaoAmbientalIdioma = solucaoAmbientalIdiomaService.Carregar(new SolucaoAmbientalIdioma() { Idioma = new Idioma((int)IdRegistro) });

            if (solucaoAmbientalIdioma.ArquivoFoto != null)
			{
                solucaoAmbientalIdioma.ArquivoFoto = new ArquivoService().Carregar(new Arquivo() { ArquivoId = solucaoAmbientalIdioma.ArquivoFoto.ArquivoId });

				DataTable dtImagem = new DataTable();
				dtImagem.Columns.Add(new DataColumn("arquivoId", typeof(int)));
				dtImagem.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));

				if (solucaoAmbientalIdioma.ArquivoFoto != null)
				{
					DataRow drow = dtImagem.NewRow();
					drow["arquivoId"] = solucaoAmbientalIdioma.ArquivoFoto.ArquivoId;
					drow["nomeArquivo"] = solucaoAmbientalIdioma.ArquivoFoto.NomeArquivo;

					dtImagem.Rows.Add(drow);
				}

				sfArquivoImagem.DataSource = dtImagem;
				sfArquivoImagem.DataBind();
			}

            this.txtTituloPrincipal.Text = solucaoAmbientalIdioma.TituloPrincipal;
            this.txtTituloChamada1.Text = solucaoAmbientalIdioma.TituloChamada1;
            this.txtTextoChamada1.Text = solucaoAmbientalIdioma.TextoChamada1;
            this.txtLink1.Text = solucaoAmbientalIdioma.Link1;
            this.txtTituloChamada2.Text = solucaoAmbientalIdioma.TituloChamada2;
            this.txtTextoChamada2.Text = solucaoAmbientalIdioma.TextoChamada2;
            this.txtLink2.Text = solucaoAmbientalIdioma.Link2;
            this.txtTituloChamada3.Text = solucaoAmbientalIdioma.TituloChamada3;
            this.txtTextoChamada3.Text = solucaoAmbientalIdioma.TextoChamada3;
            this.txtLink3.Text = solucaoAmbientalIdioma.Link3;
            this.txtLinkImagem.Text = solucaoAmbientalIdioma.LinkImagem;
            this.cmbIdioma.SelectedValue = IdRegistro.ToString();
            this.cmbIdioma.Enabled = false;
		}
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected SolucaoAmbientalIdioma FormToLoad()
	{
		SolucaoAmbientalIdioma solucaoAmbientalIdioma = new SolucaoAmbientalIdioma();

        if (!String.IsNullOrEmpty(this.txtTituloPrincipal.Text) && this.txtTituloPrincipal.Text.Length > 0)
		{
			solucaoAmbientalIdioma.TituloPrincipal = this.txtTituloPrincipal.Text;
		}
        //******CHAMADA1
        if (!String.IsNullOrEmpty(this.txtTituloChamada1.Text) && this.txtTituloChamada1.Text.Length > 0)
        {
            solucaoAmbientalIdioma.TituloChamada1 = this.txtTituloChamada1.Text;
        }
        if (!String.IsNullOrEmpty(this.txtTextoChamada1.Text) && this.txtTextoChamada1.Text.Length > 0)
		{
            solucaoAmbientalIdioma.TextoChamada1 = this.txtTextoChamada1.Text;
		}
        if (!String.IsNullOrEmpty(this.txtLink1.Text) && this.txtLink1.Text.Length > 0)
        {
            solucaoAmbientalIdioma.Link1 = this.txtLink1.Text;
        }
        //******CHAMADA2
        if (!String.IsNullOrEmpty(this.txtTituloChamada2.Text) && this.txtTituloChamada2.Text.Length > 0)
        {
            solucaoAmbientalIdioma.TituloChamada2 = this.txtTituloChamada2.Text;
        }
        if (!String.IsNullOrEmpty(this.txtTextoChamada2.Text) && this.txtTextoChamada2.Text.Length > 0)
        {
            solucaoAmbientalIdioma.TextoChamada2 = this.txtTextoChamada2.Text;
        }
        if (!String.IsNullOrEmpty(this.txtLink2.Text) && this.txtLink2.Text.Length > 0)
        {
            solucaoAmbientalIdioma.Link2 = this.txtLink2.Text;
        }
        //******CHAMADA3
        if (!String.IsNullOrEmpty(this.txtTituloChamada3.Text) && this.txtTituloChamada3.Text.Length > 0)
        {
            solucaoAmbientalIdioma.TituloChamada3 = this.txtTituloChamada3.Text;
        }
        if (!String.IsNullOrEmpty(this.txtTextoChamada3.Text) && this.txtTextoChamada3.Text.Length > 0)
        {
            solucaoAmbientalIdioma.TextoChamada3 = this.txtTextoChamada3.Text;
        }
        if (!String.IsNullOrEmpty(this.txtLink3.Text) && this.txtLink3.Text.Length > 0)
        {
            solucaoAmbientalIdioma.Link3 = this.txtLink3.Text;
        }
        if (!String.IsNullOrEmpty(this.txtLinkImagem.Text) && this.txtLinkImagem.Text.Length > 0)
        {
            solucaoAmbientalIdioma.LinkImagem = this.txtLinkImagem.Text;
        }
		solucaoAmbientalIdioma.Idioma = new Idioma();
        solucaoAmbientalIdioma.Idioma.IdiomaId = Convert.ToInt32(this.cmbIdioma.SelectedValue);

		List<Int32> lstImagem = sfArquivoImagem.BuscaPKs();
		foreach (int arquivoId in lstImagem)
		{
			solucaoAmbientalIdioma.ArquivoFoto = new Arquivo();
			solucaoAmbientalIdioma.ArquivoFoto.ArquivoId = arquivoId;
		}

		return solucaoAmbientalIdioma;
	}

	#endregion

	/// <summary>
	/// 
	/// </summary>
	private void Execute()
	{
        if (Page.IsValid)
		{
			SolucaoAmbientalIdioma solucaoAmbientalIdioma = this.FormToLoad();

            if (solucaoAmbientalIdioma != null)
			{
				this.Save(solucaoAmbientalIdioma);
			}

		}
		else
		{
			Util.ShowMessage("Por favor, complete os campos obrigatórios.");
		}
	}

    protected void cvValidarChamada1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!String.IsNullOrEmpty(this.txtTituloChamada1.Text) && String.IsNullOrEmpty(this.txtTextoChamada1.Text))
        {
            cvValidarChamada1.ErrorMessage = "Texto Chamda 1 é obrigatório.";
            args.IsValid = false;
            return;
        }
        if (String.IsNullOrEmpty(this.txtTituloChamada1.Text) && !String.IsNullOrEmpty(this.txtTextoChamada1.Text))
        {
            cvValidarChamada1.ErrorMessage = "Título Chamda 1 é obrigatório.";
            args.IsValid = false;
            return;
        }

        args.IsValid = true;
    }
    protected void cvValidarChamada2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!String.IsNullOrEmpty(this.txtTituloChamada2.Text) && String.IsNullOrEmpty(this.txtTextoChamada2.Text))
        {
            cvValidarChamada2.ErrorMessage = "Texto Chamda 2 é obrigatório.";
            args.IsValid = false;
            return;
        }
        if (String.IsNullOrEmpty(this.txtTituloChamada2.Text) && !String.IsNullOrEmpty(this.txtTextoChamada2.Text))
        {
            cvValidarChamada2.ErrorMessage = "Título Chamda 2 é obrigatório.";
            args.IsValid = false;
            return;
        }

        args.IsValid = true;
    }
    protected void cvValidarChamada3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!String.IsNullOrEmpty(this.txtTituloChamada3.Text) && String.IsNullOrEmpty(this.txtTextoChamada3.Text))
        {
            cvValidarChamada3.ErrorMessage = "Texto Chamda 3 é obrigatório.";
            args.IsValid = false;
            return;
        }
        if (String.IsNullOrEmpty(this.txtTituloChamada3.Text) && !String.IsNullOrEmpty(this.txtTextoChamada3.Text))
        {
            cvValidarChamada3.ErrorMessage = "Título Chamda 3 é obrigatório.";
            args.IsValid = false;
            return;
        }

        args.IsValid = true;
    }
    protected void cvValidarArquivo_ServerValidate(object source, ServerValidateEventArgs args)
    {
        List<Int32> lstImagem = sfArquivoImagem.BuscaPKs();
        if (lstImagem.Count == 0)
        {
            cvValidarArquivo.ErrorMessage = "Imagem é obrigatório.";
            args.IsValid = false;
            return;
        }

        args.IsValid = true;
    } 
	/// <summary>
	/// 
	/// </summary>
	protected void Save(SolucaoAmbientalIdioma solucaoAmbientalIdioma)
	{
        SolucaoAmbientalIdiomaService service = new SolucaoAmbientalIdiomaService();
        if (IdRegistro > 0)
        {
            service.Atualizar(solucaoAmbientalIdioma);
            Util.ShowUpdateMessage();
        }
        else
        {
            SolucaoAmbientalIdiomaFH FH = new SolucaoAmbientalIdiomaFH();
			FH.IdiomaId = this.cmbIdioma.SelectedValue;
            if (service.TotalRegistros(FH) > 0)
            {
                Util.ShowMessage("Já existe um registro com o mesmo Idioma cadastrado.");
            }
            else
            {
                service.Inserir(solucaoAmbientalIdioma);
                Util.ShowInsertMessage();
            }
        }
	}
    protected void BindIdiomas()
    {
        IdiomaService idiomaService = new IdiomaService();

        cmbIdioma.DataSource = idiomaService.RecuperarTodosIdiomas();
        cmbIdioma.DataValueField = "idiomaId";
        cmbIdioma.DataTextField = "name";
        cmbIdioma.DataBind();

        cmbIdioma.Items.Insert(0, new ListItem("Selecione...", ""));
    }
    protected void BindIdiomasNaoCadastrados()
    {
        IdiomaService idiomaService = new IdiomaService();

        cmbIdioma.DataSource = idiomaService.CarregarIdiomasSemSolucaoAmbiental();
        cmbIdioma.DataValueField = "idiomaId";
        cmbIdioma.DataTextField = "name";
        cmbIdioma.DataBind();

        cmbIdioma.Items.Insert(0, new ListItem("Selecione...", ""));
    }

	#endregion
}
