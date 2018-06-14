﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Dieser Quellcode wurde automatisch generiert von xsd, Version=4.6.1055.0.
// 
namespace OvgRlp.EgvpEpReceiver.Infrastructure.Models {
    using System.Xml.Serialization;
    

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("EGVPMessagePropsss", Namespace= "", IsNullable=false)]
    public partial class ExportMsgType {
        
        private string messageIDField;
        
        private System.DateTime serverEntryTimeField;
        
        private ExchangeParticipant originatorField;
        
        private EncCertProps addresseeCertPropsField;
        
        private string oSCISubjectField;
        
        private string msgSubjectField;
        
        private SignaturePropertiesType[] authorSignatureField;
        
        private OSCIContentType[] oSCIContentField;
        
        private AttachmentType[] attachmentField;
        
        private ExportMsgTypeStatus statusField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="NMTOKEN")]
        public string MessageID {
            get {
                return this.messageIDField;
            }
            set {
                this.messageIDField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime ServerEntryTime {
            get {
                return this.serverEntryTimeField;
            }
            set {
                this.serverEntryTimeField = value;
            }
        }
        
        /// <remarks/>
        public ExchangeParticipant Originator {
            get {
                return this.originatorField;
            }
            set {
                this.originatorField = value;
            }
        }
        
        /// <remarks/>
        public EncCertProps AddresseeCertProps {
            get {
                return this.addresseeCertPropsField;
            }
            set {
                this.addresseeCertPropsField = value;
            }
        }
        
        /// <remarks/>
        public string OSCISubject {
            get {
                return this.oSCISubjectField;
            }
            set {
                this.oSCISubjectField = value;
            }
        }
        
        /// <remarks/>
        public string MsgSubject {
            get {
                return this.msgSubjectField;
            }
            set {
                this.msgSubjectField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AuthorSignature")]
        public SignaturePropertiesType[] AuthorSignature {
            get {
                return this.authorSignatureField;
            }
            set {
                this.authorSignatureField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OSCIContent")]
        public OSCIContentType[] OSCIContent {
            get {
                return this.oSCIContentField;
            }
            set {
                this.oSCIContentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Attachment")]
        public AttachmentType[] Attachment {
            get {
                return this.attachmentField;
            }
            set {
                this.attachmentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ExportMsgTypeStatus status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExchangeParticipant {
        
        private EncCertProps encryptionCertificateField;
        
        private BusinessCardType businessCardField;
        
        /// <remarks/>
        public EncCertProps EncryptionCertificate {
            get {
                return this.encryptionCertificateField;
            }
            set {
                this.encryptionCertificateField = value;
            }
        }
        
        /// <remarks/>
        public BusinessCardType BusinessCard {
            get {
                return this.businessCardField;
            }
            set {
                this.businessCardField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EncCertProps {
        
        private string nameField;
        
        private string organizationField;
        
        private string encCertNameField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Organization {
            get {
                return this.organizationField;
            }
            set {
                this.organizationField = value;
            }
        }
        
        /// <remarks/>
        public string EncCertName {
            get {
                return this.encCertNameField;
            }
            set {
                this.encCertNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AttachmentType {
        
        private string filenameField;
        
        private SignaturePropertiesType[] signaturePropertiesField;
        
        private AttachmentTypeStatus statusField;
        
        private bool statusFieldSpecified;
        
        private string error_messageField;
        
        private string containerField;
        
        /// <remarks/>
        public string Filename {
            get {
                return this.filenameField;
            }
            set {
                this.filenameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SignatureProperties")]
        public SignaturePropertiesType[] SignatureProperties {
            get {
                return this.signaturePropertiesField;
            }
            set {
                this.signaturePropertiesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public AttachmentTypeStatus status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool statusSpecified {
            get {
                return this.statusFieldSpecified;
            }
            set {
                this.statusFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string error_message {
            get {
                return this.error_messageField;
            }
            set {
                this.error_messageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string container {
            get {
                return this.containerField;
            }
            set {
                this.containerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SignaturePropertiesType {
        
        private System.DateTime certCheckTimeField;
        
        private System.DateTime signingTimeField;
        
        private bool signingTimeFieldSpecified;
        
        private string sigCertNameField;
        
        private string x509SubjectNameField;
        
        private string x509SerialNumberField;
        
        private string x509IssuerNameField;
        
        private bool integrityField;
        
        private SignaturePropertiesTypeCertValidity certValidityField;
        
        private bool qualifiedSignatureField;
        
        /// <remarks/>
        public System.DateTime CertCheckTime {
            get {
                return this.certCheckTimeField;
            }
            set {
                this.certCheckTimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime SigningTime {
            get {
                return this.signingTimeField;
            }
            set {
                this.signingTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SigningTimeSpecified {
            get {
                return this.signingTimeFieldSpecified;
            }
            set {
                this.signingTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string SigCertName {
            get {
                return this.sigCertNameField;
            }
            set {
                this.sigCertNameField = value;
            }
        }
        
        /// <remarks/>
        public string X509SubjectName {
            get {
                return this.x509SubjectNameField;
            }
            set {
                this.x509SubjectNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string X509SerialNumber {
            get {
                return this.x509SerialNumberField;
            }
            set {
                this.x509SerialNumberField = value;
            }
        }
        
        /// <remarks/>
        public string X509IssuerName {
            get {
                return this.x509IssuerNameField;
            }
            set {
                this.x509IssuerNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool integrity {
            get {
                return this.integrityField;
            }
            set {
                this.integrityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public SignaturePropertiesTypeCertValidity certValidity {
            get {
                return this.certValidityField;
            }
            set {
                this.certValidityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool qualifiedSignature {
            get {
                return this.qualifiedSignatureField;
            }
            set {
                this.qualifiedSignatureField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum SignaturePropertiesTypeCertValidity {
        
        /// <remarks/>
        valid,
        
        /// <remarks/>
        invalid,
        
        /// <remarks/>
        unknown,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum AttachmentTypeStatus {
        
        /// <remarks/>
        valid,
        
        /// <remarks/>
        invalid,
        
        /// <remarks/>
        unknown,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class OSCIContentType {
        
        private string oSCIContentNameField;
        
        private string stylesheetField;
        
        /// <remarks/>
        public string OSCIContentName {
            get {
                return this.oSCIContentNameField;
            }
            set {
                this.oSCIContentNameField = value;
            }
        }
        
        /// <remarks/>
        public string Stylesheet {
            get {
                return this.stylesheetField;
            }
            set {
                this.stylesheetField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BusinessCardType {
        
        private string addressField;
        
        private string titleField;
        
        private string nameField;
        
        private string christianNameField;
        
        private string organizationField;
        
        private string organisationalUnitField;
        
        private string streetField;
        
        private string streetNumberField;
        
        private string zipCodeField;
        
        private string cityField;
        
        private string countryField;
        
        private string federalStateField;
        
        private string emailField;
        
        private string cellPhoneField;
        
        private string phoneField;
        
        private string faxField;
        
        private string userIDField;
        
        private string filterIDField;
        
        private string roleField;
        
        /// <remarks/>
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string ChristianName {
            get {
                return this.christianNameField;
            }
            set {
                this.christianNameField = value;
            }
        }
        
        /// <remarks/>
        public string Organization {
            get {
                return this.organizationField;
            }
            set {
                this.organizationField = value;
            }
        }
        
        /// <remarks/>
        public string OrganisationalUnit {
            get {
                return this.organisationalUnitField;
            }
            set {
                this.organisationalUnitField = value;
            }
        }
        
        /// <remarks/>
        public string Street {
            get {
                return this.streetField;
            }
            set {
                this.streetField = value;
            }
        }
        
        /// <remarks/>
        public string StreetNumber {
            get {
                return this.streetNumberField;
            }
            set {
                this.streetNumberField = value;
            }
        }
        
        /// <remarks/>
        public string ZipCode {
            get {
                return this.zipCodeField;
            }
            set {
                this.zipCodeField = value;
            }
        }
        
        /// <remarks/>
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public string Country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }
        
        /// <remarks/>
        public string FederalState {
            get {
                return this.federalStateField;
            }
            set {
                this.federalStateField = value;
            }
        }
        
        /// <remarks/>
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public string CellPhone {
            get {
                return this.cellPhoneField;
            }
            set {
                this.cellPhoneField = value;
            }
        }
        
        /// <remarks/>
        public string Phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
            }
        }
        
        /// <remarks/>
        public string Fax {
            get {
                return this.faxField;
            }
            set {
                this.faxField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="NMTOKEN")]
        public string UserID {
            get {
                return this.userIDField;
            }
            set {
                this.userIDField = value;
            }
        }
        
        /// <remarks/>
        public string FilterID {
            get {
                return this.filterIDField;
            }
            set {
                this.filterIDField = value;
            }
        }
        
        /// <remarks/>
        public string Role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum ExportMsgTypeStatus {
        
        /// <remarks/>
        valid,
        
        /// <remarks/>
        invalid,
        
        /// <remarks/>
        unknown,
    }
}