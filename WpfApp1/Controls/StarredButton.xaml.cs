using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Controls
{

    public partial class StarredButton : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty TitleProperty
            = DependencyProperty.Register(nameof(Title), typeof(string), typeof(StarredButton));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }


        public static readonly DependencyProperty FavoriteProperty
            = DependencyProperty.Register(nameof(Favorite), typeof(bool), typeof(StarredButton));

        public bool Favorite
        {
            get => (bool)GetValue(FavoriteProperty);
            set { SetValue(FavoriteProperty, value); }
        }

        public string IconImage
        {
            get => Favorite ? "/Img/star_full.png" : "/Img/star.png";
        }

        public event RoutedEventHandler OnFavoriteClick;
        public event RoutedEventHandler OnClick;

        public event PropertyChangedEventHandler PropertyChanged;

        public StarredButton()
        {
            InitializeComponent();
            favoriteButton1.Click += FavoriteButton1_Click;
        }

        public void RaisePropertyChange([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private void FavoriteButton1_Click(object sender, RoutedEventArgs e)
        {
            Favorite = !Favorite;
            RaisePropertyChange("IconImage");
            OnFavoriteClick?.Invoke(sender, e);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnClick?.Invoke(sender, e);
        }
    }
}
