using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private bool facingRight = true;
    private SpriteRenderer mSpriteRenderer;
    private Animator mAnimator;

	// Use this for initialization
	void Start () {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mAnimator = GetComponent<Animator>();
	}

    protected override void ComputeVelocity() {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        }

        // Letting go of jump button stops the acceleration
        /*else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > 0) {
                velocity.y = velocity.y * .5f;
            }
        }*/

        if (velocity.x > 0 && grounded) {
            mAnimator.SetFloat("Walk", Mathf.Abs(velocity.x));
        } else if (velocity.x <= 0 && grounded) {
            mAnimator.SetFloat("Walk", Mathf.Abs(velocity.x));
        }

        targetVelocity = move * maxSpeed;

        Flip(move);
    }

    private void Flip(Vector2 move) {
        if (move.x < 0 && facingRight) {
            facingRight = !facingRight;
            mSpriteRenderer.flipX = true;

        } else if (move.x > 0 && !facingRight) {
            facingRight = !facingRight;
            mSpriteRenderer.flipX = false;

        }
    }
}
