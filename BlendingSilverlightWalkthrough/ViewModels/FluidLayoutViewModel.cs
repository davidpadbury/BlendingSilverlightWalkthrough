using System.Collections.ObjectModel;
using BlendingSilverlightWalkthrough.Data;

namespace BlendingSilverlightWalkthrough.ViewModels
{
    public class FluidLayoutViewModel
    {
        public FluidLayoutViewModel()
        {
            var albumRepository = new AlbumRepository();
            var albums = albumRepository.FindAll();

            Albums = new ObservableCollection<Album>(albums);
        }

        public ObservableCollection<Album> Albums { get; private set; }
    }
}