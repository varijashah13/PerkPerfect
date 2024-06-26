﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace client.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FoodItem", Namespace="http://schemas.datacontract.org/2004/07/fooditems_servicelibrary")]
    [System.SerializableAttribute()]
    public partial class FoodItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string foodNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string priceField;
        
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
        public string foodName {
            get {
                return this.foodNameField;
            }
            set {
                if ((object.ReferenceEquals(this.foodNameField, value) != true)) {
                    this.foodNameField = value;
                    this.RaisePropertyChanged("foodName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string price {
            get {
                return this.priceField;
            }
            set {
                if ((object.ReferenceEquals(this.priceField, value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.Ifooditemsservice")]
    public interface Ifooditemsservice {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/GetFoodItems", ReplyAction="http://tempuri.org/Ifooditemsservice/GetFoodItemsResponse")]
        System.Data.DataSet GetFoodItems();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/GetFoodItems", ReplyAction="http://tempuri.org/Ifooditemsservice/GetFoodItemsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetFoodItemsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/AddFoodItem", ReplyAction="http://tempuri.org/Ifooditemsservice/AddFoodItemResponse")]
        void AddFoodItem(client.ServiceReference2.FoodItem foodItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/AddFoodItem", ReplyAction="http://tempuri.org/Ifooditemsservice/AddFoodItemResponse")]
        System.Threading.Tasks.Task AddFoodItemAsync(client.ServiceReference2.FoodItem foodItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/GetFoodItem", ReplyAction="http://tempuri.org/Ifooditemsservice/GetFoodItemResponse")]
        client.ServiceReference2.FoodItem GetFoodItem(string foodName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/GetFoodItem", ReplyAction="http://tempuri.org/Ifooditemsservice/GetFoodItemResponse")]
        System.Threading.Tasks.Task<client.ServiceReference2.FoodItem> GetFoodItemAsync(string foodName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/UpdateFoodItem", ReplyAction="http://tempuri.org/Ifooditemsservice/UpdateFoodItemResponse")]
        void UpdateFoodItem(client.ServiceReference2.FoodItem foodItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/UpdateFoodItem", ReplyAction="http://tempuri.org/Ifooditemsservice/UpdateFoodItemResponse")]
        System.Threading.Tasks.Task UpdateFoodItemAsync(client.ServiceReference2.FoodItem foodItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/DeleteFoodItem", ReplyAction="http://tempuri.org/Ifooditemsservice/DeleteFoodItemResponse")]
        void DeleteFoodItem(string foodName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ifooditemsservice/DeleteFoodItem", ReplyAction="http://tempuri.org/Ifooditemsservice/DeleteFoodItemResponse")]
        System.Threading.Tasks.Task DeleteFoodItemAsync(string foodName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IfooditemsserviceChannel : client.ServiceReference2.Ifooditemsservice, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IfooditemsserviceClient : System.ServiceModel.ClientBase<client.ServiceReference2.Ifooditemsservice>, client.ServiceReference2.Ifooditemsservice {
        
        public IfooditemsserviceClient() {
        }
        
        public IfooditemsserviceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IfooditemsserviceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IfooditemsserviceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IfooditemsserviceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetFoodItems() {
            return base.Channel.GetFoodItems();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetFoodItemsAsync() {
            return base.Channel.GetFoodItemsAsync();
        }
        
        public void AddFoodItem(client.ServiceReference2.FoodItem foodItem) {
            base.Channel.AddFoodItem(foodItem);
        }
        
        public System.Threading.Tasks.Task AddFoodItemAsync(client.ServiceReference2.FoodItem foodItem) {
            return base.Channel.AddFoodItemAsync(foodItem);
        }
        
        public client.ServiceReference2.FoodItem GetFoodItem(string foodName) {
            return base.Channel.GetFoodItem(foodName);
        }
        
        public System.Threading.Tasks.Task<client.ServiceReference2.FoodItem> GetFoodItemAsync(string foodName) {
            return base.Channel.GetFoodItemAsync(foodName);
        }
        
        public void UpdateFoodItem(client.ServiceReference2.FoodItem foodItem) {
            base.Channel.UpdateFoodItem(foodItem);
        }
        
        public System.Threading.Tasks.Task UpdateFoodItemAsync(client.ServiceReference2.FoodItem foodItem) {
            return base.Channel.UpdateFoodItemAsync(foodItem);
        }
        
        public void DeleteFoodItem(string foodName) {
            base.Channel.DeleteFoodItem(foodName);
        }
        
        public System.Threading.Tasks.Task DeleteFoodItemAsync(string foodName) {
            return base.Channel.DeleteFoodItemAsync(foodName);
        }
    }
}
