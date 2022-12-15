namespace GameServer.PlayerCommands
{
    public class PlayerCommandResetQuests : PlayerCommand
    {
        public override void Execute()
        {
            Player.CharacterData.玩家任务.Clear();

            Player.SendMessage($"You need logout to restart quests");
        }
    }
}
