using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks : MonoBehaviour
{
    private Vector2 MovingDirection = Vector2.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "Moving")
        {
            UpdateMovement();
        }
    }
    private void UpdateMovement()
    {
        if (transform.position.x > 15f)
        {
            MovingDirection = Vector2.left;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (transform.position.x < 1f)
        {
            MovingDirection = Vector2.right;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        transform.Translate(MovingDirection * Time.smoothDeltaTime);
    }
}
