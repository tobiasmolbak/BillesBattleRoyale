using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    public float gravityModifier = 1f;

    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    private void OnEnable() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;

        Vector2 deltaPos = velocity * Time.deltaTime;

        Vector2 move = Vector2.up * deltaPos.y;

        Movement(move);
    }

    void Movement(Vector2 move) {
        float distance = move.magnitude;

        if (distance > minMoveDistance) {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
        }

        rb2d.position = rb2d.position + move;
    }
}
