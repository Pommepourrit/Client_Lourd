using MegaCastingApp.ViewModel;
using MegaCastingApp.Windows.Listings;
using MegaCastingModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace MegaCastingApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //private MegaProductionBDDEntities myDb = new MegaProductionBDDEntities();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            LoginViewModel viewModel = loginWindow.DataContext as LoginViewModel;
            if (viewModel.employeAConnecter != null)
            {
                this.Title += " - " + viewModel.employeAConnecter.Prenom+ " " + viewModel.employeAConnecter.Nom ;
                Show();
            }
            else
            {
                Close();
            }
        }

        private void ListCasting_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new CastingListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }

        private void ListEmploye_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new EmployeListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }

        private void ListAnnonceur_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new AnnonceurListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }

        private void ListContenuEditorial_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new ContenuEditorialListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }

        private void ListOffre_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new OffreListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }

        private void ListPartenaireDiffusion_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new PartenaireDiffusionListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }



        #region Ref
        private void ListMetier_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new MetierListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }

        private void ListDomaine_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new DomaineListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }

        private void ListRoleEmploye_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new RoleEmployeListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }

        private void ListTypeContenuEditorial_Click(object sender, RoutedEventArgs e)
        {
            Contenu.Children.Clear();
            var userControl = new TypeContenuEditorialListWindow();
            Contenu.Children.Add(userControl);
            (this.DataContext as MainViewModel).ListingEnCours = userControl.DataContext;
        }
        #endregion
    }
}
