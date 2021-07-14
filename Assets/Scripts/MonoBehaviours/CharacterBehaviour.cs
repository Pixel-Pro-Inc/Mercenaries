using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Entities.CharacterPersona;

public class CharacterBehaviour : MonoBehaviour
{
    public Vector3[] positions = {new Vector3(-7.0f, -1.6f, 1.0f), new Vector3(-5.0f, -1.6f, 1.0f), new Vector3(-3.0f, -1.6f, 1.0f), new Vector3(-1.0f, -1.6f, 1.0f)};
    public GameObject parent;
    public Vector3 Goto;
    public SpeciesType species;
    public Image Deck;
    void Awake() 
    {
        parent = transform.parent.gameObject;
        Goto = transform.position;
        Deck = GameObject.Find("Deck").GetComponent<Image>();
    }
    
    public void OnMouseDown()
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).transform.localPosition == positions[3])
            {
                parent.transform.GetChild(i).GetComponent<CharacterBehaviour>().Goto = transform.position;
                Goto = positions[3];
            }
        }

        SpeciesType[] array = (SpeciesType[])(SpeciesType.GetValues(typeof(SpeciesType)));
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == species)
                Deck.sprite = DeckPopulate.Instance.cardsBack[i];

            if (array[i] == species)
                Deck.gameObject.GetComponent<SpeciesHolder>().type = array[i];
        }

        DeckPopulate.Instance.HideDeck();
    }
    public void Update()
    {
        transform.position = Vector3.Lerp(Goto, transform.position, .125f);
        if (transform.position == Goto);
            //IdleAnimation();
    }
    Vector3 scale = new Vector3(0.25f, 0.2407f, 0.25f);
    Vector3 initial = new Vector3();
    Vector3 desired = new Vector3();
    Vector3 position = new Vector3();
    public Vector3 GotoS;
    public Vector3 GotoP;
    public void IdleAnimation()
    {
        initial = new Vector3(transform.position.x, -1.4f, 1f);
        desired = new Vector3(transform.position.x, -1.463f, 1f);

        if(transform.localScale == new Vector3(.25f, .25f, .25f))
        {
            GotoS = scale;
            GotoP = desired;
        }        

        if (transform.localScale == scale)
            GotoS = new Vector3(.25f, .25f, .25f);

        if (GotoS != scale)
            GotoP = initial;

        transform.localScale = Vector3.Lerp(GotoS, transform.localScale, .1f);
        transform.position = Vector3.Lerp(GotoP, transform.position, .1f);
    }
}
