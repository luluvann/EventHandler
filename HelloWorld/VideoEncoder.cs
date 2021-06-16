using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class VideoEncoder
    {
        // 1-Define a delegate
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        // 2-Define an event based on that delegates - "VideoEncoded" is the name of the event, by convention - should be in past tense
        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video: " + video.Title);

            // 5-Call the method to raise the event
            OnVideoEncoded();
        }

        // 3-Raise the event by creating a method protected virtual
        protected virtual void OnVideoEncoded()
        {
            // 4-Check if the event is not null (when there is subscribers), if not null then sends "this" which is the current class that is the source of the event and we send back empty
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty);
        }

    }
}
