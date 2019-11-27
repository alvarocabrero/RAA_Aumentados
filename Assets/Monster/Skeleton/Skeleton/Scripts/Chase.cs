using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject player;
    static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        float angle = Vector3.Angle(direction,this.transform.forward);

        //Si el jugador está a menos de 50 de distancia y en el ángulo de vision del monstruo este se mueve hacia él
        if(Vector3.Distance(player.transform.position, this.transform.position) < 50 && angle < 60)
        {
            //No se quiere modificar el eje y
            direction.y = 0;

            //El monstruo mira al jugador, slerp para una rotación más natural
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle",false);
            //Si el jugador está a menos de 10 unidades del monstruo este se para y le ataca
             if(direction.magnitude > 10)
             {
                this.transform.Translate(0,0,0.07f);
                anim.SetBool("isWalking",true);
                anim.SetBool("isAttacking",false);
             }
             //Si el jugador no está cerca del monstruo este se queda quieto
             else
             {
                anim.SetBool("isAttacking",true);
                anim.SetBool("isWalking",false);
             }
        }
        else
        {
            anim.SetBool("isIdle",true);
            anim.SetBool("isAttacking",false);
            anim.SetBool("isWalking",false);
        }
    }
}
