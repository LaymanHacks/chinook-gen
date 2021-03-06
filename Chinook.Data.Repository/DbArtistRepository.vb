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
    Public Class DbArtistRepository
        Implements IArtistRepository
        Implements IDisposable

        Private ReadOnly _dbArtistCommandProvider As IDbArtistCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(ByVal dbArtistCommandProvider As IDbArtistCommandProvider)
            _dbArtistCommandProvider = dbArtistCommandProvider
            _dbConnHolder =_dbArtistCommandProvider.ArtistDbConnectionHolder
        End Sub

      
    ''' <summary>
    ''' Selects one or more records from the Artist table 
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], true)> _ 
    Public Function GetData()  as ICollection(Of Artist) Implements IArtistRepository.GetData
        Dim command As IDbCommand = _dbArtistCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Artist)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Artist( reader.GetInt32("ArtistId"),  reader.GetString("Name") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Updates one or more records from the Artist table 
    ''' </summary>
   ''' <param name="ArtistId"></param>
   ''' <param name="Name"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, true)> _ 
    Public Sub Update( ByVal artistId As Int32,  ByVal name As String)  Implements IArtistRepository.Update
        Dim command As IDbCommand = _dbArtistCommandProvider.GetUpdateDbCommand(ArtistId, Name)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Updates one or more records from the Artist table 
    ''' </summary>
    ''' <param name="Artist"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, False)> _ 
    Public Sub Update(ByVal artist as Artist)  Implements IArtistRepository.Update
             With Artist
Update( CInt(.ArtistId), .Name)
       End With

    End Sub
  
    ''' <summary>
    ''' Inserts an entity of Artist into the database.
    ''' </summary>
   ''' <param name="ArtistId"></param>
   ''' <param name="Name"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, true)> _ 
    Public Function Insert( ByVal artistId As Int32,  ByVal name As String)  as Int32 Implements IArtistRepository.Insert
        Dim command As IDbCommand = _dbArtistCommandProvider.GetInsertDbCommand(ArtistId, Name)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Inserts an entity of Artist into the database.
    ''' </summary>
    ''' <param name="Artist"></param>
    ''' <returns></returns>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, False)> _ 
    Public Function Insert(ByVal artist as Artist)  as Int32 Implements IArtistRepository.Insert
             With Artist
 Return Insert( CInt(.ArtistId), .Name)
       End With

    End Function
  
    ''' <summary>
    ''' Deletes one or more records from the Artist table 
    ''' </summary>
   ''' <param name="ArtistId"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, true)> _ 
    Public Sub Delete( ByVal artistId As Int32)  Implements IArtistRepository.Delete
        Dim command As IDbCommand = _dbArtistCommandProvider.GetDeleteDbCommand(ArtistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Deletes one or more records from the Artist table 
    ''' </summary>
    ''' <param name="Artist"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, False)> _ 
    Public Sub Delete(ByVal artist as Artist)  Implements IArtistRepository.Delete
             With Artist
Delete( CInt(.ArtistId))
       End With

    End Sub
  
    ''' <summary>
    ''' Function GetDataPageable returns a IDataReader populated with a subset of data from Artist
    ''' </summary>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Artist) Implements IArtistRepository.GetDataPageable
        Dim command As IDbCommand = _dbArtistCommandProvider.GetGetDataPageableDbCommand(sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Artist)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Artist( reader.GetInt32("ArtistId"),  reader.GetString("Name") )
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Artist
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetRowCount()  as Int32 Implements IArtistRepository.GetRowCount
        Dim command As IDbCommand = _dbArtistCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByArtistId returns a IDataReader for Artist
    ''' </summary>
   ''' <param name="ArtistId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], false)> _ 
    Public Function GetDataByArtistId( ByVal artistId As Int32)  as ICollection(Of Artist) Implements IArtistRepository.GetDataByArtistId
        Dim command As IDbCommand = _dbArtistCommandProvider.GetGetDataByArtistIdDbCommand(ArtistId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Artist)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Artist( reader.GetInt32("ArtistId"),  reader.GetString("Name") )
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
