using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(Waiter());


    }
    IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Game Over");
    }

}
