using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class ctl_ag2Uploader : System.Web.UI.UserControl
    {
        private string _FileName = string.Empty;
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
                lblArquivo.Text = value;
                AjustaImagem();
            }

        }

        private string _Diretorio = string.Empty;
        public string Diretorio { get { return _Diretorio; } set { _Diretorio = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Salva()
        {
            string strDir = HttpContext.Current.Server.MapPath(Diretorio);
            if (strDir[strDir.Length - 1] != '\\') strDir += "\\";
            string strAux = uplFile.FileName;
            int intInd = 1;

            while (System.IO.File.Exists(strDir + strAux))
            {
                strAux = uplFile.FileName.Replace(".", "(" + intInd.ToString() + ").");
                intInd++;
            }

            uplFile.SaveAs(strDir + strAux);
            FileName = strAux;
        }

        public void AjustaImagem()
        {
            if (Diretorio[Diretorio.Length - 1] != '\\') Diretorio += "\\";
            string strDir = HttpContext.Current.Server.MapPath(Diretorio);

            string strAux = strDir + FileName;

            if (System.IO.File.Exists(strAux))
            {
                imgImagem.ImageUrl = Diretorio + FileName;
                imgImagem.Visible = true;
            }
        }

    }
