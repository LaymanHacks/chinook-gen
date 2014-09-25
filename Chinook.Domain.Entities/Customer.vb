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
  <Serializable()>  _
  Partial Public Class CustomerList
     Inherits Collection(Of Customer)
                
          Public Function First() As Customer
          If  MyBase.Count > 0 Then
              Return MyBase.Item(0)
          Else
              Return Nothing
          End If
      End Function
  End Class

<Serializable()> _
Partial Public Class Customer
     Private _customerId as Int32
     Private _firstName as String
     Private _lastName as String
     Private _company as String
     Private _address as String
     Private _city as String
     Private _state as String
     Private _country as String
     Private _postalCode as String
     Private _phone as String
     Private _fax as String
     Private _email as String
     Private _supportRepId as  Nullable(Of Int32)
    Private _Invoices as InvoiceList
    Private _SupportRepIdEmployee as Employee  

  Public Sub New()
    MyBase.New
    
 End Sub

  Public Sub New(ByVal customerId as Int32, ByVal firstName as String, ByVal lastName as String, ByVal company as String, ByVal address as String, ByVal city as String, ByVal state as String, ByVal country as String, ByVal postalCode as String, ByVal phone as String, ByVal fax as String, ByVal email as String, ByVal supportRepId as  Nullable(Of Int32))
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
    Public Property CustomerId() as Int32
        Get
            Return Me._customerId
        End Get
        Set(ByVal value as Int32)
             Me._customerId = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property FirstName
    ''' </summary>
    ''' <returns>FirstName as String</returns>
    ''' <remarks></remarks>
    Public Property FirstName() as String
        Get
            Return Me._firstName
        End Get
        Set(ByVal value as String)
             Me._firstName = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property LastName
    ''' </summary>
    ''' <returns>LastName as String</returns>
    ''' <remarks></remarks>
    Public Property LastName() as String
        Get
            Return Me._lastName
        End Get
        Set(ByVal value as String)
             Me._lastName = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property Company
    ''' </summary>
    ''' <returns>Company as String</returns>
    ''' <remarks></remarks>
    Public Property Company() as String
        Get
            Return Me._company
        End Get
        Set(ByVal value as String)
             Me._company = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property Address
    ''' </summary>
    ''' <returns>Address as String</returns>
    ''' <remarks></remarks>
    Public Property Address() as String
        Get
            Return Me._address
        End Get
        Set(ByVal value as String)
             Me._address = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property City
    ''' </summary>
    ''' <returns>City as String</returns>
    ''' <remarks></remarks>
    Public Property City() as String
        Get
            Return Me._city
        End Get
        Set(ByVal value as String)
             Me._city = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property State
    ''' </summary>
    ''' <returns>State as String</returns>
    ''' <remarks></remarks>
    Public Property State() as String
        Get
            Return Me._state
        End Get
        Set(ByVal value as String)
             Me._state = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property Country
    ''' </summary>
    ''' <returns>Country as String</returns>
    ''' <remarks></remarks>
    Public Property Country() as String
        Get
            Return Me._country
        End Get
        Set(ByVal value as String)
             Me._country = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property PostalCode
    ''' </summary>
    ''' <returns>PostalCode as String</returns>
    ''' <remarks></remarks>
    Public Property PostalCode() as String
        Get
            Return Me._postalCode
        End Get
        Set(ByVal value as String)
             Me._postalCode = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property Phone
    ''' </summary>
    ''' <returns>Phone as String</returns>
    ''' <remarks></remarks>
    Public Property Phone() as String
        Get
            Return Me._phone
        End Get
        Set(ByVal value as String)
             Me._phone = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property Fax
    ''' </summary>
    ''' <returns>Fax as String</returns>
    ''' <remarks></remarks>
    Public Property Fax() as String
        Get
            Return Me._fax
        End Get
        Set(ByVal value as String)
             Me._fax = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property Email
    ''' </summary>
    ''' <returns>Email as String</returns>
    ''' <remarks></remarks>
    Public Property Email() as String
        Get
            Return Me._email
        End Get
        Set(ByVal value as String)
             Me._email = value
        End Set
    End Property


    ''' <summary>
    ''' Public Property SupportRepId
    ''' </summary>
    ''' <returns>SupportRepId as  Nullable(Of Int32)</returns>
    ''' <remarks></remarks>
    Public Property SupportRepId() as  Nullable(Of Int32)
        Get
            Return Me._supportRepId
        End Get
        Set(ByVal value as  Nullable(Of Int32))
             Me._supportRepId = value
        End Set
    End Property


  Public Overridable Property Invoices() as InvoiceList
      Get
          Return  _Invoices
      End Get
      Set(ByVal value As InvoiceList)
          _Invoices = value
      End Set
  End Property   
  

  Public Overridable Property SupportRepIdEmployee() as Employee
      Get
          Return  _SupportRepIdEmployee
      End Get
      Set(ByVal value As Employee)
          _SupportRepIdEmployee = value
      End Set
  End Property   
  

    End Class
End Namespace
 