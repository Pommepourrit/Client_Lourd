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
    /*
     * Pour la table Employe tous les champs sont obligatoires
     * **/
    public class EmployeItemViewModel : ViewModelBase
    {
        //TODO faire les vérifications
        #region Properties

        public Employe associated_entity;

        #region Entities

        #region Foreign Key(s)
        //LibelleRole
        private string libelleRole;

        public string LibelleRole
        {
            get { return libelleRole; }
            set
            {
                if (libelleRole != value)
                {
                    libelleRole = value;
                    RaisePropertyChanged("LibelleRole");
                }
                //Fonctionne pas sur ComboBox
                if (string.IsNullOrWhiteSpace(LibelleRole))
                {
                    LibelleRole_IsOk = false;
                    LibelleRole_Error = "Merci de renseigner ce champ";
                }
                else if (LibelleRole.Length > 255)
                {
                    LibelleRole_IsOk = false;
                    LibelleRole_Error = "Ce champs ne doit pas dépasser 255 charactère (actuellement "
                        + LibelleRole.Length
                        + " )";
                }
                else
                {
                    LibelleRole_IsOk = true;
                    LibelleRole_Error = string.Empty;
                }
            }
        }

        private RoleEmploye roleSelectionne;

        public RoleEmploye RoleSelectionne
        {
            get { return roleSelectionne; }
            set
            {
                if (roleSelectionne != value)
                {
                    roleSelectionne = value;
                    RaisePropertyChanged("RoleSelectionne");
                }
            }
        }

        private List<RoleEmploye> lstRoles;

        public List<RoleEmploye> LstRoles
        {
            get { return lstRoles; }
            set
            {
                if (lstRoles != value)
                {
                    lstRoles = value;
                    RaisePropertyChanged("LstRoles");
                }

                if (string.IsNullOrWhiteSpace(LibelleRole))
                {
                    LibelleRole_IsOk = false;
                    LibelleRole_Error = "Merci de renseigner ce champ";
                }
                else if (LibelleRole.Length > 255)
                {
                    LibelleRole_IsOk = false;
                    LibelleRole_Error = "Ce champs ne doit pas dépasser 255 charactère (actuellement "
                        + LibelleRole.Length
                        + " )";
                }
                else
                {
                    LibelleRole_IsOk = true;
                    LibelleRole_Error = string.Empty;
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

        private string nom;
        public string Nom
        {
            get { return nom; }
            set
            {
                if (nom != value)
                {
                    nom = value;
                    RaisePropertyChanged("Nom");
                }

            }
        }

        private string prenom;
        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (prenom != value)
                {
                    prenom = value;
                    RaisePropertyChanged("Prenom");
                }

            }
        }

        private string mail;
        public string Mail
        {
            get { return mail; }
            set
            {
                if (mail != value)
                {
                    mail = value;
                    RaisePropertyChanged("Mail");
                }

                if (String.IsNullOrWhiteSpace(mail))
                {

                }
                

            }
        }

        private string nom_Utilisateur;
        public string Nom_Utilisateur
        {
            get { return nom_Utilisateur; }
            set
            {
                if (nom_Utilisateur != value)
                {
                    nom_Utilisateur = value;
                    RaisePropertyChanged("Nom_Utilisateur");
                }

            }
        }

        private string mot_De_Passe;
        public string Mot_De_Passe
        {
            get { return mot_De_Passe; }
            set
            {
                if (mot_De_Passe != value)
                {
                    mot_De_Passe = value;
                    RaisePropertyChanged("Mot_De_Passe");
                }

            }
        }


        #endregion


        #region Verification

        public bool IsOk
        {
            get
            {
                return LibelleRole_IsOk && Nom_IsOk && Prenom_IsOk && Mail_IsOk && Nom_Utilisateur_IsOk && Mot_De_Passe_IsOk;
            }
        }


        private bool libelleRole_IsOk;

        public bool LibelleRole_IsOk
        {
            get { return libelleRole_IsOk; }
            set
            {
                libelleRole_IsOk = value;
                RaisePropertyChanged("LibelleRole_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string libelleRole_Error;

        public string LibelleRole_Error
        {
            get { return libelleRole_Error; }
            set
            {
                libelleRole_Error = value;
                RaisePropertyChanged("LibelleRole_Error");
            }
        }



        private bool nom_IsOk;

        public bool Nom_IsOk
        {
            get { return nom_IsOk; }
            set
            {
                nom_IsOk = value;
                RaisePropertyChanged("Nom_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string nom_Error;

        public string Nom_Error
        {
            get { return nom_Error; }
            set
            {
                nom_Error = value;
                RaisePropertyChanged("Nom_Error");
            }
        }


        private bool prenom_IsOk;

        public bool Prenom_IsOk
        {
            get { return prenom_IsOk; }
            set
            {
                prenom_IsOk = value;
                RaisePropertyChanged("Prenom_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string prenom_Error;

        public string Prenom_Error
        {
            get { return prenom_Error; }
            set
            {
                prenom_Error = value;
                RaisePropertyChanged("Prenom_Error");
            }
        }


        private bool mail_IsOk;

        public bool Mail_IsOk
        {
            get { return mail_IsOk; }
            set
            {
                mail_IsOk = value;
                RaisePropertyChanged("Mail_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string mail_Error;

        public string Mail_Error
        {
            get { return mail_Error; }
            set
            {
                mail_Error = value;
                RaisePropertyChanged("Mail_Error");
            }
        }


        private bool nom_Utilisateur_IsOk;

        public bool Nom_Utilisateur_IsOk
        {
            get { return nom_Utilisateur_IsOk; }
            set
            {
                nom_Utilisateur_IsOk = value;
                RaisePropertyChanged("Nom_Utilisateur_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string nom_Utilisateur_Error;

        public string Nom_Utilisateur_Error
        {
            get { return nom_Utilisateur_Error; }
            set
            {
                nom_Utilisateur_Error = value;
                RaisePropertyChanged("Nom_Utilisateur_Error");
            }
        }


        private bool mot_De_Passe_IsOk;

        public bool Mot_De_Passe_IsOk
        {
            get { return mot_De_Passe_IsOk; }
            set
            {
                mot_De_Passe_IsOk = value;
                RaisePropertyChanged("Mot_De_Passe_IsOk");
                RaisePropertyChanged("IsOk");
            }
        }

        private string mot_De_Passe_Error;

        public string Mot_De_Passe_Error
        {
            get { return mot_De_Passe_Error; }
            set
            {
                mot_De_Passe_Error = value;
                RaisePropertyChanged("Mot_De_Passe_Error");
            }
        }

        #endregion

        public EmployeItemWindow windowAssociee;

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
        public EmployeItemViewModel(Employe employe, MegaProductionBDDEntities DB)
        {
            if (employe == null)
            {
                employe = new Employe();
            }
            this.associated_entity = employe;

            this.Identifiant = employe?.Identifiant ?? 0;
            this.Nom = employe?.Nom;
            this.Prenom = employe?.Prenom;
            this.Mail = employe?.Mail;
            this.Nom_Utilisateur = employe?.Nom_Utilisateur;
            this.Mot_De_Passe = employe?.Mot_De_Passe;
            this.RoleSelectionne = employe?.RoleEmploye;

            this.LstRoles = DB.RoleEmploye.ToList();
            this.LibelleRole = employe?.RoleEmploye?.Libelle;

            ValiderCommand = new RelayCommand(Valider);
            CancelCommand = new RelayCommand(Annuler);
        }

        #endregion


        #region Functions
        private void Valider()
        {
            //TODO ajouter le booleen IsOK
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

        public Employe ToEntity()
        {
            Employe toReturn = associated_entity;
            toReturn.RoleEmploye = RoleSelectionne;
            toReturn.Nom = Nom;
            toReturn.Prenom = Prenom;
            toReturn.Mail = Mail;
            toReturn.Nom_Utilisateur = Nom_Utilisateur;
            toReturn.Mot_De_Passe = Mot_De_Passe;

            return toReturn;
        }


        #endregion

    }
}
