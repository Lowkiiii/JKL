using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    [SerializeField] private GameObject mobPrefab;

    //Time between spawns
    private float timeElapsed = 5;

    //Updated mob position with reference to this game object
    Vector2 mobPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed > 0)
        {
            timeElapsed -= Time.deltaTime;
        }
        else
        {
            //Generate random y value
            //2 units and -2 units from this object
            float y_pos = Random.Range(-4f, 4f);

            mobPosition = new Vector2(transform.position.x, transform.position.y + y_pos);

            //Spawn objects
            Instantiate(mobPrefab, mobPosition, Quaternion.identity);
            timeElapsed = 5;
        }

    }
}
