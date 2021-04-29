namespace CommsHackEvents
{
    using CommsHack;
    using Dissonance;
    using Dissonance.Audio.Capture;
    using Exiled.API.Features;
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
            string filePath = $@"{CommsHackEvents.dirPath}\";
            float volume = 1f;

            switch (eventType)
            {
                case EventType.StopSound:
                    StopSound(); return;

                case EventType.RoundStarted:
                    filePath += Config.RoundStarted.FileName; volume = Config.RoundStarted.Volume; break;

                case EventType.NtfEntrance:
                    filePath += Config.NtfEntrance.FileName; volume = Config.NtfEntrance.Volume; break;

                case EventType.CiEntrance:
                    filePath += Config.CiEntrance.FileName; volume = Config.CiEntrance.Volume; break;

                case EventType.StartingWarhead:
                    filePath += Config.WarheadStart.FileName; volume = Config.WarheadStart.Volume; break;
            }

            if (filePath.EndsWith(".raw"))
            {
                AudioAPI.API.PlayFileRaw(filePath, volume);
            }
            else
            {
                AudioAPI.API.PlayFile(filePath, volume);
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
