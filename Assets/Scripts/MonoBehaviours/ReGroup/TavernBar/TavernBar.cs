using Assets.Scripts.Entities.Character;
using Assets.Scripts.Entities.Item;
using Assets.Scripts.Entities.Worker;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.MonoBehaviours.ReGroup;

public class TavernBar : MonoBehaviour
{
    public static TavernBar Instance { get; set; }

    #region Lifecounting

    public static int CraftingCount { get; set; }
    public static int SmithingCount { get; set; }
    public static int MiningCount { get; set; }
    public static int FarmingCount { get; set; }
    public static int HunterGathringCount { get; set; }


    #endregion
    public static int LifeSkillsThreshold { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static bool OutOnExpedition { get; set; }

    List<Persona> Legion = new List<Persona>(); //These will be all the soliders in your disposal
    List<WorkerAnt> Colony = new List<WorkerAnt>(); //These will be all the workers in your disposal
    //MAke sure that the colony doesnt go above 

    public object SelectItemAtDisposal(Individual Individual, string cardId)
    {
        foreach (ItemTemplate item in Individual.RetrieveItemsAtDisposal())
        {
            if (item.CardId == cardId) return item;
        }
        Debug.Log("This is not an item you own, or it might not even exists");
        return null;
    }
    public void LifeSkillLevelUp()
    {
        if (CraftingCount >= LifeSkillsThreshold) LifeSkills.CraftingLevel++; CraftingCount = 0;
        if (SmithingCount >= LifeSkillsThreshold) LifeSkills.SmithingLevel++; SmithingCount = 0;
        if (MiningCount >= LifeSkillsThreshold) LifeSkills.MiningLevel++; MiningCount = 0;
        if (FarmingCount >= LifeSkillsThreshold) LifeSkills.FarmingLevel++; FarmingCount = 0;
        if (HunterGathringCount >= LifeSkillsThreshold) LifeSkills.HunterGatheringLevel++; HunterGathringCount = 0;
    }
}
