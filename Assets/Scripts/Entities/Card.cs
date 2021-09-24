using Assets.Scripts.Interface.CardInterfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.Models.Enums;

public class Card : MonoBehaviour,ICard
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PassiveTraitsState { get; set; }
    public float Cost { get; set; }
    public string CardId { get; set; }
    public CardIdReference CardType { get; set; }//This describes what kind of card it is eg, Item, character, minion 
    public Image CardImage { get; set; }
    public Sprite CardSprite { get; set; }


    public void passiveTraits()
    {
        throw new System.NotImplementedException();
    }
    public void DragAction()
    {
        throw new System.NotImplementedException();
    }
    public void FlipAction()
    {
        throw new System.NotImplementedException();
    }

}
