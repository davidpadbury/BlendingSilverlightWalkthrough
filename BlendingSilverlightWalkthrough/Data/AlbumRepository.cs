using System;
using System.Collections.Generic;

namespace BlendingSilverlightWalkthrough.Data
{
    public class AlbumRepository
    {
        private static readonly Album[] Albums;

        static AlbumRepository()
        {
            Albums = GenerateAlbums();
        }

        #region Generation

        private static Album[] GenerateAlbums()
        {
            return new[]
                {
                    new Album
                        {
                            Artist = "The Beatles",
                            Name = "Sgt. Pepper's Lonely Hearts Club Band",
                            Year = 1967,
                            AlbumArt = "TheBeatles_SgtPeppers.jpg"
                        },
                    new Album
                        {
                            Artist = "The Rolling Stones",
                            Name = "Exile on Main St.",
                            Year = 1972,
                            AlbumArt = "TheRollingStones_Exile.jpg"
                        },
                    new Album
                        {
                            Artist = "The Beastie Boys",
                            Name = "Licensed to Ill",
                            Year = 1986,
                            AlbumArt = "BeastieBoys.jpg"
                        },
                    new Album
                        {
                            Artist = "Led Zeppelin",
                            Name = "Physical Graffiti",
                            Year = 1975,
                            AlbumArt = "LedZeppelin_PhysicalGraffiti.jpg"
                        },
                    new Album
                        {
                            Artist = "The Velvet Underground",
                            Name = "The Velvet Underground & Nico",
                            Year = 1967,
                            AlbumArt = "VelvetUnderground.jpg"
                        }
                };
        }

        #endregion

        private readonly Random _random = new Random();
        private int _lastRandomAlbum;

        public Album GetRandomAlbum()
        {
            while (true)
            {
                var index = _random.Next(Albums.Length);

                if (_lastRandomAlbum != index)
                {
                    _lastRandomAlbum = index;
                    return Albums[index];
                }
            }
        }
    }
}