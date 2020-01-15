using System;
using System.Threading;
using System.Threading.Tasks;
using Entities.Entities;
using MediatR;
using Persistence;
using UseCases.Shared.Exceptions;

namespace UseCases.Streammers
{
    public class Delete
    {

        public Delete()
        {
        }

        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly StreamRepository _streamRepository;

            public Handler(StreamRepository streamRepository)
            {
                _streamRepository = streamRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancelation)
            {

                Stream stream = await _streamRepository.GetStream(request.Id);

                if (stream == null) throw new  NotFoundException($"Stream with id {request.Id} not found");

                Boolean result = await _streamRepository.DeleteStream(stream);

                if (result) return Unit.Value;

                throw new SaveException("Problem saving changes");
            }

        }

    }
}
