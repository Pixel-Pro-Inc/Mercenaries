using System.Collections;
using System.Collections.Generic;
using static Assets.Entities.CharacterPersona;
using static Enums;
using UnityEngine;
using Assets.Entities;

public class CardBehaviour : MonoBehaviour
{
    public SpeciesType species;
    public cardName name;

    //Create Card Interact with Target Script

    public void OnAction(object TargetInstance)
    {
        //if(TargetInstance == typeof.Enemy)

        object CharacterInstance = null;
        for (int i = 0; i < GameManager.Instance.activeCharacter.templates.Count; i++)
        {
            if (GameManager.Instance.activeCharacter.templates[i] != null)
                CharacterInstance = GameManager.Instance.activeCharacter.templates[i];

        }
        List<object> Templates = GameManager.Instance.activeCharacter.templates;

        CharacterPersona characterPersona = new CharacterPersona();

        //the code below manually sets the charactertemplates in Characterpersona to the values of the actual instances we are using so we don't have to change the values
        characterPersona.WarriorCBase = (WarriorTemplate)Templates[0];
        characterPersona.TankCBase = (TankWarriorTemplate)Templates[1];
        characterPersona.RangeCBase = (RangeTemplate)Templates[2];
        characterPersona.MageCBase = (MageTemplate)Templates[3];
        characterPersona.ControllerCBase = (ControllerTemplate)Templates[4];
        characterPersona.AssasinCBase = (AssasinTemplate)Templates[5];

        switch (name)
        {
            case cardName.lionFirstCard:
                break;
            case cardName.lionSecondCard:
                break;
            case cardName.lionThirdCard:
                break;
            case cardName.lionFourthCard:
                break;
            case cardName.lionFifthCard:
                break;
            case cardName.lionSixthCard:
                break;
            case cardName.lionSeventhCard:
                break;
            case cardName.lionEighthCard:
                break;
            case cardName.lionNinthCard:
                break;
            case cardName.crocodileFirstCard:
                break;
            case cardName.crocodileSecondCard:
                break;
            case cardName.crocodileThirdCard:
                break;
            case cardName.crocodileFourthCard:
                break;
            case cardName.crocodileFifthCard:
                break;
            case cardName.crocodileSixthCard:
                break;
            case cardName.crocodileSeventhCard:
                break;
            case cardName.crocodileEighthCard:
                break;
            case cardName.crocodileNinthCard:
                break;
            case cardName.fishFirstCard:
                break;
            case cardName.fishSecondCard:
                break;
            case cardName.fishThirdCard:
                break;
            case cardName.fishFourthCard:
                characterPersona.PolishWeapon();
                break;
            case cardName.fishFifthCard:
                characterPersona.PhysicalDamage(CharacterInstance, TargetInstance, damageType.Physical);
                break;
            case cardName.fishSixthCard:
                break;
            case cardName.fishSeventhCard:
                break;
            case cardName.fishEighthCard:
                characterPersona.Agile(CharacterInstance);
                break;
            case cardName.fishNinthCard:
                break;
            case cardName.salamanderFirstCard:
                break;
            case cardName.salamanderSecondCard:
                break;
            case cardName.salamanderThirdCard:
                break;
            case cardName.salamanderFourthCard:
                break;
            case cardName.salamanderFifthCard:
                break;
            case cardName.salamanderSixthCard:
                break;
            case cardName.salamanderSeventhCard:
                break;
            case cardName.salamanderEighthCard:
                break;
            case cardName.salamanderNinthCard:
                break;
            case cardName.frogFirstCard:
                break;
            case cardName.frogSecondCard:
                break;
            case cardName.frogThirdCard:
                break;
            case cardName.frogFourthCard:
                break;
            case cardName.frogFifthCard:
                break;
            case cardName.frogSixthCard:
                break;
            case cardName.frogSeventhCard:
                break;
            case cardName.frogEighthCard:
                break;
            case cardName.frogNinthCard:
                break;
            case cardName.tritonFirstCard:
                break;
            case cardName.tritonSecondCard:
                break;
            case cardName.tritonThirdCard:
                break;
            case cardName.tritonFourthCard:
                break;
            case cardName.tritonFifthCard:
                break;
            case cardName.tritonSixthCard:
                break;
            case cardName.tritonSeventhCard:
                break;
            case cardName.tritonEighthCard:
                break;
            case cardName.tritonNinthCard:
                break;
            default:
                break;
        }
    }
}
