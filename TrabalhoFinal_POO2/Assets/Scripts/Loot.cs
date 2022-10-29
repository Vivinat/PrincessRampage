using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public int dropChance;
    public Sprite lootSprite;

    public Loot(int dropChance)
    {
        this.dropChance = dropChance;
    }
}
