using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveAStickWP8.ViewModels
{
    public class ViewModelMainPage
    {
        #region Fields

        private string _GroupTag;
        private string _Nickname;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient ou définit le GroupTag de la personne.
        /// </summary>
        public string GroupTag
        {
            get { return _GroupTag; }
            set { Assign(ref _GroupTag, value); OnPropertyChanged(); }
        }

        /// <summary>
        ///     Obtient ou définit le pseudo de l'utilisateur.
        /// </summary>
        public string Nickname
        {
            get { return _Nickname; }
            set { Assign(ref _Nickname, value); OnPropertyChanged(); }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe GiveAStickWP8.ViewModels.ViewModelMainPage.
        /// </summary>
        public ViewModelMainPage()
        {
            
        }

        #endregion

        #region Methods

        #endregion

    }
}
