using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    // Class to send data from publisher to subscriber(s)
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    class VideoEncoder
    {
        // 1-Define a delegate
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        // 2-Define an event based on that delegates - "VideoEncoded" is the name of the event, by convention - should be in past tense
        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video: " + video.Title);

            //If there is so data passed in the event
            //OnVideoEncoded(video);

            // 5-Call the method to raise the event
            OnVideoEncoded(video);
        }

        // 3-Raise the event by creating a method protected virtual
        protected virtual void OnVideoEncoded(Video video)
        {
            // 4-Check if the event is not null (when there is subscribers), if not null then sends "this" which is the current class that is the source of the event and we send back empty
            if (VideoEncoded != null)

                //If there is so data passed in the event
                //VideoEncoded(this, EventArgs.Empty);

                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }

    }
}
