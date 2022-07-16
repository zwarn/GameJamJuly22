using UnityEngine;

[CreateAssetMenu(fileName = "Achievement", menuName = "Achievement", order = 0)]
public class Achievement : ScriptableObject
{
    public Sprite icon;
    public bool hasBeenAchieved = false;

    public void SetAchievement()
    {
        this.hasBeenAchieved = true;
    }
}