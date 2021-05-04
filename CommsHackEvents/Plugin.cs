namespace CommsHackEvents
{
    using System;
    using System.IO;
    using Exiled.API.Features;
    using HarmonyLib;

    using ServerEvent = Exiled.Events.Handlers.Server;
    using MapEvent = Exiled.Events.Handlers.Map;
    using WarheadEvent = Exiled.Events.Handlers.Warhead;

    public class CommsHackEvents : Plugin<Config>
    {
        public static CommsHackEvents Singleton;
        public override string Author => "Michal78900";
        public override Version Version => new Version(1, 2, 0);
        public override Version RequiredExiledVersion => new Version(2, 10, 0);

        public static string dirPath = $"{Paths.Configs}/CommsHackAudio";

        private Handler handler;

        private Harmony harmony;

        public override void OnEnabled()
        {
            if (!Directory.Exists(dirPath))
            {
                Log.Warn("CommsHackAudio folder does not exist. Creating...");
                Directory.CreateDirectory(dirPath);
                File.WriteAllText($"{dirPath}/README.txt", "Setup instructions are on GitHub, make sure to read them: https://github.com/Michal78900/CommsHackEvents");
            }

            Singleton = this;

            harmony = new Harmony($"michal78900.commshackevents-{DateTime.Now.Ticks}");
            harmony.PatchAll();

            handler = new Handler();

            ServerEvent.WaitingForPlayers += handler.OnWaitingForPlayers;
            ServerEvent.RoundStarted += handler.OnRoundStarted;
            MapEvent.AnnouncingNtfEntrance += handler.OnAnnouncingNtfEntrance;
            ServerEvent.RespawningTeam += handler.OnTeamRespawn;
            MapEvent.GeneratorActivated += handler.OnGeneratorActivated;
            WarheadEvent.Starting += handler.OnStartingWarhead;
            WarheadEvent.Stopping += handler.OnStoppingWarhead;
            WarheadEvent.Detonated += handler.OnDetonated;
            MapEvent.Decontaminating += handler.OnDecontaminating;
            ServerEvent.RoundEnded += handler.OnRoundEnd;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEvent.WaitingForPlayers -= handler.OnWaitingForPlayers;
            ServerEvent.RoundStarted -= handler.OnRoundStarted;
            MapEvent.AnnouncingNtfEntrance -= handler.OnAnnouncingNtfEntrance;
            ServerEvent.RespawningTeam -= handler.OnTeamRespawn;
            MapEvent.GeneratorActivated -= handler.OnGeneratorActivated;
            WarheadEvent.Starting -= handler.OnStartingWarhead;
            WarheadEvent.Stopping -= handler.OnStoppingWarhead;
            WarheadEvent.Detonated -= handler.OnDetonated;
            MapEvent.Decontaminating -= handler.OnDecontaminating;
            ServerEvent.RoundEnded -= handler.OnRoundEnd;

            harmony.UnpatchAll();
            handler = null;
            Singleton = null;

            base.OnDisabled();
        }
    }
}
