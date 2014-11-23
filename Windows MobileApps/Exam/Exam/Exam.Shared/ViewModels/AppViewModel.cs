using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Threading;
using Exam.Models;

namespace Exam.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private ObservableCollection<UserViewModel> users;
        private ObservableCollection<ServerViewModel> servers;
        private ObservableCollection<LocationViewModel> locations;

        public IEnumerable<UserViewModel> Users
        {
            get
            {
                if (this.users == null) this.Users = new ObservableCollection<UserViewModel>();
                return this.users;
            }
            set
            {
                if (this.users == null) this.users = new ObservableCollection<UserViewModel>();

                this.users.Clear();

                foreach (var item in value)
                {
                    this.users.Add(item);
                }
            }
        }

        public IEnumerable<ServerViewModel> Servers
        {
            get
            {
                if (this.servers == null) this.Servers = new ObservableCollection<ServerViewModel>();
                return this.servers;
            }
            set
            {
                if (this.servers == null) this.servers = new ObservableCollection<ServerViewModel>();

                this.servers.Clear();

                foreach (var item in value)
                {
                    this.servers.Add(item);
                }
            }
        }

        public IEnumerable<LocationViewModel> Locations
        {
            get
            {
                if (this.locations == null) this.Locations = new ObservableCollection<LocationViewModel>();
                return this.locations;
            }
            set
            {
                if (this.locations == null) this.locations = new ObservableCollection<LocationViewModel>();

                this.locations.Clear();

                foreach (var item in value)
                {
                    this.locations.Add(item);
                }
            }
        }

        public AppViewModel()
        {
            //this.LoadUsers();
            this.LoadServers();
            //this.LoadLocations();
        }

        public async Task LoadUsers()
        {
            var users = await new ParseQuery<User>().FindAsync(CancellationToken.None);
            this.Users = users.AsQueryable().Select(UserViewModel.FromModel);
        }

        public async Task LoadServers()
        {
            var servers = await new ParseQuery<Server>().FindAsync(CancellationToken.None);
            this.Servers = servers.AsQueryable().Select(ServerViewModel.FromModel);
        }

        public async Task LoadLocations()
        {
            var locations = await new ParseQuery<Location>().FindAsync(CancellationToken.None);
            this.Locations = locations.AsQueryable().Select(LocationViewModel.FromModel);
        }
    }
}
