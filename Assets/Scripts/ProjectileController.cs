using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float damage;
    public Vector2 velocity;

    public void Explode() {
        Destroy(gameObject);
    }
}
