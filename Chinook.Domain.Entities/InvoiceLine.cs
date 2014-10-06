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
    public partial class InvoiceLineList :  Collection<InvoiceLine>
    {
        public InvoiceLine First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract()]
    public partial class InvoiceLine{
      
        private Int32 _invoiceLineId;
        private Int32 _invoiceId;
        private Int32 _trackId;
        private Decimal _unitPrice;
        private Int32 _quantity; 
        private Invoice _invoice; 
        private Track _track;  

      public InvoiceLine() : base()
      {
      }

      public InvoiceLine(Int32 invoiceLineId, Int32 invoiceId, Int32 trackId, Decimal unitPrice, Int32 quantity) : base()
      {
          
           _invoiceLineId = invoiceLineId;
           _invoiceId = invoiceId;
           _trackId = trackId;
           _unitPrice = unitPrice;
           _quantity = quantity;
      }
  
    
        /// <summary>
        /// Public Property InvoiceLineId
        /// </summary>
        /// <returns>InvoiceLineId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 InvoiceLineId
        {
            get{return this._invoiceLineId;}
            set{this._invoiceLineId = value;}
        }

        /// <summary>
        /// Public Property InvoiceId
        /// </summary>
        /// <returns>InvoiceId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 InvoiceId
        {
            get{return this._invoiceId;}
            set{this._invoiceId = value;}
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

        /// <summary>
        /// Public Property Quantity
        /// </summary>
        /// <returns>Quantity as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 Quantity
        {
            get{return this._quantity;}
            set{this._quantity = value;}
        }

        [DataMember()]
        public virtual Invoice Invoice 
        {
          get { return  _invoice;}
          set { _invoice = value;}
        }
  
      
        [DataMember()]
        public virtual Track Track 
        {
          get { return  _track;}
          set { _track = value;}
        }
  
      
    }
 }     