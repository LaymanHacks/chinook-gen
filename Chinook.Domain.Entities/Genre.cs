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
    [Serializable]
    public partial class GenreList :  Collection<Genre>
    {
        public Genre First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class Genre{
      
        private Int32 _genreId;
        private String _name;
        private Collection<Track> _tracks;  

      public Genre() : base()
      {
      }

      public Genre(Int32 genreId, String name) : base()
      {
          
           _genreId = genreId;
           _name = name;
      }
  
    
        /// <summary>
        /// Public Property GenreId
        /// </summary>
        /// <returns>GenreId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 GenreId
        {
            get{return this._genreId;}
            set{this._genreId = value;}
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

        [DataMember]
        public virtual Collection<Track> Tracks 
        {
          get { return  _tracks;}
          set { _tracks = value;}
        }
  
      
    }
 }     
