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

        public string Post([FromBody]string value)
        {


            string[] rw;
            string[] values;

            rw = value.Split(Convert.ToChar(13));

            //values = rw.Split(Convert.ToChar(9));

            return rw[0];

            //values = value.Split(Convert.ToChar(9));

            //values[5] = values[5].Replace(".", ",");


            //int HeatID = int.Parse(values[0]);

            //int RaceID = int.Parse(values[1]);

            //int HeatNr = int.Parse(values[2]);

            //int BaanKleurID = int.Parse(values[3]);

            //int TeamID = int.Parse(values[4]);

            //decimal Tijd = decimal.Parse(values[5], NumberStyles.AllowDecimalPoint);

            //int ResultaatID = int.Parse(values[6]);

            //int Punten = int.Parse(values[7]);

            //int Hond1 = int.Parse(values[8]);

            //int Hond2 = int.Parse(values[9]);

            //int Hond3 = int.Parse(values[10]);

            //int Hond4 = int.Parse(values[11]);

            //int Hond5 = int.Parse(values[12]);

            //int Hond6 = int.Parse(values[13]);



            //string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;

            //SqlConnection con = new SqlConnection(conStr);

            //SqlCommand com = new SqlCommand("update [FlyForm].[dbo].[FlyFormHeat] set RaceID = @RaceID,HeatNr = @HeatNr,BaanKleurID= @BaanKleurID,TeamID = @TeamID,Tijd = @Tijd,ResultaatID= @ResultaatID,Punten = @Punten,Hond1 = @Hond1,Hond2 = @Hond2,Hond3 = @Hond3,Hond4 = @Hond4,Hond5 = @Hond5,Hond6 = @Hond6 where HeatID = @HeatID", con);

            //com.Parameters.AddWithValue("@HeatID", HeatID);
            //com.Parameters.AddWithValue("@RaceID", RaceID);
            //com.Parameters.AddWithValue("@HeatNr", HeatNr);
            //com.Parameters.AddWithValue("@BaanKleurID", BaanKleurID);
            //com.Parameters.AddWithValue("@TeamID", TeamID);
            //com.Parameters.AddWithValue("@Tijd", Tijd);
            //com.Parameters.AddWithValue("@ResultaatID", ResultaatID);
            //com.Parameters.AddWithValue("@Punten", Punten);
            //com.Parameters.AddWithValue("@Hond1", Hond1);
            //com.Parameters.AddWithValue("@Hond2", Hond2);
            //com.Parameters.AddWithValue("@Hond3", Hond3);
            //com.Parameters.AddWithValue("@Hond4", Hond4);
            //com.Parameters.AddWithValue("@Hond5", Hond5);
            //com.Parameters.AddWithValue("@Hond6", Hond6);

            //con.Open();

            //com.ExecuteNonQuery();

            //con.Close();

            //return "OK";


        }

        // PUT api/Heat/117430
        public string Put(int id, [FromBody]string value)
        {
            string[] values;

            values = value.Split(Convert.ToChar(9));

            values[5] = values[5].Replace(".", ",");


            int HeatID = int.Parse(values[0]);

            int RaceID = int.Parse(values[1]);

            int HeatNr = int.Parse(values[2]);

            int BaanKleurID = int.Parse(values[3]);

            int TeamID = int.Parse(values[4]);

            decimal Tijd = decimal.Parse(values[5], NumberStyles.AllowDecimalPoint);

            int ResultaatID = int.Parse(values[6]);

            int Punten = int.Parse(values[7]);

            int Hond1 = int.Parse(values[8]);

            int Hond2 = int.Parse(values[9]);

            int Hond3 = int.Parse(values[10]);

            int Hond4 = int.Parse(values[11]);

            int Hond5 = int.Parse(values[12]);

            int Hond6 = int.Parse(values[13]);



            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(conStr);

            SqlCommand com = new SqlCommand("update [FlyForm].[dbo].[FlyFormHeat] set RaceID = @RaceID,HeatNr = @HeatNr,BaanKleurID= @BaanKleurID,TeamID = @TeamID,Tijd = @Tijd,ResultaatID= @ResultaatID,Punten = @Punten,Hond1 = @Hond1,Hond2 = @Hond2,Hond3 = @Hond3,Hond4 = @Hond4,Hond5 = @Hond5,Hond6 = @Hond6 where HeatID = @HeatID", con);

            com.Parameters.AddWithValue("@HeatID", HeatID);
            com.Parameters.AddWithValue("@RaceID", RaceID);
            com.Parameters.AddWithValue("@HeatNr", HeatNr);
            com.Parameters.AddWithValue("@BaanKleurID", BaanKleurID);
            com.Parameters.AddWithValue("@TeamID", TeamID);
            com.Parameters.AddWithValue("@Tijd", Tijd);
            com.Parameters.AddWithValue("@ResultaatID", ResultaatID);
            com.Parameters.AddWithValue("@Punten", Punten);
            com.Parameters.AddWithValue("@Hond1", Hond1);
            com.Parameters.AddWithValue("@Hond2", Hond2);
            com.Parameters.AddWithValue("@Hond3", Hond3);
            com.Parameters.AddWithValue("@Hond4", Hond4);
            com.Parameters.AddWithValue("@Hond5", Hond5);
            com.Parameters.AddWithValue("@Hond6", Hond6);

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

            return "OK";
        }

        // DELETE api/<controller>/117430   (wordt niet gebruikt)
        public string Delete(int id)
        {
            return "Delete is niet toegestaan via de WEB API";
        }

    }

}
