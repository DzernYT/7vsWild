using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ArmsController : MonoBehaviour
{
    [Header("Animation Rigging")]
    [SerializeField] private Rig changeWeaponRig;
    public float changeWeaponDuration = 0.3f;

    public bool isWeaponAttached = true;

    Animator armsAnimator;
    PlayerMovment playerMovment;
    PlayerController playerController;

    private bool isWeaponChanging;

    void Start()
    {
        armsAnimator = GetComponent<Animator>();

        playerMovment = FindObjectOfType<PlayerMovment>();
        playerMovment.OnPlayerSprintingUpdate += HandleSprintingAnimation;

        playerController = FindObjectOfType<PlayerController>();   
        playerController.OnWeaponChangeUpdate += HandlePlayerWeaponChange;
        playerController.OnWeaponAttackUpdate += HandlePlayerWeaponAttack;
        playerController.OnGrabingUpdate += HandlePlayerGrabing;
    }

    
    void Update()
    {
        if (isWeaponChanging)
        {
            // Set Rig Weight to 1
            changeWeaponRig.weight += Time.deltaTime / changeWeaponDuration;

            if (changeWeaponRig.weight == 1)
            {
                isWeaponChanging = false;
            }
        }
        // If Rig Weigt is 0, time to Change Weapon 




        // Set Rig Weight to 0
        else
            changeWeaponRig.weight -= Time.deltaTime / changeWeaponDuration;
    }

    //Checks if Player is sprinting
    public void HandleSprintingAnimation(bool sprinting)
    {
        if (sprinting)
        {
            armsAnimator.SetBool("isRunning",true);
        }
        else
        {
            armsAnimator.SetBool("isRunning", false);
        }
    }

    //Checks if Player change Weapon
    public void HandlePlayerWeaponChange(bool changeWeapon)
    {
        if (changeWeapon)
            isWeaponChanging = true; 
    }

    //Checks if Player is Attacking with Weapon
    public void HandlePlayerWeaponAttack(bool isAttacking)
    {
        if(isAttacking && isWeaponAttached)
            armsAnimator.SetTrigger("isAttack");
    }

    //Checks if Player is Grabing 
    public void HandlePlayerGrabing(bool isGrabing)
    {
        if (isGrabing)
            armsAnimator.SetTrigger("isGrabing");
    }
}
