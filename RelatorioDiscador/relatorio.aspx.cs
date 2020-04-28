using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RelatorioDiscador
{
    public partial class relatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dataInicial"] != null && Session["dataFinal"] != null)
            {

                XtraReportRelatorio report = new XtraReportRelatorio();
                report.Parameters["dataInicial"].Value = Session["dataInicial"].ToString();
                report.Parameters["dataFinal"].Value = Session["dataFinal"].ToString();
                report.Parameters["campanha"].Value = Session["campanha"].ToString();
                report.Parameters["cpfcnpj"].Value = Session["cpfcnpj"].ToString();
                report.Parameters["telefone"].Value = Session["telefone"].ToString();
                report.Parameters["nome"].Value = Session["nome"].ToString();
                report.Parameters["callresult"].Value = Session["callresult"].ToString();
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