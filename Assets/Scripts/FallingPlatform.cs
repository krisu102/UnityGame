using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    private Rigidbody2D Rb;
    public float fallDelay;
    public float returnTime;
    public Vector2 startPosition;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    //if the player touch a platform it will start falling in fixed time
    //and then it will return to its original position
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            StartCoroutine(ReturnPlat());
        }
    }

    void Fall()
    {
        Rb.isKinematic = false;
    }

    IEnumerator ReturnPlat()
    {
        yield return new WaitForSeconds(returnTime);
        Rb.isKinematic = true;
        transform.position = startPosition;
        Rb.velocity = Vector2.zero;
    }
   
}
