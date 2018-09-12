using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;


namespace FlyBallForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                btnRed.Text = "Geselecteerd";
                btnBlue.Text = "";

                Session["Ringnummer"] = 1;
            }




            //string connString;

            //connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Flybase\FlyBallForm.mdb;Persist Security Info = False;";

            //OleDbConnection cnn = new OleDbConnection(connString);

            //cnn.Open();


        }

        protected void btnPlus_Click(object sender, ImageClickEventArgs e)
        {
            FormView1.PageIndex += 1;
            FormView1.DataBind(); //refresh het form
        }

        protected void btnMin_Click(object sender, ImageClickEventArgs e)
        {
            FormView1.PageIndex -= 1;
            FormView1.DataBind(); //refresh het form
        }
        protected void btnRing1_Click(object sender, ImageClickEventArgs e)
        {
            Session["Ringnummer"] = 1;
            FormView1.DataBind(); //refresh het form
        }

        protected void btnRing2_Click(object sender, ImageClickEventArgs e)
        {
            Session["Ringnummer"] = 2;
            FormView1.DataBind(); //refresh het form
        }

        protected void btnRed_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            btnRed.Text = "Geselecteerd";
            btnBlue.Text = "";
            FormView1.DataBind(); //refresh het form
            MultiView1.DataBind();
            GridView1.DataBind();
        }

        protected void btnBlue_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            btnRed.Text = "";
            btnBlue.Text = "Geselecteerd";
            FormView1.DataBind(); //refresh het form
            MultiView1.DataBind();
            GridView2.DataBind();
        }
    }
}