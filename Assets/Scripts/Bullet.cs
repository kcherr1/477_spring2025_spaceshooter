using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float moveSpeed;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Screen bounds")) {
            Destroy(gameObject);
        }
    }

}
