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
    Public Class DbMediaTypeRepository
        Implements IMediaTypeRepository
        Implements IDisposable

        Private ReadOnly _dbMediaTypeCommandProvider As IDbMediaTypeCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(ByVal dbMediaTypeCommandProvider As IDbMediaTypeCommandProvider)
            _dbMediaTypeCommandProvider = dbMediaTypeCommandProvider
            _dbConnHolder = _dbMediaTypeCommandProvider.MediaTypeDbConnectionHolder
        End Sub


        ''' <summary>
        ''' Selects one or more records from the MediaType table 
        ''' </summary>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], True)> _
        Public Function GetData() As ICollection(Of MediaType) Implements IMediaTypeRepository.GetData
            Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of MediaType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New MediaType(reader.GetInt32("MediaTypeId"), reader.GetString("Name"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Updates one or more records from the MediaType table 
        ''' </summary>
        ''' <param name="MediaTypeId"></param>
        ''' <param name="Name"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal mediaTypeId As Int32, ByVal name As String) Implements IMediaTypeRepository.Update
            Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetUpdateDbCommand(mediaTypeId, name)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        ''' Updates one or more records from the MediaType table 
        ''' </summary>
        ''' <param name="MediaType"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, False)> _
        Public Sub Update(ByVal mediaType As MediaType) Implements IMediaTypeRepository.Update
            With mediaType
                Update(.MediaTypeId, .Name)
            End With

        End Sub

        ''' <summary>
        ''' Inserts an entity of MediaType into the database.
        ''' </summary>
        ''' <param name="MediaTypeId"></param>
        ''' <param name="Name"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal mediaTypeId As Int32, ByVal name As String) As Int32 Implements IMediaTypeRepository.Insert
            Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetInsertDbCommand(mediaTypeId, name)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
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
        Public Function Insert(ByVal mediaType As MediaType) As Int32 Implements IMediaTypeRepository.Insert
            With mediaType
                Return Insert(.MediaTypeId, .Name)
            End With

        End Function

        ''' <summary>
        ''' Deletes one or more records from the MediaType table 
        ''' </summary>
        ''' <param name="MediaTypeId"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal mediaTypeId As Int32) Implements IMediaTypeRepository.Delete
            Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetDeleteDbCommand(mediaTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        ''' Deletes one or more records from the MediaType table 
        ''' </summary>
        ''' <param name="MediaType"></param>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, False)> _
        Public Sub Delete(ByVal mediaType As MediaType) Implements IMediaTypeRepository.Delete
            With mediaType
                Delete(.MediaTypeId)
            End With

        End Sub

        ''' <summary>
        ''' Function GetPageable returns a IDataReader populated with a subset of data from MediaType
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="startRowIndex"></param>
        ''' <param name="pageSize"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetPageable(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal pageSize As Int32) As ICollection(Of MediaType) Implements IMediaTypeRepository.GetPageable
            Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetGetPageableDbCommand(sortExpression, startRowIndex, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of MediaType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New MediaType(reader.GetInt32("MediaTypeId"), reader.GetString("Name"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList

        End Function

        ''' <summary>
        ''' Function GetRowCount returns the row count for MediaType
        ''' </summary>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetRowCount() As Int32 Implements IMediaTypeRepository.GetRowCount
            Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue

        End Function

        ''' <summary>
        ''' Function GetDataByMediaTypeId returns a IDataReader for MediaType
        ''' </summary>
        ''' <param name="MediaTypeId"></param>''' <returns></returns>
        ''' <remarks></remarks> 
        <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Function GetDataByMediaTypeId(ByVal mediaTypeId As Int32) As ICollection(Of MediaType) Implements IMediaTypeRepository.GetDataByMediaTypeId
            Dim command As IDbCommand = _dbMediaTypeCommandProvider.GetGetDataByMediaTypeIdDbCommand(mediaTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of MediaType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New MediaType(reader.GetInt32("MediaTypeId"), reader.GetString("Name"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
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
End Namespace
