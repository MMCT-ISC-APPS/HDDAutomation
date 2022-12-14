//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace MachineDLL.MailManager {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DominoSoapBinding", Namespace="urn:DefaultNamespace")]
    public partial class getManagerOfOwnerService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback READMANAGEROFOWNEROperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public getManagerOfOwnerService() {
            this.Url = global::MachineDLL.Properties.Settings.Default.MachineDLL_MailManager_getManagerOfOwnerService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event READMANAGEROFOWNERCompletedEventHandler READMANAGEROFOWNERCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("READMANAGEROFOWNER", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("READMANAGEROFOWNERReturn", Namespace="urn:DefaultNamespace")]
        public EMPLOYEEMANAGEROFOWNER READMANAGEROFOWNER([System.Xml.Serialization.XmlElementAttribute(Namespace="urn:DefaultNamespace")] string EMPNO) {
            object[] results = this.Invoke("READMANAGEROFOWNER", new object[] {
                        EMPNO});
            return ((EMPLOYEEMANAGEROFOWNER)(results[0]));
        }
        
        /// <remarks/>
        public void READMANAGEROFOWNERAsync(string EMPNO) {
            this.READMANAGEROFOWNERAsync(EMPNO, null);
        }
        
        /// <remarks/>
        public void READMANAGEROFOWNERAsync(string EMPNO, object userState) {
            if ((this.READMANAGEROFOWNEROperationCompleted == null)) {
                this.READMANAGEROFOWNEROperationCompleted = new System.Threading.SendOrPostCallback(this.OnREADMANAGEROFOWNEROperationCompleted);
            }
            this.InvokeAsync("READMANAGEROFOWNER", new object[] {
                        EMPNO}, this.READMANAGEROFOWNEROperationCompleted, userState);
        }
        
        private void OnREADMANAGEROFOWNEROperationCompleted(object arg) {
            if ((this.READMANAGEROFOWNERCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.READMANAGEROFOWNERCompleted(this, new READMANAGEROFOWNERCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:DefaultNamespace")]
    public partial class EMPLOYEEMANAGEROFOWNER {
        
        private string uSERNAMEField;
        
        private string eMAILField;
        
        private string dEPARTMENTField;
        
        private short sTATUSField;
        
        private string eMPLOYEENOField;
        
        private string aPPLEVELField;
        
        private string eRRORMESSAGEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string USERNAME {
            get {
                return this.uSERNAMEField;
            }
            set {
                this.uSERNAMEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EMAIL {
            get {
                return this.eMAILField;
            }
            set {
                this.eMAILField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DEPARTMENT {
            get {
                return this.dEPARTMENTField;
            }
            set {
                this.dEPARTMENTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public short STATUS {
            get {
                return this.sTATUSField;
            }
            set {
                this.sTATUSField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EMPLOYEENO {
            get {
                return this.eMPLOYEENOField;
            }
            set {
                this.eMPLOYEENOField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string APPLEVEL {
            get {
                return this.aPPLEVELField;
            }
            set {
                this.aPPLEVELField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ERRORMESSAGE {
            get {
                return this.eRRORMESSAGEField;
            }
            set {
                this.eRRORMESSAGEField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void READMANAGEROFOWNERCompletedEventHandler(object sender, READMANAGEROFOWNERCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class READMANAGEROFOWNERCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal READMANAGEROFOWNERCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public EMPLOYEEMANAGEROFOWNER Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((EMPLOYEEMANAGEROFOWNER)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591