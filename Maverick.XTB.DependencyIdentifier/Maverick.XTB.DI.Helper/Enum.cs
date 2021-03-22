﻿using System;
using System.Collections.Generic;
using System.Text;
using Maverick.XTB.DI.CustomAttributes;

namespace Maverick.XTB.DI.Helper
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

        public enum ComponentType
        {
            [DisplayName("Forms")]
            SystemForm = 60,

            [DisplayName("Attributes")]
            Attribute = 2,

            [DisplayName("Views")]
            SavedQuery = 26

            /* // List of attributes not supported as of now
            Entity = 1,
            Relationship = 3,
            AttributePicklistValue = 4,
            AttributeLookupValue = 5,
            ViewAttribute = 6,
            LocalizedLabel = 7,
            RelationshipExtraCondition = 8,
            OptionSet = 9,
            EntityRelationship = 10,
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
            Report = 31,
            ReportEntity = 32,
            ReportCategory = 33,
            ReportVisibility = 34,
            Attachment = 35,
            EmailTemplate = 36,
            ContractTemplate = 37,
            KBArticleTemplate = 38,
            MailMergeTemplate = 39,
            DuplicateRule = 44,
            DuplicateRuleCondition = 45,
            EntityMap = 46,
            AttributeMap = 47,
            RibbonCommand = 48,
            RibbonContextGroup = 49,
            RibbonCustomization = 50,
            RibbonRule = 52,
            RibbonTabToCommandMap = 53,
            RibbonDiff = 55,
            SavedQueryVisualization = 59,
            WebResource = 61,
            SiteMap = 62,
            ConnectionRole = 63,
            FieldSecurityProfile = 70,
            FieldPermission = 71,
            PluginType = 90,
            PluginAssembly = 91,
            SDKMessageProcessingStep = 92,
            SDKMessageProcessingStepImage = 93,
            ServiceEndpoint = 95,
            RoutingRule = 150,
            RoutingRuleItem = 151,
            SLA = 152,
            SLAItem = 153,
            ConvertRule = 154,
            ConvertRuleItem = 155,
            HierarchyRule = 65,
            MobileOfflineProfile = 161,
            MobileOfflineProfileItem = 162,
            SimilarityRule = 165,
            CustomControl = 66,
            CustomControlDefaultConfig = 68,
            */
        }
    }
}
