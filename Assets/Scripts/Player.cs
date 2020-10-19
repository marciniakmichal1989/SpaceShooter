using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private float _canFire = -1;
    [SerializeField]
    private int _lives = 3;
    private SpawnMenager _spawManager;
    private bool isTripleShotActive = false;
    [SerializeField]
    private GameObject _trippleShot;
    [SerializeField]
    private float _trippleShotTurningOf = 0f;

    [SerializeField]
    private float _speedMultiplier = 2f;
    private bool _isSpeedBoostActive = false;

     private bool _isShieldActive = false;
     //private bool _ShieldVisulal = false;
     [SerializeField]
     private GameObject _shieldVisualizer;

    [SerializeField]
     private int _score;

     private UIMenager _uiMenager;

     [SerializeField] GameObject _Right_Engine;
     [SerializeField] GameObject _Left_Engine;




    


//////////////////////////////////////////////////////////////////

    void Start(){

        _Right_Engine.SetActive(false);
        _Left_Engine.SetActive(false);

    transform.position = new Vector3(0,-3,0);   

    _spawManager = GameObject.Find("Spawn_Menager").GetComponent<SpawnMenager>();    
    _uiMenager = GameObject.Find("Canvas").GetComponent<UIMenager>();

    while(_spawManager == null){
        Debug.LogError("SpawManager is null");
        }

    if (_uiMenager == null){
        Debug.LogError("_uiMenager is null");
    }
    
    }

//////////////////////////////////////////////////////////////////

    void Update(){
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire){
            FireLaser();  
 
        }    
  
    }

//////////////////////////////////////////////////////////////////

    void CalculateMovement(){

        // 1) Input form player 2) Force/acction 
        
        float vericalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal"); 

        Vector3 direction = new Vector3(horizontalInput,vericalInput,0);

            transform.Translate(direction * _speed * Time.deltaTime);       
              
        if (transform.position.y >= 0){
            transform.position = new Vector3(transform.position.x,0,0);
        }
        else if(transform.position.y <= -3.8f){
            transform.position = new Vector3(transform.position.x,-3.8f,0);}

        if (transform.position.x < -11.35f){    
            transform.position = new Vector3(11.19f,transform.position.y,0);
        }else if(transform.position.x >=11.20f){
            transform.position = new Vector3(-11.34f,transform.position.y,0);}
    }

//////////////////////////////////////////////////////////////////

    void FireLaser(){
        _canFire = _fireRate + Time.time;
            if (isTripleShotActive == true){
                Instantiate(_trippleShot, transform.position + new Vector3(0,1.1f,0), Quaternion.identity);
            }else{
                Instantiate(_laserPrefab, transform.position + new Vector3(0,1.1f,0), Quaternion.identity);
            };              
    }

//////////////////////////////////////////////////////////////////

    public void Damage(){

        if (_isShieldActive  == true){     
        _isShieldActive = false;
        _shieldVisualizer.SetActive(false);
        return;
        }

        _lives -= 1;

        if (_lives == 2){
            _Right_Engine.SetActive(true);
        }else if((_lives == 1)){
            _Left_Engine.SetActive(true); 
        }

        _uiMenager.UpdateLives(_lives);

        if(_lives == 0){
        _spawManager.OnPlayerDeath();
        Destroy(this.gameObject);
        }
    }

//////////////////////////////////////////////////////////////////

    public void TripleShotActive(){
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRutine());
    }
    
//////////////////////////////////////////////////////////////////

    IEnumerator TripleShotPowerDownRutine(){ 
        yield return new WaitForSeconds(5f);
        isTripleShotActive = false;     

    }

//////////////////////////////////////////////////////////////////


    public void SpeedBoostActive(){
        _isSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostRutine());
    }

//////////////////////////////////////////////////////////////////

    IEnumerator SpeedBoostRutine(){ 
        yield return new WaitForSeconds(5f); 
        _isSpeedBoostActive = false;
        _speed /= _speedMultiplier;
        }

////////////////////////////////////////////////////////////////// 

    public void ShieldActive(){
        _isShieldActive  = true;    
       _shieldVisualizer.SetActive(true);

    }

//////////////////////////////////////////////////////////////////

    public void AddScore(int points){
        _score += points;
        _uiMenager.UpdateScore(_score);

    }

}
