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
    Public Interface IDbMediaTypeCommandProvider
        ReadOnly Property MediaTypeDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand( ByVal mediaTypeId As Int32,  ByVal name As String) As IDbCommand
        Function GetInsertDbCommand( ByVal mediaTypeId As Int32,  ByVal name As String) As IDbCommand
        Function GetDeleteDbCommand( ByVal mediaTypeId As Int32) As IDbCommand
        Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByMediaTypeIdDbCommand( ByVal mediaTypeId As Int32) As IDbCommand

    End Interface
End Namespace
