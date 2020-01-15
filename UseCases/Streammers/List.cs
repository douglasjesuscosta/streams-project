using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Persistence;
using Entities.DTOs;
using Entities.Mappers;
using Entities.Entities;

namespace UseCases.Streammers
{
    public class List
    {
        public class Query : IRequest<List<StreamDTO>>
        {}

        public class Handler : IRequestHandler<Query, List<StreamDTO>>
        {
            private readonly StreamRepository _streamRepository;
            private readonly StreamMapper _streamMapper;

            public Handler(StreamRepository streamRepository, StreamMapper streamMapper)
            {
                _streamRepository = streamRepository;
                _streamMapper = streamMapper;
            }

            public async Task<List<StreamDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var streammers = await _streamRepository.GetAllStreammers();

                return ConvertStreammersToStreamDTO(streammers.ToList());
            }

            private List<StreamDTO> ConvertStreammersToStreamDTO(List<Stream> streams)
            {
                return streams.Select(stream => _streamMapper.MapStreamToStreamDTO(stream)).ToList();
            }
        }
    }
}
