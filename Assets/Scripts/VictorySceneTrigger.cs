using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneTrigger : MonoBehaviour
{
    void Start() {}

    void Update() {}

    // Cuando el jugador entre en la zona tras la puerta final, se carga la escena de victoria
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene("VictoryScene");
            LockedDoorMovement.hasKey = false;
        }
    }
}
