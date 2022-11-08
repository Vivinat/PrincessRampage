using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
//Criando os atributos do nosso objeto scriptavel
{
    public int dropChance;
    public Sprite lootSprite;

    //Drop chance muda de objeto para objeto
    public Loot(int dropChance)
    {
        this.dropChance = dropChance;
    }
}
