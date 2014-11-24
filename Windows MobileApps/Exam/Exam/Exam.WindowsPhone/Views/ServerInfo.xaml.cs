using Exam.Common;
using Exam.Models;
using Exam.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Exam.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ServerInfo : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private const string dbName = "ServersLocal.db";

        public List<ServerLocal> ServersLocal { get; set; }

        public ServerInfo()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            this.DataContext = new AppViewModel();
        }

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
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);

            if (e.Parameter != null) this.LocationTb.Text = e.Parameter.ToString();

            // Create Db if not exist
            /*bool dbExists = await CheckDbAsync(dbName);
            if (!dbExists)
            {
                await CreateDatabaseAsync();
                await AddServersAsync();
            }

            // Get Articles
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            var query = conn.Table<ServerLocal>();
            ServersLocal = await query.ToListAsync();*/

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        protected override void OnDoubleTapped(DoubleTappedRoutedEventArgs e)
        {
            base.OnDoubleTapped(e);
            LocationBtn_Click(this, e);
        }
        #endregion

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SynchronizeBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateServerDescriptionAsync(this.HostnameTb.Text, this.DescriptionTb.Text);
        }

        private void PictureBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ServerImage));
        }

        private void LocationBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ServerLocation));
        }

        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.CreateTableAsync<ServerLocal>();
        }

        private async Task AddServersAsync()
        {
            var allServers = (this.DataContext as AppViewModel).Servers;
            var list = new List<ServerLocal>();
            foreach (var item in allServers)
            {
                list.Add(new ServerLocal() 
                {
                    HostName = item.HostName,
                    IPAddress = item.IPAddress,
                    Description = item.Description,
                    Location = item.Location
                });  
            }

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.InsertAllAsync(list);
        }

        private async Task UpdateServerDescriptionAsync(string hostname, string newDescription)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            var currentServer = await conn.Table<ServerLocal>().Where(x => x.HostName == hostname).FirstOrDefaultAsync();
            if (currentServer != null)
            {
                currentServer.Description = newDescription;
                await conn.UpdateAsync(currentServer);
            }
        }

        private async Task DropTableAsync(string name)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.DropTableAsync<ServerLocal>();
        }
    }
}
