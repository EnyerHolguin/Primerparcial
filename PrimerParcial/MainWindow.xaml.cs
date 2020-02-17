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
            ProductoIdTextBox.Text = "0";
            Consulta c = new Consulta();
            c.Show();
        }
        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ValorinventarioTextBox.Text = string.Empty;

        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Productos LlenaClase()
        {
            Productos Producto = new Productos();

            Producto.ProductoId = Convert.ToInt32(ProductoIdTextBox.Text);
            Producto.Descripcion = DescripcionTextBox.Text;
            Producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            Producto.Costo = Convert.ToInt32(CostoTextBox.Text);
            Producto.Valorinventario = Convert.ToInt32(Producto.Existencia * Producto.Costo);

            return Producto;
        }
        private void LlenaCampo(Productos Producto)
        {
            ProductoIdTextBox.Text = Convert.ToString(Producto.ProductoId);
            DescripcionTextBox.Text = Producto.Descripcion;
            ExistenciaTextBox.Text = Convert.ToString(Producto.Existencia);
            CostoTextBox.Text = Convert.ToString(Producto.Costo);
            ValorinventarioTextBox.Text = Convert.ToString(Producto.Valorinventario);
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text)) 
            {
                MessageBox.Show("El campo Descripcion no puede estar vacio");
                ProductoIdTextBox.Focus();
                paso = false;
            }
            if (DescripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show("La Descripcion  no puede estar vacio");
                ProductoIdTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
            {
                MessageBox.Show("La existencia no puede estar vacia");
                ExistenciaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MessageBox.Show("el costo no puede estar vacio");
                CostoTextBox.Focus();
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
            Productos Producto = new Productos();
            bool paso = false;

            if (!Validar())
                return;

            Producto = LlenaClase();
            if (ProductoIdTextBox.Text == "0")
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
            if (ProductosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se Puede Eliminar un producto que no existe");

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
                MessageBox.Show("Encontrado");
                LlenaCampo(Producto);
            }
            else
                MessageBox.Show("producto no encontrado ....");
            

         }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorinventarioTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorinventarioTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void ValorinventarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorinventarioTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }
    }
}


