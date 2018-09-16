using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using FlyBallForm.Controllers;

namespace FlyBallForm
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MultiView1.ActiveViewIndex = 0; //Toon de rode baan
                Session["Ringnummer"] = 1;
                
            }
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
            MultiView1.DataBind();
            GridView2.DataBind();
        }

        protected void btnRing2_Click(object sender, ImageClickEventArgs e)
        {
            Session["Ringnummer"] = 2;
            FormView1.DataBind(); //refresh het form
            MultiView1.DataBind();
            GridView2.DataBind();
        }

        protected void btnRed_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;

            //Zoek de textboxen eerst op, want ze staan op een FormView
            TextBox txtRed = (TextBox)FormView1.FindControl("txtRed");
            TextBox txtBlue = (TextBox)FormView1.FindControl("txtBlue");

            txtRed.Text = "Actief";
            txtRed.Visible = true;
            txtBlue.Text = "";
            txtBlue.Visible = false;

            //FormView1.DataBind(); //refresh het form
            MultiView1.DataBind();
            GridView1.DataBind();
        }

        protected void btnBlue_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;

            //Zoek de textboxen eerst op, want ze staan op een FormView
            TextBox txtRed = (TextBox)FormView1.FindControl("txtRed");
            TextBox txtBlue = (TextBox)FormView1.FindControl("txtBlue");

            txtRed.Text = "";
            txtRed.Visible = false;
            txtBlue.Text = "Actief";
            txtBlue.Visible = true;

            //FormView1.DataBind(); //refresh het form
            MultiView1.DataBind();
            GridView2.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "Error")) == 1)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].BackColor = System.Drawing.Color.Tomato;
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "Error")) == 1)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].BackColor = System.Drawing.Color.Tomato;
                }
            }
        }
    }
}

