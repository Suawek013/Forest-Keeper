using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UpsideDown : MonoBehaviour
{
    bool upsideDownLvl = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (upsideDownLvl == false)
        {
            StartCoroutine(Changer());
        }
        else
            StartCoroutine(ToNormalChanger());
    }

    IEnumerator Changer()
    {
        yield return new WaitForSeconds(5);
        transform.SetPositionAndRotation(new Vector3(16, 12), new Quaternion(0, 0, 180,0));
        upsideDownLvl = true;
    }
    IEnumerator ToNormalChanger()
    {
        yield return new WaitForSeconds(5);
        transform.SetPositionAndRotation(new Vector3(0, 0), new Quaternion(0, 0, 0, 0));
        upsideDownLvl = false;
    }

}
