using System;
using System.Collections.Generic;

public class ChatRoom
{
    private static ChatRoom instance;
    private readonly int maxParticipants;
    private List<string> participants;

    private ChatRoom(int maxParticipants)
    {
        this.maxParticipants = maxParticipants;
        this.participants = new List<string>();
    }

    public static ChatRoom GetInstance(int maxParticipants)
    {
        if (instance == null)
        {
            instance = new ChatRoom(maxParticipants);
        }
        return instance;
    }

    public bool JoinChat(string username)
    {
        if (participants.Count < maxParticipants)
        {
            participants.Add(username);
            Console.WriteLine($"{username} has joined the chat.");
            return true;
        }
        Console.WriteLine($"Sorry, {username}. The chat room is full.");
        return false;
    }

    public void SendMessage(string sender, string message)
    {
        Console.WriteLine($"{sender}: {message}");
    }

    public void RemoveParticipant(string username)
    {
        if (participants.Contains(username))
        {
            participants.Remove(username);
            Console.WriteLine($"{username} has left the chat.");
        }
        else
        {
            Console.WriteLine($"{username} is not in the chat room.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ChatRoom chat = ChatRoom.GetInstance(5); // Максимальна кількість учасників: 5

        chat.JoinChat("User1"); 
        chat.JoinChat("User2"); 
        chat.JoinChat("User3"); 
        chat.JoinChat("User4"); 
        chat.JoinChat("User5"); 
        chat.JoinChat("User6"); 

    }
}
