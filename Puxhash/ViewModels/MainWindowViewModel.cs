using CryptoUtils;
using MSM.UI.Practices;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puxhash.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        #region "Private fields"
        private String _FilePath;
        //private String _Md5;
        //private String _Sha1;
        #endregion

        #region "Properties"

        public String FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
                NotifyPropertyChanged("FilePath");
                NotifyPropertyChanged("Md5");
                NotifyPropertyChanged("Sha1");
            }
        }

        public String Md5
        {
            get
            {
                byte[] bytes = File.ReadAllBytes(FilePath);
                return CryptoUtils.CryptoUtils.Md5StringOf(bytes);
            }
        }

        public String Sha1
        {
            get
            {
                byte[] bytes = File.ReadAllBytes(FilePath);
                return CryptoUtils.CryptoUtils.Sha1StringOf(bytes);
            }
        }

        #endregion

        public MainWindowViewModel()
        {
            FilePath = "input.epub";
        }
    }
}
