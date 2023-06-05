using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticMobs : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the enemy moves

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}
