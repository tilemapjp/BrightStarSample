using System;
using System.IO;
using BrightStarSample;
using Xamarin.Forms;

[assembly: Dependency(typeof(BrightStarConnectionStringProvider_iOS))]
namespace BrightStarSample
{
    class BrightStarConnectionStringProvider_iOS : IBrightStarConnectionStringProvider
    {
        public string GetConnectionString()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var brightstarPath = Path.Combine(libraryPath, "brightstar");
            var connectionString = string.Format("type=embedded;storesDirectory={0};storeName=person", brightstarPath);
            return connectionString;
        }
    }
}
