namespace CreateAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Author
    {
        private ICollection<Album> albums;
        public Author()
        {
            this.albums = new List<Album>();
        }

        public string Name { get; set; }
        public ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }
    }
}