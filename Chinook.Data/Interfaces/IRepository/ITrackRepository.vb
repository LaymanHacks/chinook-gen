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
    Public Interface ITrackRepository
        Function GetData() As ICollection(Of Track)
        Sub Update(ByVal trackId As Int32, ByVal name As String, ByVal albumId As Int32, ByVal mediaTypeId As Int32, ByVal genreId As Int32, ByVal composer As String, ByVal milliseconds As Int32, ByVal bytes As Int32, ByVal unitPrice As Decimal)
        Sub Update(ByVal track As Track)
        Function Insert(ByVal trackId As Int32, ByVal name As String, ByVal albumId As Int32, ByVal mediaTypeId As Int32, ByVal genreId As Int32, ByVal composer As String, ByVal milliseconds As Int32, ByVal bytes As Int32, ByVal unitPrice As Decimal) As Int32
        Function Insert(ByVal track As Track) As Int32
        Sub Delete(ByVal trackId As Int32)
        Sub Delete(ByVal track As Track)
        Function GetPageable(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32) As ICollection(Of Track)
        Function GetRowCount() As Int32
        Function GetDataByTrackId(ByVal trackId As Int32) As ICollection(Of Track)
        Function GetTracksByPlaylistId(ByVal playlistId As Int32) As ICollection(Of Track)
        Function GetTracksByPlaylistIdPageable(ByVal playlistId As Int32, ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32) As ICollection(Of Track)
        Function GetTracksByPlaylistIdRowCount(ByVal playlistId As Int32) As Int32
        Function GetDataByAlbumId(ByVal albumId As Int32) As ICollection(Of Track)
        Function GetDataByAlbumIdPageable(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32, ByVal albumId As Int32) As ICollection(Of Track)
        Function GetDataByAlbumIdRowCount(ByVal albumId As Int32) As Int32
        Function GetDataByGenreId(ByVal genreId As Int32) As ICollection(Of Track)
        Function GetDataByGenreIdPageable(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32, ByVal genreId As Int32) As ICollection(Of Track)
        Function GetDataByGenreIdRowCount(ByVal genreId As Int32) As Int32
        Function GetDataByMediaTypeId(ByVal mediaTypeId As Int32) As ICollection(Of Track)
        Function GetDataByMediaTypeIdPageable(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32, ByVal mediaTypeId As Int32) As ICollection(Of Track)
        Function GetDataByMediaTypeIdRowCount(ByVal mediaTypeId As Int32) As Int32
    End Interface
End Namespace
