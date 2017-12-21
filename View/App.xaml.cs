using System;
using System.Windows;
using System.Windows.Media;
using Model.ModelStarters;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MediaPlayer BackgroundSong=new MediaPlayer();
        public App()
        {
            BaseModelStarter model;
#if RELEASE
           model=AdminModelStarter.GetModel();
#else
           model = RealModelStarter.GetModel();
#endif
            var window = new MainWindow();
            ViewModel.MainViewModel viewModel = new MainViewModel(model.MyPlayer);

            model.MyPlayer.AttachListener(viewModel.Pet);
            model.MyPlayer.AttachListener(viewModel.Inventory);
            
            window.DataContext = viewModel;
            window.Show();
           
            BackgroundSong.Open(new Uri(@"..\..\Audio\background2.mp3", UriKind.Relative));
           // BackgroundSong.Play();
        }
    }
}
