namespace CommsHackEvents
{
    using CommsHack;
    using Dissonance;
    using Dissonance.Audio.Capture;
    using Exiled.Events.EventArgs;
    using MEC;
    using Respawning;
    using UnityEngine;

    using Log = Exiled.API.Features.Log;

    public class Handler
    {
        private static readonly Config Config = CommsHackEvents.Singleton.Config;

        private readonly System.Random rng = new System.Random();

        internal void OnWaitingForPlayers() => Play(Config.WaitingForPlayers);

        internal void OnRoundStarted() => Play(Config.RoundStarted);

        internal void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev)
        {
            ev.IsAllowed = Config.NtfEntrance.FileName.Count == 0;

            Play(Config.NtfEntrance);
        }

        internal void OnTeamRespawn(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency)
            {
                Play(Config.CiEntrance);
            }
        }

        internal void OnGeneratorActivated(GeneratorActivatedEventArgs ev) => Play(Config.GeneratorActivated);

        internal void OnStartingWarhead(StartingEventArgs ev) => Play(Config.WarheadStart);

        internal void OnStoppingWarhead(StoppingEventArgs ev) => Play(Config.WarheadCancel);

        internal void OnDetonated() => Play(Config.WarheadDetonated);

        internal void OnDecontaminating(DecontaminatingEventArgs ev) => Play(Config.DecontaminationStart);

        internal void OnRoundEnd(RoundEndedEventArgs ev) => Play(Config.RoundEnded);

        private void Play(AudioFile audioFile)
        {
            if (audioFile.Delay < 0 || audioFile.Delay < 0)
            {
                Log.Debug($"Sound or delay is set to less than zero, stopping sound...", Config.Debug);
                StopSound();
                Log.Debug($"Sound have been stopped.", Config.Debug);
                return;
            }

            if (audioFile.FileName.Count == 0)
            {
                Log.Debug($"The file_name contains no elements, returning...", Config.Debug);
                return;
            }

            string filePath = $"{CommsHackEvents.dirPath}/{audioFile.FileName[rng.Next(audioFile.FileName.Count)]}";
            float volume = audioFile.Volume;

            Log.Debug($"I will play the sound in {audioFile.Delay} seconds...", Config.Debug);
            Timing.CallDelayed(audioFile.Delay, () =>
            {
                if (filePath.EndsWith(".raw"))
                {
                    Log.Debug("The file ends with .raw, so it is converted, playing...", Config.Debug);
                    AudioAPI.API.PlayFileRaw(filePath, volume);
                }
                else
                {
                    Log.Debug("The file isn't converted. Converting and playing...", Config.Debug);
                    AudioAPI.API.PlayFile(filePath, volume);
                }
            });
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
    }
}
