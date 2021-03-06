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
    public partial class MediaTypeList :  Collection<MediaType>
    {
        public MediaType First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class MediaType{
      
        private Int32 _mediaTypeId;
        private String _name;
        private Collection<Track> _tracks;  

      public MediaType() : base()
      {
      }

      public MediaType(Int32 mediaTypeId, String name) : base()
      {
          
           _mediaTypeId = mediaTypeId;
           _name = name;
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
