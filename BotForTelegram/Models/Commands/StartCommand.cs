﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotForTelegram.Models.Commands
{
    /// <summary>
    /// Класс, который реализует типичную стартовую комманду для нашего бота
    /// </summary>
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override string Discription => "Начальная комманда для приветсвия новых пользователей";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }
        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(
                chatId: chatId, 
                text: $"Привет {message.From.Username}, пока что я мало что умею. Если хочешь посмотреть, что я умею, набери комманду /help", 
                replyMarkup: new ReplyKeyboardMarkup(KeyBoards.keyboardButtons, resizeKeyboard: true), 
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }

}
