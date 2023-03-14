using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Name der zu ladenden Szene (im Inspector einstellbar)
    public string sceneName;

    // Methode zum Laden der n�chsten Szene bei Kollision
    private void OnCollisionEnter(Collision other)
    {
        //Wichtig: Spieler muss Player Tag haben!!!!!
        if (other.gameObject.CompareTag("Player"))
        {
            // Lade die n�chste Szene
            SceneManager.LoadScene(sceneName);
        }
    }
}
