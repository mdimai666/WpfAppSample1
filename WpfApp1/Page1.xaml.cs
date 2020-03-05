using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        Page1ViewModel viewModel;

        public Page1(PostItem post = null)
        {
            InitializeComponent();

            DataContext = viewModel = new Page1ViewModel();

            if (post == null)
                viewModel.Item = PostItem.GenerateRandomList(1).First();
            else
                viewModel.Item = post;
        }

        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.GoBack();
        }

        private void ClickFavorite2(object sender, RoutedEventArgs e)
        {
            PostItem post = (sender as Button).DataContext as PostItem;


        }
    }
}
