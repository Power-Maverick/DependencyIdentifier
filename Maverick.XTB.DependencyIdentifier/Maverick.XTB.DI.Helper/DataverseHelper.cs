using Maverick.XTB.DI.DataObjects;
using Maverick.XTB.DI.Extensions;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Maverick.XTB.DI.Helper
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
            Service = service;

            List<DependencyReport> lstReport = new List<DependencyReport>();

            var dependencyRequest = new RetrieveDependentComponentsRequest
                                    {
                                        ObjectId = objectId,
                                        ComponentType = componentType
                                    };

            var dependencyResponse = (RetrieveDependentComponentsResponse)service.Execute(dependencyRequest);

            // If there are no dependent components, we can ignore this component.
            if (dependencyResponse.EntityCollection.Entities.Any() == false)
                return lstReport;

            foreach (Entity dependentEntity in dependencyResponse.EntityCollection.Entities)
            {
                DependencyReport dr = GenerateDependencyReport(dependentEntity);
                if (!dr.SkipAdding)
                {
                    lstReport.Add(dr);
                }
            }

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

                var d = dependency["dependentcomponenttype"];

                if (((OptionSetValue)dependency["dependentcomponenttype"]).Value == (int)ct)
                {
                    dependencyReport.DependentComponentType = text.Name;
                }
                if (((OptionSetValue)dependency["requiredcomponenttype"]).Value == (int)ct)
                {
                    dependencyReport.RequiredComponentType = text.Name;
                }
            }

            if (string.IsNullOrEmpty(dependencyReport.DependentComponentType) || string.IsNullOrEmpty(dependencyReport.RequiredComponentType))
            {
                dependencyReport.SkipAdding = true;
            }

            dependencyReport.DependentComponentName = GetComponentName(((OptionSetValue)dependency["dependentcomponenttype"]).Value, (Guid)dependency["dependentcomponentobjectid"]);
            dependencyReport.RequiredComponentName = GetComponentName(((OptionSetValue)dependency["requiredcomponenttype"]).Value, (Guid)dependency["requiredcomponentobjectid"]);

            return dependencyReport;
        }

        // The name or display name of the component depends on the type of component.
        private static string GetComponentName(int componentType, Guid componentId)
        {
            string name = "";

            switch (componentType)
            {
                case (int)Enum.ComponentType.Entity:
                    name = componentId.ToString();
                    break;
                case (int)Enum.ComponentType.Attribute:
                    name = GetAttributeInformation(componentId);
                    break;
                case (int)Enum.ComponentType.OptionSet:
                    name = GetGlobalOptionSetName(componentId);
                    break;
                case (int)Enum.ComponentType.SystemForm:
                    name = GetFormDisplayName(componentId);
                    break;
                case (int)Enum.ComponentType.EntityRelationship:
                    name = GetEntityRelationshipName(componentId);
                    break;
                case (int)Enum.ComponentType.SavedQuery:
                    name = "To Be Implemented";
                    break;
                default:
                    name = "Not Implemented";
                    break;
            }

            return name;

        }

        private static string GetAttributeInformation(Guid id)
        {
            RetrieveAttributeRequest req = new RetrieveAttributeRequest
            {
                MetadataId = id
            };
            RetrieveAttributeResponse resp = (RetrieveAttributeResponse)Service.Execute(req);
            AttributeMetadata attmet = resp.AttributeMetadata;
            string attributeInformation = $"{attmet.SchemaName} ({attmet.DisplayName.UserLocalizedLabel.Label})";

            return attributeInformation;
        }
        
        private static string GetGlobalOptionSetName(Guid id)
        {
            RetrieveOptionSetRequest req = new RetrieveOptionSetRequest
            {
                MetadataId = id
            };
            RetrieveOptionSetResponse resp = (RetrieveOptionSetResponse)Service.Execute(req);
            OptionSetMetadataBase os = resp.OptionSetMetadata;
            string name = os.DisplayName.UserLocalizedLabel.Label;

            return name;
        }

        private static string GetFormDisplayName(Guid id)
        {
            Entity eForm = Service.Retrieve("systemform", id, new ColumnSet("name", "objecttypecode", "type"));
            OptionSetValue formType = (OptionSetValue)eForm["type"];
            string name = $"{eForm["name"]} ({GetFormTypeName(formType.Value)})";

            return name;
        }

        private static string GetEntityRelationshipName(Guid id)
        {
            RetrieveRelationshipRequest req = new RetrieveRelationshipRequest
            {
                MetadataId = id
            };
            RetrieveRelationshipResponse resp = (RetrieveRelationshipResponse)Service.Execute(req);
            string name = $"{resp.RelationshipMetadata.SchemaName} ({resp.RelationshipMetadata.RelationshipType})";

            return name;
        }

        private static string GetFormTypeName(int type)
        {
            return System.Enum.GetName(typeof(Enum.FormType), type);
        }

        #endregion
    }
}
