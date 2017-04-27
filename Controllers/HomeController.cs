using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonEx.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;


namespace PersonEx.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private static string TABLE_NAME = "Persons";

        public IActionResult Index()
        {
            string error = string.Empty;
            List<Person> personCollection = this.ListPersons(out error);

            if (!string.IsNullOrEmpty(error)) { ViewBag.ClusterIPError = error; }
            return View(personCollection);
        }

        [HttpPost]
        public IActionResult Index(Microsoft.AspNetCore.Http.IFormCollection coll)
        {
            try
            {
                
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionSetting.CONNECTION_STRING))
                {
                    string query = string.Format("Insert into {0}(Name,Address,Contactno,Picture) Values ('{1}','{2}','{3}','{4}')", TABLE_NAME, Request.Form["personname"].ToString(), Request.Form["address"].ToString(), Request.Form["contactno"].ToString(), string.Empty);
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex) { ViewBag.ClusterIPError = "Unable to add records. Please verify your connection.";
                /*Logger.Error(ex, "Index");*/ }


            string error = string.Empty;
            List<Person> personCollection = this.ListPersons(out error);

            if (!string.IsNullOrEmpty(error)) { ViewBag.ClusterIPError = error; }
            return View(personCollection);
        }

        public List<Person> ListPersons(out string error)
        {
            List<Person> personCollection = null;
            error = string.Empty;
            try
            {
                
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionSetting.CONNECTION_STRING))
                {
                    string query = string.Format("SELECT PersonID,Name,Address,ContactNo,Picture FROM {0}", TABLE_NAME);
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        sqlConnection.Open();
                        SqlDataReader personReader = command.ExecuteReader();
                        personCollection = new List<Person>();
                        while (personReader.Read())
                        {
                            Person oPerson = new Person();

                            oPerson.Id = Convert.ToInt32(personReader["PersonID"].ToString());
                            oPerson.Name = personReader["Name"].ToString();
                            oPerson.Address = personReader["Address"].ToString();
                            oPerson.ContactNo = personReader["ContactNo"].ToString();
                            oPerson.Picture = personReader["Picture"].ToString() == string.Empty ? "/pics/no_picture.jpg" : "/pics/" + personReader["Picture"].ToString();

                            personCollection.Add(oPerson);
                        }
                    }
                    sqlConnection.Close();
                }
               
            }
            catch (Exception ex) { error = ex.Message; }
            
            return personCollection;
        }
    }
}
