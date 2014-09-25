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
    Public Interface IEmployeeRepository
        Function GetData()  as ICollection(Of Employee)
        Sub Update( ByVal employeeId As Int32,  ByVal lastName As String,  ByVal firstName As String,  ByVal title As String,  ByVal reportsTo As Int32,  ByVal birthDate As DateTime,  ByVal hireDate As DateTime,  ByVal address As String,  ByVal city As String,  ByVal state As String,  ByVal country As String,  ByVal postalCode As String,  ByVal phone As String,  ByVal fax As String,  ByVal email As String) 
        Sub Update(ByVal employee as Employee) 
        Function Insert( ByVal employeeId As Int32,  ByVal lastName As String,  ByVal firstName As String,  ByVal title As String,  ByVal reportsTo As Int32,  ByVal birthDate As DateTime,  ByVal hireDate As DateTime,  ByVal address As String,  ByVal city As String,  ByVal state As String,  ByVal country As String,  ByVal postalCode As String,  ByVal phone As String,  ByVal fax As String,  ByVal email As String)  as Int32
        Function Insert(ByVal employee as Employee)  as Int32
        Sub Delete( ByVal employeeId As Int32) 
        Sub Delete(ByVal employee as Employee) 
        Function GetPagableSubSet( ByVal sortExpression As String,  ByVal startRowIndex As Int32,  ByVal maximumRows As Int32)  as ICollection(Of Employee)
        Function GetRowCount()  as Int32
        Function GetDataByEmployeeId( ByVal employeeId As Int32)  as ICollection(Of Employee)
        Function GetDataByReportsTo( ByVal reportsTo As Int32)  as ICollection(Of Employee)
        Function GetDataByReportsToPagableSubSet( ByVal sortExpression As String,  ByVal startRowIndex As Int32,  ByVal maximumRows As Int32,  ByVal reportsTo As Int32)  as ICollection(Of Employee)
        Function GetDataByReportsToRowCount( ByVal reportsTo As Int32)  as Int32
    End Interface 
End NameSpace
  