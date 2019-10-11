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

namespace Sza.FormPassContextUpdaterPlugin
{
    public class PluginService
    {
        public static List<EntityMetadata> GetEntities(IOrganizationService service)
        {
            List<EntityMetadata> list = new List<EntityMetadata>();
            RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
            metaDataRequest.EntityFilters = EntityFilters.Entity;
            metaDataRequest.RetrieveAsIfPublished = true;
            RetrieveAllEntitiesResponse  metaDataResponse = (RetrieveAllEntitiesResponse)service.Execute(metaDataRequest);
            EntityMetadata[] entityMetadatList = metaDataResponse.EntityMetadata;
            foreach (EntityMetadata item in entityMetadatList)
            {
                if (item.DisplayName.UserLocalizedLabel != null &&(((ManagedProperty<bool>)(object)item.IsCustomizable).Value || !item.IsManaged.Value))
                {
                    list.Add(item);
                }
            }
            
            return list;
        }
        public static EntityCollection GetFormsByEntity(IOrganizationService service,string entityName)
        {
            EntityCollection total = new EntityCollection();
            QueryExpression querySys = new QueryExpression("systemform");
            querySys.ColumnSet = new ColumnSet(true);
            FilterExpression filter = new FilterExpression();
            filter.Conditions.Add(new ConditionExpression("objecttypecode", ConditionOperator.Equal, entityName));
            querySys.Criteria = filter;
            EntityCollection systemFormResult = service.RetrieveMultiple(querySys);
            total.Entities.AddRange(systemFormResult.Entities.ToArray());

            QueryExpression queryUser = new QueryExpression("userform");
            queryUser.ColumnSet = new ColumnSet(true);
            FilterExpression filter2 = new FilterExpression();
            filter.Conditions.Add(new ConditionExpression("objecttypecode", ConditionOperator.Equal, entityName));
            queryUser.Criteria = filter2;
            EntityCollection userFormResult = service.RetrieveMultiple(queryUser);
            total.Entities.AddRange(userFormResult.Entities.ToArray());
            return total;
        }

        public static bool UpdateForms(IOrganizationService service, EntityCollection entityCollection)
        {
            foreach (Entity item in entityCollection.Entities)
            {
                var newXml = item.Attributes["formxml"].ToString().Replace("passExecutionContext=\"false\"", "passExecutionContext=\"true\"");
                item.Attributes["formxml"] = newXml;
                service.Update(item);
            }
            return PublishForms(service,entityCollection);
            //return true;
        }
        public static bool PublishForms(IOrganizationService service, EntityCollection entityCollection)
        {
            var ParameterXml = $" <importexportxml><entities>";
            foreach (Entity item in entityCollection.Entities)
            {
                ParameterXml += $" <entity>{item.Attributes["objecttypecode"]}</entity>";
                ParameterXml += $" </entities><nodes/><securityroles/><settings/><workflows/></importexportxml>";
            }
            var pxReq = new PublishXmlRequest ();
            pxReq.ParameterXml = ParameterXml;
            service.Execute(pxReq);
            return true;
        }
    }
}
