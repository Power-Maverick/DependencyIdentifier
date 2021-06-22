using System;
using System.Collections.Generic;
using System.Text;
using Maverick.Xrm.DI.CustomAttributes;

namespace Maverick.Xrm.DI.Helper
{
    public class Enum
    {
        public enum LogLevel
        {
            Success,
            Info,
            Warning,
            Error
        }

        public enum ListViewDisplayType
        {
            Entities,
            ComponentTypes
        }

        public enum FormType
        {
            Dashboard = 0,
            AppointmentBook = 1,
            Main = 2,
            MiniCampaignBO = 3,
            Preview = 4,
            MobileExpress = 5,
            QuickView = 6,
            QuickCreate = 7,
            Dialog = 8,
            TaskFlow = 9,
            InteractionCentricDashboard = 10,
            Card = 11,
            MainInteractiveExperience = 12,
            Other = 13,
            MainBackup = 14,
            AppointmentBookBackup = 15,
            PowerBIDashboard = 16
        }

        public enum SdkMessageStepStage
        {
            PreValidation = 10,
            PreOperation = 20,
            PostOperation = 40
        }

        public enum UserOperations
        {
            EntitiesLoaded,
            DependenciesGenerated
        }

        public enum ComponentType
        {
            [Display("Entity")]
            Entity = 1,

            [Display("Forms")]
            SystemForm = 60,

            [Display("Attributes")]
            Attribute = 2,

            [Display("Views")]
            SavedQuery = 26,

            [Display("Choice")]
            OptionSet = 9,

            [Display("Entity Relationship")]
            EntityRelationship = 10,

            [Display("Plugin Step")]
            SDKMessageProcessingStep = 92,

            [Display("Entity Map")]
            EntityMap = 46,

            [Display("Model-driven App")]
            ModelDrivenApp = 80,

            [Display("Sitemap")]
            SiteMap = 62,

            [Display("Mobile Offline Profile")]
            MobileOfflineProfile = 161,

            [Display("Email Template")]
            EmailTemplate = 36,

            [Display("Mail Merge Template")]
            MailMergeTemplate = 39,

            [Display("Report")]
            Report = 31,

            /*// List of attributes not supported as of now

            Relationship = 3,
            AttributePicklistValue = 4,
            AttributeLookupValue = 5,
            ViewAttribute = 6,
            LocalizedLabel = 7,
            RelationshipExtraCondition = 8,
            
            
            EntityRelationshipRole = 11,
            EntityRelationshipRelationships = 12,
            ManagedProperty = 13,
            EntityKey = 14,
            Role = 20,
            RolePrivilege = 21,
            DisplayString = 22,
            DisplayStringMap = 23,
            Form = 24,
            Organization = 25,

            Workflow = 29,
            
            ReportEntity = 32,
            ReportCategory = 33,
            ReportVisibility = 34,
            Attachment = 35,
            
            ContractTemplate = 37,
            KBArticleTemplate = 38,
            
            DuplicateRule = 44,
            DuplicateRuleCondition = 45,
            
            AttributeMap = 47,
            RibbonCommand = 48,
            RibbonContextGroup = 49,
            RibbonCustomization = 50,
            RibbonRule = 52,
            RibbonTabToCommandMap = 53,
            RibbonDiff = 55,
            SavedQueryVisualization = 59,
            WebResource = 61,
            
            ConnectionRole = 63,
            HierarchyRule = 65,
            CustomControl = 66,
            CustomControlDefaultConfig = 68,
            FieldSecurityProfile = 70,
            FieldPermission = 71,
            
            PluginType = 90,
            PluginAssembly = 91,
            
            SDKMessageProcessingStepImage = 93,
            ServiceEndpoint = 95,
            RoutingRule = 150,
            RoutingRuleItem = 151,
            SLA = 152,
            SLAItem = 153,
            ConvertRule = 154,
            ConvertRuleItem = 155,
            
            
            MobileOfflineProfileItem = 162,
            SimilarityRule = 165,
            DataSourceMapping = 166,
            SDKMessage = 201,
            SDKMessageFilter = 202,
            SdkMessagePair = 203,
            SdkMessageRequest = 204,
            SdkMessageRequestField = 205,
            SdkMessageResponse = 206,
            SdkMessageResponseField = 207,
            Import Map = 208,
            WebWizard = 210,
            Canvas App = 300,
            Connector = 371,
            */
        }
    }
}
