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
    public class AnnonceurItemViewModel : ViewModelBase
    {
        #region Properties

        public Annonceur associated_entity;

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

            }
        }


        private string telephone;

        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (telephone != value)
                {
                    telephone = value;
                    RaisePropertyChanged("Telephone");
                }

            }
        }


        private string nom_Contact;

        public string Nom_Contact
        {
            get { return nom_Contact; }
            set
            {
                if (nom_Contact != value)
                {
                    nom_Contact = value;
                    RaisePropertyChanged("Nom_Contact");
                }

            }
        }


        private string prenom_Contact;

        public string Prenom_Contact
        {
            get { return prenom_Contact; }
            set
            {
                if (prenom_Contact != value)
                {
                    prenom_Contact = value;
                    RaisePropertyChanged("Prenom_Contact");
                }

            }
        }


        private string mail_Contact;

        public string Mail_Contact
        {
            get { return mail_Contact; }
            set
            {
                if (mail_Contact != value)
                {
                    mail_Contact = value;
                    RaisePropertyChanged("Mail_Contact");
                }

            }
        }


        private string telephone_Contact;

        public string Telephone_Contact
        {
            get { return telephone_Contact; }
            set
            {
                if (telephone_Contact != value)
                {
                    telephone_Contact = value;
                    RaisePropertyChanged("Telephone_Contact");
                }

            }
        }


        private string adresse;

        public string Adresse
        {
            get { return adresse; }
            set
            {
                if (adresse != value)
                {
                    adresse = value;
                    RaisePropertyChanged("Adresse");
                }

            }
        }


        private string code_Postal;

        public string Code_Postal
        {
            get { return code_Postal; }
            set
            {
                if (code_Postal != value)
                {
                    code_Postal = value;
                    RaisePropertyChanged("Code_Postal");
                }

            }
        }


        private string ville;

        public string Ville
        {
            get { return ville; }
            set
            {
                if (ville != value)
                {
                    ville = value;
                    RaisePropertyChanged("Ville");
                }

            }
        }


        public AnnonceurItemWindow windowAssociee;


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



        #endregion


        #region Constructor(s)

        public AnnonceurItemViewModel(Annonceur annonceur)
        {
            if (annonceur == null)
            {
                annonceur = new Annonceur();
            }
            this.associated_entity = annonceur;

            this.Identifiant = annonceur?.Identifiant ?? 0;
            this.Libelle = annonceur?.Libelle;
            this.Mail = annonceur?.Mail;
            this.Telephone = annonceur?.Telephone;
            this.Nom_Contact = annonceur?.Nom_Contact;
            this.Prenom_Contact = annonceur?.Prenom_Contact;
            this.Mail_Contact = annonceur?.Mail_Contact;
            this.Telephone_Contact = annonceur?.Telephone_Contact;
            this.Adresse = annonceur?.Adresse;
            this.Code_Postal = annonceur?.Code_Postal;
            this.Ville = annonceur?.Ville;

            ValiderCommand = new RelayCommand(Valider);
            CancelCommand = new RelayCommand(Cancel);
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


        private void Cancel()
        {
            if (windowAssociee != null)
            {
                windowAssociee.DialogResult = false;
                windowAssociee.Close();
            }
        }

        public Annonceur ToEntity()
        {
            Annonceur toReturn = associated_entity;

            toReturn.Libelle = Libelle;
            toReturn.Mail = Mail;
            toReturn.Telephone = Telephone;
            toReturn.Nom_Contact = Nom_Contact;
            toReturn.Prenom_Contact = Prenom_Contact;
            toReturn.Mail_Contact = Mail_Contact;
            toReturn.Telephone_Contact = Telephone_Contact;
            toReturn.Adresse = Adresse;
            toReturn.Code_Postal = Code_Postal;
            toReturn.Ville = Ville;

            return toReturn;

        }


        #endregion


    }
}
