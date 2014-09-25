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

    <Global.System.ComponentModel.DataObjectAttribute(True)> _
    Public Class DbTrackRepository
        Implements ITrackRepository
        Implements IDisposable

        Private ReadOnly _dbTrackCommandProvider As IDbTrackCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(ByVal dbTrackCommandProvider As IDbTrackCommandProvider)
            _dbTrackCommandProvider = dbTrackCommandProvider
            _dbConnHolder = _dbTrackCommandProvider.TrackDbConnectionHolder
        End Sub


        ''' <summary>
        ''' Selects one or more records from the Track table 
        ''' </summary>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], True)> _
        Public Function GetData() As ICollection(Of Track) Implements ITrackRepository.GetData
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
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
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal trackId As Int32, ByVal name As String, ByVal albumId As Int32, ByVal mediaTypeId As Int32, ByVal genreId As Int32, ByVal composer As String, ByVal milliseconds As Int32, ByVal bytes As Int32, ByVal unitPrice As Decimal) Implements ITrackRepository.Update
            Dim command As IDbCommand = _dbTrackCommandProvider.GetUpdateDbCommand(trackId, name, albumId, mediaTypeId, genreId, composer, milliseconds, bytes, unitPrice)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        ''' Updates one or more records from the Track table 
        ''' </summary>
        ''' <param name="Track"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, False)> _
        Public Sub Update(ByVal track As Track) Implements ITrackRepository.Update
            With track
                Update(.TrackId, .Name, CInt(.AlbumId), .MediaTypeId, CInt(.GenreId), .Composer, .Milliseconds, CInt(.Bytes), .UnitPrice)
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
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal trackId As Int32, ByVal name As String, ByVal albumId As Int32, ByVal mediaTypeId As Int32, ByVal genreId As Int32, ByVal composer As String, ByVal milliseconds As Int32, ByVal bytes As Int32, ByVal unitPrice As Decimal) As Int32 Implements ITrackRepository.Insert
            Dim command As IDbCommand = _dbTrackCommandProvider.GetInsertDbCommand(trackId, name, albumId, mediaTypeId, genreId, composer, milliseconds, bytes, unitPrice)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
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
        Public Function Insert(ByVal track As Track) As Int32 Implements ITrackRepository.Insert
            With track
                Return Insert(.TrackId, .Name, CInt(.AlbumId), .MediaTypeId, CInt(.GenreId), .Composer, .Milliseconds, CInt(.Bytes), .UnitPrice)
            End With

        End Function

        ''' <summary>
        ''' Deletes one or more records from the Track table 
        ''' </summary>
        ''' <param name="TrackId"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal trackId As Int32) Implements ITrackRepository.Delete
            Dim command As IDbCommand = _dbTrackCommandProvider.GetDeleteDbCommand(trackId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        ''' Deletes one or more records from the Track table 
        ''' </summary>
        ''' <param name="Track"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, False)> _
        Public Sub Delete(ByVal track As Track) Implements ITrackRepository.Delete
            With track
                Delete(.TrackId)
            End With

        End Sub

        ''' <summary>
        ''' Function GetPagableSubSet returns a IDataReader populated with a subset of data from Track
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="startRowIndex"></param>
        ''' <param name="MaximumRows"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetPagableSubSet(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32) As ICollection(Of Track) Implements ITrackRepository.GetPagableSubSet
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetPagableSubSetDbCommand(sortExpression, startRowIndex, maximumRows)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetRowCount returns the row count for Track
        ''' </summary>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetRowCount() As Int32 Implements ITrackRepository.GetRowCount
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue

        End Function

        ''' <summary>
        ''' Function GetDataByTrackId returns a IDataReader for Track
        ''' </summary>
        ''' <param name="TrackId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByTrackId(ByVal trackId As Int32) As ICollection(Of Track) Implements ITrackRepository.GetDataByTrackId
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByTrackIdDbCommand(trackId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetTracksByPlaylistId returns a Playlist
        ''' </summary>
        ''' <param name="PlaylistId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetTracksByPlaylistId(ByVal playlistId As Int32) As ICollection(Of Track) Implements ITrackRepository.GetTracksByPlaylistId
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetTracksByPlaylistIdDbCommand(playlistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetTracksByPlaylistId returns a Playlist
        ''' </summary>
        ''' <param name="PlaylistId"></param>
        ''' <param name="sortExpression"></param>
        ''' <param name="startRowIndex"></param>
        ''' <param name="MaximumRows"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetTracksByPlaylistIdPagableSubSet(ByVal playlistId As Int32, ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32) As ICollection(Of Track) Implements ITrackRepository.GetTracksByPlaylistIdPagableSubSet
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetTracksByPlaylistIdPagableSubSetDbCommand(playlistId, sortExpression, startRowIndex, maximumRows)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetTracksByPlaylistIdRowCount returns the row count for Track
        ''' </summary>
        ''' <param name="PlaylistId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetTracksByPlaylistIdRowCount(ByVal playlistId As Int32) As Int32 Implements ITrackRepository.GetTracksByPlaylistIdRowCount
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetTracksByPlaylistIdRowCountDbCommand(playlistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue

        End Function

        ''' <summary>
        ''' Function GetDataByAlbumId returns a IDataReader for Track
        ''' </summary>
        ''' <param name="AlbumId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByAlbumId(ByVal albumId As Int32) As ICollection(Of Track) Implements ITrackRepository.GetDataByAlbumId
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByAlbumIdDbCommand(albumId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetPagableSubSet returns a IDataReader populated with a subset of data from Track
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="startRowIndex"></param>
        ''' <param name="MaximumRows"></param>
        ''' <param name="AlbumId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByAlbumIdPagableSubSet(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32, ByVal albumId As Int32) As ICollection(Of Track) Implements ITrackRepository.GetDataByAlbumIdPagableSubSet
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByAlbumIdPagableSubSetDbCommand(sortExpression, startRowIndex, maximumRows, albumId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetRowCount returns the row count for Track
        ''' </summary>
        ''' <param name="AlbumId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByAlbumIdRowCount(ByVal albumId As Int32) As Int32 Implements ITrackRepository.GetDataByAlbumIdRowCount
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByAlbumIdRowCountDbCommand(albumId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue

        End Function

        ''' <summary>
        ''' Function GetDataByGenreId returns a IDataReader for Track
        ''' </summary>
        ''' <param name="GenreId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByGenreId(ByVal genreId As Int32) As ICollection(Of Track) Implements ITrackRepository.GetDataByGenreId
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByGenreIdDbCommand(genreId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetPagableSubSet returns a IDataReader populated with a subset of data from Track
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="startRowIndex"></param>
        ''' <param name="MaximumRows"></param>
        ''' <param name="GenreId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByGenreIdPagableSubSet(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32, ByVal genreId As Int32) As ICollection(Of Track) Implements ITrackRepository.GetDataByGenreIdPagableSubSet
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByGenreIdPagableSubSetDbCommand(sortExpression, startRowIndex, maximumRows, genreId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetRowCount returns the row count for Track
        ''' </summary>
        ''' <param name="GenreId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByGenreIdRowCount(ByVal genreId As Int32) As Int32 Implements ITrackRepository.GetDataByGenreIdRowCount
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByGenreIdRowCountDbCommand(genreId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue

        End Function

        ''' <summary>
        ''' Function GetDataByMediaTypeId returns a IDataReader for Track
        ''' </summary>
        ''' <param name="MediaTypeId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByMediaTypeId(ByVal mediaTypeId As Int32) As ICollection(Of Track) Implements ITrackRepository.GetDataByMediaTypeId
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByMediaTypeIdDbCommand(mediaTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetPagableSubSet returns a IDataReader populated with a subset of data from Track
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="startRowIndex"></param>
        ''' <param name="MaximumRows"></param>
        ''' <param name="MediaTypeId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByMediaTypeIdPagableSubSet(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32, ByVal mediaTypeId As Int32) As ICollection(Of Track) Implements ITrackRepository.GetDataByMediaTypeIdPagableSubSet
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByMediaTypeIdPagableSubSetDbCommand(sortExpression, startRowIndex, maximumRows, mediaTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Track)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Track(reader.GetInt32("TrackId"), reader.GetString("Name"), reader.GetInt32("AlbumId"), reader.GetInt32("MediaTypeId"), reader.GetInt32("GenreId"), reader.GetString("Composer"), reader.GetInt32("Milliseconds"), reader.GetInt32("Bytes"), reader.GetDecimal("UnitPrice"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetRowCount returns the row count for Track
        ''' </summary>
        ''' <param name="MediaTypeId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByMediaTypeIdRowCount(ByVal mediaTypeId As Int32) As Int32 Implements ITrackRepository.GetDataByMediaTypeIdRowCount
            Dim command As IDbCommand = _dbTrackCommandProvider.GetGetDataByMediaTypeIdRowCountDbCommand(mediaTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
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
End Namespace
