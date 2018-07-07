using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

    public float fireRate = 0;
    public float damage = 10;
    public LayerMask notToHit;
    public Rigidbody2D projectile;
    public float projectileSpeed = 20;
    public string shootButton = "Fire1";

    private float timeToFire = 0;
    private Transform firePoint;
    private PlayerPlatformerController playerCtrl;

	// Use this for initialization
	void Awake () {
        firePoint = this.gameObject.transform.Find("ShootPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(shootButton)) {
            Rigidbody2D bulletInstance = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(projectileSpeed, 0);
        }
	}
}
