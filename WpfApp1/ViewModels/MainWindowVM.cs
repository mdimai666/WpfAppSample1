using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {

        ObservableCollection<PostItem> _posts;

        public ObservableCollection<PostItem> Posts
        {
            get => _posts;
            set { _posts = value; RaisePropertyChange("Posts"); }
        }


    }
}
