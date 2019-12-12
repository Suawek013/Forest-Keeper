using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneLoader : MonoBehaviour
{
   
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
