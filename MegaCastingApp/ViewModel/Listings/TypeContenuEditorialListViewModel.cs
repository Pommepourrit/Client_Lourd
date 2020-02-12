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
    public class TypeContenuEditorialListViewModel : BaseListViewModel<TypeContenuEditorialItemViewModel>
    {

        #region Constructor(s)
        public TypeContenuEditorialListViewModel() : base()
        {

        }
        #endregion

        #region Functions

        public override void ReloadDatas()
        {
            Items = MyDb.TypeContenuEditorial.ToList().Select(x => new TypeContenuEditorialItemViewModel(x, MyDb)).ToList();
        }

        public override void Add()
        {
            TypeContenuEditorialItemViewModel itemToAdd = new TypeContenuEditorialItemViewModel(null, MyDb);
            TypeContenuEditorialItemWindow window = new TypeContenuEditorialItemWindow(itemToAdd);
            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                try
                {
                    TypeContenuEditorial toAdd = itemToAdd.ToEntity();
                    MyDb.TypeContenuEditorial.Add(toAdd);
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
                        TypeContenuEditorial toRemove = Selected.ToEntity();
                        MyDb.TypeContenuEditorial.Remove(toRemove);
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
                TypeContenuEditorialItemViewModel itemToUpate = Selected;
                TypeContenuEditorialItemWindow window = new TypeContenuEditorialItemWindow(itemToUpate);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    try
                    {
                        TypeContenuEditorial toUpdate = itemToUpate.ToEntity();
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
