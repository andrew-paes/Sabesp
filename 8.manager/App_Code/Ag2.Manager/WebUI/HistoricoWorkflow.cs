using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.UI.HtmlControls;


namespace Ag2.Manager.WebUI
{
    [Serializable]
    [ToolboxData("<{0}:HistoricoWorkflow runat=server></{0}:HistoricoWorkflow>")]
    public class HistoricoWorkflow : System.Web.UI.WebControls.WebControl, INamingContainer
    {
        //field with selected date
        private Repeater _rptHistoricoWorkflow;
        Database db = DatabaseFactory.CreateDatabase();
        private RepeaterItem _rptItem;

        public HistoricoWorkflow()
        {
            _rptHistoricoWorkflow = new Repeater();
        }

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
            _rptHistoricoWorkflow.ID = this.ID;

            this.PopulaHistorico();
            this.Controls.Add(_rptHistoricoWorkflow);
            this.ChildControlsCreated = true;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderChildren(writer);
        }

        public int? WorkflowId { get; set; }

        protected void PopulaHistorico()
        {
            this.PopulaHistorico(string.Empty);
        }

        protected void PopulaHistorico(string userId)
        {
            Ag2.Manager.Helper.CurrentSessions cs = new Ag2.Manager.Helper.CurrentSessions();
            string sql = "HistoricoWorkflowSelect";

            DbCommand dataProc = db.GetStoredProcCommand(sql);
            db.AddInParameter(dataProc, "@workflowId", DbType.Int32, this.WorkflowId);
            if (!String.IsNullOrEmpty(userId))
            {
                db.AddInParameter(dataProc, "@userId", DbType.String, userId);
            }

            DataTable dtData = db.ExecuteDataSet(dataProc).Tables[0];
            _rptHistoricoWorkflow.DataSource = dtData;
            _rptHistoricoWorkflow.DataBind();

            foreach (RepeaterItem repeatItem in _rptHistoricoWorkflow.Items)
            {
                // if condition to add HeaderTemplate Dynamically only Once
                if (repeatItem.ItemIndex == 0)
                {
                    RepeaterItem headerItem = new RepeaterItem(repeatItem.ItemIndex, ListItemType.Header);
                    HtmlGenericControl hTag = new HtmlGenericControl("h4");
                    hTag.InnerHtml = "<br/>Revisões:<br/><br/>";
                    repeatItem.Controls.Add(hTag);
                }

                // Add ItemTemplate DataItems Dynamically
                RepeaterItem repeaterItem = new RepeaterItem(repeatItem.ItemIndex, ListItemType.Item);
                Label lbl = new Label();
                lbl.Text = string.Concat("<strong>", Convert.ToDateTime(dtData.Rows[repeatItem.ItemIndex]["ultimaAlteracao"]).ToString("dd/MM/yyyy HH:mm:ss"), "</strong>",
                                         " - '", Convert.ToString(dtData.Rows[repeatItem.ItemIndex]["UserName"]), "' salvou o registro com status '",
                                         Convert.ToString(dtData.Rows[repeatItem.ItemIndex]["statusName"]), "'. <br/>");

                if (!String.IsNullOrEmpty(Convert.ToString(dtData.Rows[repeatItem.ItemIndex]["comentario"])))
                {
                    lbl.Text = String.Concat(lbl.Text, "<strong>Comentário do Fluxo:</strong>", "<br/>", Convert.ToString(dtData.Rows[repeatItem.ItemIndex]["comentario"]).Replace("\n", "<br/>"), "<br/>");
                }

                repeatItem.Controls.Add(lbl);

                // Add SeparatorTemplate Dynamically
                repeaterItem = new RepeaterItem(repeatItem.ItemIndex, ListItemType.Separator);
                LiteralControl ltrlHR = new LiteralControl();
                ltrlHR.Text = "<hr />";
                repeatItem.Controls.Add(ltrlHR);
            }
        }
    }


}
