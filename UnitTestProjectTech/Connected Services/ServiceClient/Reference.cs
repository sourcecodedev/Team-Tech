﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTestProjectTech.ServiceClient {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonaNatural", Namespace="http://schemas.datacontract.org/2004/07/ServicesTech.Dominio")]
    [System.SerializableAttribute()]
    public partial class PersonaNatural : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string apellido_maternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string apellido_paternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string caracter_verificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string caracter_verificacion_anteriorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string dniField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombresField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string apellido_materno {
            get {
                return this.apellido_maternoField;
            }
            set {
                if ((object.ReferenceEquals(this.apellido_maternoField, value) != true)) {
                    this.apellido_maternoField = value;
                    this.RaisePropertyChanged("apellido_materno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string apellido_paterno {
            get {
                return this.apellido_paternoField;
            }
            set {
                if ((object.ReferenceEquals(this.apellido_paternoField, value) != true)) {
                    this.apellido_paternoField = value;
                    this.RaisePropertyChanged("apellido_paterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string caracter_verificacion {
            get {
                return this.caracter_verificacionField;
            }
            set {
                if ((object.ReferenceEquals(this.caracter_verificacionField, value) != true)) {
                    this.caracter_verificacionField = value;
                    this.RaisePropertyChanged("caracter_verificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string caracter_verificacion_anterior {
            get {
                return this.caracter_verificacion_anteriorField;
            }
            set {
                if ((object.ReferenceEquals(this.caracter_verificacion_anteriorField, value) != true)) {
                    this.caracter_verificacion_anteriorField = value;
                    this.RaisePropertyChanged("caracter_verificacion_anterior");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string dni {
            get {
                return this.dniField;
            }
            set {
                if ((object.ReferenceEquals(this.dniField, value) != true)) {
                    this.dniField = value;
                    this.RaisePropertyChanged("dni");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombres {
            get {
                return this.nombresField;
            }
            set {
                if ((object.ReferenceEquals(this.nombresField, value) != true)) {
                    this.nombresField = value;
                    this.RaisePropertyChanged("nombres");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Empresa", Namespace="http://schemas.datacontract.org/2004/07/ServicesTech.Dominio")]
    [System.SerializableAttribute()]
    public partial class Empresa : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string actividad_comercio_exteriorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string condicion_contribuyenteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string direccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string estado_contribuyenteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string fecha_inicio_actividadesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string fecha_inscripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombre_comercialField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string razon_socialField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string rucField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string sistema_contabilidadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tipo_contribuyenteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string actividad_comercio_exterior {
            get {
                return this.actividad_comercio_exteriorField;
            }
            set {
                if ((object.ReferenceEquals(this.actividad_comercio_exteriorField, value) != true)) {
                    this.actividad_comercio_exteriorField = value;
                    this.RaisePropertyChanged("actividad_comercio_exterior");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string condicion_contribuyente {
            get {
                return this.condicion_contribuyenteField;
            }
            set {
                if ((object.ReferenceEquals(this.condicion_contribuyenteField, value) != true)) {
                    this.condicion_contribuyenteField = value;
                    this.RaisePropertyChanged("condicion_contribuyente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string direccion {
            get {
                return this.direccionField;
            }
            set {
                if ((object.ReferenceEquals(this.direccionField, value) != true)) {
                    this.direccionField = value;
                    this.RaisePropertyChanged("direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string estado_contribuyente {
            get {
                return this.estado_contribuyenteField;
            }
            set {
                if ((object.ReferenceEquals(this.estado_contribuyenteField, value) != true)) {
                    this.estado_contribuyenteField = value;
                    this.RaisePropertyChanged("estado_contribuyente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string fecha_inicio_actividades {
            get {
                return this.fecha_inicio_actividadesField;
            }
            set {
                if ((object.ReferenceEquals(this.fecha_inicio_actividadesField, value) != true)) {
                    this.fecha_inicio_actividadesField = value;
                    this.RaisePropertyChanged("fecha_inicio_actividades");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string fecha_inscripcion {
            get {
                return this.fecha_inscripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.fecha_inscripcionField, value) != true)) {
                    this.fecha_inscripcionField = value;
                    this.RaisePropertyChanged("fecha_inscripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombre_comercial {
            get {
                return this.nombre_comercialField;
            }
            set {
                if ((object.ReferenceEquals(this.nombre_comercialField, value) != true)) {
                    this.nombre_comercialField = value;
                    this.RaisePropertyChanged("nombre_comercial");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string razon_social {
            get {
                return this.razon_socialField;
            }
            set {
                if ((object.ReferenceEquals(this.razon_socialField, value) != true)) {
                    this.razon_socialField = value;
                    this.RaisePropertyChanged("razon_social");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ruc {
            get {
                return this.rucField;
            }
            set {
                if ((object.ReferenceEquals(this.rucField, value) != true)) {
                    this.rucField = value;
                    this.RaisePropertyChanged("ruc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string sistema_contabilidad {
            get {
                return this.sistema_contabilidadField;
            }
            set {
                if ((object.ReferenceEquals(this.sistema_contabilidadField, value) != true)) {
                    this.sistema_contabilidadField = value;
                    this.RaisePropertyChanged("sistema_contabilidad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tipo_contribuyente {
            get {
                return this.tipo_contribuyenteField;
            }
            set {
                if ((object.ReferenceEquals(this.tipo_contribuyenteField, value) != true)) {
                    this.tipo_contribuyenteField = value;
                    this.RaisePropertyChanged("tipo_contribuyente");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Client", Namespace="http://schemas.datacontract.org/2004/07/ServicesTech.Dominio")]
    [System.SerializableAttribute()]
    public partial class Client : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AsessorCommercialField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Direccion_clientField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Identificador_clientField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Nombres_clientField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PersonaNaturalIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string canalAtencionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string celularField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int distritoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string identificador_representanteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string mailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string representateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tipo_clienteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AsessorCommercial {
            get {
                return this.AsessorCommercialField;
            }
            set {
                if ((object.ReferenceEquals(this.AsessorCommercialField, value) != true)) {
                    this.AsessorCommercialField = value;
                    this.RaisePropertyChanged("AsessorCommercial");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Direccion_client {
            get {
                return this.Direccion_clientField;
            }
            set {
                if ((object.ReferenceEquals(this.Direccion_clientField, value) != true)) {
                    this.Direccion_clientField = value;
                    this.RaisePropertyChanged("Direccion_client");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Identificador_client {
            get {
                return this.Identificador_clientField;
            }
            set {
                if ((object.ReferenceEquals(this.Identificador_clientField, value) != true)) {
                    this.Identificador_clientField = value;
                    this.RaisePropertyChanged("Identificador_client");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombres_client {
            get {
                return this.Nombres_clientField;
            }
            set {
                if ((object.ReferenceEquals(this.Nombres_clientField, value) != true)) {
                    this.Nombres_clientField = value;
                    this.RaisePropertyChanged("Nombres_client");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PersonaNaturalId {
            get {
                return this.PersonaNaturalIdField;
            }
            set {
                if ((this.PersonaNaturalIdField.Equals(value) != true)) {
                    this.PersonaNaturalIdField = value;
                    this.RaisePropertyChanged("PersonaNaturalId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string canalAtencion {
            get {
                return this.canalAtencionField;
            }
            set {
                if ((object.ReferenceEquals(this.canalAtencionField, value) != true)) {
                    this.canalAtencionField = value;
                    this.RaisePropertyChanged("canalAtencion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string celular {
            get {
                return this.celularField;
            }
            set {
                if ((object.ReferenceEquals(this.celularField, value) != true)) {
                    this.celularField = value;
                    this.RaisePropertyChanged("celular");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int distrito {
            get {
                return this.distritoField;
            }
            set {
                if ((this.distritoField.Equals(value) != true)) {
                    this.distritoField = value;
                    this.RaisePropertyChanged("distrito");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string identificador_representante {
            get {
                return this.identificador_representanteField;
            }
            set {
                if ((object.ReferenceEquals(this.identificador_representanteField, value) != true)) {
                    this.identificador_representanteField = value;
                    this.RaisePropertyChanged("identificador_representante");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string mail {
            get {
                return this.mailField;
            }
            set {
                if ((object.ReferenceEquals(this.mailField, value) != true)) {
                    this.mailField = value;
                    this.RaisePropertyChanged("mail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string representate {
            get {
                return this.representateField;
            }
            set {
                if ((object.ReferenceEquals(this.representateField, value) != true)) {
                    this.representateField = value;
                    this.RaisePropertyChanged("representate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tipo_cliente {
            get {
                return this.tipo_clienteField;
            }
            set {
                if ((object.ReferenceEquals(this.tipo_clienteField, value) != true)) {
                    this.tipo_clienteField = value;
                    this.RaisePropertyChanged("tipo_cliente");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceClient.IServiceClient")]
    public interface IServiceClient {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClient/ConsultDatosPersonal", ReplyAction="http://tempuri.org/IServiceClient/ConsultDatosPersonalResponse")]
        UnitTestProjectTech.ServiceClient.PersonaNatural ConsultDatosPersonal(string dni);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClient/ConsultDatosPersonal", ReplyAction="http://tempuri.org/IServiceClient/ConsultDatosPersonalResponse")]
        System.Threading.Tasks.Task<UnitTestProjectTech.ServiceClient.PersonaNatural> ConsultDatosPersonalAsync(string dni);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClient/ConsultDatosCompany", ReplyAction="http://tempuri.org/IServiceClient/ConsultDatosCompanyResponse")]
        UnitTestProjectTech.ServiceClient.Empresa ConsultDatosCompany(string RUC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClient/ConsultDatosCompany", ReplyAction="http://tempuri.org/IServiceClient/ConsultDatosCompanyResponse")]
        System.Threading.Tasks.Task<UnitTestProjectTech.ServiceClient.Empresa> ConsultDatosCompanyAsync(string RUC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClient/InsertDataClient", ReplyAction="http://tempuri.org/IServiceClient/InsertDataClientResponse")]
        int InsertDataClient(UnitTestProjectTech.ServiceClient.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClient/InsertDataClient", ReplyAction="http://tempuri.org/IServiceClient/InsertDataClientResponse")]
        System.Threading.Tasks.Task<int> InsertDataClientAsync(UnitTestProjectTech.ServiceClient.Client client);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceClientChannel : UnitTestProjectTech.ServiceClient.IServiceClient, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClientClient : System.ServiceModel.ClientBase<UnitTestProjectTech.ServiceClient.IServiceClient>, UnitTestProjectTech.ServiceClient.IServiceClient {
        
        public ServiceClientClient() {
        }
        
        public ServiceClientClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClientClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClientClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClientClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public UnitTestProjectTech.ServiceClient.PersonaNatural ConsultDatosPersonal(string dni) {
            return base.Channel.ConsultDatosPersonal(dni);
        }
        
        public System.Threading.Tasks.Task<UnitTestProjectTech.ServiceClient.PersonaNatural> ConsultDatosPersonalAsync(string dni) {
            return base.Channel.ConsultDatosPersonalAsync(dni);
        }
        
        public UnitTestProjectTech.ServiceClient.Empresa ConsultDatosCompany(string RUC) {
            return base.Channel.ConsultDatosCompany(RUC);
        }
        
        public System.Threading.Tasks.Task<UnitTestProjectTech.ServiceClient.Empresa> ConsultDatosCompanyAsync(string RUC) {
            return base.Channel.ConsultDatosCompanyAsync(RUC);
        }
        
        public int InsertDataClient(UnitTestProjectTech.ServiceClient.Client client) {
            return base.Channel.InsertDataClient(client);
        }
        
        public System.Threading.Tasks.Task<int> InsertDataClientAsync(UnitTestProjectTech.ServiceClient.Client client) {
            return base.Channel.InsertDataClientAsync(client);
        }
    }
}
