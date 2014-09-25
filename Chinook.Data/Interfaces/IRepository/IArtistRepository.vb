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
Imports System.Collections.Generic
Imports Chinook.Data
Imports Chinook.Domain.Entities

  
 Namespace Chinook.Data.Repository     
    Public Interface IArtistRepository
        Function GetData()  as ICollection(Of Artist)
        Sub Update( ByVal artistId As Int32,  ByVal name As String) 
        Sub Update(ByVal artist as Artist) 
        Function Insert( ByVal artistId As Int32,  ByVal name As String)  as Int32
        Function Insert(ByVal artist as Artist)  as Int32
        Sub Delete( ByVal artistId As Int32) 
        Sub Delete(ByVal artist as Artist) 
        Function GetPagableSubSet( ByVal sortExpression As String,  ByVal startRowIndex As Int32,  ByVal maximumRows As Int32)  as ICollection(Of Artist)
        Function GetRowCount()  as Int32
        Function GetDataByArtistId( ByVal artistId As Int32)  as ICollection(Of Artist)
    End Interface 
End NameSpace
  