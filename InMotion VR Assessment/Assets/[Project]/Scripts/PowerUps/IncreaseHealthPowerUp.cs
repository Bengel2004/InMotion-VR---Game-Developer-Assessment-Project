using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NielsDev.Objects;

namespace NielsDev.PowerUps
{
    public class IncreaseHealthPowerUp : PowerUp
    {
        public override void ActivatePowerUp(Collider2D collision)
        {
            collision.GetComponent<Player>().IncreaseHealth(value);
        }
    }
}
