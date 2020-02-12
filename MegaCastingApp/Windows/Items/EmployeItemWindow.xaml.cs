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
    /// Logique d'interaction pour EmployeItemWindow.xaml
    /// </summary>
    public partial class EmployeItemWindow : Window
    {
        public EmployeItemWindow(EmployeItemViewModel employeItemViewModel)
        {
            InitializeComponent();
            this.DataContext = employeItemViewModel;
            employeItemViewModel.windowAssociee = this;
        }

        private void PasswordBoxPwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((EmployeItemViewModel)this.DataContext).Mot_De_Passe = this.passwordBox.Password;
        }
    }
}
