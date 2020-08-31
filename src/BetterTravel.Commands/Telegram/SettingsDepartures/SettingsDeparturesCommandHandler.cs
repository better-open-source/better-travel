﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BetterTravel.Commands.Abstractions;
using BetterTravel.Commands.Telegram.SettingsDepartures.Keyboard;
using BetterTravel.DataAccess.EF.Abstractions;
using BetterTravel.DataAccess.Entities.Enumerations;
using BetterTravel.MediatR.Core.Abstractions;
using CSharpFunctionalExtensions;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Chat = BetterTravel.DataAccess.Entities.Chat;

namespace BetterTravel.Commands.Telegram.SettingsDepartures
{
    public class SettingsDeparturesCommandHandler : TelegramCommandHandler<SettingsDeparturesCommand>
    {
        private const string KeyboardMessage = "You can choose the departures from which you will receive updates";

        public SettingsDeparturesCommandHandler(
            IUnitOfWork unitOfWork, ITelegramBotClient telegram)
            : base(unitOfWork, telegram) { }

        public override async Task<IHandlerResult> Handle(
            SettingsDeparturesCommand request, 
            CancellationToken ctx) =>
            await UnitOfWork.ChatRepository
                .GetFirstAsync(c => c.ChatId == request.ChatId)
                .ToResult("That chat wasn't found between our subscribers.")
                .Bind(GetKeyboardDataResult)
                .Bind(GetMarkupResult)
                .Tap(() => EditMessageTextAsync(request.ChatId, request.MessageId, KeyboardMessage, ctx))
                .Tap(markup => EditMessageReplyMarkupAsync(request.ChatId, request.MessageId, markup, ctx))
                .Finally(result => result.IsFailure 
                    ? ValidationFailed(result.Error) 
                    : Ok());

        private static Result<List<SettingsDepartureKeyboardData>> GetKeyboardDataResult(Chat chat) =>
            Result
                .Success(DepartureLocation.AllDepartures
                .Select(departure => new SettingsDepartureKeyboardData
                {
                    Id = departure.Id,
                    Name = departure.Name,
                    IsSubscribed = chat.Settings.DepartureSubscriptions.Any(ds => ds.Departure == departure)
                }).ToList());

        private static Result<InlineKeyboardMarkup> GetMarkupResult(List<SettingsDepartureKeyboardData> data) => 
            Result.Success(new SettingsDepartureKeyboard().ConcreteKeyboardMarkup(data));
    }
}