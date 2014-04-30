﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestApi.CarServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CarRequest", Namespace="http://schemas.datacontract.org/2004/07/DataContract")]
    [System.SerializableAttribute()]
    public partial class CarRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int YearField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Year {
            get {
                return this.YearField;
            }
            set {
                if ((this.YearField.Equals(value) != true)) {
                    this.YearField = value;
                    this.RaisePropertyChanged("Year");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateCar", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class CreateCar : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RestApi.CarServiceReference.CarRequest inputCarRequestField;
        
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
        public RestApi.CarServiceReference.CarRequest inputCarRequest {
            get {
                return this.inputCarRequestField;
            }
            set {
                if ((object.ReferenceEquals(this.inputCarRequestField, value) != true)) {
                    this.inputCarRequestField = value;
                    this.RaisePropertyChanged("inputCarRequest");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="GetCarById", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class GetCarById : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int inputCarIdField;
        
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
        public int inputCarId {
            get {
                return this.inputCarIdField;
            }
            set {
                if ((this.inputCarIdField.Equals(value) != true)) {
                    this.inputCarIdField = value;
                    this.RaisePropertyChanged("inputCarId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CarServiceReference.IService")]
    public interface IService {
        
        // CODEGEN: Generating message contract since the operation CreateCar is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateCar", ReplyAction="http://tempuri.org/IService/CreateCarResponse")]
        RestApi.CarServiceReference.CreateCarResponse CreateCar(RestApi.CarServiceReference.CreateCarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateCar", ReplyAction="http://tempuri.org/IService/CreateCarResponse")]
        System.Threading.Tasks.Task<RestApi.CarServiceReference.CreateCarResponse> CreateCarAsync(RestApi.CarServiceReference.CreateCarRequest request);
        
        // CODEGEN: Generating message contract since the operation DeleteCar is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteCar", ReplyAction="http://tempuri.org/IService/DeleteCarResponse")]
        RestApi.CarServiceReference.DeleteCarResponse DeleteCar(RestApi.CarServiceReference.DeleteCarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteCar", ReplyAction="http://tempuri.org/IService/DeleteCarResponse")]
        System.Threading.Tasks.Task<RestApi.CarServiceReference.DeleteCarResponse> DeleteCarAsync(RestApi.CarServiceReference.DeleteCarRequest request);
        
        // CODEGEN: Generating message contract since the operation GetCarById is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCarById", ReplyAction="http://tempuri.org/IService/GetCarByIdResponse")]
        RestApi.CarServiceReference.GetCarByIdResponse GetCarById(RestApi.CarServiceReference.GetCarByIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCarById", ReplyAction="http://tempuri.org/IService/GetCarByIdResponse")]
        System.Threading.Tasks.Task<RestApi.CarServiceReference.GetCarByIdResponse> GetCarByIdAsync(RestApi.CarServiceReference.GetCarByIdRequest request);
        
        // CODEGEN: Generating message contract since the operation GetAllCars is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllCars", ReplyAction="http://tempuri.org/IService/GetAllCarsResponse")]
        RestApi.CarServiceReference.GetAllCarsResponse GetAllCars(RestApi.CarServiceReference.GetAllCarsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllCars", ReplyAction="http://tempuri.org/IService/GetAllCarsResponse")]
        System.Threading.Tasks.Task<RestApi.CarServiceReference.GetAllCarsResponse> GetAllCarsAsync(RestApi.CarServiceReference.GetAllCarsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateCarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public RestApi.CarServiceReference.CreateCar CreateCar;
        
        public CreateCarRequest() {
        }
        
        public CreateCarRequest(RestApi.CarServiceReference.CreateCar CreateCar) {
            this.CreateCar = CreateCar;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateCarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/", Order=0)]
        public System.Nullable<int> @int;
        
        public CreateCarResponse() {
        }
        
        public CreateCarResponse(System.Nullable<int> @int) {
            this.@int = @int;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteCar", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DeleteCarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int inputCarId;
        
        public DeleteCarRequest() {
        }
        
        public DeleteCarRequest(int inputCarId) {
            this.inputCarId = inputCarId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteCarResponse {
        
        public DeleteCarResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCarByIdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public RestApi.CarServiceReference.GetCarById GetCarById;
        
        public GetCarByIdRequest() {
        }
        
        public GetCarByIdRequest(RestApi.CarServiceReference.GetCarById GetCarById) {
            this.GetCarById = GetCarById;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCarByIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.datacontract.org/2004/07/DataContract", Order=0)]
        public RestApi.CarServiceReference.CarRequest CarRequest;
        
        public GetCarByIdResponse() {
        }
        
        public GetCarByIdResponse(RestApi.CarServiceReference.CarRequest CarRequest) {
            this.CarRequest = CarRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllCarsRequest {
        
        public GetAllCarsRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllCarsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.datacontract.org/2004/07/DataContract", Order=0)]
        public RestApi.CarServiceReference.CarRequest[] ArrayOfCarRequest;
        
        public GetAllCarsResponse() {
        }
        
        public GetAllCarsResponse(RestApi.CarServiceReference.CarRequest[] ArrayOfCarRequest) {
            this.ArrayOfCarRequest = ArrayOfCarRequest;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : RestApi.CarServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<RestApi.CarServiceReference.IService>, RestApi.CarServiceReference.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RestApi.CarServiceReference.CreateCarResponse RestApi.CarServiceReference.IService.CreateCar(RestApi.CarServiceReference.CreateCarRequest request) {
            return base.Channel.CreateCar(request);
        }
        
        public System.Nullable<int> CreateCar(RestApi.CarServiceReference.CreateCar CreateCar1) {
            RestApi.CarServiceReference.CreateCarRequest inValue = new RestApi.CarServiceReference.CreateCarRequest();
            inValue.CreateCar = CreateCar1;
            RestApi.CarServiceReference.CreateCarResponse retVal = ((RestApi.CarServiceReference.IService)(this)).CreateCar(inValue);
            return retVal.@int;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RestApi.CarServiceReference.CreateCarResponse> RestApi.CarServiceReference.IService.CreateCarAsync(RestApi.CarServiceReference.CreateCarRequest request) {
            return base.Channel.CreateCarAsync(request);
        }
        
        public System.Threading.Tasks.Task<RestApi.CarServiceReference.CreateCarResponse> CreateCarAsync(RestApi.CarServiceReference.CreateCar CreateCar) {
            RestApi.CarServiceReference.CreateCarRequest inValue = new RestApi.CarServiceReference.CreateCarRequest();
            inValue.CreateCar = CreateCar;
            return ((RestApi.CarServiceReference.IService)(this)).CreateCarAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RestApi.CarServiceReference.DeleteCarResponse RestApi.CarServiceReference.IService.DeleteCar(RestApi.CarServiceReference.DeleteCarRequest request) {
            return base.Channel.DeleteCar(request);
        }
        
        public void DeleteCar(int inputCarId) {
            RestApi.CarServiceReference.DeleteCarRequest inValue = new RestApi.CarServiceReference.DeleteCarRequest();
            inValue.inputCarId = inputCarId;
            RestApi.CarServiceReference.DeleteCarResponse retVal = ((RestApi.CarServiceReference.IService)(this)).DeleteCar(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RestApi.CarServiceReference.DeleteCarResponse> RestApi.CarServiceReference.IService.DeleteCarAsync(RestApi.CarServiceReference.DeleteCarRequest request) {
            return base.Channel.DeleteCarAsync(request);
        }
        
        public System.Threading.Tasks.Task<RestApi.CarServiceReference.DeleteCarResponse> DeleteCarAsync(int inputCarId) {
            RestApi.CarServiceReference.DeleteCarRequest inValue = new RestApi.CarServiceReference.DeleteCarRequest();
            inValue.inputCarId = inputCarId;
            return ((RestApi.CarServiceReference.IService)(this)).DeleteCarAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RestApi.CarServiceReference.GetCarByIdResponse RestApi.CarServiceReference.IService.GetCarById(RestApi.CarServiceReference.GetCarByIdRequest request) {
            return base.Channel.GetCarById(request);
        }
        
        public RestApi.CarServiceReference.CarRequest GetCarById(RestApi.CarServiceReference.GetCarById GetCarById1) {
            RestApi.CarServiceReference.GetCarByIdRequest inValue = new RestApi.CarServiceReference.GetCarByIdRequest();
            inValue.GetCarById = GetCarById1;
            RestApi.CarServiceReference.GetCarByIdResponse retVal = ((RestApi.CarServiceReference.IService)(this)).GetCarById(inValue);
            return retVal.CarRequest;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RestApi.CarServiceReference.GetCarByIdResponse> RestApi.CarServiceReference.IService.GetCarByIdAsync(RestApi.CarServiceReference.GetCarByIdRequest request) {
            return base.Channel.GetCarByIdAsync(request);
        }
        
        public System.Threading.Tasks.Task<RestApi.CarServiceReference.GetCarByIdResponse> GetCarByIdAsync(RestApi.CarServiceReference.GetCarById GetCarById) {
            RestApi.CarServiceReference.GetCarByIdRequest inValue = new RestApi.CarServiceReference.GetCarByIdRequest();
            inValue.GetCarById = GetCarById;
            return ((RestApi.CarServiceReference.IService)(this)).GetCarByIdAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RestApi.CarServiceReference.GetAllCarsResponse RestApi.CarServiceReference.IService.GetAllCars(RestApi.CarServiceReference.GetAllCarsRequest request) {
            return base.Channel.GetAllCars(request);
        }
        
        public RestApi.CarServiceReference.CarRequest[] GetAllCars() {
            RestApi.CarServiceReference.GetAllCarsRequest inValue = new RestApi.CarServiceReference.GetAllCarsRequest();
            RestApi.CarServiceReference.GetAllCarsResponse retVal = ((RestApi.CarServiceReference.IService)(this)).GetAllCars(inValue);
            return retVal.ArrayOfCarRequest;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RestApi.CarServiceReference.GetAllCarsResponse> RestApi.CarServiceReference.IService.GetAllCarsAsync(RestApi.CarServiceReference.GetAllCarsRequest request) {
            return base.Channel.GetAllCarsAsync(request);
        }
        
        public System.Threading.Tasks.Task<RestApi.CarServiceReference.GetAllCarsResponse> GetAllCarsAsync() {
            RestApi.CarServiceReference.GetAllCarsRequest inValue = new RestApi.CarServiceReference.GetAllCarsRequest();
            return ((RestApi.CarServiceReference.IService)(this)).GetAllCarsAsync(inValue);
        }
    }
}
