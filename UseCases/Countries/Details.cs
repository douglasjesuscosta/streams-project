using System;
using Entities.Entities;
using MediatR;

namespace UseCases.Countries
{
    public class Details
    {
        public class Query : IRequest<Country>
        {

        }
    }
}
