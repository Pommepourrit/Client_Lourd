using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MegaCastingApp.ViewModel.Items;
using MegaCastingApp.ViewModel.Listings.Base;
using MegaCastingApp.Windows.Items;
using MegaCastingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCastingApp.ViewModel.Listings
{
    public class CastingListViewModel : BaseListViewModel<CastingItemViewModel>
    {

        #region Properties

        #endregion

        #region Constructeur(s)

        public CastingListViewModel() : base()
        {

        }

        #endregion

        #region Funcs

        public override void ReloadDatas()
        {
            Items = MyDb?.Casting
                .ToList()
                .Select(x => new CastingItemViewModel(x, MyDb))
                .ToList();
        }

        public override void Add()
        {
            //Ouverture de la fenêtre d'ajout
            CastingItemViewModel newItem = new CastingItemViewModel(null, MyDb);
            CastingItemWindow window = new CastingItemWindow(newItem);
            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                //On a appuyé sur OK
                //Sauvegarde
                try
                {
                    Casting toAdd = newItem.ToEntity();
                    MyDb.Casting.Add(toAdd);
                    MyDb.SaveChanges();
                    ReloadDatas();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la sauvegarde des données : " + ex.Message);
                }
            }
            //On a appuyé sur annuler ou on a crash dans la sauvegrde de l'item
            MyDb = new MegaProductionBDDEntities();
        }

        public override void Update()
        {
            if (Selected != null)
            {
                //Ouverture de la fenêtre d'ajout
                CastingItemViewModel itemToUpdate = Selected;
                CastingItemWindow window = new CastingItemWindow(itemToUpdate);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    //On a appuyé sur OK
                    //Sauvegarde
                    try
                    {
                        Casting toAdd = itemToUpdate.ToEntity();
                        MyDb.SaveChanges();
                        ReloadDatas();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la sauvegarde des données : " + ex.Message);
                    }
                }
                //On a appuyé sur annuler ou on a crash dans la sauvegrde de l'item
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
                        Casting itemToDelete = Selected.ToEntity();
                        MyDb.Casting.Remove(itemToDelete);
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

