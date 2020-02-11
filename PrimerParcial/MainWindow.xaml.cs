using PrimerParcial.BLL;
using PrimerParcial.Entidades;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrimerParcial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            ProductoIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = "0";
            CostoTextBox.Text = "0";
            ValorinventarioTextBox.Text = "0";

        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Productos LlenaClase()
        {
            Productos Producto = new Productos();

            Producto.ProductoId = Convert.ToInt32(ProductoIdTextBox.Text);
            Producto.Descripcion = String.Empty;
            Producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            Producto.Costo = Convert.ToInt32(CostoTextBox.Text);
            Producto.Valorinventario = Convert.ToInt32(ValorinventarioTextBox.Text);

            return Producto;
        }
        private void LlenaCampo(Productos Producto)
        {
            ProductoIdTextBox.Text = Convert.ToString(Producto.ProductoId);
            DescripcionTextBox.Text = String.Empty;
            ExistenciaTextBox.Text = Convert.ToString(Producto.Existencia);
            CostoTextBox.Text = Convert.ToString(Producto.Costo);
        }
        private bool Validar()
        {
            bool paso = true;

            if (ProductoIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo ID no puede estar vacio");
                ProductoIdTextBox.Focus();
                paso = false;
            }
            if (DescripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show("El Descripcion campo no puede estar vacio");
                ProductoIdTextBox.Focus();
                paso = false;
            }
            if (ExistenciaTextBox.Text == string.Empty)
            {
                MessageBox.Show("El Descripcion campo no puede estar vacio");
                ProductoIdTextBox.Focus();
                paso = false;
            }
            if (CostoTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo costos no puede estar vacio");
                ProductoIdTextBox.Focus();
                paso = false;
            }
            if (ValorinventarioTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo valor inventario  no puede estar vacio");
                ProductoIdTextBox.Focus();
                paso = false;
            }


            return paso;
        }

        private bool ExisteEnLaBaseDeDAto()
        {
            Productos Producto = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            return (Producto != null);

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos Producto;
            bool paso = false;
            if (!Validar())
                return;

            Producto = LlenaClase();
            if (Convert.ToInt32(ProductoIdTextBox.Text) == 0)
                paso = ProductosBLL.Guardar(Producto);
            else
            {

                if (!ExisteEnLaBaseDeDAto())
                {
                    MessageBox.Show("No fue posible Guardar!!", " Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = ProductosBLL.Modificar(Producto);
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);



        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ProductoIdTextBox.Text, out id);

            Limpiar();
            if (!ExisteEnLaBaseDeDAto())
            {
                MessageBox.Show("No se puede eliminar un producto inexistente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ProductosBLL.Eliminar(id))
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Productos Producto = new Productos();
            int.TryParse(ProductoIdTextBox.Text, out id);
            Limpiar();
            Producto = ProductosBLL.Buscar(id);
            if (Producto != null)
            {
                LlenaCampo(Producto);
            }
            else
            {
                MessageBox.Show("Persona No Encontarda....");
            }

         }
       }
    }


