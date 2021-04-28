namespace CommsHackEvents
{
    using CommsHack;
    using Dissonance;
    using Dissonance.Audio.Capture;
    using Exiled.Events.EventArgs;
    using Respawning;
    using UnityEngine;

    public class Handler
    {
        private static readonly Config Config = CommsHackEvents.Singleton.Config;

        internal void OnRoundStarted()
        {
            if (!string.IsNullOrEmpty(Config.RoundStarted.FileName))
                Play(EventType.RoundStarted);
        }

        internal void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev)
        {
            if (!string.IsNullOrEmpty(Config.NtfEntrance.FileName))
            {
                ev.IsAllowed = false;

                Play(EventType.NtfEntrance);
            }
        }

        internal void OnTeamRespawn(RespawningTeamEventArgs ev)
        {
            if (!string.IsNullOrEmpty(Config.CiEntrance.FileName) &&
                ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency)
            {
                Play(EventType.CiEntrance);
            }
        }

        internal void OnStartingWarhead(StartingEventArgs ev)
        {
            if (!string.IsNullOrEmpty(Config.WarheadStart.FileName))
                Play(EventType.StartingWarhead);
        }

        internal void OnStoppingWarhead(StoppingEventArgs ev)
        {
            if (!string.IsNullOrEmpty(Config.WarheadStart.FileName))
                Play(EventType.StopSound);
        }

        internal void OnDetonated()
        {
            if (!string.IsNullOrEmpty(Config.WarheadStart.FileName))
                Play(EventType.StopSound);
        }

        private void Play(EventType eventType)
        {
            string pathToFile = Config.DirectoryPath;

            switch (eventType)
            {
                case EventType.StopSound:
                    StopSound(); break;

                case EventType.RoundStarted:
                    AudioAPI.API.PlayFile($@"{pathToFile}\{Config.RoundStarted.FileName}", Config.RoundStarted.Volume); break;

                case EventType.NtfEntrance:
                    AudioAPI.API.PlayFile($@"{pathToFile}\{Config.NtfEntrance.FileName}", Config.NtfEntrance.Volume); break;

                case EventType.CiEntrance:
                    AudioAPI.API.PlayFile($@"{pathToFile}\{Config.CiEntrance.FileName}", Config.CiEntrance.Volume); break;

                case EventType.StartingWarhead:
                    AudioAPI.API.PlayFile($@"{pathToFile}\{Config.WarheadStart.FileName}", Config.WarheadStart.Volume); break;
            }
        }

        private void StopSound()
        {
            var comms = Object.FindObjectOfType<DissonanceComms>();

            if (comms.TryGetComponent<IMicrophoneCapture>(out var mic))
            {
                if (mic.IsRecording)
                    mic.StopCapture();
                Object.Destroy((Component)mic);
            }
            
            var capt = comms.gameObject.GetComponent<FloatArrayCapture>();
            capt.StopCapture();
        }

        private enum EventType
        {
            StopSound = -1,
            RoundStarted = 0,
            NtfEntrance = 1,
            CiEntrance = 2,
            StartingWarhead = 3,
        }
    }
}
