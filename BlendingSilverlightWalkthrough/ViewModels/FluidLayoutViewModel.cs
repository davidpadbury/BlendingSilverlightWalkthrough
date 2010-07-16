using BlendingSilverlightWalkthrough.Data;
using System.Linq;

namespace BlendingSilverlightWalkthrough.ViewModels
{
    public class FluidLayoutViewModel : ViewModelBase
    {
        private readonly AlbumRepository _albumRepository = new AlbumRepository();

        public FluidLayoutViewModel()
        {
            // Find a album with some tracks
            Album = _albumRepository.FindAll()
                .Where(a => a.Tracks != null && a.Tracks.Length > 0)
                .FirstOrDefault();
        }

        public Album Album { get; private set; }
    }
}