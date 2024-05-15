using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : PoolObject
{
	[SerializeField]
	string hitEffectName = "BigExplosion";
	// Start is called before the first frame update
	private void OnCollisionEnter2D(Collision2D other) 
	{
		Explosion effect = (Explosion)PoolManager.Instance.Spawn(hitEffectName);
		effect.transform.position = transform.position;
		effect.transform.rotation = transform.rotation;
		this.OnDeSpawn();
	}
}
