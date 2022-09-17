using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public CharacterMove charMove;
   public void PlayerInterAction()
    {
        Debug.Log("Player Interacted");
        charMove.doAttack();
    }
}
