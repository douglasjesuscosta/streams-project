using System;
using System.Threading;
using System.Threading.Tasks;
using Entities.Entities;
using MediatR;
using Persistence;

namespace UseCases.Streammers
{
    public class Read
    {
        
        public class Query : IRequest<Stream>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Stream>
        {
            private readonly StreamRepository _streamRepository;

            public Handler(StreamRepository streamRepository)
            {
                _streamRepository = streamRepository;
            }

            public async Task<Stream> Handle(Query request, CancellationToken cancellationToken)
            {
                var stream = await _streamRepository.GetStream(request.Id);
                return stream;
            }
        }

    }
}
