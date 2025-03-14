using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public Transform spawnPt;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        var input = Game.Input.Standard;
        //if (input.MoveUp.ReadValue<float>() != 0) {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * input.MoveUp.ReadValue<float>());
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime * input.MoveDown.ReadValue<float>());
        //}
        if (input.ShootBullet.WasPressedThisFrame()) {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnPt.position;
        }
        if (input.ShootMissile.WasPressedThisFrame()) {
            var missile = Instantiate(missilePrefab);
            missile.transform.position = spawnPt.position;
        }
    }
}
