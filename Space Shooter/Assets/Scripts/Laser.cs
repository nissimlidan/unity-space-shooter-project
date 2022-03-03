using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _laser_speed = 7.1f;

    // Update is called once per frame
    void Update()
    {
        calculateLaserMovement();
    }

    void calculateLaserMovement()
    {
        transform.Translate(Vector3.up * _laser_speed * Time.deltaTime);
        if(transform.position.y > 7f)
        {
            DestroyGameObject();
        }
    } 

    void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}



