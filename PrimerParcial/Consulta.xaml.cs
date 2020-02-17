using PrimerParcial.BLL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrimerParcial
{
    /// <summary>
    /// Interaction logic for Consulta.xaml
    /// </summary>
    public partial class Consulta : Window
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void ConsultaButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();
            if (CristerioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:// todos
                        listado = ProductosBLL.GetList(p => true);
                        break;
                    case 1: //ID
                        int id = Convert.ToInt32(CristerioTextBox.Text);
                        listado = ProductosBLL.GetList(p => p.ProductoId == id);
                        break;
                }
               // listado = listado.Where(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate && c.Fecha.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = ProductosBLL.GetList(p => true);
            }
            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }

    }
    }

