using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WP.Core;

namespace GiveAStickWP8.ViewModels
{
    public class ViewModelListPage : ObservableObject
    {
        #region Fields

        private string _GroupTag = (string)PhoneApplicationService.Current.State["GroupTag"];
        private string _Nickname = (string)PhoneApplicationService.Current.State["Nickname"];
        private long _StickCount = 50;

        private DelegateCommand _AddStickCommand;
        private DelegateCommand _SelectedContact;

        #endregion

        #region Properties

        public DelegateCommand SelectedContact
        {
            get { return _SelectedContact; }
        }

        public string GroupTag 
        {
            get { return _GroupTag; }
        }
        public string Nickname 
        {
            get { return _Nickname; }
        }

        public long StickCount
        {
            get { return _StickCount; }
            set
            {
                if (_StickCount != value) //Si la valeur que l'on souhaite affecté est différente de la valeur actuelle.
                {
                    _StickCount = value; //On modifie le champ privé.
                    OnPropertyChanged();//On déclenche le OnPropertyChanged pour la mise à jour de l'UI via le Binding.
                }
            }
        }

        public DelegateCommand AddStickCommand
        {
            get { return _AddStickCommand; }
            set { _AddStickCommand = value; }
        }

        #endregion

        #region Constructors

        public ViewModelListPage()
        {
            _SelectedContact = new DelegateCommand(ExecuteSelectedContact, CanExecuteSelectContact);
        }

        #endregion

        #region Methods     

        private bool CanExecuteSelectContact(object parameters)
        {
            return true;
        }

        private void ExecuteSelectedContact(object parameters)
        {
            try
            {
                if (MessageBoxResult.OK == MessageBox.Show("Êtes-vous sûr de vouloir donner un batton à " + Nickname + " ?", "Donner", MessageBoxButton.OKCancel))
                {
                    StickCount ++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur d'ajout du batton.");
            }
        }

        // Cette méthode ne fonctionne pas
        private void ExecuteAddStick(object parameters)
        {
            try
            {
                if (MessageBoxResult.OK == MessageBox.Show("Êtes-vous sûr de vouloir donner un batton à " + Nickname + " ?", "Donner", MessageBoxButton.OKCancel))
                {
                    StickCount += StickCount;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur d'ajout du batton.");
            }
        }

        // Cette méthode ne fonctionne pas
        private bool CanExecuteAddStick(object parameters)
        {
            return true;
        }

        #endregion
    }
}
