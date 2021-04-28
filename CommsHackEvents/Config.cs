namespace CommsHackEvents
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public class Config : IConfig
    {
        [Description("Is the plugin enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Directory path, where your sounds / music are stored.")]
        public string DirectoryPath { get; private set; } = "";

        [Description("Called when the round have started:")]
        public AudioFile RoundStarted { get; private set; } = new AudioFile();

        [Description("Called when the NTF are spawned:")]
        public AudioFile NtfEntrance { get; private set; } = new AudioFile();

        [Description("Called when the CI are spawned: (will be heard by ALL players not only ClassD and Chaos!")]
        public AudioFile CiEntrance { get; private set; } = new AudioFile();

        [Description("Called when the Warhead is started:")]
        public AudioFile WarheadStart { get; private set; } = new AudioFile();
    }
}
