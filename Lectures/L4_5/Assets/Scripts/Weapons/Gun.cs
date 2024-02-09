using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] 
	Transform firePoint;
	[SerializeField]
	string projectileName = "Bullet"; //we have replaced the prefab with our projectile's name (name of the prefab)
	[SerializeField]
	float bulletForce = 15f;
	
	
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	public virtual void Shoot(Vector2 additionalVelocity = new Vector2())
	{
		Bullet bullet = (Bullet)PoolManager.Instance.Spawn(projectileName);// Instantiate<Bullet>(bulletPrefab, firePoint);
		bullet.transform.position = firePoint.transform.position;
		bullet.transform.rotation = firePoint.transform.rotation;
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //we create a new copy of a bullet and then we get its rigid body
		rb.velocity = additionalVelocity;
		rb?.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //we add a force but we add an impulse force to represent a gun, because it is an impulse force
	}
	
}
