namespace CommsHackEvents
{
    using System;
    using Exiled.API.Features;

    using ServerEvent = Exiled.Events.Handlers.Server;
    using MapEvent = Exiled.Events.Handlers.Map;
    using WarheadEvent = Exiled.Events.Handlers.Warhead;

    public class CommsHackEvents : Plugin<Config>
    {
        public static CommsHackEvents Singleton;
        public override string Author => "Michal78900";
        public override Version Version => new Version(1, 0, 0);

        private Handler handler;

        public override void OnEnabled()
        {
            Singleton = this;

            handler = new Handler();

            ServerEvent.RoundStarted += handler.OnRoundStarted;
            MapEvent.AnnouncingNtfEntrance += handler.OnAnnouncingNtfEntrance;
            ServerEvent.RespawningTeam += handler.OnTeamRespawn;
            WarheadEvent.Starting += handler.OnStartingWarhead;
            WarheadEvent.Stopping += handler.OnStoppingWarhead;
            WarheadEvent.Detonated += handler.OnDetonated;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEvent.RoundStarted -= handler.OnRoundStarted;
            MapEvent.AnnouncingNtfEntrance -= handler.OnAnnouncingNtfEntrance;
            ServerEvent.RespawningTeam -= handler.OnTeamRespawn;
            WarheadEvent.Starting -= handler.OnStartingWarhead;
            WarheadEvent.Stopping -= handler.OnStoppingWarhead;
            WarheadEvent.Detonated -= handler.OnDetonated;

            handler = null;
            Singleton = null;

            base.OnDisabled();
        }
    }
}
