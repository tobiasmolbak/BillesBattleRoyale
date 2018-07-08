using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

    public string shootButton = "Fire1";
    public float fireRate = 0;
    public float damage = 10;
    public float speed;
    public float flightTime;
    public Rigidbody2D projectilePrefab;
    public LayerMask notToHit;

    private float timeToFire = 0;
    private List<GameObject> projectileList = new List<GameObject>();
    private PlayerPlatformerController playerCtrl;
    private Animator playerAnimator;
    private Transform firePoint;

    // Use this for initialization
    void Awake () {
        firePoint = this.gameObject.transform.Find("ShootPosition");
        playerCtrl = this.gameObject.GetComponentInParent<PlayerPlatformerController>();
        playerAnimator = playerCtrl.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(shootButton)) {
            playerAnimator.SetTrigger("Shoot");
            Fire();
        }
	}

    private void Fire() {
        if (playerCtrl.facingRight) {
            Rigidbody2D bulletInstance = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(speed, 0);

            Destroy(bulletInstance.gameObject, flightTime);
        } else {
            Rigidbody2D bulletInstance = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(-speed, 0);

            Destroy(bulletInstance.gameObject, flightTime);
        }
    }
}
