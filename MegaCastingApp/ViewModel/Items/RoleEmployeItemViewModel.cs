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
    public class RoleEmployeItemViewModel : ViewModelBase
    {
            #region Properties

            #region Entities

            public RoleEmploye associated_entity;

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


            #endregion

            #region Vue

            #region Verifications

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



            #endregion

            public RoleEmployeItemWindow windowAssociee;

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

            public RoleEmployeItemViewModel(RoleEmploye roleEmploye, MegaProductionBDDEntities MyDb)
            {
                if (roleEmploye == null)
                {
                    roleEmploye = new RoleEmploye();
                }

                this.associated_entity = roleEmploye;

                this.Identifiant = roleEmploye?.Identifiant ?? 0;
                this.Libelle = roleEmploye?.Libelle;

                ValiderCommand = new RelayCommand(Valider);
                CancelCommand = new RelayCommand(Annuler);
            }
            #endregion


            #region Functions

            public RoleEmploye ToEntity()
            {
                RoleEmploye toReturn = associated_entity;

                toReturn.Libelle = Libelle;

                return toReturn;
            }

            private void Valider()
            {
                if (windowAssociee != null && Libelle_IsOk)
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
