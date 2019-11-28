using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Importar al proyecto los assets para el Google Cardboard y añadir a la escena
    // un GvrEditorEmulator.
    // La cámara debe ser hija de un Empty Object al que se le asignará este script.
    // Desde el editor de Unity, arrastrar la cámara de la escena al atributo 
    // "Main Camera" del script.

    public float horizontalMove;
    public float verticalMove;
    private Vector3 movementInput;
    private Vector3 movePlayer;

    public CharacterController player;

    public float speed;

    public float gravity = 9.8f;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    //Audios
    //public AudioSource Caminando;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();	
    }

    // Update is called once per frame
    void Update()
    {
        // Para mando, INPUT en configuración del editor > X Axis
        horizontalMove = Input.GetAxis("Horizontal");
        // Para mando, INPUT en configuración del editor > Y Axis
        verticalMove = Input.GetAxis("Vertical");

        /*if (horizontalMove > 0 || verticalMove > 0)
            Caminando.Play();
        else
            Caminando.Pause();
        */

        movementInput = new Vector3(horizontalMove, 0, verticalMove) * speed;

        lookingAt();

        movePlayer = movementInput.x * camRight + movementInput.z * camForward;

        //player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        player.Move(movePlayer);

        // Reproducir aquí sonido de jugador caminando

        //OnTriggerEnter();




    }

    /*public void PlayCaminando()
    {
       
    }

    void OnTriggerEnter()
    {
        Caminando.Play();
    }*/

    void SetGravity() {
        movePlayer.y = -gravity * Time.deltaTime;
    }

    void lookingAt() {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
