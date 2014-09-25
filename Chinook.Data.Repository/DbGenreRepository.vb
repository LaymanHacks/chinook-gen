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
    Public Class DbGenreRepository
        Implements IGenreRepository
        Implements IDisposable

        Private ReadOnly _dbGenreCommandProvider As IDbGenreCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(ByVal dbGenreCommandProvider As IDbGenreCommandProvider)
            _dbGenreCommandProvider = dbGenreCommandProvider
            _dbConnHolder =_dbGenreCommandProvider.GenreDbConnectionHolder
        End Sub

      
    ''' <summary>
    ''' Selects one or more records from the Genre table 
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], true)> _ 
    Public Function GetData()  as ICollection(Of Genre) Implements IGenreRepository.GetData
        Dim command As IDbCommand = _dbGenreCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Genre)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Genre( reader.GetInt32("GenreId"),  reader.GetString("Name") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Updates one or more records from the Genre table 
    ''' </summary>
   ''' <param name="GenreId"></param>
   ''' <param name="Name"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, true)> _ 
    Public Sub Update( ByVal genreId As Int32,  ByVal name As String)  Implements IGenreRepository.Update
        Dim command As IDbCommand = _dbGenreCommandProvider.GetUpdateDbCommand(GenreId, Name)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Updates one or more records from the Genre table 
    ''' </summary>
    ''' <param name="Genre"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, False)> _ 
    Public Sub Update(ByVal genre as Genre)  Implements IGenreRepository.Update
             With Genre
Update(.GenreId, .Name)
       End With

    End Sub
  
    ''' <summary>
    ''' Inserts an entity of Genre into the database.
    ''' </summary>
   ''' <param name="GenreId"></param>
   ''' <param name="Name"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, true)> _ 
    Public Function Insert( ByVal genreId As Int32,  ByVal name As String)  as Int32 Implements IGenreRepository.Insert
        Dim command As IDbCommand = _dbGenreCommandProvider.GetInsertDbCommand(GenreId, Name)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Inserts an entity of Genre into the database.
    ''' </summary>
    ''' <param name="Genre"></param>
    ''' <returns></returns>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, False)> _ 
    Public Function Insert(ByVal genre as Genre)  as Int32 Implements IGenreRepository.Insert
             With Genre
 Return Insert(.GenreId, .Name)
       End With

    End Function
  
    ''' <summary>
    ''' Deletes one or more records from the Genre table 
    ''' </summary>
   ''' <param name="GenreId"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, true)> _ 
    Public Sub Delete( ByVal genreId As Int32)  Implements IGenreRepository.Delete
        Dim command As IDbCommand = _dbGenreCommandProvider.GetDeleteDbCommand(GenreId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Deletes one or more records from the Genre table 
    ''' </summary>
    ''' <param name="Genre"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, False)> _ 
    Public Sub Delete(ByVal genre as Genre)  Implements IGenreRepository.Delete
             With Genre
Delete(.GenreId)
       End With

    End Sub
  
    ''' <summary>
    ''' Function GetPagableSubSet returns a IDataReader populated with a subset of data from Genre
    ''' </summary>
   ''' <param name="sortExpression"></param>
   ''' <param name="startRowIndex"></param>
   ''' <param name="MaximumRows"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetPagableSubSet( ByVal sortExpression As String,  ByVal startRowIndex As Int32,  ByVal maximumRows As Int32)  as ICollection(Of Genre) Implements IGenreRepository.GetPagableSubSet
        Dim command As IDbCommand = _dbGenreCommandProvider.GetGetPagableSubSetDbCommand(sortExpression, startRowIndex, MaximumRows)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Genre)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Genre( reader.GetInt32("GenreId"),  reader.GetString("Name") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Genre
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetRowCount()  as Int32 Implements IGenreRepository.GetRowCount
        Dim command As IDbCommand = _dbGenreCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByGenreId returns a IDataReader for Genre
    ''' </summary>
   ''' <param name="GenreId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByGenreId( ByVal genreId As Int32)  as ICollection(Of Genre) Implements IGenreRepository.GetDataByGenreId
        Dim command As IDbCommand = _dbGenreCommandProvider.GetGetDataByGenreIdDbCommand(GenreId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Genre)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Genre( reader.GetInt32("GenreId"),  reader.GetString("Name") )
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
