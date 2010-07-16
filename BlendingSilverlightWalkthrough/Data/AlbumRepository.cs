using System;
using System.Collections.Generic;
using System.Threading;

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
                            AlbumArt = "TheBeatles_SgtPeppers.jpg",
                            Tracks = new[]
                                {
                                    "Sgt. Pepper's Lonely Hearts Club Band",
                                    "With a Little Help from My Friends",
                                    "Lucy in the Sky with Diamonds",
                                    "Getting Better",
                                    "Fixing a Hole",
                                    "She's Leaving Home",
                                    "Being for the Benefit of Mr. Kite!",
                                    "Within You Without You",
                                    "When I'm Sixty-Four",
                                    "Lovely Rita",
                                    "Good Morning Good Morning",
                                    "Sgt. Pepper's Lonely Hearts Club Band (Reprise)",
                                    "A Day in the Life"
                                }
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

        public IEnumerable<Album> FindAll()
        {
            return Albums;
        }
    }
}