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
using MegaCastingApp.ViewModel.Listings;

namespace MegaCastingApp.Windows.Listings
{
    /// <summary>
    /// Logique d'interaction pour ContenuEditorialListWindow.xaml
    /// </summary>
    public partial class ContenuEditorialListWindow : UserControl
    {
        public ContenuEditorialListWindow()
        {
            InitializeComponent();
            this.DataContext = new ContenuEditorialListViewModel();
        }
    }
}
