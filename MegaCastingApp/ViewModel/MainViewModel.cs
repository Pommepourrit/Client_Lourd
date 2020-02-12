using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties
        private object listingEnCours;
        public object ListingEnCours
        {
            get { return listingEnCours; }
            set
            {
                listingEnCours = value;
                RaisePropertyChanged("ListingEnCours");
            }
        }

        private RelayCommand quitterCommand;
        public RelayCommand QuitterCommand
        {
            get { return quitterCommand; }
            set
            {
                quitterCommand = value;
                RaisePropertyChanged("QuitterCommand");
            }
        }

        #endregion

        #region Constructeur(s)
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.QuitterCommand = new RelayCommand(Quitter);
        }
        #endregion


        #region Functions
        private void Quitter()
        {
            App.Current.Shutdown();
        }
        #endregion
    }
}
