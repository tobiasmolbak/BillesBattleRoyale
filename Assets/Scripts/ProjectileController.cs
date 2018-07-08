using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public string playerName;
    public float damage;
    public Vector2 velocity;

    public void Explode() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D otherCollider) {
        GameObject colObj = otherCollider.gameObject;

        Debug.Log(colObj.GetComponent<PlayerPlatformerController>().name);

        if (colObj.GetComponent<PlayerPlatformerController>().name != playerName) {
            Debug.Log("Collision: " + colObj.name);

            // Animate and destroy
            gameObject.GetComponent<Animator>().SetTrigger("Explode");
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
