using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {

    void OnMouseUpAsButton()
    {
        //SceneManager.LoadScene(0);
        Application.Quit();
    }
}
