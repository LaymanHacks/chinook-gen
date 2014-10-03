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
    Public Interface IMediaTypeRepository
        Function GetData() As ICollection(Of MediaType)
        Sub Update(ByVal mediaTypeId As Int32, ByVal name As String)
        Sub Update(ByVal mediaType As MediaType)
        Function Insert(ByVal mediaTypeId As Int32, ByVal name As String) As Int32
        Function Insert(ByVal mediaType As MediaType) As Int32
        Sub Delete(ByVal mediaTypeId As Int32)
        Sub Delete(ByVal mediaType As MediaType)
        Function GetPageable(ByVal sortExpression As String, ByVal startRowIndex As Int32, ByVal maximumRows As Int32) As ICollection(Of MediaType)
        Function GetRowCount() As Int32
        Function GetDataByMediaTypeId(ByVal mediaTypeId As Int32) As ICollection(Of MediaType)
    End Interface
End Namespace
