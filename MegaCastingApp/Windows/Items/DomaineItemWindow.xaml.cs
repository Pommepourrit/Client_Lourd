using MegaCastingApp.ViewModel.Items;
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

namespace MegaCastingApp.Windows.Items
{
    /// <summary>
    /// Logique d'interaction pour DomaineItemWindow.xaml
    /// </summary>
    public partial class DomaineItemWindow : Window
    {
        public DomaineItemWindow(DomaineItemViewModel domaineItemViewModel)
        {
            InitializeComponent();
            DataContext = domaineItemViewModel;
            domaineItemViewModel.windowAssociee = this;

        }
    }
}
