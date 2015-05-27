using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Ag2.Manager.Helper;

public partial class content_module_arquivoProduto_arquivoProduto : SmartUserControl
{
    #region [ Properties ]

    public int ProdutoId
    {
        get
        {
            int _produtoId = 0;
            if (Request.QueryString["strIdRegistroPai"] != null)
            {
                try
                {
                    _produtoId = Convert.ToInt32(Request.QueryString["strIdRegistroPai"]);
                }
                catch
                {
                    _produtoId = 0;
                }
            }
            return _produtoId;
        }
    }

    #endregion
    
    #region [ Events ]

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || this.IdiomaHasChanged)
        {
            if (this.IdRegistro > 0)
            {
                this.LoadForm(this.IdRegistro.Value);
            }
        }
    }

    protected void btnExecute_Click(object sender, ImageClickEventArgs e)
    {
        this.SaveProdutoImagem(this.IdRegistro.Value);
    }

    #endregion

    #region [ Methods ]

    protected void LoadForm(int noticiaImagemId)
    {

    }
    /// <summary>
    /// Save file {arquivoservice}
    /// </summary>
    /// <returns></returns>
    private Arquivo SaveFile()
    {
        ArquivoService arquivoService = new ArquivoService();

        Arquivo arquivo = new Arquivo();

        // If null or empty create a new file 
        if (String.IsNullOrEmpty(hddArquivoId.Value))
        {
            arquivo.NomeArquivo = uplField.FileName;
            arquivo.Tamanho = 0;
            arquivo.Extensao = uplField.FileName.Substring(uplField.FileName.LastIndexOf("."), uplField.FileName.Length - uplField.FileName.LastIndexOf("."));
            arquivoService.Inserir(arquivo);
        }
        else
        {
            arquivo.ArquivoId = Convert.ToInt32(hddArquivoId.Value);
            arquivo.NomeArquivo = uplField.FileName;
            arquivo.Tamanho = 0;
            arquivo.Extensao = uplField.FileName.Substring(uplField.FileName.LastIndexOf("."), uplField.FileName.Length - uplField.FileName.LastIndexOf("."));
            arquivoService.Atualizar(arquivo);
        }

        return arquivo;
    }

    private void SaveProdutoImagem(int produtoImagemId)
    {
        ProdutoImagemService produtoImagemService = new ProdutoImagemService();
                
        ProdutoImagem imagem = null;        
        
        Arquivo arquivo = this.SaveFile();

        if (arquivo != null)
        {
            string message = "Registro alterado com sucesso!";

            if (produtoImagemId > 0)
            {
                imagem = produtoImagemService.Carregar(new ProdutoImagem() { ProdutoImagemId = produtoImagemId });
                imagem.Arquivo = arquivo;
                imagem.Produto = new Produto() { ProdutoId = this.ProdutoId };
                imagem.Ordem = Convert.ToInt32(this.txtOrdem.Text);
                produtoImagemService.Atualizar(imagem);               
                
            }
            else
            {
                imagem = new ProdutoImagem();
                imagem.Arquivo = arquivo;
                imagem.Produto = new Produto() { ProdutoId = this.ProdutoId };
                imagem.Ordem = Convert.ToInt32(this.txtOrdem.Text);
                produtoImagemService.Inserir(imagem);

                message = "Registro salvo com sucesso!";
            }

            Util.ShowMessage(message);
           
        }
        else
        {
            Util.ShowMessage("Registro não atualizado. Erro ao salvar arquivo.");
        }
    }

    #endregion

}
