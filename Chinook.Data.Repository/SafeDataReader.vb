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

Namespace Chinook.Data

    Public Class SafeDataReader
        Implements IDataReader

        Private _dr As IDataReader

        Public Sub New(ByVal dr As IDataReader)
            _dr = dr
        End Sub

        Public Sub Close() Implements System.Data.IDataReader.Close
            _dr.Close()
        End Sub

        Public ReadOnly Property Depth() As Integer Implements System.Data.IDataReader.Depth
            Get
                Return _dr.Depth
            End Get
        End Property

        Public Function GetSchemaTable() As System.Data.DataTable Implements System.Data.IDataReader.GetSchemaTable
            Return _dr.GetSchemaTable
        End Function

        Public ReadOnly Property IsClosed() As Boolean Implements System.Data.IDataReader.IsClosed
            Get
                Return _dr.IsClosed
            End Get
        End Property

        Public Function NextResult() As Boolean Implements System.Data.IDataReader.NextResult
            Return _dr.NextResult
        End Function

        Public Function Read() As Boolean Implements System.Data.IDataReader.Read
            Return _dr.Read
        End Function

        Public ReadOnly Property RecordsAffected() As Integer Implements System.Data.IDataReader.RecordsAffected
            Get
                Return _dr.RecordsAffected
            End Get
        End Property

        Public ReadOnly Property FieldCount() As Integer Implements System.Data.IDataRecord.FieldCount
            Get
                Return _dr.FieldCount
            End Get
        End Property

        Public Function GetBoolean(ByVal i As Integer) As Boolean Implements System.Data.IDataRecord.GetBoolean
            If _dr.IsDBNull(i) Then
                Return False
            End If
            Return _dr.GetBoolean(i)
        End Function

        Public Function GetByte(ByVal i As Integer) As Byte Implements System.Data.IDataRecord.GetByte
            If _dr.IsDBNull(i) Then
                Return 0 'Could be Byte.MinValue
            End If
            Return _dr.GetByte(i)
        End Function

        Public Function GetBytes(ByVal i As Integer, ByVal fieldOffset As Long, ByVal buffer() As Byte, ByVal bufferoffset As Integer, ByVal length As Integer) As Long Implements System.Data.IDataRecord.GetBytes
            If _dr.IsDBNull(i) Then
                Return 0 'Could be Long.MinValue
            End If
            Return _dr.GetBytes(i, fieldOffset, buffer, bufferoffset, length)
        End Function

        Public Function GetChar(ByVal i As Integer) As Char Implements System.Data.IDataRecord.GetChar
            If _dr.IsDBNull(i) Then
                Return Char.MinValue
            End If
            Return _dr.GetChar(i)
        End Function

        Public Function GetChars(ByVal i As Integer, ByVal fieldoffset As Long, ByVal buffer() As Char, ByVal bufferoffset As Integer, ByVal length As Integer) As Long Implements System.Data.IDataRecord.GetChars
            If _dr.IsDBNull(i) Then
                Return 0
            End If
            Return _dr.GetChars(i, fieldoffset, buffer, bufferoffset, length)
        End Function

        Public Function GetData(ByVal i As Integer) As System.Data.IDataReader Implements System.Data.IDataRecord.GetData
            Return _dr.GetData(i)
        End Function

        Public Function GetDataTypeName(ByVal i As Integer) As String Implements System.Data.IDataRecord.GetDataTypeName
            Return _dr.GetDataTypeName(i)
        End Function

        Public Function GetDateTime(ByVal i As Integer) As Date Implements System.Data.IDataRecord.GetDateTime
            If _dr.IsDBNull(i) Then
                Return DateTime.MinValue
            End If
            Return _dr.GetDateTime(i)
        End Function

        Public Function GetDecimal(ByVal i As Integer) As Decimal Implements System.Data.IDataRecord.GetDecimal
            If _dr.IsDBNull(i) Then
                Return 0 'Could use Decimal.MinValue
            End If
            Return _dr.GetDecimal(i)
        End Function

        Public Function GetDouble(ByVal i As Integer) As Double Implements System.Data.IDataRecord.GetDouble
            If _dr.IsDBNull(i) Then
                Return 0 'Could use Double.MinValue
            End If
            Return _dr.GetDouble(i)
        End Function

        Public Function GetFieldType(ByVal i As Integer) As System.Type Implements System.Data.IDataRecord.GetFieldType
            Return _dr.GetFieldType(i)
        End Function

        Public Function GetFloat(ByVal i As Integer) As Single Implements System.Data.IDataRecord.GetFloat
            If _dr.IsDBNull(i) Then
                Return 0 'Could use Single.MinValue
            End If
            Return _dr.GetFloat(i)
        End Function

        Public Function GetGuid(ByVal i As Integer) As System.Guid Implements System.Data.IDataRecord.GetGuid
            If _dr.IsDBNull(i) Then
                Return Guid.Empty
            End If
            Return _dr.GetGuid(i)
        End Function

        Public Function GetInt16(ByVal i As Integer) As Short Implements System.Data.IDataRecord.GetInt16
            If _dr.IsDBNull(i) Then
                Return 0 'Could use Short.MinValue
            End If
            Return _dr.GetInt16(i)
        End Function

        Public Function GetInt32(ByVal i As Integer) As Integer Implements System.Data.IDataRecord.GetInt32
            If _dr.IsDBNull(i) Then
                Return 0 'Could use Int32.MinValue
            End If
            Return _dr.GetInt32(i)
        End Function

        Public Function GetInt64(ByVal i As Integer) As Long Implements System.Data.IDataRecord.GetInt64
            If _dr.IsDBNull(i) Then
                Return 0 'Could use Long.MinValue
            End If
            Return _dr.GetInt64(i)
        End Function

        Public Function GetName(ByVal i As Integer) As String Implements System.Data.IDataRecord.GetName
            Return _dr.GetName(i)
        End Function

        Public Function GetOrdinal(ByVal name As String) As Integer Implements System.Data.IDataRecord.GetOrdinal
            Return _dr.GetOrdinal(name)
        End Function

        Public Function GetString(ByVal i As Integer) As String Implements System.Data.IDataRecord.GetString
            If _dr.IsDBNull(i) Then
                Return String.Empty
            End If
            Return _dr.GetString(i)
        End Function

        Public Function GetValue(ByVal i As Integer) As Object Implements System.Data.IDataRecord.GetValue
            Return _dr.GetValue(i)
        End Function

        Public Function GetValues(ByVal values() As Object) As Integer Implements System.Data.IDataRecord.GetValues
            Return _dr.GetValues(values)
        End Function

        Public Function IsDBNull(ByVal i As Integer) As Boolean Implements System.Data.IDataRecord.IsDBNull
            Return _dr.IsDBNull(i)
        End Function

        Default Public Overloads ReadOnly Property Item(ByVal i As Integer) As Object Implements System.Data.IDataRecord.Item
            Get
                If _dr.IsDBNull(i) Then
                    Return Nothing
                End If
                Return _dr.Item(i)
            End Get
        End Property

        Default Public Overloads ReadOnly Property Item(ByVal name As String) As Object Implements System.Data.IDataRecord.Item
            Get
                If _dr.IsDBNull(_dr.GetOrdinal(name)) Then
                    Return Nothing
                End If
                Return _dr.Item(name)
            End Get
        End Property

