namespace LavaGame
{
    public class SwitchBulletTypeGuiButton : BaseGuiButton
    {
        protected override void ButtonClickHandler() =>
            EventBus.SwitchBulletType.Publish();
    }
}