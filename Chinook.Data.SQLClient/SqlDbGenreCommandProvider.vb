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

  
Public Class SqlDbGenreCommandProvider
      Implements IDbGenreCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbGenreCommandProvider.DbConnectionName
          Get
              Return "ChinookConnection"
          End Get
      End Property

      Public ReadOnly Property GenreDbConnectionHolder() As DbConnectionHolder Implements IDbGenreCommandProvider.GenreDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the Genre table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbGenreCommandProvider.GetGetDataDbCommand
            
    
            Dim command As New SqlCommand("Genre_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the Genre table 
        ''' </summary>
      ''' <param name="genreId" />
      ''' <param name="name" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand(ByVal genreId As Int32, ByVal name As String) As IDbCommand Implements IDbGenreCommandProvider.GetUpdateDbCommand


            Dim command As New SqlCommand("Genre_Update")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@GenreId", SqlDbType.int, genreId))

            If (Not name Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, name))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, Global.System.DBNull.Value))
            End If

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Inserts a record into the Genre table on the database.
        ''' </summary>
        ''' <param name="genreId" />
        ''' <param name="name" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand(ByVal genreId As Int32, ByVal name As String) As IDbCommand Implements IDbGenreCommandProvider.GetInsertDbCommand


            Dim command As New SqlCommand("Genre_Insert")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@GenreId", SqlDbType.int, genreId))

            If (Not name Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, name))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, Global.System.DBNull.Value))
            End If

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function
         
            
        ''' <summary>
        ''' Deletes one or more records from the Genre table 
        ''' </summary>
      ''' <param name="genreId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal genreId As Int32) As IDbCommand Implements IDbGenreCommandProvider.GetDeleteDbCommand
            
    
            Dim command As New SqlCommand("Genre_Delete")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@GenreId", SqlDbType.int, genreId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from Genre
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbGenreCommandProvider.GetGetDataPageableDbCommand
            
    
            Dim command As New SqlCommand("Genre_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for Genre
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbGenreCommandProvider.GetGetRowCountDbCommand
            
    
            Dim command As New SqlCommand("Genre_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByGenreId returns a IDataReader for Genre
        ''' </summary>
      ''' <param name="genreId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByGenreIdDbCommand( ByVal genreId As Int32) As IDbCommand Implements IDbGenreCommandProvider.GetGetDataByGenreIdDbCommand
            
    
            Dim command As New SqlCommand("Genre_GetDataByGenreId")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@GenreId", SqlDbType.int, genreId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  