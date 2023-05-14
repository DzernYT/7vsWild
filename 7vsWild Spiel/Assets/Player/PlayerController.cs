using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerController : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode changeWeaponKey = KeyCode.Q;
    public KeyCode grabKey = KeyCode.E;
    public KeyCode attackWeaponKey = KeyCode.Mouse0;

    private bool isWeaponChanging;
    private bool isWeaponAttacking;
    private bool isGrabing;

    public event Action <bool> OnWeaponChangeUpdate;
    public event Action <bool> OnWeaponAttackUpdate;
    public event Action <bool> OnGrabingUpdate;


    void Update()
    {
        if (Input.GetKeyDown(changeWeaponKey))
        {
            isWeaponChanging = true;
            OnWeaponChangeUpdate?.Invoke(isWeaponChanging);
        }
        else
            isWeaponChanging=false;

        if (Input.GetKeyDown(attackWeaponKey))
        {
            isWeaponAttacking = true;
            OnWeaponAttackUpdate?.Invoke(isWeaponAttacking); 
        }
        else
        isWeaponAttacking=false;

        if (Input.GetKeyDown(grabKey))
        {
            isGrabing = true;
            OnGrabingUpdate?.Invoke(isGrabing);
        }
        else 
            isGrabing=false;
    }
}
