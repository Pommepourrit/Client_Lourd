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
    public class PartenaireDiffusionListViewModel : BaseListViewModel<PartenaireDiffusionItemViewModel>
    {
        #region Contructor(s)
        public PartenaireDiffusionListViewModel () : base()
        {

        }

        #endregion


        #region Functions
        public override void Add()
        {
            PartenaireDiffusionItemViewModel item = new PartenaireDiffusionItemViewModel(null);
            PartenaireDiffusionItemWindow window = new PartenaireDiffusionItemWindow(item);
            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                try
                {
                    PartenaireDiffusion toAdd = item.ToEntity();
                    MyDb.PartenaireDiffusion.Add(toAdd);
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
                PartenaireDiffusionItemViewModel item = Selected;
                PartenaireDiffusionItemWindow window = new PartenaireDiffusionItemWindow(item);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    try
                    {
                        PartenaireDiffusion toUpdate = Selected.ToEntity();
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
                try
                {
                    PartenaireDiffusion toRemove = Selected.ToEntity();
                    MyDb.PartenaireDiffusion.Remove(toRemove);
                    MyDb.SaveChanges();
                    ReloadDatas();
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erreur lors de la sauvegarde des données : " + e.Message);
                }
            }
        }

        public override void ReloadDatas()
        {
            Items = MyDb?.PartenaireDiffusion.ToList().Select(x => new PartenaireDiffusionItemViewModel(x)).ToList();
        }

        #endregion
    }
}
