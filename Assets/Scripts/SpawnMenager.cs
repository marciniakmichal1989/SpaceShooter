using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _timeBetweneRespown = 2f;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpowning = false;

    void Start(){
        StartCoroutine(SpawRutine());
    }


    void Update()
    {

        
    }
    
    IEnumerator SpawRutine(){

        while(_stopSpowning == false){
            Vector3 posToSpown = new Vector3(Random.Range(-9,9),Random.Range(7,8),0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpown, Quaternion.identity);   
            newEnemy.transform.parent = _enemyContainer.transform;
        yield return new WaitForSeconds(_timeBetweneRespown);
        }   

    }

    public void OnPlayerDeath(){
        _stopSpowning = true;

    }
}
