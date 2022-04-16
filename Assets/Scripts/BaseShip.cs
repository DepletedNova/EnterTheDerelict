using Assets.Scripts.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShip : MonoBehaviour
{
    public bool Wrapping = false;

    public enum ShipType { PLAYER, ENEMY }

    public abstract ShipType shipType { get; }
	
	public abstract (Ship ship, Weapon weapon) Defaults { get; }
	
    public Ship shipData;
    public Weapon weaponData;

    public float Health = 9999;

    public float ScaleMod = 1;
    public float ThrustMod = 1;
    public float DragMod = 1;
    public float RotationMod = 1;

    public float ProjectileDamageMod = 1;
    public float HullDamageMod = 1;

    public Vector3 Momentum = new Vector3();
    protected bool Moving = false;
	
	public virtual void Start()
	{
        UpdateShip(Defaults.ship);
        UpdateWeapon(Defaults.weapon);
	}
	
    protected float invCurrent = 0;
    protected float invTime = 0.03f;
    public virtual void FixedUpdate()
    {
        invCurrent += Time.fixedDeltaTime;

        // Movement drag
        if (!Moving)
        {
            if (Momentum != Vector3.zero)
            {
                Momentum = Vector3.Lerp(Momentum, Vector3.zero, Time.deltaTime / (1.5f * DragMod * shipData.Drag));
            }
        }

        // Wrapping
        if (Wrapping && Camera.main != null)
        {
            // Vertical
            if (Mathf.Abs(transform.position.y) > Camera.main.orthographicSize + Mathf.Max(transform.localScale.x, transform.localScale.y))
                transform.position = new Vector3(transform.position.x, transform.position.y < 0 ? Camera.main.orthographicSize : -Camera.main.orthographicSize);
            // Horizontal
            var aspectOrtho = Camera.main.orthographicSize * Screen.width / Screen.height;
            if (Mathf.Abs(transform.position.x) > aspectOrtho + Mathf.Max(transform.localScale.x, transform.localScale.y))
                transform.position = new Vector3(transform.position.x < 0 ? aspectOrtho : -aspectOrtho, transform.position.y);
        }

        // Movement
        GetComponent<Rigidbody2D>().velocity = Momentum;
    }

    // Data
    public void UpdateShip(Ship newShip)
    {
        shipData = newShip;
        Health = Health > newShip.Health ? newShip.Health : Health;
        gameObject.transform.localScale = Vector3.one * ScaleMod * shipData.Scale;
    }
    public void UpdateWeapon(Weapon newWeapon)
    {
        weaponData = newWeapon;
        if (newWeapon.StartInCooldown) weaponData.fireDelay = 0;
    }

    // Damage
    public void TakeDamage(float amount, BaseShip Source)
    {
        if (Source.shipType != shipType)
        {
            if (invCurrent >= invTime)
            {
                invCurrent = 0;
                Health -= amount;
                if (Health <= 0) DestroyShip();
            }
        }
    }
    public void DestroyShip()
    {
        var explosionPrefab = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"));
        explosionPrefab.transform.position = gameObject.transform.position;
        explosionPrefab.GetComponent<ParticleSystem>().Play();
        explosionPrefab.transform.localScale = gameObject.transform.localScale;
        Destroy(explosionPrefab, 6);
        Destroy(gameObject);
    }

    // Movement
    public void AddMovement(Vector3 Direction)
    {
        Momentum = Vector3.Lerp(Momentum, Direction * 20 * ThrustMod * shipData.Thrust, Time.deltaTime / 4);
    }

    public void RotateToVector(Vector3 Point)
    {
        Vector3 vectorToTarget = Point - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.smoothDeltaTime * 3 * shipData.Rotation * RotationMod);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BaseShip>() != null)
        {
            Vector3 vectorToTarget = collision.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector3 up = q * Vector3.up;
            Momentum -= up * 4;
            var hitShip = collision.gameObject.GetComponent<BaseShip>();
            TakeDamage(hitShip.shipData.HullDamage * hitShip.HullDamageMod, hitShip);
        }
    }
}
