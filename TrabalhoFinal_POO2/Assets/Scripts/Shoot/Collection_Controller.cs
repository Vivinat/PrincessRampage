using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public Sprite itemImage;
}


public class Collection_Controller : MonoBehaviour
{
    public Item item;
    public float healthChange;
    public float damageChange;
    public float fireRateChange;
    public float moveSpeedChange;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.itemImage;
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player_Controller.collectedAmount++;
            //Player_Controller.HealPlayer(healthChange);
            //Player_Controller.DamageChange(damageChange);
            //Player_Controller.FireRateChange(fireRateChange);
            //Player_Controller.MoveSpeedChange(moveSpeedChange);
            Destroy(gameObject);
        }


    }


}
