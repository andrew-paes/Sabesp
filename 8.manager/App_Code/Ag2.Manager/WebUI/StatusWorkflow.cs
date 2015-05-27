using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Ag2.Manager.WebUI
{
    [Serializable]
    [ValidationProperty("StatusIdSelected")]
    [DefaultProperty("StatusIdSelected"), ToolboxData("<{0}:StatusWorkflow runat=\"server\"></{0}:StatusWorkflow>")]
    public class StatusWorkflow : System.Web.UI.WebControls.WebControl, INamingContainer
    {
        #region Properties

        private PlaceHolder _phStatusAtual;
        private Label _lblStatusAtual;
        private Literal _ltlStatusAtual;
        private Label _lblAlterarStatus;
        private DropDownList _ddlStatusWorkflow;
        private TextBox _txtComentario;
        private RequiredFieldValidator _rfvStatus;
        private RequiredFieldValidator _rfvComentario;
        private Literal _ltlTextoIntermediario;
        Database db = DatabaseFactory.CreateDatabase();

        /// <summary>
        /// Sets the validation group of controls
        /// </summary>
        public string ValidationGroup { get; set; }

        /// <summary>
        /// Gets or Sets the atual status of Workflow based on WorkflowId
        /// </summary>
        private string StatusAtual { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Bindable(true),
        Category("Default"),
        DefaultValue(null),
        Description("Id do Fluxo")]
        public int? FluxoId { get; set; }

        /// <summary>
        /// Id of workflow
        /// </summary>
        [Bindable(true),
        Category("Default"),
        DefaultValue(null),
        Description("Id do Workflow")]
        public int? WorkflowId { get; set; }

        /// <summary>
        /// Comment for textarea
        /// </summary>
        [Bindable(true),
         Category("Default"),
         DefaultValue(""),
         Description("Comentário do Fluxo")]
        public String Comentario
        {
            get
            {
                EnsureChildControls();
                return _txtComentario.Text;
            }
            set
            {
                EnsureChildControls();
                _txtComentario.Text = value;
            }
        }

        /// <summary>
        /// Error message to dropdownlist with statuses
        /// </summary>
        [Bindable(true),
        Category("Appearance"),
        DefaultValue("Campo obrigatório"),
        Description("Error message for the status validator.")]
        public string StatusSelectedErrorMessage
        {
            get
            {
                EnsureChildControls();
                return _rfvStatus.ErrorMessage;
            }
            set
            {
                EnsureChildControls();
                _rfvStatus.ErrorMessage = value;
                _rfvStatus.ToolTip = value;
            }
        }

        /// <summary>
        /// Error message for the comment textarea
        /// </summary>
        [Bindable(true),
        Category("Appearance"),
        DefaultValue("Campo obrigatório"),
        Description("Error message for the comment validator.")]
        public string CommentErrorMessage
        {
            get
            {
                EnsureChildControls();
                return _rfvComentario.ErrorMessage;
            }
            set
            {
                EnsureChildControls();
                _rfvComentario.ErrorMessage = value;
                _rfvComentario.ToolTip = value;
            }
        }

        /// <summary>
        /// Text of label that identify the atual status
        /// </summary>
        [Bindable(true),
        Category("Appearance"),
        DefaultValue("Status atual:"),
        Description("Error message for the comment validator.")]
        public string MessageStatusAtual
        {
            get
            {
                EnsureChildControls();
                return _lblStatusAtual.Text;
            }
            set
            {
                EnsureChildControls();
                _lblStatusAtual.Text = value;
            }
        }

        /// <summary>
        /// Text of label that identify the new status
        /// </summary>
        [Bindable(true),
        Category("Appearance"),
        DefaultValue("Alterar status para:"),
        Description("Error message for the comment validator.")]
        public string MessageAlterarStatus
        {
            get
            {
                EnsureChildControls();
                return _lblAlterarStatus.Text;
            }
            set
            {
                EnsureChildControls();
                _lblAlterarStatus.Text = value;
            }
        }

        /// <summary>
        /// Gets the new status selected on dropdown
        /// </summary>
        public string StatusIdSelected
        {
            get
            {
                EnsureChildControls();
                return _ddlStatusWorkflow.SelectedValue;
            }
        }



        #endregion

        #region Constructor

        public StatusWorkflow()
        {
            _phStatusAtual = new PlaceHolder();
            _lblStatusAtual = new Label();
            _ltlStatusAtual = new Literal();
            _lblAlterarStatus = new Label();
            _ddlStatusWorkflow = new DropDownList();
            _rfvStatus = new RequiredFieldValidator();
            _ltlTextoIntermediario = new Literal();
            _txtComentario = new TextBox();
            _rfvComentario = new RequiredFieldValidator();

            this.ConfigureControls();
        }

        #endregion

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Request.QueryString["wid"])))
            {
                this.WorkflowId = Convert.ToInt32(Convert.ToString(HttpContext.Current.Request.QueryString["wid"]));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void CreateChildControls()
        {
            var br = new HtmlGenericControl("br");

            this.ConfigureStatusAtual();

            this.Controls.Add(_phStatusAtual);
            this.Controls.Add(_lblAlterarStatus);
            br = new HtmlGenericControl("br");
            this.Controls.Add(br);

            this.ConfigureNextStatus();
            this.Controls.Add(_ddlStatusWorkflow);
            this.Controls.Add(_rfvStatus);

            _ltlTextoIntermediario.Text = "<br/><br/><strong>Comentário:</strong><br/>";
            this.Controls.Add(_ltlTextoIntermediario);

            this.ConfigureComentario();
            this.Controls.Add(_txtComentario);
            this.Controls.Add(_rfvComentario);

            this.ChildControlsCreated = true;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderChildren(writer);
        }

        public override void DataBind()
        {
            base.DataBind();

            this.BindNextStatus();
            this.ConfigureStatusAtual();
            _txtComentario.Text = string.Empty;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Set the initial values of some controls
        /// </summary>
        private void ConfigureControls()
        {
            _rfvStatus.ErrorMessage = _rfvComentario.ErrorMessage = " Campo obrigatório";
            _lblAlterarStatus.Text = "Alterar status para:";
            _lblAlterarStatus.Font.Bold = true;
            _lblStatusAtual.Text = "Status atual:";
            _lblStatusAtual.Font.Bold = true;
        }

        /// <summary>
        /// Configure controls associed with the render of next status
        /// </summary>
        protected void ConfigureNextStatus()
        {
            _ddlStatusWorkflow.ID = this.ID;
            _ddlStatusWorkflow.ValidationGroup = this.ValidationGroup;

            _rfvStatus.InitialValue = "";
            _rfvStatus.ID = "validator1";
            _rfvStatus.ValidationGroup = this.ValidationGroup;
            _rfvStatus.ControlToValidate = _ddlStatusWorkflow.ID;
            _rfvStatus.Display = ValidatorDisplay.Static;

            this.BindNextStatus();
        }

        /// <summary>
        /// Configure controls associed with the comments textarea
        /// </summary>
        protected void ConfigureComentario()
        {
            //comment textarea
            _txtComentario.ID = String.Concat("txtComentario_", this.ID);
            _txtComentario.TextMode = TextBoxMode.MultiLine;
            _txtComentario.Width = 450;
            _txtComentario.Rows = 5;
            _txtComentario.Text = string.Empty;

            //required field validator to comment textarea
            _rfvComentario.InitialValue = "";
            _rfvComentario.ID = "validator2";
            _rfvComentario.ValidationGroup = this.ValidationGroup;
            _rfvComentario.ControlToValidate = _txtComentario.ID;
            _rfvComentario.Display = ValidatorDisplay.Static;
        }

        /// <summary>
        /// Configure controls associed with the atual status 
        /// </summary>
        protected void ConfigureStatusAtual()
        {
            this.BindStatusAtual();
            
            //clear the previous controls on this place holder
            _phStatusAtual.Controls.Clear();
            //add the new controls to place holder
            _phStatusAtual.Controls.Add(_lblStatusAtual);

            //new html generic control to be used with line separator
            var br = new HtmlGenericControl("br");
            _phStatusAtual.Controls.Add(br);
            _ltlStatusAtual.Text = this.StatusAtual;
            _phStatusAtual.Controls.Add(_ltlStatusAtual);
            br = new HtmlGenericControl("br");
            _phStatusAtual.Controls.Add(br);
            br = new HtmlGenericControl("br");
            _phStatusAtual.Controls.Add(br);

            _phStatusAtual.Visible = !String.IsNullOrEmpty(this.StatusAtual);
        }

        /// <summary>
        /// Bind the dropdownlist with the valid possible new status
        /// </summary>
        public void BindNextStatus()
        {
            Ag2.Manager.Helper.CurrentSessions cs = new Ag2.Manager.Helper.CurrentSessions();
            string sql = "StatusWorkflowSelect";

            DbCommand dataProc = db.GetStoredProcCommand(sql);
            db.AddInParameter(dataProc, "@perfilId", DbType.Int32, cs.Perfil.PerfilId);
            db.AddInParameter(dataProc, "@fluxoId", DbType.Int32, this.FluxoId);
            db.AddInParameter(dataProc, "@workflowId", DbType.Int32, this.WorkflowId);

            DataTable dtData = db.ExecuteDataSet(dataProc).Tables[0];
            _ddlStatusWorkflow.DataSource = dtData;
            _ddlStatusWorkflow.DataTextField = "descricao";
            _ddlStatusWorkflow.DataValueField = "statusId";
            _ddlStatusWorkflow.DataBind();
            _ddlStatusWorkflow.Items.Insert(0, new ListItem(":: Selecione ::", ""));
        }

        /// <summary>
        /// Bind the property StatusAtual with status of the atual workflow based on workflowId
        /// </summary>
        public void BindStatusAtual()
        {
            if (this.WorkflowId != null)
            {
                WorkflowData wd = WorkflowUtil.GetWorkflowModuleData(Convert.ToInt32(this.WorkflowId));
                this.StatusAtual = wd.Status;
            }
        } 

        #endregion
    }
}
