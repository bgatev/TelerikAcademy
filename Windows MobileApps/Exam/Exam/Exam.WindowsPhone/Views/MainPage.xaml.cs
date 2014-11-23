using Exam.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.Devices.Sensors;
using Windows.Networking.Connectivity;
using Exam.ViewModels;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Exam.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private MediaPlayer _mediaPlayer;

        public MainPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            this.Accelerometer = Accelerometer.GetDefault();
            this.Accelerometer.Shaken += (sender, args) =>
            {
                LoginNow();
            };

            this.Accelerometer.ReadingChanged += (sender, args) =>
            {
                this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var x = args.Reading.AccelerationX;
                    var y = args.Reading.AccelerationY;
                    var z = args.Reading.AccelerationZ;
                });
            };

            //this.DataContext = new AppViewModel();
        }

        public Accelerometer Accelerometer { get; set; }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);

            _mediaPlayer = BackgroundMediaPlayer.Current;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        protected override void OnTapped(TappedRoutedEventArgs e)
        {
            base.OnTapped(e);

            if (animatedImage.Opacity == 0) ShowFrontLogo.Begin();
            else HideFrontLogo.Begin();
        }

        public static bool IsConnected()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            bool isNowConnected = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;

            var networkInformation = NetworkInformation.GetConnectionProfiles();
            if (networkInformation.Count == 0) return false;

            return isNowConnected;
        }

        private void LoginNow()
        {
            


            this.Frame.Navigate(typeof(ServerInfo));
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsConnected())
            {
                PlayAudio();
                LoginNow();
            }

        }

        private void PlayAudio()
        {
            var message = new ValueSet
                    {
                        {
                            "Play",
                            "http://r14---sn-aigllnek.googlevideo.com/videoplayback?upn=ge8_P7SWZfA&itag=140&sparams=clen%2Cdur%2Cgir%2Cid%2Cinitcwndbps%2Cip%2Cipbits%2Citag%2Clmt%2Cmm%2Cms%2Cmv%2Cnh%2Csource%2Cupn%2Cexpire&signature=31546BE0560840EA683035A9A6B9D711662DD0E0.10DDBA1F11866351D7CD6AC5FCC3B7C060C8A7C7&sver=3&source=youtube&ms=au&ipbits=0&mv=m&id=o-AKxhtCUFFMYh4Jg6llU87AY0Swe2VUdMIVVvSJPYvNfE&mm=31&expire=1416710500&clen=2891186&mt=1416688837&dur=180.047&lmt=1415069204140793&ip=146.185.29.13&fexp=900234%2C907259%2C924637%2C927622%2C931987%2C932404%2C936117%2C943909%2C943916%2C947209%2C947215%2C948124%2C952302%2C952605%2C952901%2C953912%2C957103%2C957105%2C957201%2C960800&initcwndbps=2512500&gir=yes&key=yt5&nh=IgpwcjAzLmxocjE0KgkxMjcuMC4wLjE&title=Krisia%2C+Hasan+and+Ibrahim+-+Planet+Of+The+Children+%28Junior+Eurovision+2014%29+-+Official+Video"
                        }
                    };
            BackgroundMediaPlayer.SendMessageToBackground(message);
        }

        #endregion
    }
}
