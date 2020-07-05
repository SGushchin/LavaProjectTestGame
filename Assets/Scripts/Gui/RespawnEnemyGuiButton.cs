namespace LavaGame
{
    public class RespawnEnemyGuiButton : BaseGuiButton
    {
        protected override void ButtonClickHandler() =>
            EventBus.RespawnEnemy.Publish();
    }
}