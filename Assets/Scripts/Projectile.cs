using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 5.0f;
    public float Damage = 5.0f;
    public Entity OwnedBy;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ENTERED COLLISION");
        Entity hitEntity = collision.gameObject.GetComponent<Entity>();
        if (hitEntity == null)
        {
            Debug.Log("HIT NOTHING");
            return;
        }
        if (hitEntity is PlayerController && OwnedBy is PlayerController)
        {
            Debug.Log("PLAYER HIT PLAYER");
            return;
        }
        if (hitEntity is Enemy && OwnedBy is Enemy)
        {
            Debug.Log("ENEMY HIT ENEMY");
            return;
        }
        hitEntity.Damage(Damage);
        Debug.Log("DAMAGE TAKEN");


        Destroy(gameObject);
    }
}
