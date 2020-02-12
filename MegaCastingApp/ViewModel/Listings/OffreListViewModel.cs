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
    public class OffreListViewModel : BaseListViewModel<OffreItemViewModel>
    {

        #region Constructor(s)
        public OffreListViewModel() : base()
        {
            
        }
        #endregion


        #region Functions
        public override void Add()
        {
            OffreItemViewModel item = new OffreItemViewModel(null);
            OffreItemWindow window = new OffreItemWindow(item);
            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                try
                {
                    Offre toAdd = item.ToEntity();
                    MyDb.Offre.Add(toAdd);
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
                OffreItemViewModel item = Selected;
                OffreItemWindow window = new OffreItemWindow(item);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    try
                    {
                        Offre toUpdate = Selected.ToEntity();
                        MyDb.SaveChanges();
                        ReloadDatas();
                        return;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erreur lors de la sauvegarde : " + e.Message );
                    }
                }
                MyDb = new MegaProductionBDDEntities();
            }
            
        }

        public override void Delete()
        {
            if (Selected != null)
            {
                if(MessageBox.Show("Voulez-vous réellement supprimer cet élément ? ",
                    "Suppression",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question)==MessageBoxResult.Yes)
                {
                    try
                    {
                        Offre toRemove = Selected.ToEntity();
                        MyDb.Offre.Remove(toRemove);
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

        public override void ReloadDatas()
        {
            Items = MyDb.Offre?.ToList().Select(x => new OffreItemViewModel(x)).ToList();
        }

        #endregion
    }
}
