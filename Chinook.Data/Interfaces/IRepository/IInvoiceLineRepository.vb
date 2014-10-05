'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Generated by Merlin Version: 1.0.0.0
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------
Imports System
Imports System.Collections.Generic
Imports Chinook.Data
Imports Chinook.Domain.Entities

  
 Namespace Chinook.Data.Repository     
    Public Interface IInvoiceLineRepository
        Function GetData()  as ICollection(Of InvoiceLine)
        Sub Update( ByVal invoiceLineId As Int32,  ByVal invoiceId As Int32,  ByVal trackId As Int32,  ByVal unitPrice As Decimal,  ByVal quantity As Int32) 
        Sub Update(ByVal invoiceLine as InvoiceLine) 
        Function Insert( ByVal invoiceLineId As Int32,  ByVal invoiceId As Int32,  ByVal trackId As Int32,  ByVal unitPrice As Decimal,  ByVal quantity As Int32)  as Int32
        Function Insert(ByVal invoiceLine as InvoiceLine)  as Int32
        Sub Delete( ByVal invoiceLineId As Int32) 
        Sub Delete(ByVal invoiceLine as InvoiceLine) 
        Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of InvoiceLine)
        Function GetRowCount()  as Int32
        Function GetDataByInvoiceLineId( ByVal invoiceLineId As Int32)  as ICollection(Of InvoiceLine)
        Function GetDataByInvoiceId( ByVal invoiceId As Int32)  as ICollection(Of InvoiceLine)
        Function GetDataByInvoiceIdPageable( ByVal invoiceId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of InvoiceLine)
        Function GetDataByInvoiceIdRowCount( ByVal invoiceId As Int32)  as Int32
        Function GetDataByTrackId( ByVal trackId As Int32)  as ICollection(Of InvoiceLine)
        Function GetDataByTrackIdPageable( ByVal trackId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of InvoiceLine)
        Function GetDataByTrackIdRowCount( ByVal trackId As Int32)  as Int32
    End Interface 
End NameSpace
  