using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneController : MonoBehaviour
{
    void Start()
    {}

    void Update()
    {
        // Para salir del juego, pulsar "espacio" o "cuadrado"
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("space"))
        {
            Application.Quit();
        }
        // Para volver a jugar, pulsar "R" o "cuadrado"
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
