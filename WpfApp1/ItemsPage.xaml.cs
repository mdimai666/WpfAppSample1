using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ToastNotifications;
using ToastNotifications.Messages;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ItemsPage.xaml
    /// </summary>
    public partial class ItemsPage : Page
    {

        MainWindowVM viewModel;
        Notifier notifier;
        public ItemsPage()
        {
            notifier = (App.Current as App).notifier;
            InitializeComponent();
            DataContext = viewModel = new MainWindowVM();
            viewModel.Posts = new ObservableCollection<PostItem>(PostItem.GenerateRandomList(5).ToList());

            //Content.NavigationService.Navigate(new Page1());

            //Content = new Page1();
        }

        public void TestNotify(string text)
        {
            Random r = new Random();
            notifier.ShowInformation($"T {r.Next(100)} i {text}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Posts.Add(PostItem.GenerateRandomList(1).First());
            TestNotify("Add");
        }

        private void OnfavoriteClick(object sender, RoutedEventArgs e)
        {
            PostItem postItem = (sender as Button).DataContext as PostItem;
            //postItem.Favorite = !postItem.Favorite;
            //TestNotify($"{postItem.Title} {postItem.Favorite}");
        }

        private void listView1_Selected(object sender, RoutedEventArgs e)
        {
            PostItem post = (sender as Grid).DataContext as PostItem;

            //this.win
            App.Navigate(new Page1(post));
        }
    }
}
