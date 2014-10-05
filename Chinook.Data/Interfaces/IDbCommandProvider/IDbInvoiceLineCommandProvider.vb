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
Imports System.Data

Namespace Chinook.Data.DbCommandProvider
    Public Interface IDbInvoiceLineCommandProvider
        ReadOnly Property InvoiceLineDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand( ByVal invoiceLineId As Int32,  ByVal invoiceId As Int32,  ByVal trackId As Int32,  ByVal unitPrice As Decimal,  ByVal quantity As Int32) As IDbCommand
        Function GetInsertDbCommand( ByVal invoiceLineId As Int32,  ByVal invoiceId As Int32,  ByVal trackId As Int32,  ByVal unitPrice As Decimal,  ByVal quantity As Int32) As IDbCommand
        Function GetDeleteDbCommand( ByVal invoiceLineId As Int32) As IDbCommand
        Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByInvoiceLineIdDbCommand( ByVal invoiceLineId As Int32) As IDbCommand
        Function GetGetDataByInvoiceIdDbCommand( ByVal invoiceId As Int32) As IDbCommand
        Function GetGetDataByInvoiceIdPageableDbCommand( ByVal invoiceId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByInvoiceIdRowCountDbCommand( ByVal invoiceId As Int32) As IDbCommand
        Function GetGetDataByTrackIdDbCommand( ByVal trackId As Int32) As IDbCommand
        Function GetGetDataByTrackIdPageableDbCommand( ByVal trackId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByTrackIdRowCountDbCommand( ByVal trackId As Int32) As IDbCommand

    End Interface
End Namespace
