using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class MailService
    {
        // 6-Create the subscriber method that will be raised after the event
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("MailService: sending email");
        }
    }
}
