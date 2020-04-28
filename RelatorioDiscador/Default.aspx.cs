using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RelatorioDiscador
{
    public partial class _Default : Page
    {
        Conexao con = new Conexao();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherCbox();
            }
        }

        private void PreencherCbox()
        {
            gen_configEntities ctx = new gen_configEntities();
            var resultado = (from t in ctx.cfg_campaign
                             select new
                             {
                                 t.dbid,
                                 t.name,
                             });
            cboxCampanha.Items.Insert(0, new ListItem("Selecione", "selecione"));
            cboxCampanha.Items.Insert(1, new ListItem("**** TODAS AS CAMPANHAS ****", "todas"));
            foreach (var item in resultado)
            {
                cboxCampanha.Items.Add(new ListItem(item.name, item.dbid.ToString()));
            }
        }

        protected void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            if (TextInicial.Text == "" || TextInicial.Text == " ")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "datainicio();", true);
            }
            else if (TextFinal.Text == "" || TextFinal.Text == " ")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "datafim();", true);
            }
            else
            if (rbResultadoChama.Checked == false && rbCPF.Checked == false && rbTelefone.Checked == false && rbNome.Checked == false)
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroSemEscolha();", true);
            }
            else
            if (cboxCampanha.SelectedValue == "Selecione")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "selCampanha();", true);
            }
            else
            if (rbResultadoChama.Checked == true)
            {
                if (cboxCallResult.SelectedValue == "Selecione")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erroSemEscolhaTipo();", true);
                }
                else
                if (cboxCallResult.SelectedValue == "todas" && cboxCampanha.SelectedValue != "todas" && cboxCampanha.SelectedValue != "Selecione")
                {
                    Session["dataInicial"] = TextInicial.Text.Trim();
                    Session["dataFinal"] = TextFinal.Text.Trim();
                    Session["callresult"] = "todas";
                    Session["campanha"] = cboxCampanha.SelectedValue;
                    Session["cpfcnpj"] = "null";
                    Session["telefone"] = "null";
                    Session["nome"] = "null";
                    Response.Redirect("relatorio.aspx");
                }
                else
                if (cboxCallResult.SelectedValue != "todas" && cboxCallResult.SelectedValue != "SELECIONE" && cboxCampanha.SelectedValue != "todas" && cboxCampanha.SelectedValue != "Selecione")
                {
                    Session["dataInicial"] = TextInicial.Text.Trim();
                    Session["dataFinal"] = TextFinal.Text.Trim();
                    Session["callresult"] = cboxCallResult.SelectedValue;
                    Session["campanha"] = cboxCampanha.SelectedValue;
                    Session["cpfcnpj"] = "null";
                    Session["telefone"] = "null";
                    Session["nome"] = "null";
                    Response.Redirect("relatorio.aspx");
                }
                else
                    if (cboxCallResult.SelectedValue == "todas" && cboxCampanha.SelectedValue == "todas")
                {
                    Session["dataInicial"] = TextInicial.Text.Trim();
                    Session["dataFinal"] = TextFinal.Text.Trim();
                    Session["callresult"] = "todas";
                    Session["campanha"] = "todas";
                    Session["cpfcnpj"] = "null";
                    Session["telefone"] = "null";
                    Session["nome"] = "null";
                    Response.Redirect("relatorio.aspx");
                }
                else
                    if (cboxCallResult.SelectedValue != "todas" && cboxCallResult.SelectedValue != "Selecione" && cboxCampanha.SelectedValue == "todas")
                {
                    Session["dataInicial"] = TextInicial.Text.Trim();
                    Session["dataFinal"] = TextFinal.Text.Trim();
                    Session["callresult"] = cboxCallResult.SelectedValue;
                    Session["campanha"] = "todas";
                    Session["cpfcnpj"] = "null";
                    Session["telefone"] = "null";
                    Session["nome"] = "null";
                    Response.Redirect("relatorio.aspx");
                }

            }

            else if (rbCPF.Checked == true)
            {
                if (cboxCampanha.SelectedValue == "todas")
                {
                    Session["dataInicial"] = TextInicial.Text.Trim();
                    Session["dataFinal"] = TextFinal.Text.Trim();
                    Session["callresult"] = "null";
                    Session["campanha"] = "todas";
                    Session["cpfcnpj"] = TextCpfCnpj.Text;
                    Session["telefone"] = "null";
                    Session["nome"] = "null";
                    Response.Redirect("relatorio.aspx");
                }
                else
                {
                    if (cboxCampanha.SelectedValue != "todas" && cboxCampanha.SelectedValue != "selecione")
                    {
                        Session["dataInicial"] = TextInicial.Text.Trim();
                        Session["dataFinal"] = TextFinal.Text.Trim();
                        Session["callresult"] = "null";
                        Session["campanha"] = cboxCampanha.SelectedValue;
                        Session["cpfcnpj"] = TextCpfCnpj.Text;
                        Session["telefone"] = "null";
                        Session["nome"] = "null";
                        Response.Redirect("relatorio.aspx");
                    }
                }
            }
            else if (rbTelefone.Checked == true)
            {
                if (cboxCampanha.SelectedValue == "todas")
                {
                    Session["dataInicial"] = TextInicial.Text.Trim();
                    Session["dataFinal"] = TextFinal.Text.Trim();
                    Session["callresult"] = "null";
                    Session["campanha"] = "todas";
                    Session["cpfcnpj"] = "null";
                    Session["telefone"] = TextTelefone.Text;
                    Session["nome"] = "null";
                    Response.Redirect("relatorio.aspx");
                }
                else
                {
                    if (cboxCampanha.SelectedValue != "todas" && cboxCampanha.SelectedValue != "selecione")
                    {
                        Session["dataInicial"] = TextInicial.Text.Trim();
                        Session["dataFinal"] = TextFinal.Text.Trim();
                        Session["callresult"] = "null";
                        Session["campanha"] = cboxCampanha.SelectedValue;
                        Session["cpfcnpj"] = "null";
                        Session["telefone"] = TextTelefone.Text;
                        Session["nome"] = "null";
                        Response.Redirect("relatorio.aspx");
                    }
                }
            }
            else if (rbNome.Checked == true)
            {
                if (cboxCampanha.SelectedValue == "todas")
                {
                    Session["dataInicial"] = TextInicial.Text.Trim();
                    Session["dataFinal"] = TextFinal.Text.Trim();
                    Session["callresult"] = "null";
                    Session["campanha"] = "todas";
                    Session["cpfcnpj"] = "null";
                    Session["telefone"] = "null";
                    Session["nome"] = TextNome.Text;
                    Response.Redirect("relatorio.aspx");
                }
                else
                {
                    if (cboxCampanha.SelectedValue != "todas" && cboxCampanha.SelectedValue != "selecione")
                    {
                        Session["dataInicial"] = TextInicial.Text.Trim();
                        Session["dataFinal"] = TextFinal.Text.Trim();
                        Session["callresult"] = "null";
                        Session["campanha"] = cboxCampanha.SelectedValue;
                        Session["cpfcnpj"] = "null";
                        Session["telefone"] = "null";
                        Session["nome"] = TextNome.Text;
                        Response.Redirect("relatorio.aspx");
                    }
                }
            }
        }

    }
}

