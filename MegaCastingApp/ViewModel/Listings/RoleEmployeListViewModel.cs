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
    public class RoleEmployeListViewModel : BaseListViewModel<RoleEmployeItemViewModel>
    {
        #region Constructor(s)
        public RoleEmployeListViewModel() : base()
        {

        }
        #endregion

        #region Functions

        public override void ReloadDatas()
        {
            Items = MyDb.RoleEmploye.ToList().Select(x => new RoleEmployeItemViewModel(x, MyDb)).ToList();
        }

        public override void Add()
        {
            RoleEmployeItemViewModel itemToAdd = new RoleEmployeItemViewModel(null, MyDb);
            RoleEmployeItemWindow window = new RoleEmployeItemWindow(itemToAdd);
            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                try
                {
                    RoleEmploye toAdd = itemToAdd.ToEntity();
                    MyDb.RoleEmploye.Add(toAdd);
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
                        RoleEmploye toRemove = Selected.ToEntity();
                        MyDb.RoleEmploye.Remove(toRemove);
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
                RoleEmployeItemViewModel itemToUpate = Selected;
                RoleEmployeItemWindow window = new RoleEmployeItemWindow(itemToUpate);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    try
                    {
                        RoleEmploye toUpdate = itemToUpate.ToEntity();
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
