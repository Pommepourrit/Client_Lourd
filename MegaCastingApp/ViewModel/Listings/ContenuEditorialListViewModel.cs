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
    public class ContenuEditorialListViewModel : BaseListViewModel<ContenuEditorialItemViewModel>
    {
        #region Constructor(s)
        public ContenuEditorialListViewModel() : base()
        {

        }
        #endregion


        #region Functions

        public override void ReloadDatas()
        {
            Items = MyDb.ContenuEditorial.ToList().Select(x => new ContenuEditorialItemViewModel(x, MyDb)).ToList();
        }


        public override void Add()
        {
            ContenuEditorialItemViewModel itemToAdd = new ContenuEditorialItemViewModel(null, MyDb);
            ContenuEditorialItemWindow window = new ContenuEditorialItemWindow(itemToAdd);
            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                try
                {
                    ContenuEditorial toAdd = itemToAdd.ToEntity();
                    MyDb.ContenuEditorial.Add(toAdd);
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
                ContenuEditorialItemViewModel itemToUpate = Selected;
                ContenuEditorialItemWindow window = new ContenuEditorialItemWindow(itemToUpate);
                window.ShowDialog();

                if(window.DialogResult.HasValue && window.DialogResult == true)
                {
                    try
                    {
                        ContenuEditorial toUpdate = itemToUpate.ToEntity();
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

        //TODO gestion des clés étrangères
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
                        ContenuEditorial toRemove = Selected.ToEntity();
                        MyDb.ContenuEditorial.Remove(toRemove);
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
        }
        #endregion
    }
}
