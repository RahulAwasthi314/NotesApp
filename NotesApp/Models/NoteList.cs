using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace NotesApp.Models
{
    public class NoteList
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public NoteList()
        {
            LoadNotes();
        }

        public async void LoadNotes()
        {
            Notes.Clear();
        }

        private async Task GetFilesInFolderAsync(StorageFolder folder)
        {
            IReadOnlyList<IStorageItem> storageItems = await folder.GetFilesAsync();

            foreach (IStorageItem storageItem in storageItems)
            {
                if (storageItem.IsOfType(StorageItemTypes.Folder))
                {
                    await GetFilesInFolderAsync((StorageFolder)storageItem);
                }
                else if (storageItem.IsOfType(StorageItemTypes.File))
                {
                    StorageFile file = (StorageFile)storageItem;
                    Note note = new()
                    {
                        Filename = file.Name,
                        Text = await FileIO.ReadTextAsync(file),
                        Date = file.DateCreated.DateTime
                    };

                    Notes.Add(note);
                }
            }
        }
    }
}
