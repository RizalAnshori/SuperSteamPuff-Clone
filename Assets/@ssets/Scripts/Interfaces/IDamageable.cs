﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable{
    void Damage(int _DamageAmount, GameObject _DamageSender);
}
