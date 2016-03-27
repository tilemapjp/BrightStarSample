using System;
using System.IO;
using BrightStarSample;
using Xamarin.Forms;

[assembly: Dependency(typeof(BrightStarConnectionStringProvider_Android))]
namespace BrightStarSample
{
    class BrightStarConnectionStringProvider_Android : IBrightStarConnectionStringProvider
    {
        public string GetConnectionString()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var brightstarPath = Path.Combine(documentPath, "brightstar");
            var connectionString = string.Format("type=embedded;storesDirectory={0};storeName=person", brightstarPath);
            return connectionString;
        }
    }
}