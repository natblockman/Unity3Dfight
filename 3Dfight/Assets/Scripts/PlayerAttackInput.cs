using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimation playerAnimation;

    public GameObject attackPoint;

    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.Defend(true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack0();
            }
            else
            {
                playerAnimation.Attack1();
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
