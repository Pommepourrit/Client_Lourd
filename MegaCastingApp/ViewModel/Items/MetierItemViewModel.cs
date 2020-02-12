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
    public class MetierItemViewModel : ViewModelBase
    {
        #region Properties

        #region Entities

        public Metier associated_entity;

        #region Foreign Key(s)

        private string libelleDomaine;

        public string LibelleDomaine
        {
            get { return libelleDomaine; }
            set
            {
                if (libelleDomaine != value)
                {
                    libelleDomaine = value;
                    RaisePropertyChanged("LibelleDomaine");
                }
            }
        }


        private List<Domaine> lstDomaines;

        public List<Domaine> LstDomaines
        {
            get { return lstDomaines; }
            set
            {
                if (lstDomaines != value)
                {
                    lstDomaines = value;
                    RaisePropertyChanged("LstDomaines");
                }
            }
        }


        private Domaine domaineSelectionne;

        public Domaine DomaineSelectionne
        {
            get { return domaineSelectionne; }
            set
            {
                if (domaineSelectionne != value)
                {
                    domaineSelectionne = value;
                    RaisePropertyChanged("DomaineSelectionne");
                }

                if(domaineSelectionne == null)
                {
                    Domaine_IsOk = false;
                    Domaine_Error = "Merci de séléctionner un domaine";
                }
                else
                {
                    Domaine_IsOk = true;
                    Domaine_Error = string.Empty;
                }
            }
        }



        #endregion

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


        private string libelle;

        public string Libelle
        {
            get { return libelle; }
            set
            {
                if (libelle != value)
                {
                    libelle = value;
                    RaisePropertyChanged("Libelle");
                }

                if (string.IsNullOrWhiteSpace(Libelle))
                {
                    Libelle_IsOk = false;
                    Libelle_Error = "Merci de renseigner ce champ";
                }
                else if (Libelle.Length > 255)
                {
                    Libelle_IsOk = false;
                    Libelle_Error= "Ce champ doit faire maximum 255 caractères (actuellement "
                        + libelle.Length
                        + ")";
                }
                else
                {
                    Libelle_IsOk = true;
                    Libelle_Error = string.Empty;
                }
            }
        }


        #endregion

        #region Vue

        #region Verifications

        public bool IsOk
        { get
            {
                return Libelle_IsOk && Domaine_IsOk;
            }
        }

        private bool libelle_IsOk;

        public bool Libelle_IsOk
        {
            get { return libelle_IsOk; }
            set
            {
                libelle_IsOk = value;
                RaisePropertyChanged("Libelle_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string libelle_Error;

        public string Libelle_Error
        {
            get { return libelle_Error; }
            set
            {
                libelle_Error = value;
                RaisePropertyChanged("Libelle_Error");
            }
        }


        private bool domaine_IsOk;

        public bool Domaine_IsOk
        {
            get { return domaine_IsOk; }
            set
            {
                domaine_IsOk = value;
                RaisePropertyChanged("Domaine_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string domaine_Error;

        public string Domaine_Error
        {
            get { return domaine_Error; }
            set
            {
                domaine_Error = value;
                RaisePropertyChanged("Domaine_Error");
            }
        }


        #endregion

        public MetierItemWindow windowAssociee;

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

        #endregion


        #region Constructor(s)

        public MetierItemViewModel(Metier metier, MegaProductionBDDEntities MyDb)
        {
            if (metier == null)
            {
                metier = new Metier();
            }

            this.associated_entity = metier;

            this.Identifiant = metier?.Identifiant ?? 0;
            this.Libelle = metier?.Libelle;
            this.DomaineSelectionne = metier?.Domaine1;

            this.LstDomaines = MyDb.Domaine.ToList();
            this.LibelleDomaine = metier?.Domaine1?.Libelle;

            ValiderCommand = new RelayCommand(Valider);
            CancelCommand = new RelayCommand(Annuler);
        }
        #endregion


        #region Functions

        public Metier ToEntity()
        {
            Metier toReturn = associated_entity;

            toReturn.Libelle = Libelle;
            toReturn.Domaine1 = DomaineSelectionne;

            return toReturn;
        }

        private void Valider()
        {
            if (windowAssociee != null && IsOk)
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
        #endregion
    }
}
