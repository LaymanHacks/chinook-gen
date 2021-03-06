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

  
Public Class SqlDbMediaTypeCommandProvider
      Implements IDbMediaTypeCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbMediaTypeCommandProvider.DbConnectionName
          Get
              Return "ChinookConnection"
          End Get
      End Property

      Public ReadOnly Property MediaTypeDbConnectionHolder() As DbConnectionHolder Implements IDbMediaTypeCommandProvider.MediaTypeDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the MediaType table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbMediaTypeCommandProvider.GetGetDataDbCommand
            
    
            Dim command As New SqlCommand("MediaType_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the MediaType table 
        ''' </summary>
      ''' <param name="mediaTypeId" />
      ''' <param name="name" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand(ByVal mediaTypeId As Int32, ByVal name As String) As IDbCommand Implements IDbMediaTypeCommandProvider.GetUpdateDbCommand


            Dim command As New SqlCommand("MediaType_Update")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@MediaTypeId", SqlDbType.int, mediaTypeId))

            If (Not name Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, name))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, Global.System.DBNull.Value))
            End If

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        ''' Inserts a record into the MediaType table on the database.
        ''' </summary>
        ''' <param name="mediaTypeId" />
        ''' <param name="name" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand(ByVal mediaTypeId As Int32, ByVal name As String) As IDbCommand Implements IDbMediaTypeCommandProvider.GetInsertDbCommand


            Dim command As New SqlCommand("MediaType_Insert")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@MediaTypeId", SqlDbType.int, mediaTypeId))

            If (Not name Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, name))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.nvarchar, Global.System.DBNull.Value))
            End If

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function
         
            
        ''' <summary>
        ''' Deletes one or more records from the MediaType table 
        ''' </summary>
      ''' <param name="mediaTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal mediaTypeId As Int32) As IDbCommand Implements IDbMediaTypeCommandProvider.GetDeleteDbCommand
            
    
            Dim command As New SqlCommand("MediaType_Delete")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@MediaTypeId", SqlDbType.int, mediaTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from MediaType
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbMediaTypeCommandProvider.GetGetDataPageableDbCommand
            
    
            Dim command As New SqlCommand("MediaType_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for MediaType
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbMediaTypeCommandProvider.GetGetRowCountDbCommand
            
    
            Dim command As New SqlCommand("MediaType_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByMediaTypeId returns a IDataReader for MediaType
        ''' </summary>
      ''' <param name="mediaTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByMediaTypeIdDbCommand( ByVal mediaTypeId As Int32) As IDbCommand Implements IDbMediaTypeCommandProvider.GetGetDataByMediaTypeIdDbCommand
            
    
            Dim command As New SqlCommand("MediaType_GetDataByMediaTypeId")
            command.CommandType = CommandType.StoredProcedure
              command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@MediaTypeId", SqlDbType.int, mediaTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  