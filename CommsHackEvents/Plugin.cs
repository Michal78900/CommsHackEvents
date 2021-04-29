namespace CommsHackEvents
{
    using System;
    using System.IO;
    using Exiled.API.Features;

    using ServerEvent = Exiled.Events.Handlers.Server;
    using MapEvent = Exiled.Events.Handlers.Map;
    using WarheadEvent = Exiled.Events.Handlers.Warhead;

    public class CommsHackEvents : Plugin<Config>
    {
        public static CommsHackEvents Singleton;
        public override string Author => "Michal78900";
        public override Version Version => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(2, 10, 0);

        public static string dirPath = $@"{Paths.Configs}\CommsHackAudio";

        private Handler handler;

        public override void OnEnabled()
        {
            if (!Directory.Exists(dirPath))
            {
                Log.Warn("CommsHackAudio folder does not exist. Creating...");
                Directory.CreateDirectory(dirPath);
                File.WriteAllText($@"{dirPath}\README.txt", "Setup instructions are on GitHub, make sure to read them: https://github.com/Michal78900/CommsHackEvents");
            }

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
