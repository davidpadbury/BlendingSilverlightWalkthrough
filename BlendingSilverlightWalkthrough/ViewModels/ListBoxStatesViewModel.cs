using System.Collections.ObjectModel;
using System.Linq;
using BlendingSilverlightWalkthrough.Data;

namespace BlendingSilverlightWalkthrough.ViewModels
{
    public class ListBoxStatesViewModel
    {
        private readonly AlbumRepository _albumRepository;

        public ListBoxStatesViewModel()
        {
            _albumRepository = new AlbumRepository();
            Albums = new ObservableCollection<Album>();
        }

        public ObservableCollection<Album> Albums { get; private set; }

        public void AddAlbum()
        {
            Albums.Add(_albumRepository.GetRandomAlbum());
        }

        public void RemoveAlbum()
        {
            if (Albums.Any())
                Albums.RemoveAt(Albums.Count - 1);
        }
    }
}