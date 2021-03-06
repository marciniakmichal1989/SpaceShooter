﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int PowerUpID;

    [SerializeField] private AudioClip _clip;



//////////////////////////////////////////////////////////////////

    void Start()
    {
        transform.position = new Vector3(Random.Range(-8,9),8,0);

    }

//////////////////////////////////////////////////////////////////

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime); 
        if (transform.position.y <= -6){
                Destroy(this.gameObject);
        }
    }

//////////////////////////////////////////////////////////////////

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);

            if (player != null){
                switch (PowerUpID){
                case 0:
                    player.TripleShotActive();
                    break;
                case 1:
                    player.SpeedBoostActive();
                    break;
                case 2:
                    player.ShieldActive();
                    break;
                    }
            Destroy(this.gameObject);
            }
        }
    }
       
}