using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDescriptionManager : MonoBehaviour
{
    public static CardDescriptionManager Instance { get; set; }

    public GameObject cardDetailsView;

    public Image cardBack;
    public Image cardFront;
    public Image cardHighlight;

    public Text cardDescription;
    public Text cardTitle;

    public List<List<Sprite>> cards = new List<List<Sprite>>();
    public List<Sprite> cardBacks = new List<Sprite>();
    public List<Color> cardHighlights = new List<Color>();

    public List<List<string>> descriptions = new List<List<string>>();

    public List<string> descriptionLion = new List<string>();
    public List<string> descriptionCrocodile = new List<string>();
    public List<string> descriptionFish = new List<string>();
    public List<string> descriptionSalamander = new List<string>();
    public List<string> descriptionFrog = new List<string>();
    public List<string> descriptionTriton = new List<string>();

    public List<List<string>> titles = new List<List<string>>();

    public List<string> titleLion = new List<string>();
    public List<string> titleCrocodile = new List<string>();
    public List<string> titleFish = new List<string>();
    public List<string> titleSalamander = new List<string>();
    public List<string> titleFrog = new List<string>();
    public List<string> titleTriton = new List<string>();

    public List<Sprite> activeCards = new List<Sprite>();

    private void Awake() => Instance = this;

    private void Start()
    {
        cards.AddRange(DeckPopulate.Instance.cards);
        cardBacks.AddRange(DeckPopulate.Instance.cardsBack);

        Descriptions descriptionsStore = new Descriptions();
        Titles titlesStore = new Titles();

        #region Populate Lists
        descriptionLion.AddRange(descriptionsStore.descriptionLion);
        descriptionCrocodile.AddRange(descriptionsStore.descriptionCrocodile);
        descriptionFish.AddRange(descriptionsStore.descriptionFish);
        descriptionSalamander.AddRange(descriptionsStore.descriptionSalamander);
        descriptionFrog.AddRange(descriptionsStore.descriptionFrog);
        descriptionTriton.AddRange(descriptionsStore.descriptionTriton);

        titleLion.AddRange(titlesStore.titleLion);
        titleCrocodile.AddRange(titlesStore.titleCrocodile);
        titleFish.AddRange(titlesStore.titleFish);
        titleSalamander.AddRange(titlesStore.titleSalamander);
        titleFrog.AddRange(titlesStore.titleFrog);
        titleTriton.AddRange(titlesStore.titleTriton);

        descriptions.Add(descriptionLion);
        descriptions.Add(descriptionCrocodile);
        descriptions.Add(descriptionFish);
        descriptions.Add(descriptionSalamander);
        descriptions.Add(descriptionFrog);
        descriptions.Add(descriptionTriton);

        titles.Add(titleLion);
        titles.Add(titleCrocodile);
        titles.Add(titleFish);
        titles.Add(titleSalamander);
        titles.Add(titleFrog);
        titles.Add(titleTriton);
        #endregion
    }
    void DisplayCard(
        Sprite _cardBack, 
        Sprite _cardFront, 
        Color _cardHighlightColor, 
        string _cardDescription, 
        string _cardTitle)
    {
        cardBack.sprite = _cardBack;
        cardFront.sprite = _cardFront;
        cardHighlight.color = _cardHighlightColor;

        cardDescription.text = _cardDescription;
        cardTitle.text = _cardTitle;

        cardDetailsView.SetActive(true);
    }

    public void CardDetailsShow(Sprite card)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            foreach (Sprite item in cards[i])
            {
                if(item == card)
                {
                    string descriptionText = "no description";
                    string titleText = "no title";

                    if (descriptions[i].Count > cards[i].IndexOf(item))
                        descriptionText = descriptions[i][cards[i].IndexOf(item)];

                    if (titles[i].Count > cards[i].IndexOf(item))
                        titleText = titles[i][cards[i].IndexOf(item)];


                    DisplayCard(
                        cardBacks[i],
                        item,
                        cardHighlights[i],
                        descriptionText,
                        titleText);
                }
            }
        }
    }

    public void UpdateActiveCards()
    {
        activeCards.Clear();

        for (int i = 0; i < GameObject.Find("Cards").transform.childCount; i++)
        {
            if (GameObject.Find("Cards").transform.GetChild(i).gameObject.activeSelf)
                activeCards.Add(GameObject.Find("Cards").transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite);
        }
    }

    public void NextButtonClick()
    {
        UpdateActiveCards();

        int index = activeCards.IndexOf(cardFront.sprite);

        index = (index + 1 < activeCards.Count) ? index + 1 : 0;

        CardDetailsShow(activeCards[index]);
    }

    public void PreviousButtonClick()
    {
        UpdateActiveCards();

        int index = activeCards.IndexOf(cardFront.sprite);

        index = (index - 1 > -1) ? index - 1 : activeCards.Count - 1;

        CardDetailsShow(activeCards[index]);
    }
}
