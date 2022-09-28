using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BProduct
    {
        private DProduct DProduct = null;
        public List<Product> Listar(int IdProducto)
        {
            List<Product> products = null;
            try
            {
                DProduct = new DProduct();
                products = DProduct.Listar(new Product { IdProducto = IdProducto });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }
        public bool Insertar(Product producto)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.Insertar(producto);
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
            }
            return result;
        }
        public bool Actualizar(Product producto)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.Actualizar(producto);
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
            }
            return result;
        }
        public bool Eliminar(int IdProducto)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.Eliminar(IdProducto);
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
            }
            return result;
        }
    }
}
