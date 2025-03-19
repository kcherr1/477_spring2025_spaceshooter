using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour {
    #region public fields
    public GameObject enemyPrefab;
    public TextMeshProUGUI txtScore;
    #endregion

    // private fields and properties
    private float enemyTimer;
    private float score;
    public static SpaceShooterControls Input { get; private set; }
    // singleton design
    public static Game Instance { get; private set; }

    // Start is called before the first frame update
    void Start() {
        Instance = this;
        Input = new SpaceShooterControls();
        enemyTimer = float.MaxValue;
    }

    // Update is called once per frame
    void Update() {
        enemyTimer -= Time.deltaTime;
        if (enemyTimer < 0) {
            Instantiate(enemyPrefab);
            enemyTimer = Random.Range(2f, 7f);
        }
        txtScore.text = score.ToString("0000000");
    }

    public void StartGame(GameObject mainMenuScreen) {
        Input.Enable();
        mainMenuScreen.SetActive(false);
        enemyTimer = 3f;
        score = 0;
    }

    public void AddToScore(float amount) {
        score += amount;
    }
}
