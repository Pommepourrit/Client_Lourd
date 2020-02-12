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
    public class PartenaireDiffusionItemViewModel : ViewModelBase
    {
        #region Properties
        public PartenaireDiffusion associated_entity;
        public PartenaireDiffusionItemWindow windowAssociee;

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


        private string site;

        public string Site
        {
            get { return site; }
            set
            {
                if (site != value)
                {
                    site = value;
                    RaisePropertyChanged("Site");
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
        public PartenaireDiffusionItemViewModel(PartenaireDiffusion partenaire)
        {
            if (partenaire == null)
            {
                partenaire = new PartenaireDiffusion();
            }
            associated_entity = partenaire;

            this.Identifiant = partenaire?.Identifiant ?? 0;
            this.Libelle = partenaire?.Libelle;
            this.Mail = partenaire?.Mail;
            this.Telephone = partenaire?.Telephone;
            this.Nom_Contact = partenaire?.Nom_Contact;
            this.Prenom_Contact = partenaire?.Prenom_Contact;
            this.Mail_Contact = partenaire?.Mail_Contact;
            this.Telephone_Contact = partenaire?.Telephone_Contact;
            this.Adresse = partenaire?.Adresse;
            this.Code_Postal = partenaire?.Code_Postal;
            this.Ville = partenaire?.Ville;
            this.Site = partenaire?.Site;
            this.Nom_Utilisateur = partenaire?.Nom_Utilisateur;
            this.Mot_De_Passe = partenaire?.Mot_De_Passe;

            validerCommand = new RelayCommand(Valider);
            cancelCommand = new RelayCommand(Annuler);


        }

        #endregion


        #region Functions
        public PartenaireDiffusion ToEntity()
        {
            PartenaireDiffusion toReturn = associated_entity;

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
            toReturn.Site = Site;
            toReturn.Nom_Utilisateur = Nom_Utilisateur;
            toReturn.Mot_De_Passe = Mot_De_Passe;

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
