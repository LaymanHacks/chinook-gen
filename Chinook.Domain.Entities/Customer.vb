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
Imports System.Collections.ObjectModel
Imports System.Xml.Serialization

Namespace Chinook.Domain.Entities
    <Serializable()> _
    Partial Public Class CustomerList
        Inherits Collection(Of Customer)

        Public Function First() As Customer
            If MyBase.Count > 0 Then
                Return MyBase.Item(0)
            Else
                Return Nothing
            End If
        End Function
    End Class

    <Serializable()> _
    Partial Public Class Customer
        Private _customerId As Int32
        Private _firstName As String
        Private _lastName As String
        Private _company As String
        Private _address As String
        Private _city As String
        Private _state As String
        Private _country As String
        Private _postalCode As String
        Private _phone As String
        Private _fax As String
        Private _email As String
        Private _supportRepId As Nullable(Of Int32)
        Private _Invoices As InvoiceList
        Private _SupportRepIdEmployee As Employee

        Public Sub New()
            MyBase.New()

        End Sub

        Public Sub New(ByVal customerId As Int32, ByVal firstName As String, ByVal lastName As String, ByVal company As String, ByVal address As String, ByVal city As String, ByVal state As String, ByVal country As String, ByVal postalCode As String, ByVal phone As String, ByVal fax As String, ByVal email As String, ByVal supportRepId As Nullable(Of Int32))
            MyBase.New()

            _customerId = customerId
            _firstName = firstName
            _lastName = lastName
            _company = company
            _address = address
            _city = city
            _state = state
            _country = country
            _postalCode = postalCode
            _phone = phone
            _fax = fax
            _email = email
            _supportRepId = supportRepId
        End Sub


        ''' <summary>
        ''' Public Property CustomerId
        ''' </summary>
        ''' <returns>CustomerId as Int32</returns>
        ''' <remarks></remarks>
        Public Property CustomerId() As Int32
            Get
                Return Me._customerId
            End Get
            Set(ByVal value As Int32)
                Me._customerId = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property FirstName
        ''' </summary>
        ''' <returns>FirstName as String</returns>
        ''' <remarks></remarks>
        Public Property FirstName() As String
            Get
                Return Me._firstName
            End Get
            Set(ByVal value As String)
                Me._firstName = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property LastName
        ''' </summary>
        ''' <returns>LastName as String</returns>
        ''' <remarks></remarks>
        Public Property LastName() As String
            Get
                Return Me._lastName
            End Get
            Set(ByVal value As String)
                Me._lastName = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property Company
        ''' </summary>
        ''' <returns>Company as String</returns>
        ''' <remarks></remarks>
        Public Property Company() As String
            Get
                Return Me._company
            End Get
            Set(ByVal value As String)
                Me._company = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property Address
        ''' </summary>
        ''' <returns>Address as String</returns>
        ''' <remarks></remarks>
        Public Property Address() As String
            Get
                Return Me._address
            End Get
            Set(ByVal value As String)
                Me._address = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property City
        ''' </summary>
        ''' <returns>City as String</returns>
        ''' <remarks></remarks>
        Public Property City() As String
            Get
                Return Me._city
            End Get
            Set(ByVal value As String)
                Me._city = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property State
        ''' </summary>
        ''' <returns>State as String</returns>
        ''' <remarks></remarks>
        Public Property State() As String
            Get
                Return Me._state
            End Get
            Set(ByVal value As String)
                Me._state = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property Country
        ''' </summary>
        ''' <returns>Country as String</returns>
        ''' <remarks></remarks>
        Public Property Country() As String
            Get
                Return Me._country
            End Get
            Set(ByVal value As String)
                Me._country = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property PostalCode
        ''' </summary>
        ''' <returns>PostalCode as String</returns>
        ''' <remarks></remarks>
        Public Property PostalCode() As String
            Get
                Return Me._postalCode
            End Get
            Set(ByVal value As String)
                Me._postalCode = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property Phone
        ''' </summary>
        ''' <returns>Phone as String</returns>
        ''' <remarks></remarks>
        Public Property Phone() As String
            Get
                Return Me._phone
            End Get
            Set(ByVal value As String)
                Me._phone = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property Fax
        ''' </summary>
        ''' <returns>Fax as String</returns>
        ''' <remarks></remarks>
        Public Property Fax() As String
            Get
                Return Me._fax
            End Get
            Set(ByVal value As String)
                Me._fax = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property Email
        ''' </summary>
        ''' <returns>Email as String</returns>
        ''' <remarks></remarks>
        Public Property Email() As String
            Get
                Return Me._email
            End Get
            Set(ByVal value As String)
                Me._email = value
            End Set
        End Property


        ''' <summary>
        ''' Public Property SupportRepId
        ''' </summary>
        ''' <returns>SupportRepId as  Nullable(Of Int32)</returns>
        ''' <remarks></remarks>
        Public Property SupportRepId() As Nullable(Of Int32)
            Get
                Return Me._supportRepId
            End Get
            Set(ByVal value As Nullable(Of Int32))
                Me._supportRepId = value
            End Set
        End Property


        Public Overridable Property Invoices() As InvoiceList
            Get
                Return _Invoices
            End Get
            Set(ByVal value As InvoiceList)
                _Invoices = value
            End Set
        End Property


        Public Overridable Property SupportRepIdEmployee() As Employee
            Get
                Return _SupportRepIdEmployee
            End Get
            Set(ByVal value As Employee)
                _SupportRepIdEmployee = value
            End Set
        End Property


    End Class
End Namespace
