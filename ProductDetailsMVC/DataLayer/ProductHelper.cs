using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductHelper
    {
        /// <summary>
        /// get all the product related to Products
        /// </summary>
        /// <returns></returns>
        public List<ProductDetails> GetProductDetails()
        {
            List<ProductDetails> lst = new List<ProductDetails>();

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                string Query = "SELECT * FROM ProductDetails";
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.Fill(ds);
                lst = ds.Tables[0].DataTableToList<ProductDetails>();

            }
            catch (Exception ex)
            {
                throw;
            }

            return lst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public string AddProductDetails(ProductDetails product)
        {
            string result = "";
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();

                string Query = @"INSERT INTO [FSE].[dbo].[ProductDetails](ProductId, ProductName,SupplierID )VALUES 
                                        (@ProductId,@ProductName,@SupplierId)";

                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = "Record Added Successfully !";
            }
            catch (Exception ex)
            {
                result = "Error" + ex.InnerException;
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public string EditProductDetails(ProductDetails product)
        {
            string result = "";
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();

                string Query = @"Update [FSE].[dbo].[ProductDetails] SET ProductName=@ProductName,SupplierID=@SupplierId WHERE ProductId=@ProductId";

                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = "Record Updated Successfully !";
            }
            catch (Exception ex)
            {
                result = "Error" + ex.InnerException;
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public  ProductDetails SearachProductDetails(int ProductId)
        {
            ProductDetails p = new ProductDetails();
            try
            {
                
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                string Query = @"SELECT * FROM [dbo].[ProductDetails] WHERE ProductId=@ProductId";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.SelectCommand.Parameters.AddWithValue("@ProductId", ProductId);
                con.Open();
                DataSet ds = new DataSet();
                sda.Fill(ds);
                p= ds.Tables[0].DataTableToList<ProductDetails>().FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return p;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public string DeleteProductDetails(int ProductId)
        {
            string Result;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                string Query = @"DELETE FROM [dbo].[ProductDetails] WHERE ProductId=@ProductId";
                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                con.Open();
                cmd.ExecuteNonQuery();
                Result = "Record Deleted Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }
    }
}
