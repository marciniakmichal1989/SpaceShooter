﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;


    void Start()
    {
        transform.position = new Vector3(Random.Range(-8,9),8,0);
    }


    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime); 
        if (transform.position.y <= -6){
                Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            Player player = other.transform.GetComponent<Player>();

            if (player != null){
                player.TripleShotActive();
                Destroy(this.gameObject);
                
            }
        }

    }
    
}
