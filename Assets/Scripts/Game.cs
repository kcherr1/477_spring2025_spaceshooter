using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public static SpaceShooterControls Input { get; private set; }

    // Start is called before the first frame update
    void Start() {
        Input = new SpaceShooterControls();
        Input.Enable();
    }

    // Update is called once per frame
    void Update() {
        print("hey");
    }
}
