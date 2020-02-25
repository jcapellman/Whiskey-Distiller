using WhiskeyDistiller.library.Interfaces;
using WhiskeyDistiller.Mobile.UWP.InterfaceImplementations;

using Xamarin.Forms;

[assembly: Dependency(typeof(FileIO))]
namespace WhiskeyDistiller.Mobile.UWP.InterfaceImplementations
{
    public class FileIO : IFileIO
    {
        public string GamePath => Windows.Storage.ApplicationData.Current.LocalFolder.Path;
    }
}