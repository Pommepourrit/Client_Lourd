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
    public class CastingItemViewModel : ViewModelBase
    {

        #region Properties

        #region Entities

        public Casting associated_entity;


        #region Foreign Key(s)
        private string libelleAnnonceur;

        public string LibelleAnnonceur
        {
            get { return libelleAnnonceur; }
            set
            {
                if (libelleAnnonceur != value)
                {
                    libelleAnnonceur = value;
                    RaisePropertyChanged("LibelleAnnonceur");
                }
            }
        }


        private List<Annonceur> lstAnnonceurs;

        public List<Annonceur> LstAnnonceurs
        {
            get { return lstAnnonceurs; }
            set
            {
                if (lstAnnonceurs != null)
                {
                    lstAnnonceurs = value;
                    RaisePropertyChanged("LstAnnonceurs");
                }
            }
        }

        private Annonceur annonceurSelectionne;

        public Annonceur AnnonceurSelectionne
        {
            get { return annonceurSelectionne; }
            set
            {
                if (annonceurSelectionne != null)
                {
                    annonceurSelectionne = value;
                    RaisePropertyChanged("AnnonceurSelectionne");
                }
            }
        }




        private string employeUserName;

        public string EmployeUserName
        {
            get { return employeUserName; }
            set
            {
                if (employeUserName != value)
                {
                    employeUserName = value;
                    RaisePropertyChanged("EmployeUserName");
                }
            }
        }

        private List<Employe> employes;

        public List<Employe> Employes
        {
            get { return employes; }
            set
            {
                if (employes != null)
                {
                    employes = value;
                    RaisePropertyChanged("Employes");
                }
            }
        }


        private Employe employeSelectionne;

        public Employe EmployeSelectionne
        {
            get { return employeSelectionne; }
            set
            {
                if (employeSelectionne != null)
                {
                    employeSelectionne = value;
                    RaisePropertyChanged("EmployeSelectionne");
                }
            }
        }



        private string libelleMetier;

        public string LibelleMetier
        {
            get { return libelleMetier; }
            set
            {
                if (libelleMetier != value)
                {
                    libelleMetier = value;
                    RaisePropertyChanged("LibelleMetier");
                }
            }
        }

        private List<Metier> metiers;

        public List<Metier> Metiers
        {
            get { return metiers; }
            set
            {
                if (metiers != null)
                {
                    metiers = value;
                    RaisePropertyChanged("Metiers");
                }
            }
        }

        private Metier metierSelectionne;

        public Metier MetierSelectionne
        {
            get { return metierSelectionne; }
            set
            {
                if (metierSelectionne != null)
                {
                    metierSelectionne = value;
                    RaisePropertyChanged("MetierSelectionne");
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
                //TESTS
                //Test chaine vide
                if (string.IsNullOrWhiteSpace(Libelle))
                {
                    Libelle_IsOk = false;
                    Libelle_Error = "Merci de renseigner ce champ";
                }
                else if (Libelle.Length > 255)
                {
                    Libelle_IsOk = false;
                    Libelle_Error = "Ce champ doit faire maximum 255 caractères (actuellement "
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

        private DateTime? date_Debut_Publication;
        public DateTime? Date_Debut_Publication
        {
            get { return date_Debut_Publication; }
            set
            {
                if (date_Debut_Publication != value)
                {
                    date_Debut_Publication = value;
                    RaisePropertyChanged("Date_Debut_Publication");
                }
            }
        }

        private int nb_Jour_Diffusion;
        public int Nb_Jour_Diffusion
        {
            get { return nb_Jour_Diffusion; }
            set
            {
                if (nb_Jour_Diffusion != value)
                {
                    nb_Jour_Diffusion = value;
                    RaisePropertyChanged("Nb_Jour_Diffusion");
                }

                if (string.IsNullOrEmpty(Nb_Jour_Diffusion.ToString()))
                {
                    Nb_Jour_Diffusion_IsOk = false;
                    Nb_Jour_Diffusion_Error = "Ce champ doit obligatoirement comporter une valeur";

                }
                else if (Nb_Jour_Diffusion < 1)
                {
                    Nb_Jour_Diffusion_IsOk = false;
                    Nb_Jour_Diffusion_Error = "Cette valeur doit être supérieur à 0";

                }
                else
                {
                    Nb_Jour_Diffusion_IsOk = true;
                    Nb_Jour_Diffusion_Error = string.Empty;
                }
            }
        }

        private DateTime? date_Debut_Contrat;
        public DateTime? Date_Debut_Contrat
        {
            get { return date_Debut_Contrat; }
            set
            {
                if (date_Debut_Contrat != value)
                {
                    date_Debut_Contrat = value;
                    RaisePropertyChanged("Date_Debut_Contrat");
                }

            }
        }

        private int? nb_Poste;
        public int? Nb_Poste
        {
            get { return nb_Poste; }
            set
            {
                if (nb_Poste != value)
                {
                    nb_Poste = value;
                    RaisePropertyChanged("Nb_Poste");
                }
                //TESTS
                //Test chaine vide
                if (Nb_Poste == null)
                {
                    Nb_Poste_IsOk = false;
                    Nb_Poste_Error = "Merci de renseigner ce champ";
                }
                /*else if (!int.TryParse(Nb_Poste, out int converted))
                {
                    Nb_Poste_IsOk = false;
                    Nb_Poste_Error = "Ce champ doit être au format numérique";
                }*/
                if (string.IsNullOrEmpty(Nb_Poste.ToString()))
                {
                    Nb_Poste_IsOk = false;
                    Nb_Jour_Diffusion_Error = "Ce champ doit obligatoirement comporter une valeur";

                }
                else if (Nb_Poste < 1)
                {
                    Nb_Poste_IsOk = false;
                    Nb_Poste_Error = "Cette valeur doit être supérieur à 0";

                }
                else
                {
                    Nb_Poste_IsOk = true;
                    Nb_Poste_Error = string.Empty;
                }
            }
        }

        private string description_Poste;
        public string Description_Poste
        {
            get { return description_Poste; }
            set
            {
                if (description_Poste != value)
                {
                    description_Poste = value;
                    RaisePropertyChanged("Description_Poste");
                }
            }
        }

        private string description_Profil;
        public string Description_Profil
        {
            get { return description_Profil; }
            set
            {
                if (description_Profil != value)
                {
                    description_Profil = value;
                    RaisePropertyChanged("Description_Profil");
                }
            }
        }

        private string type_Contrat;
        public string Type_Contrat
        {
            get { return type_Contrat; }
            set
            {
                if (type_Contrat != value)
                {
                    type_Contrat = value;
                    RaisePropertyChanged("Type_Contrat");
                }
               ///*if (Type_Contrat.Length > 255)
               // {
               //     Type_Contrat_IsOk = false;
               //     Type_Contrat_Error = "Ce champ doit faire maximum 255 caractères (actuellement "
               //         + type_Contrat.Length
               //         + ")";
               // }
               // else*/

               // {
               //     Type_Contrat_IsOk = true;
               //     Type_Contrat_Error = string.Empty;
               // }
            }
        }

        private string adresse_Contrat;
        public string Adresse_Contrat
        {
            get { return adresse_Contrat; }
            set
            {
                if (adresse_Contrat != value)
                {
                    adresse_Contrat = value;
                    RaisePropertyChanged("Adresse_Contrat");
                }
                ///*if (Adresse_Contrat.Length > 255)
                //{
                //    Adresse_Contrat_IsOk = false;
                //    Adresse_Contrat_Error = "Ce champ doit faire maximum 255 caractères (actuellement "
                //        + adresse_Contrat.Length
                //        + ")";
                //}
                //else*/
                //{
                //    Adresse_Contrat_IsOk = true;
                //    Adresse_Contrat_Error = string.Empty;
                //}
            }
        }

        #endregion

        #region Vue

        #region Verifications

        public bool IsOk
        {
            get
            {
                return Libelle_IsOk && Nb_Jour_Diffusion_IsOk && Nb_Poste_IsOk && Type_Contrat_IsOk && Adresse_Contrat_IsOk;
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
                RaisePropertyChanged(nameof(IsOk));
            }
        }

        private string libelle_Error;
        public string Libelle_Error
        {
            get { return libelle_Error; }
            set
            {
                libelle_Error = value;
                RaisePropertyChanged(nameof(Libelle_Error));
            }
        }

        private bool nb_Jour_Diffusion_IsOk;
        public bool Nb_Jour_Diffusion_IsOk
        {
            get { return nb_Jour_Diffusion_IsOk; }
            set
            {
                nb_Jour_Diffusion_IsOk = value;
                RaisePropertyChanged(nameof(Nb_Jour_Diffusion_IsOk));
                RaisePropertyChanged(nameof(IsOk));
            }
        }

        private string nb_Jour_Diffusion_Error;
        public string Nb_Jour_Diffusion_Error
        {
            get { return nb_Jour_Diffusion_Error; }
            set
            {
                nb_Jour_Diffusion_Error = value;
                RaisePropertyChanged(nameof(Nb_Jour_Diffusion_Error));
            }
        }


        private bool nb_Poste_IsOk;
        public bool Nb_Poste_IsOk
        {
            get { return nb_Poste_IsOk; }
            set
            {
                nb_Poste_IsOk = value;
                RaisePropertyChanged(nameof(Nb_Poste_IsOk));
                RaisePropertyChanged(nameof(IsOk));
            }
        }

        private string nb_Poste_Error;
        public string Nb_Poste_Error
        {
            get { return nb_Poste_Error; }
            set
            {
                nb_Poste_Error = value;
                RaisePropertyChanged(nameof(Nb_Poste_Error));
            }
        }

        private bool type_Contrat_IsOk;
        public bool Type_Contrat_IsOk
        {
            get { return type_Contrat_IsOk; }
            set
            {
                type_Contrat_IsOk = value;
                RaisePropertyChanged(nameof(Type_Contrat_IsOk));
                RaisePropertyChanged(nameof(IsOk));
            }
        }

        private string type_Contrat_Error;
        public string Type_Contrat_Error
        {
            get { return type_Contrat_Error; }
            set
            {
                type_Contrat_Error = value;
                RaisePropertyChanged(nameof(Type_Contrat_Error));
            }
        }

        private bool adresse_Contrat_IsOk;
        public bool Adresse_Contrat_IsOk
        {
            get { return adresse_Contrat_IsOk; }
            set
            {
                adresse_Contrat_IsOk = value;
                RaisePropertyChanged(nameof(Adresse_Contrat_IsOk));
                RaisePropertyChanged(nameof(IsOk));
            }
        }

        private string adresse_Contrat_Error;
        public string Adresse_Contrat_Error
        {
            get { return adresse_Contrat_Error; }
            set
            {
                adresse_Contrat_Error = value;
                RaisePropertyChanged(nameof(Adresse_Contrat_Error));
            }
        }


        private bool annonceur_IsOk;
        public bool Annonceur_IsOk
        {
            get { return annonceur_IsOk; }
            set
            {
                annonceur_IsOk = value;
                RaisePropertyChanged(nameof(Annonceur_IsOk));
                RaisePropertyChanged(nameof(IsOk));
            }
        }

        private string annonceur_Error;
        public string Annonceur_Error
        {
            get { return annonceur_Error; }
            set
            {
                annonceur_Error = value;
                RaisePropertyChanged(nameof(Annonceur_Error));
            }
        }


        private bool employe_IsOk;
        public bool Employe_IsOk
        {
            get { return employe_IsOk; }
            set
            {
                employe_IsOk = value;
                RaisePropertyChanged(nameof(Employe_IsOk));
                RaisePropertyChanged(nameof(IsOk));
            }
        }

        private string employe_Error;
        public string Employe_Error
        {
            get { return employe_Error; }
            set
            {
                employe_Error = value;
                RaisePropertyChanged(nameof(Employe_Error));
            }
        }


        private bool metier_IsOk;
        public bool Metier_IsOk
        {
            get { return metier_IsOk; }
            set
            {
                metier_IsOk = value;
                RaisePropertyChanged(nameof(Metier_IsOk));
                RaisePropertyChanged(nameof(IsOk));
            }
        }

        private string metier_Error;
        public string Metier_Error
        {
            get { return metier_Error; }
            set
            {
                metier_Error = value;
                RaisePropertyChanged(nameof(Metier_Error));
            }
        }

        #endregion


        public CastingItemWindow windowAssociee;

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

        #region Constructeur(s)

        public CastingItemViewModel(Casting casting, MegaProductionBDDEntities MyDb)
        {
            if (casting == null)
            {
                casting = new Casting();
            }
            this.associated_entity = casting;

            this.Identifiant = casting?.Identifiant ?? 0;
            this.Libelle = casting?.Libelle;
            //Initialisé à des valeurs par défaut car pas récupéré de la bdd
            this.Date_Debut_Publication = casting?.Date_Debut_Publication;
            this.Nb_Jour_Diffusion = casting.Nb_Jour_Diffusion;
            this.Date_Debut_Contrat = casting?.Date_Debut_Contrat;
            this.Nb_Poste = casting?.Nb_Poste;
            this.Description_Poste = casting?.Description_Poste;
            this.Description_Profil = casting?.Description_Profil;
            this.Type_Contrat = casting?.Type_Contrat;
            this.Adresse_Contrat = casting?.Adresse_Contrat;
            this.AnnonceurSelectionne = casting?.Annonceur1;
            this.EmployeSelectionne = casting?.Employe1;
            this.MetierSelectionne = casting?.Metier1;

            this.LstAnnonceurs = MyDb.Annonceur.ToList();
            int nbAnn = MyDb.Annonceur.ToList().Count;
            this.Employes = MyDb.Employe.ToList();
            this.Metiers = MyDb.Metier.ToList();

     
            this.LibelleAnnonceur = casting?.Annonceur1?.Libelle;
            this.EmployeUserName = casting?.Employe1?.Nom_Utilisateur;
            this.LibelleMetier = casting?.Metier1?.Libelle;


            ValiderCommand = new RelayCommand(Valider);
            CancelCommand = new RelayCommand(Annuler);
        }

        #endregion

        #region Funcs

        public Casting ToEntity()
        {
            Casting toReturn = associated_entity;

            toReturn.Libelle = Libelle;
            toReturn.Date_Debut_Publication = Date_Debut_Publication;
            toReturn.Nb_Jour_Diffusion = Nb_Jour_Diffusion;
            toReturn.Date_Debut_Contrat = Date_Debut_Contrat;
            toReturn.Nb_Poste = Nb_Poste;
            toReturn.Description_Poste = Description_Poste;
            toReturn.Description_Profil = Description_Profil;
            toReturn.Type_Contrat = Type_Contrat;
            toReturn.Adresse_Contrat = Adresse_Contrat;
            toReturn.Annonceur1 = AnnonceurSelectionne;
            toReturn.Metier1 = MetierSelectionne;
            toReturn.Employe1 = EmployeSelectionne;

            return toReturn;
        }

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

        #endregion

    }
}
