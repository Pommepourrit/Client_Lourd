using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MegaCastingApp.ViewModel.Items;
using MegaCastingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingApp.ViewModel.Listings.Base
{
    public class BaseListViewModel<T> : ViewModelBase
    {

        #region Properties

        private MegaProductionBDDEntities myDb;
        public MegaProductionBDDEntities MyDb
        {
            get
            {
                return myDb;
            }
            set
            {
                myDb = value;
                //Recharger mes données
                ReloadDatas();
                RaisePropertyChanged("MyDb");
            }
        }

        private List<T> items;
        public List<T> Items
        {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    RaisePropertyChanged("Items");
                }
            }
        }

        private T selected;
        public T Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                RaisePropertyChanged("Selected");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get { return addCommand; }
            set
            {
                addCommand = value;
                RaisePropertyChanged("AddCommand");
            }
        }

        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
            set
            {
                updateCommand = value;
                RaisePropertyChanged("UpdateCommand");
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                deleteCommand = value;
                RaisePropertyChanged("DeleteCommand");
            }
        }

        #endregion

        #region Constructeur

        public BaseListViewModel()
        {
            MyDb = new MegaProductionBDDEntities();
            this.AddCommand = new RelayCommand(Add);
            this.UpdateCommand = new RelayCommand(Update);
            this.DeleteCommand = new RelayCommand(Delete);
        }

        #endregion

        #region Funcs

        public virtual void ReloadDatas()
        {
            throw new NotImplementedException("Vous n'avez pas overridé la fonction ReloadDatas");
        }

        public virtual void Add()
        {
            throw new NotImplementedException("Vous n'avez pas overridé la fonction Add");
        }

        public virtual void Update()
        {
            throw new NotImplementedException("Vous n'avez pas overridé la fonction Update");
        }

        public virtual void Delete()
        {
            throw new NotImplementedException("Vous n'avez pas overridé la fonction Delete");
        }

        #endregion

    }
}

