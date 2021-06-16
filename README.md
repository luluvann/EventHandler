# Events and Delegates in C#
How to create events in C#

## Summary
Events handling:
- is a mechanism for communication between objects
- is used in building Loosely Coupled Applications
- helps extending applications (adding functionalities without breaking or modifying existing functionalities)

## Publisher / Subscribers
The concept of events handling comes with the concept of having a Publisher class and Subscriber class(es).
In this example, the publisher is the class "VideoEncoder" and subscribers are "MailService" and "TextService" classes.
The publisher will send a notification to its subscriber(s) through an event but it doesn't know about its subscribers. The advantage of this is we can add as many subscribers as we want afterwards without modifying the code of the publisher class.

## Steps
1. Create the delegate in the publisher class
````
public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args)
````
2. Create the event in the publisher class
````
public event VideoEncodedEventHandler VideoEncoded
````
or 1. and 2. combined
````
public EventHandler<VideoEventArgs> VideoEncoded;
````
1. and 2. a. Add a class that inherits from EventArgs that will be the data passed in the event
````
public class VideoEventArgs : EventArgs
{
  public Video Video { get; set; }
}
````
3. Create a method that will raise the event
````
protected virtual void OnVideoEncoded(Video video)
{
  if (VideoEncoded != null)
    VideoEncoded(this, new VideoEventArgs() { Video = video });
}
````
4. Call the method in the publisher class
````
OnVideoEncoded(video);
````
5. Create the subscriber class(es) and create a method that will be raised when the publisher notifies its subscriber(s)
````
public void OnVideoEncoded(object source, VideoEventArgs e)
{
  Console.WriteLine("MailService: sending text " + e.Video.Title);
}
````
6. Instantiate subscriber
````
var mailService = new MailService();
````
7. Add the subscription
````
videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
````
