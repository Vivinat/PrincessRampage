using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;         //Atributos dos meus coletaveis
    public Sprite itemImage;
}


public class Collection_Controller : MonoBehaviour
{
    public Item item;           //Mais atributos aqui
    public int healthChange;
    public float moveSpeedChange;
    public int mHealthChange;
    public int DamChange;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.itemImage; 
    }

    private void OnTriggerEnter2D(Collider2D collision) //Se player colidir com o item
    {
        if (collision.tag == "Player")
        {
            AudioManager.instance.PlaySound("CollectSound");
            Game_Controller.HealPlayer(healthChange);      //Modifique essas coisas
            Game_Controller.MoveSpeedChange(moveSpeedChange);
            Game_Controller.MaxHealthChange(mHealthChange);
            Game_Controller.DamageChange(DamChange);
            Destroy(gameObject);
        }


    }


}
