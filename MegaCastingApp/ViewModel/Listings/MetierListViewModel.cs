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
    public class MetierListViewModel : BaseListViewModel<MetierItemViewModel>
    {
        #region Constructor(s)
        public MetierListViewModel() : base()
        {

        }
        #endregion

        #region Functions

        public override void ReloadDatas()
        {
            Items = MyDb.Metier.ToList().Select(x => new MetierItemViewModel(x, MyDb)).ToList();
        }

        public override void Add()
        {
            MetierItemViewModel itemToAdd = new MetierItemViewModel(null, MyDb);
            MetierItemWindow window = new MetierItemWindow(itemToAdd);
            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                try
                {
                    Metier toAdd = itemToAdd.ToEntity();
                    MyDb.Metier.Add(toAdd);
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
                        Metier toRemove = Selected.ToEntity();
                        MyDb.Metier.Remove(toRemove);
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
                MetierItemViewModel itemToUpate = Selected;
                MetierItemWindow window = new MetierItemWindow(itemToUpate);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    try
                    {
                        Metier toUpdate = itemToUpate.ToEntity();
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
