using LogicLyric.Interfaces;
using System;
using System.Threading.Tasks;
using LogicLyric.Core;
using LogicLyric.Utils;
using System.Collections.Generic;
namespace LogicLyric
{
    public class NewCharacterEventHandler : EventPacketHandler<NewCharacterEvent>
    {

        PlayerHandler playerHandler;


        INewEnemyPlayer newEnemyPlayer;

        public NewCharacterEventHandler() : base(EventCodes.NewCharacter) { }

        public NewCharacterEventHandler(PlayerHandler playerHandler, INewEnemyPlayer newEnemyPlayer) : base(EventCodes.NewCharacter)
        {

            this.playerHandler = playerHandler;
            this.newEnemyPlayer = newEnemyPlayer;

        }

        protected override Task OnActionAsync(NewCharacterEvent value)
        {







            for (int i = 0; i < IgnoreListItems.members.Count; i++)
            {



                if (IgnoreListItems.members[i].Name.ToLower().Equals(value.Name.ToLower()) && IgnoreListItems.members[i].Type.Equals("Player"))
                {
                    return Task.CompletedTask;
                }

                if (value.GuildName != null)
                {
                    if (IgnoreListItems.members[i].Name.ToLower().Equals(value.GuildName.ToLower()) && IgnoreListItems.members[i].Type.Equals("Guild"))
                    {
                        return Task.CompletedTask;
                    }
                }


                if (value.Alliance != null)
                {
                    if (IgnoreListItems.members[i].Name.ToLower().Equals(value.Alliance.ToLower()) && IgnoreListItems.members[i].Type.Equals("Alliance"))
                    {
                        return Task.CompletedTask;
                    }
                }

            }


            lock (StaticLocks.playersLock)
            {

                playerHandler.AddPlayer(value.Position[0], value.Position[1], int.Parse(value.Id), value.Name, value.CurrentHealth, value.InitialHealth, value.Items, value.GuildName);
                if (Properties.Settings.Default.soundOnNewPlayerSetting)
                {
                    newEnemyPlayer.notify();
                }

            }

            return Task.CompletedTask;
        }
    }
}
