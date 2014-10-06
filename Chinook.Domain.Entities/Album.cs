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
    public partial class AlbumList :  Collection<Album>
    {
        public Album First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract()]
    public partial class Album{
      
        private Int32 _albumId;
        private String _title;
        private Int32 _artistId;
        private TrackList _tracks; 
        private Artist _artist;  

      public Album() : base()
      {
      }

      public Album(Int32 albumId, String title, Int32 artistId) : base()
      {
          
           _albumId = albumId;
           _title = title;
           _artistId = artistId;
      }
  
    
        /// <summary>
        /// Public Property AlbumId
        /// </summary>
        /// <returns>AlbumId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 AlbumId
        {
            get{return this._albumId;}
            set{this._albumId = value;}
        }

        /// <summary>
        /// Public Property Title
        /// </summary>
        /// <returns>Title as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String Title
        {
            get{return this._title;}
            set{this._title = value;}
        }

        /// <summary>
        /// Public Property ArtistId
        /// </summary>
        /// <returns>ArtistId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 ArtistId
        {
            get{return this._artistId;}
            set{this._artistId = value;}
        }

        [DataMember()]
        public virtual TrackList Tracks 
        {
          get { return  _tracks;}
          set { _tracks = value;}
        }
  
      
        [DataMember()]
        public virtual Artist Artist 
        {
          get { return  _artist;}
          set { _artist = value;}
        }
  
      
    }
 }     