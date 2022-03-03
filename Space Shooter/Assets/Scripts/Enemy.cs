using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;
    private float _maxBottomY = -4.0f;
    private float _maxTopY = 6.2f;

    // Start is ca lled before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < _maxBottomY)
        {   
            DisappearedBottom();
        }
    }

    void DisappearedBottom()
    {   
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, _maxTopY , 0);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
          
        }

         if(other.tag == "Player")
        {
            //Destroy(other.gameObject);
            Player player = other.transform.GetComponent<Player>(); 
            
            if(player != null){
                player.Damage();
            }
            
            Destroy(this.gameObject);
          
        }
    
    }
}
