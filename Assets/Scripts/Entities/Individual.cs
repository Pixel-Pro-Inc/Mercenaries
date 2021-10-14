using Assets.Scripts.Entities.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected bool PassiveTraitsState { get; set; }
    protected float Cost { get; set; }
    protected int IndividualId { get; set; }
    protected string IndividualType { get; set; }
    public enum Kingdom { FarWest, MiddleEarth, DarkSyde };
    public List<object> Master = new List<object>();
    public List<Persona> Allies = new List<Persona>();
    public List<Persona> Enemies = new List<Persona>();

    public void passiveTraits()
    {
        throw new System.NotImplementedException();
    }
    public virtual List<object> RetrieveItemsAtDisposal()
    {
        List<object> Items = new List<object>();
        return Items;
    }
}
