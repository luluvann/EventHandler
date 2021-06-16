using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class TextService
    {
        //If there is so data passed in the event
        //public void OnVideoEncoded(object source, EventArgs e)
        //{
        //    Console.WriteLine("TextService: sending text");
        //}

        // 6-Create the subscriber method that will be raised after the event
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("TextService: sending text " + e.Video.Title);
        }


    }
}
