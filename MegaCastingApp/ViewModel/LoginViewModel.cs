using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MegaCastingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCastingApp.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields
        private LoginWindow windowAssociee;
        public Employe employeAConnecter;
        #endregion

        #region Properties
        private RelayCommand annulerCommand;

        public RelayCommand AnnulerCommand
        {
            get { return annulerCommand; }
            set
            {
                annulerCommand = value;
                RaisePropertyChanged("AnnulerCommand");
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

        private string nom_Utilisateur;

        public string Nom_Utilisateur
        {
            get { return nom_Utilisateur; }
            set
            {
                nom_Utilisateur = value;
                RaisePropertyChanged("Nom_Utilisateur");
            }
        }

        private string mot_De_Passe;

        public string Mot_De_Passe
        {
            get { return mot_De_Passe; }
            set
            {
                mot_De_Passe = value;
                RaisePropertyChanged("Mot_De_Passe");
            }
        }


        #endregion

        #region Constructeur
        public LoginViewModel(LoginWindow _windowAssociee)
        {
            windowAssociee = _windowAssociee;
            this.ValiderCommand = new RelayCommand(() => Valider());
            this.AnnulerCommand = new RelayCommand(() => Annuler());
        }
        #endregion

        #region Functions
        private void Valider()
        {
            //hash le mot de passe avec SHA512 pour le comparer à la bdd 
            SHA512 shaM = new SHA512Managed();
            byte[] passwordHashed = shaM.ComputeHash(stringToByte(Mot_De_Passe));

            string passe = Encoding.UTF8.GetString(passwordHashed);

            //Verifier utilisateur
            MegaProductionBDDEntities MyDB = new MegaProductionBDDEntities();
            if (MyDB.Employe.Any(x =>
                                x.Nom_Utilisateur == Nom_Utilisateur &&
                                x.Mot_De_Passe == passe))
            {
                employeAConnecter = MyDB.Employe.First(x =>
                                x.Nom_Utilisateur == Nom_Utilisateur &&
                                x.Mot_De_Passe == passe);
                windowAssociee.Close();
            }
            else
            {
                MessageBox.Show("Mauvaise combinaison utilisateur / mdp");
            }
        }

        private void Annuler()
        {
            windowAssociee.Close();
        }

        /// <summary>
        /// Converti une chaine de caractère en tableau de bytes
        /// </summary>
        /// <param name="toConvert"> chaîne de caractère à convertir</param>
        /// <returns>bytes array</returns>
        private byte[] stringToByte (string toConvert)
        {
            byte[] converted = Encoding.UTF8.GetBytes(toConvert);
            return converted;
        }
        #endregion



    }
}
