using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using NotesApp.Models;
using System;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NotesApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotePage : Page
    {
        private Note? noteModel;

        public NotePage()
        {
            InitializeComponent();
        }

        private async void SaveNote_Click(object sender, RoutedEventArgs e)
        {
            if (noteModel != null)
            {
                await noteModel.SaveAsync();
            }
        }

        private async void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            if (noteModel is not null)
            {
                await noteModel.DeleteAsync();

            }
        }
    }
}