using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProduct
    {
        public List<Product> Listar(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Product> products = null;

            try
            {
                comandText = "UPS_GetProducts";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idProducto", System.Data.SqlDbType.Int);
                parameters[0].Value = product.IdProducto;
                products = new List<Product>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, comandText, System.Data.CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            IdProducto = reader["idProducto"] != null ? Convert.ToInt32(reader["idProducto"]) : 0,
                            Nombre = reader["nombre"] != null ? Convert.ToString(reader["nombre"]) : string.Empty,
                            Precio = reader["precio"] != null ? Convert.ToDouble(reader["precio"]) : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

        public void Insertar(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "UPS_InsProducts";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombre", System.Data.SqlDbType.VarChar);
                parameters[0].Value = product.Nombre;
                parameters[1] = new SqlParameter("@precio", System.Data.SqlDbType.Decimal);
                parameters[1].Value = product.Precio;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, System.Data.CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_UpdProduct";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idcategoria", System.Data.SqlDbType.Int);
                parameters[0].Value = product.IdProducto;
                parameters[1] = new SqlParameter("@nombrecategoria", System.Data.SqlDbType.VarChar);
                parameters[1].Value = product.Nombre;
                parameters[2] = new SqlParameter("@descripcion", System.Data.SqlDbType.Text);
                parameters[3].Value = product.Precio;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, System.Data.CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_DelProduct";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idcategoria", System.Data.SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, System.Data.CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
