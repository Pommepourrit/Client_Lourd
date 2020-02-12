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
    public class ContenuEditorialItemViewModel : ViewModelBase
    {
        //TODO Vérifications
        #region Properties

        #region Entities
        public ContenuEditorial associated_entity;

        #region Foreign Keys

        private string libelleTypeContenu;

        public string LibelleTypeContenu
        {
            get { return libelleTypeContenu; }
            set
            {
                if (libelleTypeContenu != value)
                {
                    libelleTypeContenu = value;
                    RaisePropertyChanged("LibelleTypeContenu");
                }
            }
        }

        private List<TypeContenuEditorial> lstTypes;

        public List<TypeContenuEditorial> LstTypes
        {
            get { return lstTypes; }
            set
            {
                if (lstTypes != value)
                {
                    lstTypes = value;
                    RaisePropertyChanged("LstTypes");
                }
            }
        }

        private TypeContenuEditorial typeContenuSelectionne;

        public TypeContenuEditorial TypeContenuSelectionne
        {
            get { return typeContenuSelectionne; }
            set
            {
                if (typeContenuSelectionne != value)
                {
                    typeContenuSelectionne = value;
                    RaisePropertyChanged("TypeContenuSelectionne");
                }

                if (typeContenuSelectionne == null)
                {
                    Type_IsOk = false;
                    Type_Error = "Merci de séléctionner un type de contenu";
                }
                else
                {
                    Type_IsOk = true;
                    Type_Error = string.Empty;
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


        private string titre;

        public string Titre
        {
            get { return titre; }
            set
            {
                if (titre != value)
                {
                    titre = value;
                    RaisePropertyChanged("Titre");
                }

                if (string.IsNullOrWhiteSpace(Titre))
                {
                    Titre_IsOk = false;
                    Titre_Error = "Merci de renseigner ce champ";
                }
                else if (Titre.Length > 255)
                {
                    Titre_IsOk = false;
                    Titre_Error = "Ce champ doit faire maximum 255 caractères(actuellement "
                        + titre.Length
                        + ")";
                }
                else
                {
                    Titre_IsOk = true;
                    Titre_Error = string.Empty;
                }

            }
        }


        private DateTime? date_Publication;

        public DateTime? Date_Publication
        {
            get { return date_Publication; }
            set
            {
                if (date_Publication != value)
                {
                    date_Publication = value;
                    RaisePropertyChanged("Date_Publication");
                }

                if (!Date_Publication.HasValue)
                {
                    Date_Publication_IsOk = false;
                    Date_Publication_Error = "Merci de renseigner ce champ";
                }
                else if (Date_Publication.Value < DateTime.Today)
                {
                    Date_Publication_IsOk = false;
                    Date_Publication_Error = "Veuillez saisir une date valide";
                }
                else
                {
                    Date_Publication_IsOk = true;
                    Date_Publication_Error = string.Empty;
                }


            }
        }

        #endregion

        #region Vue

        #region Verification

        public bool IsOk
        {
            get
            {
                return Titre_IsOk && Date_Publication_IsOk && Type_IsOk;
            }
        }

        
        private bool titre_IsOk;

        public bool Titre_IsOk
        {
            get { return titre_IsOk; }
            set
            {
                titre_IsOk = value;
                RaisePropertyChanged("Titre_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string titre_Error;

        public string Titre_Error
        {
            get { return titre_Error; }
            set
            {
                titre_Error = value;
                RaisePropertyChanged("Titre_Error");
            }
        }



        private bool date_Publication_IsOk;

        public bool Date_Publication_IsOk
        {
            get { return date_Publication_IsOk; }
            set
            {
                date_Publication_IsOk = value;
                RaisePropertyChanged("Date_Publication_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string date_Publication_Error;

        public string Date_Publication_Error
        {
            get { return date_Publication_Error; }
            set
            {
                date_Publication_Error = value;
                RaisePropertyChanged("Date_Publication_Error");
            }
        }

        
        private bool type_IsOk;

        public bool Type_IsOk
        {
            get { return type_IsOk; }
            set
            {
                type_IsOk = value;
                RaisePropertyChanged("Type_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string type_Error;

        public string Type_Error
        {
            get { return type_Error; }
            set
            {
                type_Error = value;
                RaisePropertyChanged("Type_Error");
            }
        }

        #endregion

        public ContenuEditorialItemWindow windowAssociee;


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
        public ContenuEditorialItemViewModel(ContenuEditorial contenu, MegaProductionBDDEntities DB)
        {
            if (contenu == null)
            {
                contenu = new ContenuEditorial();
            }
            this.associated_entity = contenu;

            this.Identifiant = contenu?.Identifiant ?? 0;
            this.Titre = contenu?.Titre;
            this.Date_Publication = contenu?.Date_Publication;
            this.TypeContenuSelectionne = contenu?.TypeContenuEditorial;
            ValiderCommand = new RelayCommand(Valider);
            CancelCommand = new RelayCommand(Annuler);

            this.LstTypes = DB.TypeContenuEditorial.ToList();
            this.LibelleTypeContenu = contenu?.TypeContenuEditorial?.Libelle;
        }

        #endregion

        #region Functions

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

        public ContenuEditorial ToEntity()
        {
            ContenuEditorial toReturn = associated_entity;

            toReturn.Titre = Titre;
            toReturn.Date_Publication = Date_Publication;
            toReturn.TypeContenuEditorial = TypeContenuSelectionne;

            return toReturn;
        }

        #endregion
    }
}
