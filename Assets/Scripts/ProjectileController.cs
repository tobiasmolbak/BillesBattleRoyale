using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public string playerName;
    public float damage;
    public Vector2 velocity;

    public void SetupProjectile(string playerName, float damage, Vector2 velocity) {
        this.playerName = playerName;
        this.damage = damage;
        this.velocity = velocity;
    }

    public void Explode() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D otherCollider) {
        GameObject colObj = otherCollider.gameObject;

        if (colObj.GetComponent<PlayerPlatformerController>() == null ||
            colObj.GetComponent<PlayerPlatformerController>().playerName != playerName) {
            Debug.Log("Collision: " + colObj.name);

            // Animate and destroy
            gameObject.GetComponent<Animator>().SetTrigger("Explode");
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
