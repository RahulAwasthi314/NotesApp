using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace NotesApp.Models
{
    public class Note
    {
        private StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;
        public string Filename { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public Note()
        {
            Filename = "NotesApp_" + DateTime.Now.ToBinary().ToString() + ".txt";
        }

        public async Task SaveAsync()
        {
            StorageFile noteFile = (StorageFile) await _storageFolder.TryGetItemAsync(Filename);
            
            if (noteFile is null)
            {
                noteFile = await _storageFolder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting);
            }

            await FileIO.WriteTextAsync(noteFile, Text);
        }

        public async Task DeleteAsync()
        {
            StorageFile noteFile = (StorageFile) await _storageFolder.TryGetItemAsync(Filename);

            if (noteFile is not null)
            {
                await noteFile.DeleteAsync();
            }
        }
    }
}
