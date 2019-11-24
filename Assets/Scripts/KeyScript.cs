using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    // Al objeto que represente la llave se le añade este script y un componente
    // Capsule Collider, con el check "Is Trigger" marcado.
    // Si el jugador está dentro del collider y pulsa el botón indicado, cogerá la
    // llave, que dejará de ser renderizada.

    private bool enter = false;
    Renderer renderer;

    //Audio
    public AudioSource Llaves;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Para coger la llave, se necesita configurar botón "Fire3" en el editor
        // Joystick button 2 para botón CUADRADO en el móvil
        if ((Input.GetButtonDown("Fire3") || Input.GetKeyDown("space")) && enter)
        {
            LockedDoorMovement.hasKey = true;
            renderer.enabled = false;

            // Reproducir aquí sonido de coger llaves
            Llaves.Play();
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

    void OnGUI()
    {
        if (enter && renderer.enabled)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 50), "Press 'SPACE' to pick the key");
        }
    }
}
