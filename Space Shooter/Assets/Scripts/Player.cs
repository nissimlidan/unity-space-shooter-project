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
 
    private float offset = 0.8f;
    private float _fireRate = 0.2f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    

   
    
    void Start()
    {
        transform.position = new UnityEngine.Vector3(0, 0, 0); // transform to object to the 0,0,0 point
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
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

    void FireLaser()
    {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefabs, transform.position + new UnityEngine.Vector3(0, offset, 0) ,UnityEngine.Quaternion.identity);
            
    }

    public void Damage()
    {
        _lives --;
        if(_lives < 1){
            _spawnManager.onPlayerDeath();
            Destroy(this.gameObject);
        }
                    
    }

}
