using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using WP.Core;

namespace GiveAStickWP8.ViewModels
{
    public class ViewModelListPage : ObservableObject
    {
        #region Fields

        #endregion

        #region Properties

        public string GroupTag { get { return (string)PhoneApplicationService.Current.State["GroupTag"]; } }
        public string Nickname { get { return (string)PhoneApplicationService.Current.State["Nickname"]; } }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion
    }
}
