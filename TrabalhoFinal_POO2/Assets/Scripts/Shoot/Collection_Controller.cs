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
    public int healthChange;
    public float moveSpeedChange;
    public int mHealthChange;
    public int DamChange;


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
            AudioManager.instance.PlaySound("CollectSound");
            Game_Controller.HealPlayer(healthChange);
            Game_Controller.MoveSpeedChange(moveSpeedChange);
            Game_Controller.MaxHealthChange(mHealthChange);
            Game_Controller.DamageChange(DamChange);
            Destroy(gameObject);
        }


    }


}
