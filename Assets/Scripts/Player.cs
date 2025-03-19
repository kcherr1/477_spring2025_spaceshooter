using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public Transform spawnPt;
    public Slider sliderHealth;
    public GameObject expoPrefab;
    public AudioClip clipBullet;
    public AudioClip clipExpo;

    private float curHealth;
    private float maxHealth;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start() {
        audioSrc = GetComponent<AudioSource>();
        maxHealth = 100;
        curHealth = maxHealth;
        sliderHealth.value = 1.0f;
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
            audioSrc.clip = clipBullet;
            audioSrc.Play();
        }
        if (input.ShootMissile.WasPressedThisFrame()) {
            var missile = Instantiate(missilePrefab);
            missile.transform.position = spawnPt.position;
            audioSrc.clip = clipBullet;
            audioSrc.Play();
        }
        sliderHealth.value = (curHealth / maxHealth);
    }

    public void DamagePlayer(float amount) {
        curHealth -= amount;
        if (curHealth < 0) {
            var expo = Instantiate(expoPrefab);
            expo.transform.position = this.transform.position;
            gameObject.SetActive(false);
            curHealth = 0;
        }
    }
}
