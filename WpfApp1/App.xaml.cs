using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using System.Windows.Navigation;

namespace WpfApp1
{
    public partial class App : Application
    {
        public Notifier notifier;

        public MainWindow win;

        public App()
        {

            Notifier notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.TopRight,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });

            this.notifier = notifier;


        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


        }

        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            base.OnLoadCompleted(e);
            this.win = (this.MainWindow as MainWindow);
        }

        public static bool Navigate(Uri source)
        {
            return (App.Current as App).win.mainFrame.Navigate(source);
        }
        public static bool Navigate(Uri source, object extraData)
        {
            return (App.Current as App).win.mainFrame.Navigate(source, extraData);
        }
        public static bool Navigate(object content)
        {
            return (App.Current as App).win.mainFrame.Navigate(content);
        }
        public static bool Navigate(object content, object extraData)
        {
            return (App.Current as App).win.mainFrame.Navigate(content, extraData);
        }

        public static bool GoBack()
        {
            var f = (App.Current as App).win.mainFrame;

            if (f.CanGoBack)
            {
                f.GoBack();
                return true;
            }
            else return false;
        }
        public static bool CanGoBack()
        {
            return (App.Current as App).win.mainFrame.CanGoBack;
        }

    }
}
