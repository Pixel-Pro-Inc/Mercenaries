using System.Collections;
using System.Collections.Generic;

//This is where you will write down the descriptions
//You have to follow the order from card 1 - 9 for each species otherwise PROBLEMS
public class Descriptions 
{
    public string[] descriptionLion = {"1. Deals Damage, gains shield by 30% of damage dealt and 5% to allies", "2.Deals damage and buffs up by 30% for his next attack", 
        "3.Deals damage and 10% of the damage dealt, he gains as armor and magic resistance for one round","4.Damages enemies and buff all allies by 5% in all statuses",
        "5.After activating this card, your next kill will have 50%* chance of making an enemy with 30% health or less, flee the battle" +
            "50% for normal" +
            "20%  for elite" +
            "1% for a boss",
        "6.Deals normal base damage , if character has more than 20% health than the enemy it will stun the target." +
            " If He has twice more health stuns the entire team gaining 10% shield for each stunned enemy",
        "7.Roar intimidates enemies and decrease all their stats by 5%." +
            "Gets enraged gains 10% damage next action","8. Normal hit and gains a critcial hit next action","9. Increase deffence and magic resistance by 5% for each buff or shield in allies", };
    public string[] descriptionCrocodile = { "1.Killing an enemy when piercing armour, heals the same amount as damage dealt", "2.Deals damage to two enemies and ignores their armour (true damage)", 
        "3.Deals normal damage and breaks their armour by 50%","4.Deals damage as True damage( Directly to health)","5.If next attack pierces armour, character gains attack buff(40%)   for the next two rounds"
            ,"6.Pierces the enemy and will apply bleeding","7.Normal attack, if you kill the enemy, you can attack one more, dealing piercing damage","8.Pierces all enemies but dels 40% of base damage" +
            "heals same amount as damage dealt","9. Doubles own speed" };
    public string[] descriptionFish = { "1.Strikes enemy and crits the beind", "2.Normal attack","3.If enemy has 15% less health, he can bite the eneemy dealing twice the damage dealt",
        "4.Polishes blade, dealing next hit crit attack, if he is max health, he breaks 20% of enemy armour","5. Normal attack then next turn draws one more card",
        "6.Deal twice damage if the enemy is full health, deals half damage if enemy health is 50% or less",
        "7.If enemyy has a debuff, he smells their weakness, making hm excited and deals a lethal hit of 500% damage but it will exhaust him","8.Gains 20% extra dodge chance",
        "9.Can attack twice (extra action)" };
    public string[] descriptionSalamander = {"1.Gains shield equals to gray health, after your shield is removed, character loses 10% max health", 
        "2. Deals damage to two enemies, draws anextra cards next turn, cost 5% max health", "3.Attacks and gains 30% extra Attack damage",
        "4.Attacks 2 enemies and decreases both their attack damage, costs 5% max health",
        "5.All damage absorbed in the last two rounds is dealt on one target and heals 50% damage dealt, costs 5% of max health",
        "6.Normal attack, stuns one enemy. Next turn, if you don't do any direct action you get an extra action the following turn",
        "7.Exchange health for armour" +
            " You can increase your amour by offering your blood. Each 10% health=20% exra armour ( for 2 turns)",
        "8.Hits two enemies dealing true damage." +
            "Heals 2% max health to each debuff the targets has","9.Attaks two enemies dealing 50% of base damage and aplying weak grip debuff to both" };
    public string[] descriptionFrog = { "1.50% chance of enemy attacking himself in attack", "2.50% more doge for character and one other ally", "3. Heals health by a percent of an ally " +
            "(20% of lost health of ally)","4.Singles out a target and poisons them for 4 turns (blight=base damage)","5.Stuns the last two enemies and applies poison",
        "6.Draws two cards and gets extra action","7.Stuns first 2 enemies and buffs characters armour by 10%. Stun last for 1 round and blight is applied for two rounds",
        "8.Normal attack, if enemy is poisoned you double his debuffs, if enemy wasn't blighted you apply blight for 5 rounds and heals character by 50% of dmaage dealt",
        "9.Poisons enemy with current lowest % in health, with 10% of all the enemies combined health. The blight last 3 rounds" };
    public string[] descriptionTriton = { "1.Gains shield by 10% for each warrior or Tank Warrior in battle", "2.Gives shield to the team by 10% of his max health",
       "3.Normal attack, if enemy shielded, deals double damage","4.Doubles own armour and taunts enemy",
        "5.Normal attack, if chracter not shielded he gains shield by 15% of his current health","6. Normal attack, if character shielded, he decreases enemy defence",
        "7.If shielded when attacked, all damage is reflected and sent in the next turn",
        "8.Normal attack, if shielded gains 20% shield, if already shielded, removes all shield and deals shield amount as additional damage ",
        "9.Doubles current shieldand gains 10% shield for each enemy alive" };
}