using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] public string targetScene;
    public string DestinationGameObjectName;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            if (Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("Returning to " + targetScene);
                SceneManager.LoadScene(targetScene);
            }
        }
    }

}
