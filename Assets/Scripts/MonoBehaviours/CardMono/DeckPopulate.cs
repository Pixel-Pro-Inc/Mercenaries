using Assets.Scripts.MonoBehaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Entities.Character.Persona;
using static Assets.Scripts.Models.Enums;

public class DeckPopulate : MonoBehaviour
{
    public static DeckPopulate Instance { get; set; }
    public List<Sprite> cardsLion = new List<Sprite>();
    public List<Sprite> cardsCrocodile = new List<Sprite>();
    public List<Sprite> cardsFish = new List<Sprite>();
    public List<Sprite> cardsSalamander = new List<Sprite>();
    public List<Sprite> cardsFrog = new List<Sprite>();
    public List<Sprite> cardsTriton = new List<Sprite>();

    public List<cardName> lionsCardsNames = new List<cardName>();
    public List<cardName> crocodileCardsNames = new List<cardName>();
    public List<cardName> fishCardsNames = new List<cardName>();
    public List<cardName> salamanderCardsNames = new List<cardName>();
    public List<cardName> frogCardsNames = new List<cardName>();
    public List<cardName> tritonCardsNames = new List<cardName>();

    public List<List<Sprite>> cards = new List<List<Sprite>>();
    public List<List<cardName>> names = new List<List<cardName>>();
    public List<Sprite> cardsBack = new List<Sprite>();

    public bool showingDeck;
    private void Awake()
    {
        Instance = this;
        cards.Add(cardsLion);
        cards.Add(cardsCrocodile);
        cards.Add(cardsFish);
        cards.Add(cardsSalamander);
        cards.Add(cardsFrog);
        cards.Add(cardsTriton);

        cardName[] array = (cardName[])(cardName.GetValues(typeof(cardName)));

        for (int i = 0; i < array.Length; i++)
        {
            if (i < 9)
                lionsCardsNames.Add(array[i]);
            if (i > 8 && i < 18)
                crocodileCardsNames.Add(array[i]);
            if (i > 17 && i < 27)
                fishCardsNames.Add(array[i]);
            if (i > 26 && i < 36)
                salamanderCardsNames.Add(array[i]);
            if (i > 35 && i < 45)
                frogCardsNames.Add(array[i]);
            if (i > 44 && i < 54)
                tritonCardsNames.Add(array[i]);
        }
        

        names.Add(lionsCardsNames);
        names.Add(crocodileCardsNames);
        names.Add(fishCardsNames);
        names.Add(salamanderCardsNames);
        names.Add(frogCardsNames);
        names.Add(tritonCardsNames);
    }
    public void OnClick(GameObject button)
    {
        if (!GameManager.Instance.activeCharacter.turnUsed)
        {
            SpeciesType type = button.GetComponent<SpeciesHolder>().type;

            SpeciesType[] array = (SpeciesType[])(SpeciesType.GetValues(typeof(SpeciesType)));
            for (int i = 0; i < array.Length; i++)
            {
                if (type == array[i] && !showingDeck)
                {
                    Populate(cards[i], array[i], names[i]);
                }
                else if (type == array[i] && showingDeck)
                {
                    HideDeck();
                }
            }
        }        
    }
    List<Sprite> currentlyActive = new List<Sprite>();
    public void HideDeck()
    {
        for (int i = 0; i < GameObject.Find("Cards").transform.childCount; i++)
        {
            //Destroy(GameObject.Find("Cards").transform.GetChild(i).gameObject);
            GameObject.Find("Cards").transform.GetChild(i).gameObject.SetActive(false);
        }
        showingDeck = false;
    }
    private void Populate(List<Sprite> sprites, SpeciesType species, List<cardName> name)
    {
        for (int i = 0; i < currentlyActive.Count; i++)
        {
            Destroy(currentlyActive[i]);
        }

        List<int> usedCards = new List<int>();

        List<SpeciesType> createdCards = new List<SpeciesType>();
        for (int i = 0; i < GameObject.Find("Cards").transform.childCount; i++)
        {
            createdCards.Add(GameObject.Find("Cards").transform.GetChild(i).GetComponent<CardBehaviour>().species);
        }
        if (!createdCards.Contains(species))
        {
            Vector2 location = new Vector2(-6f, -3.8f);
            Vector2 scale = new Vector2(.25f, .25f);
            for (int i = 0; i < 5; i++)
            {
                int k = 0;
                int ran = 0;
                while (k == 0)
                {
                    ran = Random.Range(1, sprites.Count);
                    if (!usedCards.Contains(ran))
                    {
                        usedCards.Add(ran);
                        k = 1;
                    }
                }

                GameObject spawnObject = new GameObject();
                GameObject _object = Instantiate(spawnObject, Vector3.zero, Quaternion.identity, GameObject.Find("Cards").transform);
                _object.transform.localScale = scale;
                CreateCard(_object, sprites[ran], species, name[ran], location);
                Destroy(spawnObject);

                location += new Vector2(1.6f, 0);
            }
        }
        else
        {
            for (int i = 0; i < GameObject.Find("Cards").transform.childCount; i++)
            {
                GameObject.Find("Cards").transform.GetChild(i).gameObject.SetActive(false);
            }

            for (int i = 0; i < GameObject.Find("Cards").transform.childCount; i++)
            {
                if (GameObject.Find("Cards").transform.GetChild(i).GetComponent<CardBehaviour>().species == species)
                    GameObject.Find("Cards").transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        

        showingDeck = true;
    }
    public void DeleteCards()
    {
        for (int i = 0; i < GameObject.Find("Cards").transform.childCount; i++)
        {
            Destroy(GameObject.Find("Cards").transform.GetChild(i).gameObject);
        }
    }

    private void CreateCard(GameObject _object, Sprite sprite, SpeciesType species, cardName name, Vector3 position)
    {
        CardBehaviour cardBehaviour = _object.AddComponent<CardBehaviour>();
        SpriteRenderer renderer = _object.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        _object.AddComponent<BoxCollider2D>();

        cardBehaviour.species = species;
        cardBehaviour.cardname = name;
        cardBehaviour.GoTo = position;
    }
}
