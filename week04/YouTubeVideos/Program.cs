using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C#", "John Smith", 600);
        video1.AddComment(new Comment("Anna", "Great tutorial!"));
        video1.AddComment(new Comment("Mike", "Very helpful."));
        video1.AddComment(new Comment("Sara", "I learned a lot."));

        Video video2 = new Video("OOP Basics", "Programming Hub", 450);
        video2.AddComment(new Comment("Tom", "Nice explanation."));
        video2.AddComment(new Comment("Lucy", "Clear and simple."));
        video2.AddComment(new Comment("David", "Good examples."));

        Video video3 = new Video("Abstraction in C#", "Code Academy", 720);
        video3.AddComment(new Comment("Emma", "This helped me a lot."));
        video3.AddComment(new Comment("James", "Excellent video."));
        video3.AddComment(new Comment("Paul", "Thanks for sharing!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"   {comment.GetAuthor()}: {comment.GetText()}");
            }
        }
    }
}
