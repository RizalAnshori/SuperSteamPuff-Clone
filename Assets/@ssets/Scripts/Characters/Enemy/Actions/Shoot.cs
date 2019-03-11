using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XBT;

public partial class EnemyInput {
    ReturnValue UseWeapon()
    {
        if (isTimeToShoot() && isTargetInRange())
        {
            //enemyWeapon.Shoot();
            return ReturnValue.Succeed;
        }
        return ReturnValue.Running;
    }

    bool isTargetInRange()
    {
        if (playerPos.position.y < transform.position.y + offSet && playerPos.position.y > transform.position.y - offSet)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool isTimeToShoot()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
