using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MegaCastingApp.Windows.Items;
using MegaCastingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingApp.ViewModel.Items
{
    public class OffreItemViewModel : ViewModelBase
    {
        #region Properties
        public Offre associated_entity;
        public OffreItemWindow windowAssociee;

        private long identifiant;

        public long Identifiant
        {
            get { return identifiant; }
            set
            {
                if (identifiant != value)
                {
                    identifiant = value;
                    RaisePropertyChanged("Identifiant");
                }
                
            }
        }


        private string type;

        public string Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    RaisePropertyChanged("Type");
                }

            }
        }



        private double tarif;

        public double Tarif
        {
            get { return tarif; }
            set
            {
                if (tarif != value)
                {
                    tarif = value;
                    RaisePropertyChanged("Tarif");
                }

            }
        }


        private int? nb_Casting;

        public int? Nb_Casting
        {
            get { return nb_Casting; }
            set
            {
                if (nb_Casting != value)
                {
                    nb_Casting = value;
                    RaisePropertyChanged("Nb_Casting");
                }

            }
        }


        private RelayCommand validerCommand;

        public RelayCommand ValiderCommand
        {
            get { return validerCommand; }
            set
            {
                validerCommand = value;
                RaisePropertyChanged("ValiderCommand");
            }
        }


        private RelayCommand cancelCommand;

        public RelayCommand CancelCommand
        {
            get { return cancelCommand; }
            set
            {
                cancelCommand = value;
                RaisePropertyChanged("CancelCommand");
            }
        }



        #endregion


        #region Constructor(s)
        public OffreItemViewModel(Offre offre)
        {
            if (offre == null)
            {
                offre = new Offre();
            }
            associated_entity = offre;

            this.Identifiant = offre?.Identifiant ?? 0;
            this.Type = offre?.Type;
            this.Tarif = offre.Tarif;
            this.Nb_Casting = offre.Nb_Casting;

            this.ValiderCommand = new RelayCommand(Valider);
            this.CancelCommand = new RelayCommand(Annuler);

        }

        #endregion


        #region Functions
        private void Valider()
        {
            if (windowAssociee != null)
            {
                windowAssociee.DialogResult = true;
                windowAssociee.Close();
            }
        }


        private void Annuler()
        {
            if (windowAssociee != null)
            {
                windowAssociee.DialogResult = false;
                windowAssociee.Close();
            }
        }

        public Offre ToEntity()
        {
            Offre toReturn = associated_entity;

            toReturn.Type = Type;
            toReturn.Tarif = Tarif;
            toReturn.Nb_Casting = Nb_Casting;


            return toReturn;
        }

        #endregion
    }
}
