using System.Net.Http;
using System.Web;
using System.Web.Http;
using AttributeRouting.Web.Http;
using AutoMapper;
using MiniTrello.Domain.DataObjects;
using MiniTrello.Domain.Entities;
using MiniTrello.Domain.Services;

namespace MiniTrello.Api.Controllers
{
    public class OrganizationController : ApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;
        readonly IMappingEngine _mappingEngine;

        public OrganizationController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository, IMappingEngine mappingEngine)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _mappingEngine = mappingEngine;
        }

        [AcceptVerbs(new []{"DELETE"})]
        [DELETE("organization/{accessToken}")]
        public OrganizationModel Archive(string accessToken, [FromBody] OrganizationArchiveModel model)
        {
            var organization = _readOnlyRepository.GetById<Organization>(model.Id);
            var archivedOrganization = _writeOnlyRepository.Archive(organization);
            return _mappingEngine.Map<Organization, OrganizationModel>(archivedOrganization);
        }

        [GET("organization/{accessToken}/{organizationId}")]
        public OrganizationModel GetById(string accessToken, long organizationId)
        {
            var organization = _readOnlyRepository.GetById<Organization>(organizationId);
            return _mappingEngine.Map<Organization, OrganizationModel>(organization);
        }

        [AcceptVerbs("PUT")]
        [PUT("organization/name/{accessToken}")]
        public OrganizationModel UpdateName(string accessToken, [FromBody] OrganizationUpdateNameModel model)
        {
            var organization = _readOnlyRepository.GetById<Organization>(model.Id);
            organization.Name = model.NewName;
            organization = _writeOnlyRepository.Update(organization);
            return _mappingEngine.Map<Organization, OrganizationModel>(organization);
        }


    }

    public class OrganizationUpdateNameModel
    {
        public long Id { get; set; }
        public string NewName { get; set; }
    }
}