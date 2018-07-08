﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 20;
    public bool facingRight = true;

    private bool prevGrounded;
    private bool doubleJumpReady = false;
    private Transform mTransform;
    private Animator mAnimator;

    // Use this for initialization
    void Start() {
        mTransform = GetComponent<Transform>();
        mAnimator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity() {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        // Jump / Double jump
        if (Input.GetButtonDown("Jump") && (grounded || doubleJumpReady)) {
            if (grounded) {
                doubleJumpReady = true;

                velocity.y = jumpTakeOffSpeed;
                mAnimator.SetFloat("Jump", Mathf.Abs(velocity.y));

            } /*else if (doubleJumpReady) {
                doubleJumpReady = false;

                mAnimator.SetTrigger("Jump2");
                velocity.y = velocity.y + jumpTakeOffSpeed;
            }*/
        }

        // Landing
        if (grounded && !prevGrounded) {
            mAnimator.SetFloat("Jump", Mathf.Abs(velocity.y));
            doubleJumpReady = false;
        }

        // Falling
        if (!grounded && velocity.y < 0) {
            mAnimator.SetTrigger("Falling");
            mAnimator.SetFloat("Jump", Mathf.Abs(velocity.y));
        }

        // Walking
        if (velocity.x > 0 && grounded) {
            mAnimator.SetFloat("Walk", Mathf.Abs(velocity.x));
        } else if (velocity.x <= 0 && grounded) {
            mAnimator.SetFloat("Walk", Mathf.Abs(velocity.x));
        }

        targetVelocity = move * maxSpeed;

        Flip(move);

        prevGrounded = grounded;
    }

    private void Flip(Vector2 move) {
        if (move.x < 0 && facingRight) {
            facingRight = !facingRight;

            mTransform.localScale = new Vector3(mTransform.localScale.x * -1, mTransform.localScale.y, mTransform.localScale.z);

        } else if (move.x > 0 && !facingRight) {
            facingRight = !facingRight;

            mTransform.localScale = new Vector3(mTransform.localScale.x * -1, mTransform.localScale.y, mTransform.localScale.z);

        }
    }
}
