using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace App5
{
    /// <summary>
    /// Lógica de interacción para ManProduct.xaml
    /// </summary>
    public partial class ManProduct : Window
    {
        public int ID { get; set; }
        public ManProduct(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BProduct bProduct = new BProduct();
                List<Product> products = new List<Product>();
                products = bProduct.Listar(ID);
                if (products.Count > 0)
                {
                    lblID.Content = products[0].IdProducto.ToString();
                    txtNombre.Text = products[0].Nombre;
                    txtPrecio.Text = products[0].Precio.ToString();
                }
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProduct Bproduct = null;
            bool result = true;
            try
            {
                Bproduct = new BProduct();
                if (ID > 0)
                    result = Bproduct.Actualizar(new Product { IdProducto = ID, Nombre = txtNombre.Text, Precio = Convert.ToDouble(txtPrecio.Text) });
                else
                    result = Bproduct.Insertar(new Product { Nombre = txtNombre.Text, Precio = Convert.ToDouble(txtPrecio.Text) });

                if (!result)
                    MessageBox.Show("Comunicarse con el Administrador");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bproduct = null;
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
