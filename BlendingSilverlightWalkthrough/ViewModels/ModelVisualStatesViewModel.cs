using System;
using System.Threading;
using BlendingSilverlightWalkthrough.Data;

namespace BlendingSilverlightWalkthrough.ViewModels
{
    public class ModelVisualStatesViewModel : ViewModelBase
    {
        private readonly AlbumRepository _albumRepository = new AlbumRepository();
        private Album _album;
        private string _name;
        private string _artist;
        private int _year;
        private bool _isEditing;
        private bool _isSaving;

        public ModelVisualStatesViewModel()
        {
            _album = _albumRepository.GetRandomAlbum();

            LoadAlbum(_album);
        }

        #region public bool IsEditing { get; private set; }

        public bool IsEditing
        {
            get { return _isEditing; }
            private set
            {
                _isEditing = value;
                NotifyChanged(() => IsEditing);
            }
        }

        #endregion

        #region public IsSaving { get; private set; }

        public bool IsSaving
        {
            get { return _isSaving; }
            private set
            {
                _isSaving = value;
                NotifyChanged(() => IsSaving);
            }
        }

        #endregion

        #region public string Name { get; set; }

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                NotifyChanged(() => Name);
            }
        }

        #endregion

        #region public string Artist { get; set; }

        public string Artist
        {
            get { return _artist; }
            set 
            { 
                _artist = value;
                NotifyChanged(() => Artist);
            }
        }

        #endregion

        #region public int Year { get; set; }

        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                NotifyChanged(() => Year);
            }
        }

        #endregion

        public void Save()
        {
            IsSaving = true;

            ThreadPool.QueueUserWorkItem(delegate
                {
                    _album.Name = Name;
                    _album.Artist = Artist;
                    _album.Year = Year;

                    Thread.Sleep(TimeSpan.FromSeconds(2));

                    InvokeOnDispatcher(() =>
                        {
                            LoadAlbum(_album);
                            IsSaving = false;
                        });
                });
        }

        public void CancelEdit()
        {
            LoadAlbum(_album);
        }

        private void LoadAlbum(Album album)
        {
            Name = album.Name;
            Artist = album.Artist;
            Year = album.Year;
        }
    }
}