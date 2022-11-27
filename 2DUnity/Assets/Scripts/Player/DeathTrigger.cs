using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            ResetPlayerPosition(collision.gameObject);
    }

    private void ResetPlayerPosition(GameObject player)
    {
        player.transform.position = Vector3.zero;
    }
}
