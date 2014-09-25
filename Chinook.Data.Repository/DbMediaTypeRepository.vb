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
    Public Class DbMediaTypeRepository
        Implements IMediaTypeRepository
        Implements IDisposable

        Private ReadOnly _dbMediaTypeCommandProvider As IDbMediaTypeCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(ByVal dbMediaTypeCommandProvider As IDbMediaTypeCommandProvider)
            _dbMediaTypeCommandProvider = dbMediaTypeCommandProvider
            _dbConnHolder =_dbMediaTypeCommandProvider.MediaTypeDbConnectionHolder
        End Sub

      
    ''' <summary>
    ''' Selects one or more records from the MediaType table 
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], true)> _ 
    Public Function GetData()  as ICollection(Of MediaType) Implements IMediaTypeRepository.GetData
        Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of MediaType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New MediaType( reader.GetInt32("MediaTypeId"),  reader.GetString("Name") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Updates one or more records from the MediaType table 
    ''' </summary>
   ''' <param name="MediaTypeId"></param>
   ''' <param name="Name"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, true)> _ 
    Public Sub Update( ByVal mediaTypeId As Int32,  ByVal name As String)  Implements IMediaTypeRepository.Update
        Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetUpdateDbCommand(MediaTypeId, Name)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Updates one or more records from the MediaType table 
    ''' </summary>
    ''' <param name="MediaType"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, False)> _ 
    Public Sub Update(ByVal mediaType as MediaType)  Implements IMediaTypeRepository.Update
             With MediaType
Update(.MediaTypeId, .Name)
       End With

    End Sub
  
    ''' <summary>
    ''' Inserts an entity of MediaType into the database.
    ''' </summary>
   ''' <param name="MediaTypeId"></param>
   ''' <param name="Name"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, true)> _ 
    Public Function Insert( ByVal mediaTypeId As Int32,  ByVal name As String)  as Int32 Implements IMediaTypeRepository.Insert
        Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetInsertDbCommand(MediaTypeId, Name)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Inserts an entity of MediaType into the database.
    ''' </summary>
    ''' <param name="MediaType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, False)> _ 
    Public Function Insert(ByVal mediaType as MediaType)  as Int32 Implements IMediaTypeRepository.Insert
             With MediaType
 Return Insert(.MediaTypeId, .Name)
       End With

    End Function
  
    ''' <summary>
    ''' Deletes one or more records from the MediaType table 
    ''' </summary>
   ''' <param name="MediaTypeId"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, true)> _ 
    Public Sub Delete( ByVal mediaTypeId As Int32)  Implements IMediaTypeRepository.Delete
        Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetDeleteDbCommand(MediaTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Deletes one or more records from the MediaType table 
    ''' </summary>
    ''' <param name="MediaType"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, False)> _ 
    Public Sub Delete(ByVal mediaType as MediaType)  Implements IMediaTypeRepository.Delete
             With MediaType
Delete(.MediaTypeId)
       End With

    End Sub
  
    ''' <summary>
    ''' Function GetPagableSubSet returns a IDataReader populated with a subset of data from MediaType
    ''' </summary>
   ''' <param name="sortExpression"></param>
   ''' <param name="startRowIndex"></param>
   ''' <param name="MaximumRows"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetPagableSubSet( ByVal sortExpression As String,  ByVal startRowIndex As Int32,  ByVal maximumRows As Int32)  as ICollection(Of MediaType) Implements IMediaTypeRepository.GetPagableSubSet
        Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetGetPagableSubSetDbCommand(sortExpression, startRowIndex, MaximumRows)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of MediaType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New MediaType( reader.GetInt32("MediaTypeId"),  reader.GetString("Name") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for MediaType
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetRowCount()  as Int32 Implements IMediaTypeRepository.GetRowCount
        Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByMediaTypeId returns a IDataReader for MediaType
    ''' </summary>
   ''' <param name="MediaTypeId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByMediaTypeId( ByVal mediaTypeId As Int32)  as ICollection(Of MediaType) Implements IMediaTypeRepository.GetDataByMediaTypeId
        Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetGetDataByMediaTypeIdDbCommand(MediaTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of MediaType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New MediaType( reader.GetInt32("MediaTypeId"),  reader.GetString("Name") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
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
