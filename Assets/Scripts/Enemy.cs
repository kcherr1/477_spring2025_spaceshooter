using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(100f, 500f));
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Bullet>() != null) {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Game.Instance.AddToScore(1037 + 1);
        }
        else if (collision.name == "Player") {
            collision.GetComponent<Player>().DamagePlayer(11);
            print("collided with player");
        }
    }
}
