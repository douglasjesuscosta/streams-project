using System;
using System.Threading;
using System.Threading.Tasks;
using Entities.DTOs;
using MediatR;
using Persistence;
using UseCases.Shared.Exceptions;

namespace UseCases.Streammers
{
    public class Edit
    {
        private StreamRepository _streamRepository;

        public Edit()
        {}

        public class Command : StreamDTO, IRequest
        {}

        public class Handler : IRequestHandler<Command>
        {
            private StreamRepository _streamRepository;

            public Handler(StreamRepository streamRepository)
            {
                _streamRepository = streamRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var streamPersisted = _streamRepository.GetStream(request.Id).Result;

                /* Caso stream nao encontrada nao sera prosseguida a edicao */
                if (streamPersisted == null) throw new  NotFoundException("Stream nao encontrada");

                /* Atualizacao dos valores */
                streamPersisted.Name = request.Name ?? streamPersisted.Name;
                streamPersisted.Description = request.Description ?? streamPersisted.Description;
                streamPersisted.CountryId = request.IdCountry ?? streamPersisted.CountryId;

                /* Tentativa de persistencia */
                var sucesso = await _streamRepository.UpdateStream(streamPersisted);

                /* Caso o salvar tenha sido bem sucedido */
                if (sucesso) return Unit.Value;

                throw new SaveException("Nao foi possivel salvar, tente novamente");
            }
        }
    }
}
