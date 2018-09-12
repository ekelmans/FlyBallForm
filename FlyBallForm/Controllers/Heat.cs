using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace FlyBallForm.Controllers
{
    public class HeatController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand com = new SqlCommand("SELECT * FROM FlyFormHeat ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string csv = "";
        

            foreach (DataRow rw in ds.Tables["Table"].Rows)
            {
                for (int i = 0; i < ds.Tables["Table"].Columns.Count; i++)
                {
                    csv += rw[i].ToString();

                    //add tab separator (maar niet bij de laatste kolom)
                    if (i < ds.Tables["Table"].Columns.Count -1) csv += Convert.ToChar(9);
                }

                csv += Environment.NewLine;

            }

            //System.Diagnostics.Debug.WriteLine(csv);

            return csv;
        }

        // GET api/<controller>/117430
        public string Get(int id)
        {

            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand com = new SqlCommand("SELECT * FROM FlyFormHeat WHERE HeatID = @HeatID", con);
            com.Parameters.AddWithValue("@HeatID", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string csv = "";


            foreach (DataRow rw in ds.Tables["Table"].Rows)
            {
                for (int i = 0; i < ds.Tables["Table"].Columns.Count; i++)
                {
                    csv += rw[i].ToString();

                    //add tab separator (maar niet bij de laatste kolom)
                    if (i < ds.Tables["Table"].Columns.Count - 1) csv += Convert.ToChar(9);
                }

                csv += Environment.NewLine;

            }

            //System.Diagnostics.Debug.WriteLine(csv);

            return csv;
        }

        //Insert Access Heat in FlyFormHeat via WEB API
        public string Post([FromBody]string value)
        {

            ClearFlyFormHeat();


            string[] rws;
            string[] values;
            int i;

            rws = value.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            for (i = 0 ; i < rws.Length; i++)
            {
                int TeamID;
                decimal Tijd;
                int Punten;

                rws[i] = rws[i].Replace("Waar", "True");
                rws[i] = rws[i].Replace("Onwaar", "False");

                values = rws[i].Split(Convert.ToChar(9));

                values[5] = values[5].Replace(".", ",");


                int HeatID = int.Parse(values[0]);
                int RaceID = int.Parse(values[1]);
                int HeatNr = int.Parse(values[2]);
                int BaanKleurID = int.Parse(values[3]);
                if (values[4] == "NULL") TeamID = -1;    else TeamID = int.Parse(values[4], NumberStyles.AllowDecimalPoint);
                if (values[5] == "NULL") Tijd = -1;      else Tijd = decimal.Parse(values[5], NumberStyles.AllowDecimalPoint);
                int ResultaatID = int.Parse(values[6]);
                if (values[7] == "NULL") Punten = -1; else Punten = int.Parse(values[7], NumberStyles.AllowDecimalPoint);
                bool Hond1 = bool.Parse(values[8]);
                bool Hond2 = bool.Parse(values[9]);
                bool Hond3 = bool.Parse(values[10]);
                bool Hond4 = bool.Parse(values[11]);
                bool Hond5 = bool.Parse(values[12]);
                bool Hond6 = bool.Parse(values[13]);

                string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;

                SqlConnection con = new SqlConnection(conStr);

                //SqlCommand com = new SqlCommand("update [FlyForm].[dbo].[FlyFormHeat] set RaceID = @RaceID,HeatNr = @HeatNr,BaanKleurID= @BaanKleurID,TeamID = @TeamID,Tijd = @Tijd,ResultaatID= @ResultaatID,Punten = @Punten,Hond1 = @Hond1,Hond2 = @Hond2,Hond3 = @Hond3,Hond4 = @Hond4,Hond5 = @Hond5,Hond6 = @Hond6 where HeatID = @HeatID", con);
                SqlCommand com = new SqlCommand("insert into [FlyForm].[dbo].[FlyFormHeat](HeatID, RaceID, HeatNr, BaanKleurID, TeamID, Tijd, ResultaatID, Punten, Hond1, Hond2, Hond3, Hond4, Hond5, Hond6) values (@HeatID, @RaceID, @HeatNr, @BaanKleurID, @TeamID, @Tijd, @ResultaatID, @Punten, @Hond1, @Hond2, @Hond3, @Hond4, @Hond5, @Hond6)", con);
                

                com.Parameters.AddWithValue("@HeatID", HeatID);
                com.Parameters.AddWithValue("@RaceID", RaceID);
                com.Parameters.AddWithValue("@HeatNr", HeatNr);
                com.Parameters.AddWithValue("@BaanKleurID", BaanKleurID);
                if (TeamID==-1)  com.Parameters.AddWithValue("@TeamID", DBNull.Value);       else    com.Parameters.AddWithValue("@TeamID", TeamID);
                if (Tijd==-1)    com.Parameters.AddWithValue("@Tijd", DBNull.Value);         else    com.Parameters.AddWithValue("@Tijd", Tijd);
                com.Parameters.AddWithValue("@ResultaatID", ResultaatID);
                if (Punten ==-1) com.Parameters.AddWithValue("@Punten", DBNull.Value); else com.Parameters.AddWithValue("@Punten", Punten);
                com.Parameters.AddWithValue("@Hond1", Hond1);
                com.Parameters.AddWithValue("@Hond2", Hond2);
                com.Parameters.AddWithValue("@Hond3", Hond3);
                com.Parameters.AddWithValue("@Hond4", Hond4);
                com.Parameters.AddWithValue("@Hond5", Hond5);
                com.Parameters.AddWithValue("@Hond6", Hond6);

                con.Open();

                com.ExecuteNonQuery();

                con.Close();
            }

            return "OK, rows inserted: " + i.ToString() ;


        }

        //Update 1 row in FlyFormHeat via WEB API
        public string Put(int id, [FromBody]string value)
        {
            int TeamID;
            decimal Tijd;
            int Punten;

            string[] values;

            value = value.Replace("Waar", "True");
            value = value.Replace("Onwaar", "False");

            values = value.Split(Convert.ToChar(9));

            values[5] = values[5].Replace(".", ",");


            int HeatID = int.Parse(values[0]);
            int RaceID = int.Parse(values[1]);
            int HeatNr = int.Parse(values[2]);
            int BaanKleurID = int.Parse(values[3]);
            if (values[4] == "NULL") TeamID = -1; else TeamID = int.Parse(values[4], NumberStyles.AllowDecimalPoint);
            if (values[5] == "NULL") Tijd = -1; else Tijd = decimal.Parse(values[5], NumberStyles.AllowDecimalPoint);
            int ResultaatID = int.Parse(values[6]);
            if (values[7] == "NULL") Punten = -1; else Punten = int.Parse(values[7], NumberStyles.AllowDecimalPoint);
            bool Hond1 = bool.Parse(values[8]);
            bool Hond2 = bool.Parse(values[9]);
            bool Hond3 = bool.Parse(values[10]);
            bool Hond4 = bool.Parse(values[11]);
            bool Hond5 = bool.Parse(values[12]);
            bool Hond6 = bool.Parse(values[13]);



            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(conStr);

            SqlCommand com = new SqlCommand("update [FlyForm].[dbo].[FlyFormHeat] set RaceID = @RaceID,HeatNr = @HeatNr,BaanKleurID= @BaanKleurID,TeamID = @TeamID,Tijd = @Tijd,ResultaatID= @ResultaatID,Punten = @Punten,Hond1 = @Hond1,Hond2 = @Hond2,Hond3 = @Hond3,Hond4 = @Hond4,Hond5 = @Hond5,Hond6 = @Hond6 where HeatID = @HeatID", con);

            com.Parameters.AddWithValue("@HeatID", HeatID);
            com.Parameters.AddWithValue("@RaceID", RaceID);
            com.Parameters.AddWithValue("@HeatNr", HeatNr);
            com.Parameters.AddWithValue("@BaanKleurID", BaanKleurID);
            if (TeamID == -1) com.Parameters.AddWithValue("@TeamID", DBNull.Value); else com.Parameters.AddWithValue("@TeamID", TeamID);
            if (Tijd == -1) com.Parameters.AddWithValue("@Tijd", DBNull.Value); else com.Parameters.AddWithValue("@Tijd", Tijd);
            com.Parameters.AddWithValue("@ResultaatID", ResultaatID);
            if (Punten == -1) com.Parameters.AddWithValue("@Punten", DBNull.Value); else com.Parameters.AddWithValue("@Punten", Punten);
            com.Parameters.AddWithValue("@Hond1", Hond1);
            com.Parameters.AddWithValue("@Hond2", Hond2);
            com.Parameters.AddWithValue("@Hond3", Hond3);
            com.Parameters.AddWithValue("@Hond4", Hond4);
            com.Parameters.AddWithValue("@Hond5", Hond5);
            com.Parameters.AddWithValue("@Hond6", Hond6);

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

            return "OK, updated HeatID: " +HeatID.ToString();
        }

        // DELETE api/<controller>/117430   (wordt niet gebruikt)
        public string Delete(int id)
        {
            return "Delete is niet toegestaan via de WEB API";
        }

        // Maak de FlyFormHeat table leeg via WEB API
        private void ClearFlyFormHeat()
        {
            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand com = new SqlCommand("delete from [FlyForm].[dbo].[FlyFormHeat]", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
