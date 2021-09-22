using Assets.Scripts.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Helpers
{
    public class InnerVoice
    {
        public string InnerMessage { get; set; }// This is the true and actual characters actual inner voice
        public List<Image> SpokenWord { get; set; }
        public string manifest { get; set; } //This is word (complete or not) of what actually shows up on the screen. Only when manifest has the right string Keys will innerVoice method fire

        public Dictionary<string, string> MercenariesDialect = new Dictionary<string, string>
        {
           
            {"A", "Image name"},{"B", "Image name"},{"C", "Image name"},{"D", "Image name"},
            {"E", "Image name"},{"F", "Image name"},{"G", "Image name"},
            {"H", "Image name"},{"I", "Image name"},{"J", "Image name"},{"K", "Image name"},
            {"L", "Image name"},{"M", "Image name"},{"N", "Image name"},{"O", "Image name"},{"P", "Image name"},
            {"Q", "Image name"},{"R", "Image name"},{"S", "Image name"},
            {"T", "Image name"},{"U", "Image name"},{"V", "Image name"},
            {"W", "Image name"},
            {"X", "Image name"},
            {"Y", "Image name"},{"Z", "Image name"},
            {" ", "White space" }

        };

        string GetTranlateLetterImageName(char CapitalAlphabetLetter)
        {
            return MercenariesDialect[CapitalAlphabetLetter.ToString()];
        }
        void SpeakInnervoice()
        {
            
            Debug.Log("Yewo, You didnt put an image place for the mercenary lanaguage to be shown on screen as Alex asked. The Image list to get from is called SpokenWord. " +
                "If this is done remove this log and everything should work fine");
            for (int i = 0; i < manifest.Length; i++)
            {
                SpokenWord.Add(GameObject.Find($"{GetTranlateLetterImageName(char.ToUpper(manifest[i]))}").GetComponent<Image>());
            }
            //Show SpokenWord
        }

        public void CallInnerVoice(char spoken, object CharacterInstance, object TargetInstance) //spoken will be one letter each and the method called every time an action happens to a person
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            manifest += spoken;

            if (InnerMessage== manifest)
            {
                SpeakInnervoice();
                Character.UniqueSkill(Character, Target);
            }
            else { SpeakInnervoice(); }
        }

    }
}
