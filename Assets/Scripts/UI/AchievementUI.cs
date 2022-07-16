using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AchievementUI : MonoBehaviour
    {
        public List<Achievement> achievements;
        void Start()
        {
            foreach (Achievement a in achievements)
            {
                GameObject obj = new GameObject();
            
                RectTransform trans = obj.AddComponent<RectTransform>();
                trans.transform.SetParent(gameObject.transform);
                trans.localScale = new Vector3(1, 1, 1);

                Image image = obj.AddComponent<Image>();
                image.sprite = a.icon;
                
                obj.SetActive(a.hasBeenAchieved);
            }
        }
    }
}

