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
   public class SupplierHelper
    {
        /// <summary>
        /// get all the product related to Products
        /// </summary>
        /// <returns></returns>
        public List<Supplierinfo> GetSupplierDetails()
        {
            List<Supplierinfo> lst = new List<Supplierinfo>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                string Query = "SELECT * FROM Supplierinfo";
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.Fill(ds);
                lst = ds.Tables[0].DataTableToList<Supplierinfo>();
            }
            catch (Exception)
            {
                throw;
            }

            return lst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public string AddSupplierDetails(Supplierinfo supplier)
        {
            string result = "";
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                string Query = @"INSERT INTO [FSE].[dbo].Supplierinfo (SupplierId ,SupplierName ,Address ,City,ContactNumber,Email )VALUES 
                                        (@SupplierId ,@SupplierName ,@Address ,@City,@ContactNumber,@Email )";
                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                cmd.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.Parameters.AddWithValue("@City", supplier.City);
                cmd.Parameters.AddWithValue("@ContactNumber", supplier.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
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
        public string EditSupplierDetails(Supplierinfo supplier)
        {
            string result = "";
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();

                string Query = @"Update [FSE].[dbo].[Supplierinfo] SET SupplierName=@SupplierName,Address=@Address,City=@City,ContactNumber=@ContactNumber,Email=@Email WHERE SupplierId=@SupplierId";

                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                cmd.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.Parameters.AddWithValue("@City", supplier.City);
                cmd.Parameters.AddWithValue("@ContactNumber", supplier.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = "Record Updated Successfully !";
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SupplierId"></param>
        /// <returns></returns>
        public Supplierinfo SearchSupplierDetails(int SupplierId)
        {
            Supplierinfo p = new Supplierinfo();
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                string Query = @"SELECT * FROM [dbo].[SupplierInfo] WHERE SupplierId=@SupplierId";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.SelectCommand.Parameters.AddWithValue("@SupplierId", SupplierId);
                con.Open();
                DataSet ds = new DataSet();
                
                 
                sda.Fill(ds);
                p = ds.Tables[0].DataTableToList<Supplierinfo>().FirstOrDefault();
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
        public string DeleteSupplierDetails(int SupplierId)
        {
            string Result;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                string Query = @"DELETE FROM [dbo].[Supplierinfo] WHERE SupplierId=@SupplierId";
                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
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
