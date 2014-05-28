using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using WP.Core;

namespace GiveAStickWP8.ViewModels
{
    public class ViewModelMainPage : ObservableObject
    {
        #region Fields

        private string _GroupTag;
        private string _Nickname;

        private DelegateCommand _GoToListCommand;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient ou définit le GroupTag de l'utilisateur.
        /// </summary>
        public string GroupTag
        {
            get { return _GroupTag; }
            set { _GroupTag = value; OnPropertyChanged(); this._GoToListCommand.OnCanExecuteChanged(); }
        }

        /// <summary>
        ///     Obtient ou définit le pseudo de l'utilisateur.
        /// </summary>
        public string Nickname
        {
            get { return _Nickname; }
            set { _Nickname = value; OnPropertyChanged(); this._GoToListCommand.OnCanExecuteChanged(); }
        }

        /// <summary>
        ///     Obtient ou définit la commande pour accèder à la liste.
        /// </summary>
        public DelegateCommand GoToListCommand
        {
            get { return _GoToListCommand; }
            set { _GoToListCommand = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe GiveAStickWP8.ViewModels.ViewModelMainPage.
        /// </summary>
        public ViewModelMainPage()
        {
            _GoToListCommand = new DelegateCommand(ExecuteGoToListCommand, CanExecuteGoToListCommand);
        }

        #endregion

        #region Methods

        private void ExecuteGoToListCommand(object arg)
        {
            Uri u = new Uri("/ListPage.xaml", UriKind.Relative);
            App.RootFrame.Navigate(u);
        }

        private bool CanExecuteGoToListCommand(object arg)
        {
            return !string.IsNullOrWhiteSpace(GroupTag) && !string.IsNullOrWhiteSpace(Nickname);
        }

        #endregion

    }
}
