using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaseAbajo : MonoBehaviour
{
    public Transform player;
    static Animator anim;
    private int contador;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        contador = 60;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction,this.transform.forward);

        //Si el jugador está a menos de 800 de distancia y en el ángulo de vision del monstruo este se mueve hacia él
        if((Vector3.Distance(player.position, this.transform.position) < 600 && angle < 70) || Vector3.Distance(player.position, this.transform.position) < 250)
        {
            //No se quiere modificar el eje y
            direction.y = 0;

            //El monstruo mira al jugador, slerp para una rotación más natural
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle",false);

             if(direction.magnitude > 180)
             {
                this.transform.Translate(0,0,1.5f);
                anim.SetBool("isWalking",true);
                anim.SetBool("isAttacking",false);
             }
             //Si el jugador está a menos de 10 unidades del monstruo este se para y le ataca
             else 
             {
               
                if (anim.GetBool("isAttacking") && direction.magnitude < 150)
                {
                    if (contador == 0)
                    {
                        SceneManager.LoadScene("MapaDefinitivo");
                    }
                    else { contador--; }
                }
                anim.SetBool("isAttacking",true);
                anim.SetBool("isWalking",false);
             }
        }
        //Si el jugador no está cerca del monstruo este se queda quieto
        else
        {
            anim.SetBool("isIdle",true);
            anim.SetBool("isAttacking",false);
            anim.SetBool("isWalking",false);
        }
    }
}
