using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using MusicBox.Annotations;
using MusicBox.Entity;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicBox.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserForm : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserForm()
        {
            FormUser = new User();
            this.InitializeComponent();
        }
        private User _formUser;
        public User FormUser { get => _formUser; set { if (_formUser != value) { _formUser = value; OnPropertyChanged(); } } }

        private void SaveUser(object sender, RoutedEventArgs e)
        {

            Entity.User user = new Entity.User()
            {
                Name = this.name.Text,
                Email = this.Email.Text,
                Phone = this.Phone.Text,
                Address = this.Address.Text,
                Avatar = this.Avatar.Text
            };
            Model.UserModel.AddUser(user);
        }
    }
}
