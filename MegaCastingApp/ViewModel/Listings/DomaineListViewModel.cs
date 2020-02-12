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
    public class DomaineListViewModel : BaseListViewModel<DomaineItemViewModel>
    {
        #region Constructor(s)
        public DomaineListViewModel() : base()
        {

        }
        #endregion

        #region Functions

        public override void ReloadDatas()
        {
            Items = MyDb.Domaine.ToList().Select(x => new DomaineItemViewModel(x, MyDb)).ToList();
        }

        public override void Add()
        {
            DomaineItemViewModel itemToAdd = new DomaineItemViewModel(null, MyDb);
            DomaineItemWindow window = new DomaineItemWindow(itemToAdd);
            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                try
                {
                    Domaine toAdd = itemToAdd.ToEntity();
                    MyDb.Domaine.Add(toAdd);
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

        public override void Delete()
        {
            if (Selected != null)
            {
                if (MessageBox.Show("Souhaitez-vous réellement supprimer cet élément ?",
                    "Suppression",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Domaine toRemove = Selected.ToEntity();
                        MyDb.Domaine.Remove(toRemove);
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

        public override void Update()
        {
            if (Selected != null)
            {
                DomaineItemViewModel itemToUpate = Selected;
                DomaineItemWindow window = new DomaineItemWindow(itemToUpate);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    try
                    {
                        Domaine toUpdate = itemToUpate.ToEntity();
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


        #endregion

    }
}
