using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        // Check if the player object is null or has been destroyed
        if (player == null)
            return;

        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;
        cameraPosition.y = Mathf.Lerp(cameraPosition.y, player.position.y, Time.deltaTime * 5f);
        transform.position = cameraPosition;
    }
}
