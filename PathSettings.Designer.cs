﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrmManager {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
    internal sealed partial class PathSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static PathSettings defaultInstance = ((PathSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new PathSettings())));
        
        public static PathSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string path_sot_operator {
            get {
                return ((string)(this["path_sot_operator"]));
            }
            set {
                this["path_sot_operator"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Error {
            get {
                return ((string)(this["Error"]));
            }
            set {
                this["Error"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string path_phone_number {
            get {
                return ((string)(this["path_phone_number"]));
            }
            set {
                this["path_phone_number"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("99,77")]
        public string cutCodes {
            get {
                return ((string)(this["cutCodes"]));
            }
            set {
                this["cutCodes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string dbConnectionName {
            get {
                return ((string)(this["dbConnectionName"]));
            }
            set {
                this["dbConnectionName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int RepeatActualiz {
            get {
                return ((int)(this["RepeatActualiz"]));
            }
            set {
                this["RepeatActualiz"] = value;
            }
        }
    }
}