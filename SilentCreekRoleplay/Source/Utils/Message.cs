using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SilentCreekRoleplay.Server.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilentCreekRoleplay.Server.Source
{
    static class Message
    {
       public static void SendServerMessageToPlayer(BasePlayer player, MessageType type, string message)
       {
            var messageColor = Color.Red;
            var messageStart = string.Empty;
            var messageEnd = string.Empty;

            switch (type)
            {
                case MessageType.Action:
                {
                    messageStart = "** ";
                    messageColor = Color.Aquamarine;
                    break;
                }
                case MessageType.InCharacter:
                {
                    messageColor = Color.White;
                    break;
                }
                case MessageType.OutOfCharacter:
                {
                    messageStart = "(( ";
                    messageEnd = " ))";
                    messageColor = Color.LightGray;
                    break;
                }
                case MessageType.Error:
                {
                    messageStart = "((** ";
                    messageEnd = " **))";
                    messageColor = Color.Red;
                    break;
                }
                case MessageType.Warning:
                {
                    messageStart = "((* ";
                    messageEnd = " ))";
                    messageColor = Color.Yellow;
                    break;
                }
                case MessageType.Information:
                {
                    messageStart = "((* ";
                    messageEnd = " *))";
                    messageColor = Color.WhiteSmoke;
                    break;
                }
            }

            var messageToSend = message;

            messageToSend.Insert(0, messageStart);
            messageToSend.Insert(message.Length, messageEnd);

            player.SendClientMessage(messageColor, message);
        }
    }
}
