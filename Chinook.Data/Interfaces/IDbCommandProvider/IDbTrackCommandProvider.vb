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
    Public Interface IDbTrackCommandProvider
        ReadOnly Property TrackDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand( ByVal trackId As Int32,  ByVal name As String,  ByVal albumId As  Nullable(Of Int32) ,  ByVal mediaTypeId As Int32,  ByVal genreId As  Nullable(Of Int32) ,  ByVal composer As String,  ByVal milliseconds As Int32,  ByVal bytes As  Nullable(Of Int32) ,  ByVal unitPrice As Decimal) As IDbCommand
        Function GetInsertDbCommand( ByVal trackId As Int32,  ByVal name As String,  ByVal albumId As  Nullable(Of Int32) ,  ByVal mediaTypeId As Int32,  ByVal genreId As  Nullable(Of Int32) ,  ByVal composer As String,  ByVal milliseconds As Int32,  ByVal bytes As  Nullable(Of Int32) ,  ByVal unitPrice As Decimal) As IDbCommand
        Function GetDeleteDbCommand( ByVal trackId As Int32) As IDbCommand
        Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByTrackIdDbCommand( ByVal trackId As Int32) As IDbCommand
        Function GetGetTracksByPlaylistIdDbCommand( ByVal playlistId As Int32) As IDbCommand
        Function GetGetTracksByPlaylistIdPageableDbCommand( ByVal playlistId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetTracksByPlaylistIdRowCountDbCommand( ByVal playlistId As Int32) As IDbCommand
        Function GetGetDataByAlbumIdDbCommand( ByVal albumId As Int32) As IDbCommand
        Function GetGetDataByAlbumIdPageableDbCommand( ByVal albumId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByAlbumIdRowCountDbCommand( ByVal albumId As Int32) As IDbCommand
        Function GetGetDataByGenreIdDbCommand( ByVal genreId As Int32) As IDbCommand
        Function GetGetDataByGenreIdPageableDbCommand( ByVal genreId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByGenreIdRowCountDbCommand( ByVal genreId As Int32) As IDbCommand
        Function GetGetDataByMediaTypeIdDbCommand( ByVal mediaTypeId As Int32) As IDbCommand
        Function GetGetDataByMediaTypeIdPageableDbCommand( ByVal mediaTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByMediaTypeIdRowCountDbCommand( ByVal mediaTypeId As Int32) As IDbCommand

    End Interface
End Namespace
