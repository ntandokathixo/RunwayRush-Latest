using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRoute : MonoBehaviour
{
    public GameObject FlipSpot, FlipSpot2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == FlipSpot)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 0);
        }

        if (collision.gameObject == FlipSpot2)
        {
            transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y , 0);
        }
    }
}