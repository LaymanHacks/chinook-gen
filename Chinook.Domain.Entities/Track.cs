//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace Chinook.Domain.Entities
{
    [Serializable()]
    public partial class TrackList :  Collection<Track>
    {
        public Track First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract()]
    public partial class Track{
      
        private Int32 _trackId;
        private String _name;
        private Nullable<Int32> _albumId;
        private Int32 _mediaTypeId;
        private Nullable<Int32> _genreId;
        private String _composer;
        private Int32 _milliseconds;
        private Nullable<Int32> _bytes;
        private Decimal _unitPrice;
        private InvoiceLineList _invoiceLines;
        private PlaylistList _playlists; 
        private Album _album; 
        private Genre _genre; 
        private MediaType _mediaType;  

      public Track() : base()
      {
      }

      public Track(Int32 trackId, String name, Nullable<Int32> albumId, Int32 mediaTypeId, Nullable<Int32> genreId, String composer, Int32 milliseconds, Nullable<Int32> bytes, Decimal unitPrice) : base()
      {
          
           _trackId = trackId;
           _name = name;
           _albumId = albumId;
           _mediaTypeId = mediaTypeId;
           _genreId = genreId;
           _composer = composer;
           _milliseconds = milliseconds;
           _bytes = bytes;
           _unitPrice = unitPrice;
      }
  
    
        /// <summary>
        /// Public Property TrackId
        /// </summary>
        /// <returns>TrackId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 TrackId
        {
            get{return this._trackId;}
            set{this._trackId = value;}
        }

        /// <summary>
        /// Public Property Name
        /// </summary>
        /// <returns>Name as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String Name
        {
            get{return this._name;}
            set{this._name = value;}
        }

        /// <summary>
        /// Public Property AlbumId
        /// </summary>
        /// <returns>AlbumId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Nullable<Int32> AlbumId
        {
            get{return this._albumId;}
            set{this._albumId = value;}
        }

        /// <summary>
        /// Public Property MediaTypeId
        /// </summary>
        /// <returns>MediaTypeId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 MediaTypeId
        {
            get{return this._mediaTypeId;}
            set{this._mediaTypeId = value;}
        }

        /// <summary>
        /// Public Property GenreId
        /// </summary>
        /// <returns>GenreId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Nullable<Int32> GenreId
        {
            get{return this._genreId;}
            set{this._genreId = value;}
        }

        /// <summary>
        /// Public Property Composer
        /// </summary>
        /// <returns>Composer as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String Composer
        {
            get{return this._composer;}
            set{this._composer = value;}
        }

        /// <summary>
        /// Public Property Milliseconds
        /// </summary>
        /// <returns>Milliseconds as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 Milliseconds
        {
            get{return this._milliseconds;}
            set{this._milliseconds = value;}
        }

        /// <summary>
        /// Public Property Bytes
        /// </summary>
        /// <returns>Bytes as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Nullable<Int32> Bytes
        {
            get{return this._bytes;}
            set{this._bytes = value;}
        }

        /// <summary>
        /// Public Property UnitPrice
        /// </summary>
        /// <returns>UnitPrice as Decimal</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Decimal UnitPrice
        {
            get{return this._unitPrice;}
            set{this._unitPrice = value;}
        }

        [DataMember()]
        public virtual InvoiceLineList InvoiceLines 
        {
          get { return  _invoiceLines;}
          set { _invoiceLines = value;}
        }
  
      
        [DataMember()]
        public virtual PlaylistList Playlists 
        {
          get { return  _playlists;}
          set { _playlists = value;}
        }
  
      
        [DataMember()]
        public virtual Album Album 
        {
          get { return  _album;}
          set { _album = value;}
        }
  
      
        [DataMember()]
        public virtual Genre Genre 
        {
          get { return  _genre;}
          set { _genre = value;}
        }
  
      
        [DataMember()]
        public virtual MediaType MediaType 
        {
          get { return  _mediaType;}
          set { _mediaType = value;}
        }
  
      
    }
 }     