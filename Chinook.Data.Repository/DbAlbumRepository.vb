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
    Public Class DbAlbumRepository
        Implements IAlbumRepository
        Implements IDisposable

        Private ReadOnly _dbAlbumCommandProvider As IDbAlbumCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(ByVal dbAlbumCommandProvider As IDbAlbumCommandProvider)
            _dbAlbumCommandProvider = dbAlbumCommandProvider
            _dbConnHolder = _dbAlbumCommandProvider.AlbumDbConnectionHolder
        End Sub


        ''' <summary>
        ''' Selects one or more records from the Album table 
        ''' </summary>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], True)> _
        Public Function GetData() As ICollection(Of Album) Implements IAlbumRepository.GetData
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Album)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Album(reader.GetInt32("AlbumId"), reader.GetString("Title"), reader.GetInt32("ArtistId"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Updates one or more records from the Album table 
        ''' </summary>
        ''' <param name="AlbumId"></param>
        ''' <param name="Title"></param>
        ''' <param name="ArtistId"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal albumId As Int32, ByVal title As String, ByVal artistId As Int32) Implements IAlbumRepository.Update
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetUpdateDbCommand(albumId, title, artistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        ''' Updates one or more records from the Album table 
        ''' </summary>
        ''' <param name="Album"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, False)> _
        Public Sub Update(ByVal album As Album) Implements IAlbumRepository.Update
            With album
                Update(.AlbumId, .Title, .ArtistId)
            End With

        End Sub

        ''' <summary>
        ''' Inserts an entity of Album into the database.
        ''' </summary>
        ''' <param name="AlbumId"></param>
        ''' <param name="Title"></param>
        ''' <param name="ArtistId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal albumId As Int32, ByVal title As String, ByVal artistId As Int32) As Int32 Implements IAlbumRepository.Insert
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetInsertDbCommand(albumId, title, artistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue

        End Function

        ''' <summary>
        ''' Inserts an entity of Album into the database.
        ''' </summary>
        ''' <param name="Album"></param>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, False)> _
        Public Function Insert(ByVal album As Album) As Int32 Implements IAlbumRepository.Insert
            With album
                Return Insert(.AlbumId, .Title, .ArtistId)
            End With

        End Function

        ''' <summary>
        ''' Deletes one or more records from the Album table 
        ''' </summary>
        ''' <param name="AlbumId"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal albumId As Int32) Implements IAlbumRepository.Delete
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetDeleteDbCommand(albumId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        ''' Deletes one or more records from the Album table 
        ''' </summary>
        ''' <param name="Album"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, False)> _
        Public Sub Delete(ByVal album As Album) Implements IAlbumRepository.Delete
            With album
                Delete(.AlbumId)
            End With

        End Sub

        ''' <summary>
        ''' Function GetPageable returns a IDataReader populated with a subset of data from Album
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="startRowIndex"></param>
        ''' <param name="pageSize"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetPageable(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal pageSize As Int32) As ICollection(Of Album) Implements IAlbumRepository.GetPageable
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetGetPageableDbCommand(sortExpression, startRowIndex, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Album)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Album(reader.GetInt32("AlbumId"), reader.GetString("Title"), reader.GetInt32("ArtistId"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetRowCount returns the row count for Album
        ''' </summary>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetRowCount() As Int32 Implements IAlbumRepository.GetRowCount
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue

        End Function

        ''' <summary>
        ''' Function GetDataByAlbumId returns a IDataReader for Album
        ''' </summary>
        ''' <param name="AlbumId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByAlbumId(ByVal albumId As Int32) As ICollection(Of Album) Implements IAlbumRepository.GetDataByAlbumId
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetGetDataByAlbumIdDbCommand(albumId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Album)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Album(reader.GetInt32("AlbumId"), reader.GetString("Title"), reader.GetInt32("ArtistId"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetDataByArtistId returns a IDataReader for Album
        ''' </summary>
        ''' <param name="ArtistId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByArtistId(ByVal artistId As Int32) As ICollection(Of Album) Implements IAlbumRepository.GetDataByArtistId
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetGetDataByArtistIdDbCommand(artistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Album)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Album(reader.GetInt32("AlbumId"), reader.GetString("Title"), reader.GetInt32("ArtistId"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetPageable returns a IDataReader populated with a subset of data from Album
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="startRowIndex"></param>
        ''' <param name="pageSize"></param>
        ''' <param name="ArtistId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByArtistIdPageable(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal pageSize As Int32, ByVal artistId As Int32) As ICollection(Of Album) Implements IAlbumRepository.GetDataByArtistIdPageable
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetGetDataByArtistIdPageableDbCommand(sortExpression, startRowIndex, pageSize, artistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Album)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New Album(reader.GetInt32("AlbumId"), reader.GetString("Title"), reader.GetInt32("ArtistId"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetRowCount returns the row count for Album
        ''' </summary>
        ''' <param name="ArtistId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByArtistIdRowCount(ByVal artistId As Int32) As Int32 Implements IAlbumRepository.GetDataByArtistIdRowCount
            Dim command As IDbCommand = _dbAlbumCommandProvider.GetGetDataByArtistIdRowCountDbCommand(artistId)
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
