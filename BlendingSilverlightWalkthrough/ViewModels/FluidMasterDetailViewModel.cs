using System.Collections.Generic;
using System.Collections.ObjectModel;
using BlendingSilverlightWalkthrough.Data;

namespace BlendingSilverlightWalkthrough.ViewModels
{
    public class FluidMasterDetailViewModel : ViewModelBase
    {
        private readonly AlbumRepository _albumRepository = new AlbumRepository();
        private Album _selectedAlbum;

        public FluidMasterDetailViewModel()
        {
            var albums = _albumRepository.FindAll();

            Albums = new ObservableCollection<Album>(albums);
        }

        public ObservableCollection<Album> Albums { get; private set; }
        
        public Album SelectedAlbum
        {
            get { return _selectedAlbum; }
            set 
            { 
                _selectedAlbum = value;
                NotifyChanged(() => SelectedAlbum);
            }
        }

    }
}