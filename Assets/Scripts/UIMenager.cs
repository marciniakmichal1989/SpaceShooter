using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMenager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _RestartText;

    private GameMenager _gameMenager;

    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);  
        _RestartText.gameObject.SetActive(false);
        _gameMenager = GameObject.Find("Game_Menager").GetComponent<GameMenager>();

        if (_gameMenager == null)
        {
            Debug.LogError("Game_Menager is Null");
        }
    }


    void Update()
    {
        
    }

    public void UpdateScore(int playerScore){
        _scoreText.text = "Score: " + playerScore.ToString();
        _gameOverText.gameObject.SetActive(false);


    }

    public void UpdateLives(int currentLives){

        _livesImg.sprite = _liveSprites[currentLives];

        if (currentLives == 0){
            GameOverSequence();                       
        }

    }

    void GameOverSequence(){
        
        _gameMenager.GameOver();
        _gameOverText.gameObject.SetActive(true); 
        _RestartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRutine());     
    }

    IEnumerator GameOverFlickerRutine(){

        while(true){
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);

        }
    }

}
