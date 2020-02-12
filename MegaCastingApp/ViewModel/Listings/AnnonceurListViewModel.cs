using MegaCastingApp.ViewModel.Items;
using MegaCastingApp.ViewModel.Listings.Base;
using MegaCastingApp.Windows.Items;
using MegaCastingModel;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingApp.ViewModel.Listings
{
    public class AnnonceurListViewModel : BaseListViewModel<AnnonceurItemViewModel>
    {
        #region Properties



        #endregion


        #region Constructor(s)
        public AnnonceurListViewModel() : base()
        {

        }

        #endregion


        #region Functions
        public override void ReloadDatas()
        {
            Items = MyDb?.Annonceur
                .ToList()
                .Select(x => new AnnonceurItemViewModel(x))
                .ToList();
        }

        public override void Add()
        {
            AnnonceurItemViewModel newItem = new AnnonceurItemViewModel(null);
            AnnonceurItemWindow window = new AnnonceurItemWindow(newItem);
            window.ShowDialog();

            if(window.DialogResult.HasValue && window.DialogResult == true)
            {
                try
                {
                    Annonceur toAdd = newItem.ToEntity();
                    MyDb.Annonceur.Add(toAdd);
                    MyDb.SaveChanges();
                    ReloadDatas();
                    return;

                }
                catch (Exception e)
                {
                    MessageBox.Show("Erreur lors de la sauvegarde des données : " + e.Message);
                }
            }


            MyDb = new MegaProductionBDDEntities();

        }


        public override void Update()
        {
            if (Selected != null)
            {
                AnnonceurItemViewModel itemToUpdate = Selected;
                AnnonceurItemWindow window = new AnnonceurItemWindow(itemToUpdate);
                window.ShowDialog();

                if(window.DialogResult.HasValue && window.DialogResult == true)
                {
                    try
                    {
                        Annonceur toAdd = itemToUpdate.ToEntity();
                        MyDb.SaveChanges();
                        ReloadDatas();
                        return;


                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erreur lors de la sauvegarde des données : " + e.Message);
                    }
                }

                MyDb = new MegaProductionBDDEntities();

            }
        }


        public override void Delete()
        {
            if (Selected != null)
            {
                if (MessageBox.Show("Souhaitez-vous rééllement supprimer cet élément ?",
                    "Suppresion",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Annonceur itemToDelete = Selected.ToEntity();
                        /*if (itemToDelete.Employe_Createur.Any())
                        {
                            MessageBox.Show("Suppression impossible car il y a un employe associé");
                            return;
                        }
                        if (itemToDelete.Metier.Any())
                        {
                            MessageBox.Show("Suppression impossible car il existe un métier associé");
                            return;
                        }
                        if (itemToDelete.Annonceur.Any())
                        {
                            MessageBox.Show("Suppression impossible car il existe des annonceurs associés");
                            return;
                        }*/
                        MyDb.Annonceur.Remove(itemToDelete);
                        MyDb.SaveChanges();
                        ReloadDatas();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la sauvegarde des données : " + ex.Message);
                    }
                    //Erreur à la suppression
                    MyDb = new MegaProductionBDDEntities();
                }
            }
        }


        #endregion
    }
}
