using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Entity;

namespace App5.ViewModel
{
    public class ListaCategoriaVM : VMBase
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        public ICommand NuevoCommand { get; set; }
        public ICommand ConsultarCommand { get; set; }
        public ListaCategoriaVM()
        {
            Categorias = new Model.CategoriaM().Categorias;

            NuevoCommand = new RelayCommand<Window>(
                param => Abrir()
                );

            ConsultarCommand = new RelayCommand<object>(
                o => { Categorias = (new Model.CategoriaM()).Categorias; }
                );

            void Abrir()
            {
                View.ManCategoria window = new View.ManCategoria();
                window.ShowDialog();
            }
        }
    }
}
