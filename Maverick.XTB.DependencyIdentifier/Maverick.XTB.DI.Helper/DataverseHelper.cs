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
                lstReport.Add(GenerateDependencyReport(dependentEntity));
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
                default:
                    name = "not implemented";
                    break;
            }

            return name;

        }

        private static string GetAttributeInformation(Guid id)
        {
            string attributeInformation = "";
            RetrieveAttributeRequest req = new RetrieveAttributeRequest
            {
                MetadataId = id
            };
            RetrieveAttributeResponse resp = (RetrieveAttributeResponse)Service.Execute(req);
            AttributeMetadata attmet = resp.AttributeMetadata;
            attributeInformation = attmet.SchemaName + " : " + attmet.DisplayName.UserLocalizedLabel.Label;

            return attributeInformation;
        }
        
        private static string GetGlobalOptionSetName(Guid id)
        {
            string name = "";
            RetrieveOptionSetRequest req = new RetrieveOptionSetRequest
            {
                MetadataId = id
            };
            RetrieveOptionSetResponse resp = (RetrieveOptionSetResponse)Service.Execute(req);
            OptionSetMetadataBase os = (OptionSetMetadataBase)resp.OptionSetMetadata;
            name = os.DisplayName.UserLocalizedLabel.Label;

            return name;
        }

        #endregion
    }
}
