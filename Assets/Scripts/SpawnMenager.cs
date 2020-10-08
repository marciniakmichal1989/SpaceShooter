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
    [SerializeField]
    private GameObject _TripleShotPowerUpPrefab;

//////////////////////////////////////////////////////////////////

    void Start(){
        StartCoroutine(SpawEnemyRutine());
        StartCoroutine(SpawPowerupRutine());  
    }

//////////////////////////////////////////////////////////////////

    void Update()
    {
            
        
    }

//////////////////////////////////////////////////////////////////

    IEnumerator SpawEnemyRutine(){

        while(_stopSpowning == false){
            Vector3 posToSpown = new Vector3(Random.Range(-9,9),Random.Range(7,8),0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpown, Quaternion.identity);   
            newEnemy.transform.parent = _enemyContainer.transform;
        yield return new WaitForSeconds(_timeBetweneRespown);
        }   

    }

//////////////////////////////////////////////////////////////////

    IEnumerator SpawPowerupRutine(){
        while(_stopSpowning == false){
            Vector3 postToSpawn = new Vector3(Random.Range(-9f,9f),8,0);
            GameObject newPowerUp = Instantiate(_TripleShotPowerUpPrefab ,postToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f,8f));
            
        }
    }

//////////////////////////////////////////////////////////////////

    public void OnPlayerDeath(){
        _stopSpowning = true;

    }
}
