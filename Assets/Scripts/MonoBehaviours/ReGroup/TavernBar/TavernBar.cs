using Assets.Scripts.Entities.Character;
using Assets.Scripts.Entities.Worker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static bool OutOnExpedition { get; set; }

    List<Persona> Legion = new List<Persona>(); //These will be all the soliders in your disposal
    List<WorkerAnt> Colony = new List<WorkerAnt>(); //These will be all the workers in your disposal
    //MAke sure that the colony doesnt go above 

}
