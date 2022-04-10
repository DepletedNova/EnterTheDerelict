using Assets.Scripts;
using Assets.Scripts.Ships;
using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : BaseShip
{
    public override ShipType shipType => ShipType.PLAYER;

    public void Start()
    {
        UpdateShip(new DefaultShip());
        UpdateWeapon(new DefaultWeapon());
        Game.instance.player = this;
    }

    private bool leftMouseDown = false;
    private bool rightMouseDown = false;
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // Movement
        if (rightMouseDown) AddMovement(transform.up);

        weaponData.FireWeapon(this, leftMouseDown);
    }

    public void Update()
    {
        // Right Mouse Update
        if (Input.GetMouseButtonDown(1) && !rightMouseDown) { rightMouseDown = true; Moving = true; }
        if (Input.GetMouseButtonUp(1) && rightMouseDown) { rightMouseDown = false; Moving = false; }
        // Left Mouse Update
        if (Input.GetMouseButtonDown(0)) { leftMouseDown = true; }
        if (Input.GetMouseButtonUp(0)) { leftMouseDown = false; }
    }

    public void LateUpdate()
    {
        // Rotation
        if (Camera.main != null) RotateToVector(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
