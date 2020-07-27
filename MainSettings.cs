using Exiled.API.Features;

namespace BetterPersonnel
{
    public class MainSettings : Plugin<Config>
    {
        public override string Name => nameof(BetterPersonnel);
        public SetEvents SetEvents { get; set; }

        public override void OnEnabled()
        {
            Global.IsFullRp = Config.IsFullRp;
            Global.IsMediumRp = Config.IsMediumRp;
            Global.IsLightRp = Config.IsLightRp;
            Log.Info(nameof(Global.IsFullRp) + ": " + Global.IsFullRp);
            Log.Info(nameof(Global.IsMediumRp) + ": " + Global.IsMediumRp);
            Log.Info(nameof(Global.IsLightRp) + ": " + Global.IsLightRp);
            SetEvents = new SetEvents();
            Exiled.Events.Handlers.Server.WaitingForPlayers += SetEvents.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted += SetEvents.OnRoundStarted;
            Exiled.Events.Handlers.Player.InteractingDoor += SetEvents.OnInteractingDoor;
            Exiled.Events.Handlers.Player.ChangingRole += SetEvents.OnChangingRole;
            Log.Info(Name + " on");
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= SetEvents.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted -= SetEvents.OnRoundStarted;
            Exiled.Events.Handlers.Player.InteractingDoor -= SetEvents.OnInteractingDoor;
            Exiled.Events.Handlers.Player.ChangingRole -= SetEvents.OnChangingRole;
            Log.Info(Name + " off");
        }
    }
}