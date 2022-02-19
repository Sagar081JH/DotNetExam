using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        string ConnncetionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Exam; Integrated Security=True";
        public ActionResult Index()
        {
            DataTable mytbl = new DataTable();
            using (SqlConnection sqlConn=new SqlConnection(ConnncetionString))
            {
                sqlConn.Open();
                string selctQuery = "Select * from Products";
                SqlDataAdapter sqDa = new SqlDataAdapter(selctQuery, sqlConn);
                sqDa.Fill(mytbl);
            }
            return View(mytbl);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View(new ProductsModel());
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(ProductsModel pm)
        {
           // DataTable dtbl = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(ConnncetionString))
            {
                sqlConn.Open();
               // string insertQuery = "insert into Products values (@ProductId,@ProductName,@Rate,@Description,@CategoryName)";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                //cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = insertQuery;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertProduct";
                cmd.Parameters.AddWithValue("@ProductId", pm.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", pm.ProductName);
                cmd.Parameters.AddWithValue("@Rate", pm.Rate);
                cmd.Parameters.AddWithValue("@Description", pm.Description);
;                cmd.Parameters.AddWithValue("@CategoryName", pm.CategoryName);

                cmd.ExecuteNonQuery();
                sqlConn.Close();
                
            }
            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            ProductsModel pm = new ProductsModel();
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(ConnncetionString))
            {
                sqlConn.Open();
                string selctQuery = "select * from Products where ProductId=@ProductId";
                SqlDataAdapter sqDa = new SqlDataAdapter(selctQuery, sqlConn);
                sqDa.SelectCommand.Parameters.AddWithValue("@ProductId", id);
                sqDa.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    pm.ProductId = Convert.ToInt32(dtbl.Rows[0][0].ToString());
                    pm.ProductName = dtbl.Rows[0][1].ToString();
                    pm.Rate = Convert.ToDecimal(dtbl.Rows[0][2].ToString());
                    pm.Description = dtbl.Rows[0][3].ToString();
                    pm.CategoryName = dtbl.Rows[0][4].ToString();
                    return View(pm);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

     
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductsModel pm1 )
        {
            // DataTable dtbl = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(ConnncetionString))
            {
                sqlConn.Open();
              //  string updateQuery = "update Products set ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName where ProductId=@ProductId";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                // cmd.CommandType = System.Data.CommandType.Text;
                // cmd.CommandText = updateQuery;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.CommandText = "Update";
                cmd.Parameters.AddWithValue("@ProductId", pm1.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", pm1.ProductName);
                cmd.Parameters.AddWithValue("@Rate", pm1.Rate);
                cmd.Parameters.AddWithValue("@Description", pm1.Description);
                cmd.Parameters.AddWithValue("@CategoryName", pm1.CategoryName);

                cmd.ExecuteNonQuery();
                sqlConn.Close();

            }
            return RedirectToAction("Index");
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
