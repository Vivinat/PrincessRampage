using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D rb;          //Referencia para o corpo do player
    public Animator anim;           //Referencia para nosso animador
    public float MovementSpeed;     //Referencia para a speed to player
    Vector2 movement;               //Guardará posicionamento vertical e horizontal
    public GameObject BulletPrefab; //A bala
    public float BulletSpeed;       //Velocidade da bala
    private float LastFire;         //Quando foi que disparei minha ultima bala?
    public float FireDelay;         //Delay entre os tiros
    public int currentExp;          //Quanto de XP eu tenho?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update é chamada uma vez por frame
    void Update(){

        FireDelay = Game_Controller.FireRate;
        MovementSpeed = Game_Controller.MoveSpeed;
        currentExp = Game_Controller.Exp;

        movement.x = Input.GetAxisRaw("Horizontal"); //Verifica a posição do player na horizontal e retorna um valor
        movement.y = Input.GetAxisRaw("Vertical");
        float shootHor = Input.GetAxis("ShootHorizontal"); //Verifica a posição para atirar
        float shootVer = Input.GetAxis("ShootVertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if((shootHor != 0 || shootVer != 0) && Time.time > LastFire + FireDelay){   //O player pode atirar?
            Shoot(shootHor, shootVer);
            LastFire = Time.time;
        }

        void Shoot(float x, float y){
            GameObject bullet = Instantiate(BulletPrefab, transform.position,transform.rotation) as GameObject;
            bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(  //Operador ternário vai checar se o x e y são menores que zero
                (x < 0) ? Mathf.Floor(x) * BulletSpeed : Mathf.Ceil(x) * BulletSpeed, //Se sim, vamos multiplicar para negativo para ter velocidade constante
                (y < 0) ? Mathf.Floor(y) * BulletSpeed : Mathf.Ceil(y) * BulletSpeed, //Se não, vamos usar Ceil para subir o valor para inteiro 
                0 //Não precisamos do Z neste vetor.
            );
        }

        if (currentExp == 100)
        {
            //LevelUp();
        }

    }

    void FixedUpdate(){ //Fixed Update é independente a quantidade de frames 
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.fixedDeltaTime); 
        //Ande de acordo com sua posição atual, influenciada pelo vetor de direção, multiplicada pela speed
        //e multiplicada pelo tempo fixo da animação 

        //Pra qual direçao nosso personagem está olhando?
        if (movement.y > 0){
        anim.SetInteger("Direction", 2);
        }

        else if (movement.y < 0){
        anim.SetInteger("Direction", 0);
        }

        else if (movement.x < 0){
        anim.SetInteger("Direction", 1);
        }

        else if (movement.x > 0){
        anim.SetInteger("Direction", 3);
        }
        else{}
    }
}

