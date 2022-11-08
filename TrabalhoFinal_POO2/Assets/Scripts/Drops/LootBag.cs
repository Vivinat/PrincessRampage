using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{

    public GameObject LootPrefab;
    public List<Loot> lootList = new List<Loot>();
    //Lista de itens dropados pelo inimigo

    Loot GetDrop()
    {
        //Gera um numero aleatorio
        int RandomNumber = Random.Range(1,101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (RandomNumber <= item.dropChance)
            {
                //Se o numero aleatorio é menor ou igual do que a chance de drop do item
                possibleItems.Add(item); 
                //Voce conseguiu o item
               
            }
        }
        if (possibleItems.Count > 0)
        {
            //Aqui é para gerar posiçao do item dropado 
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log ("Dropou nada");
        return null;
    }

    //Aqui vamos instanciar o drop
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDrop();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(LootPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
        }
    }
}
