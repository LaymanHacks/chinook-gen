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
Imports System.Collections.Generic
Imports Chinook.Data
Imports Chinook.Domain.Entities
Imports Chinook.Data.DbCommandProvider
Imports System.Collections.ObjectModel

  
Namespace Chinook.Data.Repository    
    
    <Global.System.ComponentModel.DataObjectAttribute(true)>  _
    Public Class DbTrackRepository
        Implements ITrackRepository
        Implements IDisposable

        Private ReadOnly _dbTrackCommandProvider As IDbTrackCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(ByVal dbTrackCommandProvider As IDbTrackCommandProvider)
            _dbTrackCommandProvider = dbTrackCommandProvider
            _dbConnHolder =_dbTrackCommandProvider.TrackDbConnectionHolder
        End Sub

      
    ''' <summary>
    ''' Selects one or more records from the Track table 
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], true)> _ 
    Public Function GetData()  as ICollection(Of Track) Implements ITrackRepository.GetData
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Updates one or more records from the Track table 
    ''' </summary>
   ''' <param name="TrackId"></param>
   ''' <param name="Name"></param>
   ''' <param name="AlbumId"></param>
   ''' <param name="MediaTypeId"></param>
   ''' <param name="GenreId"></param>
   ''' <param name="Composer"></param>
   ''' <param name="Milliseconds"></param>
   ''' <param name="Bytes"></param>
   ''' <param name="UnitPrice"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, true)> _ 
    Public Sub Update( ByVal trackId As Int32,  ByVal name As String,  ByVal albumId As  Nullable(Of Int32) ,  ByVal mediaTypeId As Int32,  ByVal genreId As  Nullable(Of Int32) ,  ByVal composer As String,  ByVal milliseconds As Int32,  ByVal bytes As  Nullable(Of Int32) ,  ByVal unitPrice As Decimal)  Implements ITrackRepository.Update
        Dim command As IDbCommand = _dbTrackCommandProvider.GetUpdateDbCommand(TrackId, Name, AlbumId, MediaTypeId, GenreId, Composer, Milliseconds, Bytes, UnitPrice)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Updates one or more records from the Track table 
    ''' </summary>
    ''' <param name="Track"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, False)> _ 
    Public Sub Update(ByVal track as Track)  Implements ITrackRepository.Update
             With Track