#Region " Custom methods"
        Public Function GetNullableDateTime(ByVal name As String) As Nullable(Of DateTime)
            Return CType(_dr(name), Nullable(Of DateTime))
        End Function

        Public Function GetNullableDecimal(ByVal name As String) As Nullable(Of Decimal)
            Return CType(_dr(name), Nullable(Of Decimal))
        End Function

        Public Function GetNullableInteger(ByVal name As String) As Nullable(Of Integer)
            Return CType(_dr(name), Nullable(Of Integer))
        End Function

        Public Function GetNullableInt32(ByVal name As String) As Nullable(Of Int32)
            Return CType(_dr(name), Nullable(Of Int32))
        End Function

        Public Function GetNullableBoolean(ByVal name As String) As Nullable(Of Boolean)
            Return CType(_dr(name), Nullable(Of Boolean))
        End Function

        Public Function GetGuid(ByVal name As String) As System.Guid
            Return GetGuid(_dr.GetOrdinal(name))
        End Function

        Public Function GetDateTime(ByVal name As String) As DateTime
            Return GetDateTime(_dr.GetOrdinal(name))
        End Function

        Public Function GetDecimal(ByVal name As String) As Decimal
            Return GetDecimal(_dr.GetOrdinal(name))
        End Function

        Public Function GetInt16(ByVal name As String) As Int16
            Return GetInt16(_dr.GetOrdinal(name))
        End Function

        Public Function GetInt32(ByVal name As String) As Int32
            Return GetInt32(_dr.GetOrdinal(name))
        End Function

        Public Function GetInt64(ByVal name As String) As Int64
            Return GetInt64(_dr.GetOrdinal(name))
        End Function

        Public Function GetBoolean(ByVal name As String) As Boolean
            Return GetBoolean(_dr.GetOrdinal(name))
        End Function

        Public Function GetString(ByVal name As String) As String
            Return GetString(_dr.GetOrdinal(name))
        End Function

#End Region

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If
                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace


