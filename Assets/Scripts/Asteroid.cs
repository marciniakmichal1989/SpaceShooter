using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField]
    private float _rotateSpeed = 3f;
    [SerializeField]
    private GameObject _explosionPrefab;

    private SpawnMenager _spawMenager;
    


    void Start()
    {
        _spawMenager = GameObject.Find("Spawn_Menager").GetComponent<SpawnMenager>();

    }


    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * _rotateSpeed);
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Laser"){
            Instantiate(_explosionPrefab, transform.position,Quaternion.identity);
            Destroy(other.gameObject);

            _spawMenager.StartSpawing();

            Destroy(this.gameObject,0.5f);
        }
    }
    
}