Update( CInt(.TrackId),  CStr(.Name), .AlbumId,  CInt(.MediaTypeId), .GenreId, .Composer,  CInt(.Milliseconds), .Bytes,  CDec(.UnitPrice))
       End With

    End Sub
  
    ''' <summary>
    ''' Inserts an entity of Track into the database.
    ''' </summary>
   ''' <param name="TrackId"></param>
   ''' <param name="Name"></param>
   ''' <param name="AlbumId"></param>
   ''' <param name="MediaTypeId"></param>
   ''' <param name="GenreId"></param>
   ''' <param name="Composer"></param>
   ''' <param name="Milliseconds"></param>
   ''' <param name="Bytes"></param>
   ''' <param name="UnitPrice"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, true)> _ 
    Public Function Insert( ByVal trackId As Int32,  ByVal name As String,  ByVal albumId As  Nullable(Of Int32) ,  ByVal mediaTypeId As Int32,  ByVal genreId As  Nullable(Of Int32) ,  ByVal composer As String,  ByVal milliseconds As Int32,  ByVal bytes As  Nullable(Of Int32) ,  ByVal unitPrice As Decimal)  as Int32 Implements ITrackRepository.Insert
        Dim command As IDbCommand = _dbTrackCommandProvider.GetInsertDbCommand(TrackId, Name, AlbumId, MediaTypeId, GenreId, Composer, Milliseconds, Bytes, UnitPrice)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Inserts an entity of Track into the database.
    ''' </summary>
    ''' <param name="Track"></param>
    ''' <returns></returns>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, False)> _ 
    Public Function Insert(ByVal track as Track)  as Int32 Implements ITrackRepository.Insert
             With Track
 Return Insert( CInt(.TrackId),  CStr(.Name), .AlbumId,  CInt(.MediaTypeId), .GenreId, .Composer,  CInt(.Milliseconds), .Bytes,  CDec(.UnitPrice))
       End With

    End Function
  
    ''' <summary>
    ''' Deletes one or more records from the Track table 
    ''' </summary>
   ''' <param name="TrackId"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, true)> _ 
    Public Sub Delete( ByVal trackId As Int32)  Implements ITrackRepository.Delete
        Dim command As IDbCommand = _dbTrackCommandProvider.GetDeleteDbCommand(TrackId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Deletes one or more records from the Track table 
    ''' </summary>
    ''' <param name="Track"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, False)> _ 
    Public Sub Delete(ByVal track as Track)  Implements ITrackRepository.Delete
             With Track
Delete( CInt(.TrackId))
       End With

    End Sub
  
    ''' <summary>
    ''' Function GetDataPageable returns a IDataReader populated with a subset of data from Track
    ''' </summary>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetDataPageable
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataPageableDbCommand(sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Track
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetRowCount()  as Int32 Implements ITrackRepository.GetRowCount
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByTrackId returns a IDataReader for Track
    ''' </summary>
   ''' <param name="TrackId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByTrackId( ByVal trackId As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetDataByTrackId
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByTrackIdDbCommand(TrackId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetTracksByPlaylistId returns a Playlist
    ''' </summary>
   ''' <param name="PlaylistId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetTracksByPlaylistId( ByVal playlistId As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetTracksByPlaylistId
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetTracksByPlaylistIdDbCommand(PlaylistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetTracksByPlaylistId returns a Playlist
    ''' </summary>
   ''' <param name="PlaylistId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="PageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetTracksByPlaylistIdPageable( ByVal playlistId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetTracksByPlaylistIdPageable
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetTracksByPlaylistIdPageableDbCommand(PlaylistId, sortExpression, page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetTracksByPlaylistIdRowCount returns the row count for Track
    ''' </summary>
   ''' <param name="PlaylistId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetTracksByPlaylistIdRowCount( ByVal playlistId As Int32)  as Int32 Implements ITrackRepository.GetTracksByPlaylistIdRowCount
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetTracksByPlaylistIdRowCountDbCommand(PlaylistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByAlbumId returns a IDataReader for Track
    ''' </summary>
   ''' <param name="AlbumId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByAlbumId( ByVal albumId As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetDataByAlbumId
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByAlbumIdDbCommand(AlbumId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetDataByAlbumIdPageable returns a IDataReader populated with a subset of data from Track
    ''' </summary>
   ''' <param name="AlbumId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByAlbumIdPageable( ByVal albumId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetDataByAlbumIdPageable
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByAlbumIdPageableDbCommand(AlbumId, sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Track
    ''' </summary>
   ''' <param name="AlbumId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByAlbumIdRowCount( ByVal albumId As Int32)  as Int32 Implements ITrackRepository.GetDataByAlbumIdRowCount
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByAlbumIdRowCountDbCommand(AlbumId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByGenreId returns a IDataReader for Track
    ''' </summary>
   ''' <param name="GenreId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByGenreId( ByVal genreId As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetDataByGenreId
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByGenreIdDbCommand(GenreId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetDataByGenreIdPageable returns a IDataReader populated with a subset of data from Track
    ''' </summary>
   ''' <param name="GenreId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByGenreIdPageable( ByVal genreId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetDataByGenreIdPageable
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByGenreIdPageableDbCommand(GenreId, sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Track
    ''' </summary>
   ''' <param name="GenreId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByGenreIdRowCount( ByVal genreId As Int32)  as Int32 Implements ITrackRepository.GetDataByGenreIdRowCount
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByGenreIdRowCountDbCommand(GenreId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByMediaTypeId returns a IDataReader for Track
    ''' </summary>
   ''' <param name="MediaTypeId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByMediaTypeId( ByVal mediaTypeId As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetDataByMediaTypeId
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByMediaTypeIdDbCommand(MediaTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetDataByMediaTypeIdPageable returns a IDataReader populated with a subset of data from Track
    ''' </summary>
   ''' <param name="MediaTypeId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByMediaTypeIdPageable( ByVal mediaTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Track) Implements ITrackRepository.GetDataByMediaTypeIdPageable
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByMediaTypeIdPageableDbCommand(MediaTypeId, sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Track( reader.GetInt32("TrackId"),  reader.GetString("Name") ,  reader.GetNullableInt32("AlbumId"),  reader.GetInt32("MediaTypeId"),  reader.GetNullableInt32("GenreId"),  reader.GetString("Composer") ,  reader.GetInt32("Milliseconds"),  reader.GetNullableInt32("Bytes"),  reader.GetDecimal("UnitPrice") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Track
    ''' </summary>
   ''' <param name="MediaTypeId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByMediaTypeIdRowCount( ByVal mediaTypeId As Int32)  as Int32 Implements ITrackRepository.GetDataByMediaTypeIdRowCount
        Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByMediaTypeIdRowCountDbCommand(MediaTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
   
  
#Region "IDisposable Support"
        Private disposedValue As Boolean
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Select Case _dbConnHolder.Connection.State
                        Case ConnectionState.Open
                            _dbConnHolder.Close()
                    End Select
                    _dbConnHolder = Nothing
                End If

            End If
            Me.disposedValue = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region
 
  End Class 
End NameSpace
