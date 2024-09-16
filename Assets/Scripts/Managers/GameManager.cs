using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance for global access

    // UI elements for displaying game information
    [SerializeField] private TextMeshProUGUI turnText;
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private TextMeshProUGUI fullHandText;

    // References to card prefabs
    [SerializeField] private GameObject chaCard;
    [SerializeField] private GameObject couCard;
    [SerializeField] private GameObject cleCard;
    [SerializeField] private GameObject creCard;

    // References to gameplay elements
    [SerializeField] private PlayerArea playerArea;
    [SerializeField] public ConvoTopic currentConvoTopic;
    [SerializeField] private TopicContainer topicContainer;
    [SerializeField] private PlayerDeckScript deckContainer;
    [SerializeField] private Dropzone dropzone;
    [SerializeField] private DiscardPile discard;

    // Player health and turn tracking
    [SerializeField] public int health = 3;
    private int missingCards;
    private int turnCount = 0;

    public List<string> categories = new List<string> { "Cha", "Cou", "Cle", "Cre" }; // List of categories for conversation topics

    // Initial game setup
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);  // Ensures only one instance of GameManager
        }
        else
        {
            instance = this;
        }

        SetConvoStart();
    }

    // Setup the conversation at the start of the game (Currenty empty)
    public void SetConvoStart()
    {
    }

    // Sets the topic for the current game manager
    public void SetTopicGM(string type, ConvoTopic topic)
    {
        topic.SetTopic(type);
    }

    // Handles end of turn logic
    public void OnEndTurn()
    {
        // Increment the turn counter and update the UI
        turnCount++;
        turnText.SetText("Round: " + turnCount.ToString());

        // Draw cards if the player has fewer than 5 cards in hand and the deck is not empty
        if (playerArea.CardsInHand.Count < 5 && deckContainer.Deck.Count > 0)
        {
            missingCards = 5 - playerArea.CardsInHand.Count;
            fullHandText.enabled = false;

            // Draw the necessary number of cards to fill the player's hand
            for (int i = 0; i < missingCards; i++)
            {
                Card card = deckContainer.Draw();
                if (card != null)  // Ensure the drawn card is valid
                {
                    deckContainer.RemoveCard(card);
                    card.transform.SetParent(playerArea.transform);
                    playerArea.AddCards(card);
                }
            }
        }
        else
        {
            // Show "full hand" text if player cannot draw more cards
            fullHandText.enabled = true;
        }

        // Score the current conversation topic if it exists
        if (currentConvoTopic != null)
        {
            dropzone.ScoreCards();
        }
    }
}