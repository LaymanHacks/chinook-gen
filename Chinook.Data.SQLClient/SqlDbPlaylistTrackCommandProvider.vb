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
Imports System.Data.Common
Imports System.Data.SqlClient
Imports Chinook.Data.DbCommandProvider

Namespace Chinook.Data.SqlDbCommandProvider


    Public Class SqlDbPlaylistTrackCommandProvider
        Implements IDbPlaylistTrackCommandProvider

        ReadOnly _dbConnHolder As DbConnectionHolder

        Public Sub New()
            _dbConnHolder = New DbConnectionHolder(DbConnectionName)
        End Sub

        Public ReadOnly Property DbConnectionName() As String Implements IDbPlaylistTrackCommandProvider.DbConnectionName
            Get
                Return "ChinookConnection"
            End Get
        End Property

        Public ReadOnly Property PlaylistTrackDbConnectionHolder() As DbConnectionHolder Implements IDbPlaylistTrackCommandProvider.PlaylistTrackDbConnectionHolder
            Get
                Return _dbConnHolder
            End Get
        End Property


        ''' <summary>
        ''' Selects one or more records from the PlaylistTrack table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetDataDbCommand


            Dim command As New SqlCommand("PlaylistTrack_Select")
            command.CommandType = CommandType.StoredProcedure

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Updates one or more records from the PlaylistTrack table 
        ''' </summary>
        ''' <param name="playlistId" />
        ''' <param name="trackId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand(ByVal playlistId As Int32, ByVal trackId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetUpdateDbCommand


            Dim command As New SqlCommand("PlaylistTrack_Update")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.Int, playlistId))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.Int, trackId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Inserts a record into the PlaylistTrack table on the database.
        ''' </summary>
        ''' <param name="playlistId" />
        ''' <param name="trackId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand(ByVal playlistId As Int32, ByVal trackId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetInsertDbCommand


            Dim command As New SqlCommand("PlaylistTrack_Insert")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.Int, playlistId))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.Int, trackId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Deletes one or more records from the PlaylistTrack table 
        ''' </summary>
        ''' <param name="playlistId" />
        ''' <param name="trackId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand(ByVal playlistId As Int32, ByVal trackId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetDeleteDbCommand


            Dim command As New SqlCommand("PlaylistTrack_Delete")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.Int, playlistId))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.Int, trackId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Function GetPageable returns a IDataReader populated with a subset of data from PlaylistTrack
        ''' </summary>
        ''' <param name="sortExpression" />
        ''' <param name="startRowIndex" />
        ''' <param name="maximumRows" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetPageableDbCommand(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetPageableDbCommand


            Dim command As New SqlCommand("PlaylistTrack_GetPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.VarChar, sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@startRowIndex", SqlDbType.Int, startRowIndex))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@MaximumRows", SqlDbType.Int, maximumRows))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Function GetRowCount returns the row count for PlaylistTrack
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetRowCountDbCommand


            Dim command As New SqlCommand("PlaylistTrack_GetRowCount")
            command.CommandType = CommandType.StoredProcedure

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Function GetDataByPlaylistIdTrackId returns a IDataReader for PlaylistTrack
        ''' </summary>
        ''' <param name="playlistId" />
        ''' <param name="trackId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByPlaylistIdTrackIdDbCommand(ByVal playlistId As Int32, ByVal trackId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetDataByPlaylistIdTrackIdDbCommand


            Dim command As New SqlCommand("PlaylistTrack_GetDataByPlaylistIdTrackId")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.Int, playlistId))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.Int, trackId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Function GetDataByPlaylistId returns a IDataReader for PlaylistTrack
        ''' </summary>
        ''' <param name="playlistId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByPlaylistIdDbCommand(ByVal playlistId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetDataByPlaylistIdDbCommand


            Dim command As New SqlCommand("PlaylistTrack_GetDataByPlaylistId")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.Int, playlistId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Function GetPageable returns a IDataReader populated with a subset of data from PlaylistTrack
        ''' </summary>
        ''' <param name="sortExpression" />
        ''' <param name="startRowIndex" />
        ''' <param name="maximumRows" />
        ''' <param name="playlistId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByPlaylistIdPageableDbCommand(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32, ByVal playlistId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetDataByPlaylistIdPageableDbCommand


            Dim command As New SqlCommand("PlaylistTrack_GetDataByPlaylistIdPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.VarChar, sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@startRowIndex", SqlDbType.Int, startRowIndex))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@MaximumRows", SqlDbType.Int, maximumRows))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.Int, playlistId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Function GetRowCount returns the row count for PlaylistTrack
        ''' </summary>
        ''' <param name="playlistId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByPlaylistIdRowCountDbCommand(ByVal playlistId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetDataByPlaylistIdRowCountDbCommand


            Dim command As New SqlCommand("PlaylistTrack_GetDataByPlaylistIdRowCount")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.Int, playlistId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Function GetDataByTrackId returns a IDataReader for PlaylistTrack
        ''' </summary>
        ''' <param name="trackId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTrackIdDbCommand(ByVal trackId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetDataByTrackIdDbCommand


            Dim command As New SqlCommand("PlaylistTrack_GetDataByTrackId")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.Int, trackId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Function GetPageable returns a IDataReader populated with a subset of data from PlaylistTrack
        ''' </summary>
        ''' <param name="sortExpression" />
        ''' <param name="startRowIndex" />
        ''' <param name="maximumRows" />
        ''' <param name="trackId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTrackIdPageableDbCommand(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32, ByVal trackId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetDataByTrackIdPageableDbCommand


            Dim command As New SqlCommand("PlaylistTrack_GetDataByTrackIdPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.VarChar, sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@startRowIndex", SqlDbType.Int, startRowIndex))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@MaximumRows", SqlDbType.Int, maximumRows))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.Int, trackId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Function GetRowCount returns the row count for PlaylistTrack
        ''' </summary>
        ''' <param name="trackId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTrackIdRowCountDbCommand(ByVal trackId As Int32) As IDbCommand Implements IDbPlaylistTrackCommandProvider.GetGetDataByTrackIdRowCountDbCommand


            Dim command As New SqlCommand("PlaylistTrack_GetDataByTrackIdRowCount")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.Int, trackId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


    End Class
End Namespace
