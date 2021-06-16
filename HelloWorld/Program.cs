using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = new List<int>() { 1, 2, 3, 4, 5 };
            //Console.WriteLine(list);

            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //publisher
            // 8-Instantiate the subscriber(s)
            var mailService = new MailService(); //subscriber 1
            var textService = new TextService(); //subscriber 2

            // 9-Add the subscription: on the left is the event from the publisher and on the right is the subscriber event method
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += textService.OnVideoEncoded;

            videoEncoder.Encode(video);

        }
    }
}
