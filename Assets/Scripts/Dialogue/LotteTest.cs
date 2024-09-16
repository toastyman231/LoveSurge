using System.IO;
using UnityEngine;

public class LotteTest : Playtest
{
    // Start is called before the first frame update
    protected new void Start()
    {
        // Set the file paths for player and Lotte text
        base.playerSource = new FileInfo("Assets/Assets/DialogueResources/Dialogue Files/LotteText.txt");
        reader = base.playerSource.OpenText();

        playerSource = new FileInfo("Assets/Assets/DialogueResources/Dialogue Files/playerText.txt");
        playerReader = playerSource.OpenText();

        // Show the topics at the start
        ShowTopics();
    }

    // Sets the conversation topics with provided power and topic names
    protected new void SetTopics(int num1, string topic1, int num2, string topic2, int num3, string topic3)
    {
        convoTopic1.SetNum(num1);
        convoTopic1.SetTopic(topic1);
        //convoTopics.Add(convoTopic1);

        convoTopic2.SetNum(num2);
        convoTopic2.SetTopic(topic2);
        //convoTopics.Add(convoTopic2);

        convoTopic3.SetNum(num3);
        convoTopic3.SetTopic(topic3);
    }

    // Displays the topics with power and types
    private void ShowTopics()
    {
        SetTopics(power1, type1, power2, type2, power3, type3);
    }
}