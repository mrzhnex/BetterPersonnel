using EXILED;

namespace BetterPersonnel
{
    public class MainSettings : Plugin
    {
        public override string getName => nameof(BetterPersonnel);
        public SetEvents SetEvents { get; set; }

        public override void OnEnable()
        {
            SetEvents = new SetEvents();
            Events.WaitingForPlayersEvent += SetEvents.OnWaitingForPlayers;
            Events.RoundStartEvent += SetEvents.OnRoundStart;
            Events.PlayerSpawnEvent += SetEvents.OnPlayerSpawn;
            Events.DoorInteractEvent += SetEvents.OnDoorInteract;
            Log.Info(getName + " on");
        }

        public override void OnDisable()
        {
            Events.WaitingForPlayersEvent -= SetEvents.OnWaitingForPlayers;
            Events.RoundStartEvent -= SetEvents.OnRoundStart;
            Events.PlayerSpawnEvent -= SetEvents.OnPlayerSpawn;
            Events.DoorInteractEvent -= SetEvents.OnDoorInteract;
            Log.Info(getName + " off");
        }

        public override void OnReload() { }
    }
}