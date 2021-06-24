using Maverick.Xrm.DI.DataObjects;
using Maverick.Xrm.DI.Extensions;
using Maverick.XTB.DI.DataObjects;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Maverick.Xrm.DI.Helper
{
    public class DataverseHelper
    {
        static IOrganizationService Service = null;

        /// <summary>
        /// Rerieve all entities with the given filter conditions
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entityFilters"></param>
        /// <param name="retrieveAsIfPublished"></param>
        /// <returns></returns>
        public static List<EntityMetadata> RetrieveAllEntities(IOrganizationService service, List<EntityFilters> entityFilters = null, bool retrieveAsIfPublished = true)
        {
            Service = service;

            if (entityFilters == null)
            {
                entityFilters = new List<EntityFilters>() { EntityFilters.Default };
            }

            // build the bitwise or list of the entity filters
            var filters = entityFilters.Aggregate<EntityFilters, EntityFilters>(0, (current, item) => current | item);

            var req = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = filters,
                RetrieveAsIfPublished = retrieveAsIfPublished
            };
            var resp = (RetrieveAllEntitiesResponse)service.Execute(req);

            // set the itemsource of the itembox equal to entity metadata that is customizable (takes out systemjobs and stuff like that)
            var entities = resp.EntityMetadata.Where(x => x.IsCustomizable.Value == true).ToList<EntityMetadata>();

            return entities;
        }

        public static List<DependencyReport> GetDependencyList(IOrganizationService service, Guid objectId, int componentType)
        {
            List<DependencyReport> lstReport = new List<DependencyReport>();
            Service = service;

            var dependencyRequest = new RetrieveDependentComponentsRequest
            {
                ObjectId = objectId,
                ComponentType = componentType
            };

            var dependencyResponse = (RetrieveDependentComponentsResponse)service.Execute(dependencyRequest);

            // If there are no dependent components, we can ignore this component.
            if (dependencyResponse.EntityCollection.Entities.Any() == false)
                return lstReport;

            lstReport = ProcessDependencyList(service, dependencyResponse.EntityCollection);

            return lstReport;
        }

        public static List<DependencyReport> ProcessDependencyList(IOrganizationService service, EntityCollection dependencyEC)
        {
            List<DependencyReport> lstReport = new List<DependencyReport>();
            Service = service;

            // If there are no dependent components, we can ignore this component.
            if (dependencyEC.Entities.Any() == false)
                return lstReport;

            Parallel.ForEach(dependencyEC.Entities,
                new ParallelOptions { MaxDegreeOfParallelism = 10 },
                (dependentEntity) =>
                {
                    DependencyReport dr = GenerateDependencyReport(dependentEntity);
                    if (!dr.SkipAdding)
                    {
                        lstReport.Add(dr);
                    }
                });

            return lstReport;
        }

        #region Private Methods

        private static DependencyReport GenerateDependencyReport(Entity dependency)
        {
            DependencyReport dependencyReport = new DependencyReport();

            var lstComponentTypes = System.Enum.GetValues(typeof(Enum.ComponentType)).Cast<Enum.ComponentType>().ToList();
            foreach (var ct in lstComponentTypes)
            {
                var text = ct.GetAttribute<DI.CustomAttributes.DisplayAttribute>();

                if (((OptionSetValue)dependency["dependentcomponenttype"]).Value == (int)ct)
                {
                    dependencyReport.DependentComponentType = text.Name;
                }
                if (((OptionSetValue)dependency["requiredcomponenttype"]).Value == (int)ct)
                {
                    dependencyReport.RequiredComponentType = text.Name;
                }
            }

            ComponentInfo dependentCI = GetComponentName(((OptionSetValue)dependency["dependentcomponenttype"]).Value, (Guid)dependency["dependentcomponentobjectid"]);
            if (dependentCI != null)
            {
                dependencyReport.DependentComponentName = dependentCI.Name;
                dependencyReport.DependentDescription = dependentCI.Description;
            }
            else
            {
                dependencyReport.SkipAdding = true;
            }

            ComponentInfo requiredCI = GetComponentName(((OptionSetValue)dependency["requiredcomponenttype"]).Value, (Guid)dependency["requiredcomponentobjectid"]);
            dependencyReport.RequiredComponentName = requiredCI.Name;

            // Disabled for testing
            if (!dependencyReport.SkipAdding 
                && (string.IsNullOrEmpty(dependencyReport.DependentComponentType)
                || string.IsNullOrEmpty(dependencyReport.RequiredComponentType)
                || string.IsNullOrEmpty(dependencyReport.DependentComponentName)
                || string.IsNullOrEmpty(dependencyReport.RequiredComponentName)))
            {
                dependencyReport.SkipAdding = true;
            }

            return dependencyReport;
        }

        // The name or display name of the component depends on the type of component.
        private static ComponentInfo GetComponentName(int componentType, Guid componentId)
        {
            ComponentInfo info = null;

            switch (componentType)
            {
                case (int)Enum.ComponentType.Entity:
                    info = new ComponentInfo();
                    info.Name = componentId.ToString();
                    break;
                case (int)Enum.ComponentType.Attribute:
                    //name = GetAttributeInformation(componentId);
                    info = GetAttributeInformation(componentId);
                    break;
                case (int)Enum.ComponentType.OptionSet:
                    info = GetGlobalOptionSetName(componentId);
                    break;
                case (int)Enum.ComponentType.SystemForm:
                    info = GetFormDisplayName(componentId);
                    break;
                case (int)Enum.ComponentType.EntityRelationship:
                    info = GetEntityRelationshipName(componentId);
                    break;
                case (int)Enum.ComponentType.SDKMessageProcessingStep:
                    info = GetSdkMessageProcessingStepName(componentId);
                    break;
                case (int)Enum.ComponentType.EntityMap:
                    info = GetEntityMapName(componentId);
                    break;
                case (int)Enum.ComponentType.SavedQuery:
                    info = GetSavedQueryName(componentId);
                    break;
                case (int)Enum.ComponentType.ModelDrivenApp:
                    info = GetModelDrivenAppName(componentId);
                    break;
                case (int)Enum.ComponentType.SiteMap:
                    info = GetSitemapName(componentId);
                    break;
                case (int)Enum.ComponentType.MobileOfflineProfile:
                    info = GetMobileProfileName(componentId);
                    break;
                case (int)Enum.ComponentType.EmailTemplate:
                    info = GetEmailTemplateName(componentId);
                    break;
                case (int)Enum.ComponentType.MailMergeTemplate:
                    info = GetMailMergeTemplateName(componentId);
                    break;
                case (int)Enum.ComponentType.Report:
                    info = GetReportName(componentId);
                    break;
                default:
                    //name = $"{componentType} - Not Implemented";
                    break;
            }

            return info;

        }

        private static ComponentInfo GetAttributeInformation(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            RetrieveAttributeRequest req = new RetrieveAttributeRequest
            {
                MetadataId = id
            };
            RetrieveAttributeResponse resp = null;

            if (Service is CrmServiceClient svc)
            {
                resp = (RetrieveAttributeResponse)svc.Execute(req);
            }
            else
            {
                resp = (RetrieveAttributeResponse)Service.Execute(req);
            }

            AttributeMetadata attmet = resp.AttributeMetadata;
            info.Name = attmet.SchemaName;
            info.Description = $"Entity: {attmet.EntityLogicalName}, Label: {attmet.DisplayName.UserLocalizedLabel.Label}";

            return info;
        }

        private static ComponentInfo GetGlobalOptionSetName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            RetrieveOptionSetRequest req = new RetrieveOptionSetRequest
            {
                MetadataId = id
            };
            RetrieveOptionSetResponse resp = (RetrieveOptionSetResponse)Service.Execute(req);
            OptionSetMetadataBase os = resp.OptionSetMetadata;
            info.Name = os.DisplayName.UserLocalizedLabel.Label;
            info.Description = $"Schema: {os.Name}, Is Global: {os.IsGlobal}";

            return info;
        }

        private static ComponentInfo GetFormDisplayName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eForm = Service.Retrieve("systemform", id, new ColumnSet("name", "objecttypecode", "type", "formactivationstate"));
            if (eForm != null && eForm.Contains("type") && eForm.Contains("name"))
            {
                info.Name = $"{eForm["name"]}";
                info.Description = $"Entity: {eForm["objecttypecode"]}, Type: {eForm.FormattedValues["type"]}, Status: {eForm.FormattedValues["formactivationstate"]}";
            }

            return info;
        }

        private static ComponentInfo GetSavedQueryName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eSavedQuery = Service.Retrieve("savedquery", id, new ColumnSet("name", "returnedtypecode", "statuscode", "isdefault"));
            if (eSavedQuery != null && eSavedQuery.Contains("name") && eSavedQuery.Contains("returnedtypecode"))
            {
                info.Name = $"{eSavedQuery["name"]}";
                info.Description = $"Entity: {eSavedQuery["returnedtypecode"]}, Status: {eSavedQuery.FormattedValues["statuscode"]}, Is Default: {eSavedQuery["isdefault"]}";
            }

            return info;
        }

        private static ComponentInfo GetEntityMapName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eEntityMap = Service.Retrieve("entitymap", id, new ColumnSet("sourceentityname", "targetentityname"));
            if (eEntityMap != null && eEntityMap.Contains("sourceentityname") && eEntityMap.Contains("targetentityname"))
            {
                info.Name = $"Source: {eEntityMap["sourceentityname"]} | Target: {eEntityMap["targetentityname"]}";
            }

            return info;
        }

        private static ComponentInfo GetModelDrivenAppName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eAppModule = Service.Retrieve("appmodule", id, new ColumnSet("name", "uniquename", "statuscode"));
            if (eAppModule != null && eAppModule.Contains("name"))
            {
                info.Name = $"{eAppModule["name"]}";
                info.Description = $"Unique Name: {eAppModule["uniquename"]}, Status: {eAppModule.FormattedValues["statuscode"]}";
            }

            return info;
        }

        private static ComponentInfo GetSitemapName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eSitemap = Service.Retrieve("sitemap", id, new ColumnSet(true));
            if (eSitemap != null && eSitemap.Contains("sitemapname"))
            {
                info.Name = $"{eSitemap["sitemapname"]}";
            }

            return info;
        }

        private static ComponentInfo GetMobileProfileName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eMobileProfile = Service.Retrieve("mobileofflineprofile", id, new ColumnSet("name"));
            if (eMobileProfile != null && eMobileProfile.Contains("name"))
            {
                info.Name = $"{eMobileProfile["name"]}";
            }

            return info;
        }

        private static ComponentInfo GetEmailTemplateName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eEmailTemplate = Service.Retrieve("template", id, new ColumnSet("title", "templatetypecode", "languagecode"));
            if (eEmailTemplate != null && eEmailTemplate.Contains("title"))
            {
                info.Name = $"{eEmailTemplate["title"]}";
                info.Description = $"Type: {eEmailTemplate["templatetypecode"]}, Language: {eEmailTemplate["languagecode"]}";
            }

            return info;
        }

        private static ComponentInfo GetMailMergeTemplateName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eMailMerge = Service.Retrieve("mailmergetemplate", id, new ColumnSet("name", "languagecode", "templatetypecode"));
            if (eMailMerge != null && eMailMerge.Contains("name"))
            {
                info.Name = $"{eMailMerge["name"]}";
                info.Description = $"Type: {eMailMerge["templatetypecode"]}, Language: {eMailMerge["languagecode"]}";
            }

            return info;
        }

        private static ComponentInfo GetReportName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eReport = Service.Retrieve("report", id, new ColumnSet("name", "languagecode", "reporttypecode"));
            if (eReport != null && eReport.Contains("name"))
            {
                info.Name = $"{eReport["name"]}";
                info.Description = $"Type: {eReport.FormattedValues["reporttypecode"]}, Language: {eReport["languagecode"]}";

            }

            return info;
        }

        private static ComponentInfo GetSdkMessageProcessingStepName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            Entity eSdkMessage = Service.Retrieve("sdkmessageprocessingstep", id, new ColumnSet("name", "stage", "sdkmessageid", "statuscode"));
            if (eSdkMessage != null && eSdkMessage.Contains("name"))
            {
                info.Name = $"{eSdkMessage["name"]}";
                info.Description = $"Stage: {eSdkMessage.FormattedValues["stage"]}, SDK Message: {eSdkMessage.FormattedValues["sdkmessageid"]}";
            }

            return info;
        }

        private static ComponentInfo GetEntityRelationshipName(Guid id)
        {
            ComponentInfo info = new ComponentInfo();
            RetrieveRelationshipRequest req = new RetrieveRelationshipRequest
            {
                MetadataId = id
            };
            RetrieveRelationshipResponse resp = (RetrieveRelationshipResponse)Service.Execute(req);
            if (resp != null)
            {
                if (resp.RelationshipMetadata.GetType().Name == "OneToManyRelationshipMetadata")
                {
                    info.Name = $"{resp.RelationshipMetadata.SchemaName} (1:M)";
                    OneToManyRelationshipMetadata oneToMany = (OneToManyRelationshipMetadata)resp.RelationshipMetadata;
                    info.Description = $"Referenced: {oneToMany.ReferencedEntity} ({oneToMany.ReferencedAttribute}), Referencing: {oneToMany.ReferencingEntity} ({oneToMany.ReferencingAttribute})";
                }
                else if (resp.RelationshipMetadata.GetType().Name == "ManyToManyRelationshipMetadata")
                {
                    info.Name = $"{resp.RelationshipMetadata.SchemaName} (M:M)";
                    ManyToManyRelationshipMetadata manyToMany = (ManyToManyRelationshipMetadata)resp.RelationshipMetadata;
                    info.Description = $"First: {manyToMany.Entity1LogicalName} ({manyToMany.Entity1IntersectAttribute}), Second: {manyToMany.Entity2LogicalName} ({manyToMany.Entity2IntersectAttribute})";
                }
            }

            return info;
        }

        #endregion
    }
}
