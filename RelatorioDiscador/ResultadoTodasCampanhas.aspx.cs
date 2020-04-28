using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RelatorioDiscador
{
    public partial class ResultadoTodasCampanhas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dataInicio"] != null && Session["dataFim"] != null)
            {
                XtraReport_TodasCallResultCampanha report = new XtraReport_TodasCallResultCampanha();
                report.Parameters["parameter1"].Value = Session["dataInicio"].ToString();
                report.Parameters["parameter2"].Value = Session["dataFim"].ToString();
                report.RequestParameters = false;
                ASPxWebDocumentViewer1.OpenReport(report);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}