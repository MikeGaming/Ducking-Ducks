using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectile Projectile;
    public Entity Parent;
    public float FireRate;
    public float _cooldown;

    public virtual void Fire()
    {
        if (_cooldown > 0) return;
        if (Input.GetKey(KeyCode.Z))
        {
            Projectile newProjectile = Instantiate(Projectile, transform.position, Parent.transform.rotation);
            newProjectile.OwnedBy = Parent;
            _cooldown = FireRate;
            StartCoroutine(DestroyOverSeconds(5.0f, newProjectile.gameObject));
        }
    }


    private void Update()
    {
        
        _cooldown -= Time.deltaTime;
    }

    public IEnumerator DestroyOverSeconds(float time, GameObject go)
    {
        yield return new WaitForSeconds(time);
        Destroy(go);
    }
}
