using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3f;

    private Player _player;

    Animator _anim;


    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _anim = GetComponent<Animator>();

        if (_anim == null){
            Debug.LogError("Animator is null");
        }
    }

//////////////////////////////////////////////////////////////////  

    void Update()
    {
        //6.5
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -6.5){
            float randomX = Random.Range(-12f,10f);
            transform.position = new Vector3(randomX,6.5f,0);
        }
    }

//////////////////////////////////////////////////////////////////


    private void OnTriggerEnter2D(Collider2D other){

        //Debug.Log("You Hit : " + other.transform.tag);

        if(other.gameObject.tag == "Player"){
            
            Player player = other.transform.GetComponent<Player>();

            if(player != null){
                 player.Damage(); 
            }      
            _anim.SetTrigger("OnEnymyDeath");   
            _speed = 0;    
            Destroy(this.gameObject,2.8f);
            
        }
        
        if(other.gameObject.tag == ("Laser")){
            Destroy(other.gameObject);  

            if (_player != null){
                _player.AddScore(10);
            }
            
            _anim.SetTrigger("OnEnymyDeath");
            _speed = 0;  
            Destroy(this.gameObject,2.8f);  

            
            }    

    }

//////////////////////////////////////////////////////////////////



}
