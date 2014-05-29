using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using WP.Core;
using System.Data.Linq;

namespace GiveAStickWP8.Model
{
    [Table]
    public class List : ObservableObject
    {
        #region Fields

        private string _GroupTag;
        private string _Nickname;

        #endregion

        #region Properties

        [Column(DbType = "NVarChar(140) NOT NULL", CanBeNull = false)]
        public string GroupTag
        {
            get { return _GroupTag; }
            set { Assign(ref _GroupTag, value); }
        }

        [Column(DbType = "NVarChar(140) NOT NULL", CanBeNull = false)]
        public string Nickname
        {
            get { return _Nickname; }
            set { Assign(ref _Nickname, value); }
        }

        #endregion
    }
}
