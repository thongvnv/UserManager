using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicBox.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListUser : Page
    {
        private ObservableCollection<Entity.User> _users;
        private Entity.User _selectedUser = null;
        public ObservableCollection<Entity.User> Users;

        public ListUser()
        {
            this.InitializeComponent();
        }
        public Entity.User SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (value != this._selectedUser)
                {
                    this._selectedUser = value;
                    OnPropertyChanged();
                }
            }
        }

        private void Kind_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Songs = SongService.GetSongs(((MetaData)e.AddedItems[0]).Page, 6);
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            SelectedUser = (Entity.User)((StackPanel)sender).Tag;
            if (SelectedUser != null)
            {
                this.UserDetail.Visibility = Visibility.Visible;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
