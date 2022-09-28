using Business;
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
    /// Lógica de interacción para ListarProduct.xaml
    /// </summary>
    public partial class ListarProduct : Window
    {
        public ListarProduct()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }
        private void Cargar()
        {
            BProduct Bproduct = null;
            try
            {
                Bproduct = new BProduct();
                dgvProducto.ItemsSource = Bproduct.Listar(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comunicarse con el Administrador" + ex);
            }
            finally
            {
                Bproduct = null;
            }
        }
        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ManProduct manProduct = new ManProduct(0);
            manProduct.ShowDialog();
            Cargar();
        }

        private void DgvProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
