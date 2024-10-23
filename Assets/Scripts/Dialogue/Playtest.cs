using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
//using FMOD.Studio;


public class Playtest : MonoBehaviour
{
    // Text is typing
    public bool isWriting = false;

    // Audio
    // private EventInstance playerVoice;
    // private EventInstance dateVoice;

    // Serialized fields for conversation topics, power levels, and types
    [SerializeField] public int power1;
    [SerializeField] public int power2;
    [SerializeField] public int power3;
    [SerializeField] public int power4;
    [SerializeField] public string type1;
    [SerializeField] public string type2;
    [SerializeField] public string type3;
    [SerializeField] public string type4;
    [SerializeField] public string label1;
    [SerializeField] public string label2;
    [SerializeField] public string label3;
    [SerializeField] public string label4;

    // List to hold conversation topics
    private List<ConvoTopic> convoTopics;

    // List to hold colorable UI sprites
    [SerializeField] private List<Image> uiOpaqueImages;
    [SerializeField] private Color uiOpaqueColor;
    [SerializeField] private List<Image> uiImages;
    [SerializeField] private Color uiColor;

    // Serialized fields for the individual conversation topics
    [SerializeField] public ConvoTopic convoTopic1;
    [SerializeField] public ConvoTopic convoTopic2;
    [SerializeField] public ConvoTopic convoTopic3;
    [SerializeField] public ConvoTopic convoTopic4;

    // Serialized fields for the conversation dialogue (by topic)
    [SerializeField] public List<string> couLines;
    [SerializeField] public List<string> couSpeaker;
    [SerializeField] public List<Sprite> couSprites;

    [SerializeField] public List<string> chaLines;
    [SerializeField] public List<string> chaSpeaker;
    [SerializeField] public List<Sprite> chaSprites;

    [SerializeField] public List<string> cleLines;
    [SerializeField] public List<string> cleSpeaker;
    [SerializeField] public List<Sprite> cleSprites;

    [SerializeField] public List<string> creLines;
    [SerializeField] public List<string> creSpeaker;
    [SerializeField] public List<Sprite> creSprites;

    // Text for conversation output
    protected string text = " ";
    protected string playerText = " ";

    // Field for the date character so we can change their sprites
    [SerializeField] public Image dateCharacter;

    //[SerializeField] private AudioSource dateTextSFX;
    //[SerializeField] private AudioSource playerTextSFX;
    // Start is called before the first frame update
    protected void Start()
    {
        //InitializeFileSources();
        ShowTopics();
        SetUIColor();
    }

    // Sets the conversation topics with power and topic names
    protected void SetTopics(int num1, string topic1, string label1, int num2, string topic2, string label2, int num3, string topic3, string label3, int num4, string topic4, string label4)
    {
        convoTopic1.SetNum(num1);
        convoTopic1.SetTopic(topic1, label1);

        convoTopic2.SetNum(num2);
        convoTopic2.SetTopic(topic2, label2);

        convoTopic3.SetNum(num3);
        convoTopic3.SetTopic(topic3, label3);

        convoTopic4.SetNum(num4);
        convoTopic4.SetTopic(topic4, label4);
    }

    // Displays the conversation topics
    public void ShowTopics()
    {
        SetTopics(power1, type1, label1, power2, type2, label2, power3, type3, label3, power4, type4, label4);
    }

    public void SetUIColor()
    {
        foreach (var uiSprite in uiOpaqueImages)
        {
            uiSprite.color = uiOpaqueColor;
        }

        foreach (var uiSprite in uiImages)
        {
            uiSprite.color = uiColor;
        }
    }

    // Plays player text sounds
    public void ReadPlayerText()
    {
        //playerVoice.start();
        //if (isWriting)
        //{
            AudioManager.instance.PlayOneShot(FMODEvents.instance.playerVoice, this.transform.position);
        //}
        //Debug.Log("AHHHHHHHHHHHHH");
        //playerVoice.stop(STOP_MODE.IMMEDIATE); 
        //playerTextSFX.Play();
    }

    // Changes the character pose and plays sounds
    public void ReadDateText(Sprite characterPose)
    {
        // Change the sprite of the date character
        dateCharacter.sprite = characterPose;

        // Play date voice sound
        AudioManager.instance.PlayOneShot(FMODEvents.instance.dateVoice, this.transform.position);

        // Start the jump animation coroutine
        StartCoroutine(JumpAnimation());
    }

    // Coroutine to handle the jump animation
    private IEnumerator JumpAnimation()
    {
        // Store the original position of the dateCharacter
        Vector3 originalPosition = dateCharacter.transform.localPosition;

        // Define the jump height and speed
        float jumpHeight = 50f;
        float jumpSpeed = 0.15f;

        // Move the character up
        Vector3 targetPosition = originalPosition + new Vector3(0, jumpHeight, 0);
        float elapsedTime = 0f;

        // Animate the upward movement
        while (elapsedTime < jumpSpeed)
        {
            dateCharacter.transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / jumpSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset time for downward movement
        elapsedTime = 0f;

        // Animate the downward movement back to the original position
        while (elapsedTime < jumpSpeed)
        {
            dateCharacter.transform.localPosition = Vector3.Lerp(targetPosition, originalPosition, (elapsedTime / jumpSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the position is set exactly to the original
        dateCharacter.transform.localPosition = originalPosition;
    }
}
