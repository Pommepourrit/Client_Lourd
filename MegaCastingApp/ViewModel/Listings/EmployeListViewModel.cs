using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MegaCastingApp.ViewModel.Items;
using MegaCastingApp.ViewModel.Listings.Base;
using MegaCastingApp.Windows.Items;
using MegaCastingModel;

namespace MegaCastingApp.ViewModel.Listings
{
    public class EmployeListViewModel : BaseListViewModel<EmployeItemViewModel>
    {
        #region Properties


        #endregion


        #region Constructor(s)
        public EmployeListViewModel() :base()
        {

        }
        #endregion


        #region Functions
        public override void ReloadDatas()
        {
            Items = MyDb.Employe.ToList().Select(x => new EmployeItemViewModel(x, MyDb)).ToList();
        }

        //TODO Attention clé étrangère pas encore gérée
        public override void Add()
        {
            EmployeItemViewModel item = new EmployeItemViewModel(null, MyDb);
            EmployeItemWindow window = new EmployeItemWindow(item);
            window.ShowDialog();

            if(window.DialogResult.HasValue && window.DialogResult == true)
            {
                try
                {
                    Employe toAdd = item.ToEntity();
                    MyDb.Employe.Add(toAdd);
                    MyDb.SaveChanges();
                    ReloadDatas();
                    return;

                }
                catch(Exception e)
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
                EmployeItemViewModel item = Selected;
                EmployeItemWindow window = new EmployeItemWindow(item);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    try
                    {
                        Employe updated = item.ToEntity();
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

        //TODO vérification pour les clés étrangères
        public override void Delete()
        {
            if (Selected != null)
            {
                if(MessageBox.Show("Souhaitez-vous réellement supprimer cet élément ?",
                    "Suppression",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Employe itemToDelete = Selected.ToEntity();
                        MyDb.Employe.Remove(itemToDelete);
                        MyDb.SaveChanges();
                        ReloadDatas();
                        return;

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erreur lors de la sauvegarde des données : " + e.Message);
                    }

                    MyDb = new MegaProductionBDDEntities();

                }
            }
        }


        #endregion
    }
}
