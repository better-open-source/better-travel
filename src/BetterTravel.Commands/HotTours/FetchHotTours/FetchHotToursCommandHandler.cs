﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BetterTravel.Application.HotTours.Abstractions;
using BetterTravel.Commands.Abstractions;
using BetterTravel.DataAccess.Abstraction.Entities;
using BetterTravel.DataAccess.Abstraction.Repositories;
using BetterTravel.MediatR.Core.HandlerResults.Abstractions;

namespace BetterTravel.Commands.HotTours.FetchHotTours
{
    public class FetchHotToursCommandHandler : CommandHandlerBase<FetchHotToursCommand>
    {
        private readonly ITourFetcherService _service;
        
        public FetchHotToursCommandHandler(
            IUnitOfWork unitOfWork, 
            ITourFetcherService service) 
            : base(unitOfWork) =>
            _service = service;

        public override async Task<IHandlerResult> Handle(
            FetchHotToursCommand request, 
            CancellationToken cancellationToken)
        {
            var tours = await _service.FetchToursAsync(100);
            var aTours = tours
                .Select(q => q.Info.Name)
                .ToList();

            Expression<Func<HotTour, bool>> predicate = tour => 
                aTours.Any(t => t == tour.Info.Name);
            
            var queryObject = new QueryObject<HotTour> {WherePredicate = predicate};

            var dbTours = await UnitOfWork.HotToursRepository.GetAsync(queryObject);
            var uniqueTours = tours
                    .Where(t =>
                        dbTours.All(db =>
                            db.Info.Name != t.Info.Name &&
                            db.Price.Amount != t.Price.Amount &&
                            db.Info.Stars != t.Info.Stars))
                    .ToList();
            
            await UnitOfWork.HotToursRepository.SaveAsync(uniqueTours);
            await UnitOfWork.CommitAsync();
            
            return Ok();
        }
    }
}