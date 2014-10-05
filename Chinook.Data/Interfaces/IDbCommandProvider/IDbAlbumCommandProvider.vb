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
    Public Interface IDbAlbumCommandProvider
        ReadOnly Property AlbumDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand(ByVal albumId As Int32, ByVal title As String, ByVal artistId As Int32) As IDbCommand
        Function GetInsertDbCommand(ByVal albumId As Int32, ByVal title As String, ByVal artistId As Int32) As IDbCommand
        Function GetDeleteDbCommand(ByVal albumId As Int32) As IDbCommand
        Function GetGetDataPageableDbCommand(ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByAlbumIdDbCommand(ByVal albumId As Int32) As IDbCommand
        Function GetGetDataByArtistIdDbCommand(ByVal artistId As Int32) As IDbCommand
        Function GetGetDataByArtistIdPageableDbCommand(ByVal artistId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByArtistIdRowCountDbCommand(ByVal artistId As Int32) As IDbCommand

    End Interface
End Namespace
