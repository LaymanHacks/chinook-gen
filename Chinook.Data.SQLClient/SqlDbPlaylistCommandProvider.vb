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

  
Public Class SqlDbPlaylistCommandProvider
      Implements IDbPlaylistCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbPlaylistCommandProvider.DbConnectionName
          Get
              Return "ChinookConnection"
          End Get
      End Property

      Public ReadOnly Property PlaylistDbConnectionHolder() As DbConnectionHolder Implements IDbPlaylistCommandProvider.PlaylistDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the Playlist table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbPlaylistCommandProvider.GetGetDataDbCommand
            
    
            Dim command As New SqlCommand("Playlist_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the Playlist table 
        ''' </summary>
      ''' <param name="playlistId" />
      ''' <param name="name" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand( ByVal playlistId As Int32,  ByVal name As String) As IDbCommand Implements IDbPlaylistCommandProvider.GetUpdateDbCommand
            
    
            Dim command As New SqlCommand("Playlist_Update")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.int, playlistId))
      
            If (Not name  Is Nothing ) Then
                          command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, name))
      Else
                          command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, global.System.DBNull.Value))
      End If
        
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Inserts a record into the Playlist table on the database.
        ''' </summary>
      ''' <param name="playlistId" />
      ''' <param name="name" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand( ByVal playlistId As Int32,  ByVal name As String) As IDbCommand Implements IDbPlaylistCommandProvider.GetInsertDbCommand
            
    
            Dim command As New SqlCommand("Playlist_Insert")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.int, playlistId))
      
            If (Not name  Is Nothing ) Then
                          command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, name))
      Else
                          command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, global.System.DBNull.Value))
      End If
        
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Deletes one or more records from the Playlist table 
        ''' </summary>
      ''' <param name="playlistId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal playlistId As Int32) As IDbCommand Implements IDbPlaylistCommandProvider.GetDeleteDbCommand
            
    
            Dim command As New SqlCommand("Playlist_Delete")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.int, playlistId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from Playlist
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbPlaylistCommandProvider.GetGetDataPageableDbCommand
            
    
            Dim command As New SqlCommand("Playlist_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for Playlist
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbPlaylistCommandProvider.GetGetRowCountDbCommand
            
    
            Dim command As New SqlCommand("Playlist_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByPlaylistId returns a IDataReader for Playlist
        ''' </summary>
      ''' <param name="playlistId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByPlaylistIdDbCommand( ByVal playlistId As Int32) As IDbCommand Implements IDbPlaylistCommandProvider.GetGetDataByPlaylistIdDbCommand
            
    
            Dim command As New SqlCommand("Playlist_GetDataByPlaylistId")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PlaylistId", SqlDbType.int, playlistId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetPlaylistsByTrackId returns a IDataReader for Playlist
        ''' </summary>
      ''' <param name="trackId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetPlaylistsByTrackIdDbCommand( ByVal trackId As Int32) As IDbCommand Implements IDbPlaylistCommandProvider.GetGetPlaylistsByTrackIdDbCommand
            
    
            Dim command As New SqlCommand("Playlist_GetPlaylistsByTrackId")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.int, trackId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetPlaylistsByTrackId returns a IDataReader for Playlist
        ''' </summary>
      ''' <param name="trackId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetPlaylistsByTrackIdPageableDbCommand( ByVal trackId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbPlaylistCommandProvider.GetGetPlaylistsByTrackIdPageableDbCommand
            
    
            Dim command As New SqlCommand("Playlist_GetPlaylistsByTrackIdPageable")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.int, trackId))
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetPlaylistsByTrackIdRowCount returns the row count for Playlist
        ''' </summary>
      ''' <param name="trackId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetPlaylistsByTrackIdRowCountDbCommand( ByVal trackId As Int32) As IDbCommand Implements IDbPlaylistCommandProvider.GetGetPlaylistsByTrackIdRowCountDbCommand
            
    
            Dim command As New SqlCommand("Playlist_GetPlaylistsByTrackIdRowCount")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TrackId", SqlDbType.int, trackId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  