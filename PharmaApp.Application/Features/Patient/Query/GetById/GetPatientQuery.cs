using MediatR;

namespace PharmaApp.Application.Features.Query.GetPatientQuery
{
    public class GetPatientQuery : IRequest<GetPatientQueryResponse>
    {
        public int Id { get; set; }
    }
}