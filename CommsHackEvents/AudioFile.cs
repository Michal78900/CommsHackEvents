namespace CommsHackEvents
{
    using System.Collections.Generic;
    public class AudioFile
    {
        public List<string> FileName { get; private set; } = new List<string>();
        public float Volume { get; private set; } = 1f;
        public float Delay { get; private set; } = 0f;
    }
}
