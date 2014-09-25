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
    Public Interface IDbArtistCommandProvider
        ReadOnly Property ArtistDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand(ByVal artistId As Int32, ByVal name As String) As IDbCommand
        Function GetInsertDbCommand(ByVal artistId As Int32, ByVal name As String) As IDbCommand
        Function GetDeleteDbCommand(ByVal artistId As Int32) As IDbCommand
        Function GetGetPagableSubSetDbCommand(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByArtistIdDbCommand(ByVal artistId As Int32) As IDbCommand

    End Interface
End Namespace
