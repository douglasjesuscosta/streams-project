using MediatR;
using System.Threading;
using System.Threading.Tasks;

using Persistence;
using Entities.DTOs;
using Entities.Entities;
using UseCases.Shared.Exceptions;

namespace UseCases.Streammers
{
    public class Create
    {
        public class Command : StreamDTO, IRequest
        {}

        public class Handler : IRequestHandler<Command>
        {
            private readonly StreamRepository _streamRepository;

            public Handler(StreamRepository streamRepository)
            {
                _streamRepository = streamRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                Country country = new Country
                {
                    Id = (int)request.IdCountry
                };

                var streammer = new Stream
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                    CountryId = (int) request.IdCountry,
                    Country = country
                };

                var success = await _streamRepository.AddStream(streammer);
                if (success) return Unit.Value;

                throw new SaveException("Problem saving changes");
            }
        }
    }
}
