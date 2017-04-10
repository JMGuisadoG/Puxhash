using MSM.UI.Practices;
using System;
using System.IO;
using CryptoUtils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Win32;
using Puxhash.Practices;

namespace Puxhash.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        #region "Private fields"
        private String _FilePath;
        //private String _Md5;
        //private String _Sha1;
        private string _TextBoxMd5;
        private string _TextBoxSha1;
        #endregion

        #region "Properties"

        public string FilePath
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

        public string Md5
        {
            get
            {
                byte[] bytes = File.ReadAllBytes(FilePath);
                return CryptoStrings.Md5StringOf(bytes);
            }
        }

        public string Sha1
        {
            get
            {
                byte[] bytes = File.ReadAllBytes(FilePath);
                return CryptoStrings.Sha1StringOf(bytes);
            }
        }

        public string TextBoxMd5
        {
            get
            {
                return _TextBoxMd5;
            }
            set
            {
                _TextBoxMd5 = value;
                NotifyPropertyChanged("TextBoxMd5");
                NotifyPropertyChanged("Md5Background");
            }
        }

        public string TextBoxSha1
        {
            get
            {
                return _TextBoxSha1;
            }
            set
            {
                _TextBoxSha1 = value;
                NotifyPropertyChanged("TextBoxSha1");
                NotifyPropertyChanged("Sha1Background");
            }
        }

        public Brush Md5Background
        {
            get
            {
                SolidColorBrush brush;
                if(!String.IsNullOrEmpty(TextBoxMd5))
                {
                    brush = Md5.Equals(TextBoxMd5) ? Brushes.Green : Brushes.PaleVioletRed;
                } else
                {
                    brush = Brushes.Gainsboro;
                }
                return brush;
            }
        }

        public Brush Sha1Background
        {
            get
            {
                SolidColorBrush brush;
                if (!String.IsNullOrEmpty(TextBoxSha1))
                {
                    brush = Sha1.Equals(TextBoxSha1) ? Brushes.Green : Brushes.PaleVioletRed;
                }
                else
                {
                    brush = Brushes.Gainsboro;
                }
                return brush;
            }
        }

        #endregion

        public RelayCommand OpenFileCommand { get; set; }
        private void OpenFileCommand_Executed()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                FilePath = ofd.FileName;
            }
        }

        public MainWindowViewModel()
        {
            OpenFileCommand = new RelayCommand(OpenFileCommand_Executed);
            FilePath = "input.epub";
        }
    }
}
