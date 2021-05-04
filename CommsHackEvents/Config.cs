namespace CommsHackEvents
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public class Config : IConfig
    {
        [Description("Is the plugin enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should messages about the playing sound be shown.")]
        public bool Debug { get; set; } = false;

        [Description("Called when the server waits for players:")]
        public AudioFile WaitingForPlayers { get; private set; } = new AudioFile();

        [Description("Called when the round have started:")]
        public AudioFile RoundStarted { get; private set; } = new AudioFile();

        [Description("Called when the NTF are spawned:")]
        public AudioFile NtfEntrance { get; private set; } = new AudioFile();

        [Description("Called when the CI are spawned: (will be heard by ALL players not only ClassD and Chaos!")]
        public AudioFile CiEntrance { get; private set; } = new AudioFile();

        [Description("Called when the SCP-079 generator is activated: (this will override cassie saying about generators' activation, but no that saying: \"Overcharge in 3 2 1... \")")]
        public AudioFile GeneratorActivated { get; private set; } = new AudioFile();

        [Description("Called when the Warhead is started: (the default Alpha Warhead cassie WILL still play!)")]
        public AudioFile WarheadStart { get; private set; } = new AudioFile();

        [Description("Called when the Warhead is cancaled: (the default Alpha Warhead cassie WILL still play!)")]
        public AudioFile WarheadCancel { get; private set; } = new AudioFile();

        [Description("Called when the Warhead is detonated:")]
        public AudioFile WarheadDetonated { get; private set; } = new AudioFile();

        [Description("Called when the Decontamination proccess has started: (the default decontamination cassie WILL still play!)")]
        public AudioFile DecontaminationStart { get; private set; } = new AudioFile();

        [Description("Called when the round has ended:")]
        public AudioFile RoundEnded { get; private set; } = new AudioFile();
    }
}
