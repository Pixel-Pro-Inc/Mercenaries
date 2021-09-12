using Assets.Scripts.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Helpers.Traits
{
    public class Gods: GameManager
    {
        //These below are objects cause some gods like Keeper use different Combat actions
        List<object> KeepersScroll = new List<object>
        {

        };
        List<object> DevotionsScroll = new List<object>
        { 
        
        };
        List<object> EdgesScroll = new List<object>
        { 
        
        };

        public void GodsHand(Deity deity)
        {
            switch (deity)
            {
                case Deity.Keeper:
                    KeepersMiracle();
                    break;
                case Deity.Devotion:
                    DevotionsMiracle();
                    break;
                case Deity.Edge:
                    EdgesMiracle();
                    break;
                default:
                    break;
            }
        }

        void KeepersMiracle()
        {

        }
        void DevotionsMiracle()
        {

        }
        void EdgesMiracle()
        {

        }

    }
}
