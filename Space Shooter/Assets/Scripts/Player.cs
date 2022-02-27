using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3.5f;

   [SerializeField]
    private GameObject _laserPrefabs;
   
    
    void Start()
    {
        //transform.position = new Vector3(0, 0, 0); // transform to object to the 0,0,0 point
 
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();

        if(Input.GetKeyDown(KeyCode.Space)){
            
            Instantiate(_laserPrefabs, transform.position, UnityEngine.Quaternion.identity);
        }

        
    
    }

    void calculateMovement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        UnityEngine.Vector3 direction = new UnityEngine.Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);


        //player position x is between -11.8f to 11.8f and y is between -3.8f to 0

        transform.position = new UnityEngine.Vector3(Mathf.Clamp(transform.position.x, -11.8f, 11.8f), Mathf.Clamp(transform.position.y, -3.8f,5), 0);

    }
}
