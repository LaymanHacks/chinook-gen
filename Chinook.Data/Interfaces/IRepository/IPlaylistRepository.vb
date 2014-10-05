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
    Public Interface IPlaylistRepository
        Function GetData()  as ICollection(Of Playlist)
        Sub Update( ByVal playlistId As Int32,  ByVal name As String) 
        Sub Update(ByVal playlist as Playlist) 
        Function Insert( ByVal playlistId As Int32,  ByVal name As String)  as Int32
        Function Insert(ByVal playlist as Playlist)  as Int32
        Sub Delete( ByVal playlistId As Int32) 
        Sub Delete(ByVal playlist as Playlist) 
        Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Playlist)
        Function GetRowCount()  as Int32
        Function GetDataByPlaylistId( ByVal playlistId As Int32)  as ICollection(Of Playlist)
        Function GetPlaylistsByTrackId( ByVal trackId As Int32)  as ICollection(Of Playlist)
        Function GetPlaylistsByTrackIdPageable( ByVal trackId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Playlist)
        Function GetPlaylistsByTrackIdRowCount( ByVal trackId As Int32)  as Int32
    End Interface 
End NameSpace
  