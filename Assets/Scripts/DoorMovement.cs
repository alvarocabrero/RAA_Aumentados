using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour {

    // Es necesario asignar este script a un Empty Object, situado en el eje de rotación
    // de la puerta, y hacer a esta su hija. A este objeto se le debe añadir un componente
    // Box Collider, con el check "Is Trigger" marcado.
    // Si el jugador está dentro del collider y pulsa el botón indicado, la puerta se abre
    // o cierra.

    public float doorOpenAngle = 90.0f; // Ángulo de apertura de la puerta
    public float openSpeed = 2.0f; // Velocidad de apertura

    bool open = false;
    bool enter = false;

    float defaultRotationAngle;
    float currentRotationAngle;
    float openTime = 0;

    //Audios
    public AudioSource AbrirPuerta;
    public AudioSource CerrarPuerta;

    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;
    }

    // Main function
    void Update()
    {
        if(openTime < 1)
        {
            openTime += Time.deltaTime * openSpeed;
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);

        // Para abrir con el mando, se necesita configurar botón "Fire3" en el editor
        // Joystick button 2 para botón CUADRADO en el móvil
        if (Input.GetButtonDown("Fire3") && enter)
        {
            open = !open;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
            // Reporudcir aquí sonido de puerta abriéndose
            AbrirPuerta.Play();
        }

        // Para abrir con el teclado
        if (Input.GetKeyDown("space") && enter)
        {
            open = !open;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
            // Reporudcir aquí sonido de puerta abriéndose
            AbrirPuerta.Play();
        }
    }

    // Enseña un mensaje en pantalla (en el móvil con VR no funciona)
    void OnGUI()
    {
        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 50), "Press 'SPACE' to interact with the door");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
}
