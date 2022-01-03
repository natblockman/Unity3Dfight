using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimation playerAnimation;

    public GameObject attackPoint;

    private PlayerMovement playerMovement;

    private PlayerShield playerShield;

    private CharacterSoundFX SoundFX;

    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimation>();
        playerShield = GetComponent<PlayerShield>();
        SoundFX=GetComponentInChildren<CharacterSoundFX>();
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.Defend(true);
            playerShield.ActiveShield(true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false);
            playerShield.ActiveShield(false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack0();
                SoundFX.Attack_Sound1();
               
            }
            else
            {
                playerAnimation.Attack1();
                SoundFX.Attack_Sound2();

            }

        }
    }
    void Active_AttackPoint()
    {
        attackPoint.SetActive(true);
    }
    void Deactive_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
