using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XBT;

public partial class EnemyInput {
    ReturnValue Chase()
    {
        ChaseUp();
        UseWeapon();
        return ReturnValue.Running;
    }

    void ChaseUp()
    {
        if (playerPos.position.y > transform.position.y)
        {
            movementScript.MoveUp();
        }
    }
}
