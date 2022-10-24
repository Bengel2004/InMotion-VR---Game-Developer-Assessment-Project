using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NielsDev.Objects;

namespace NielsDev.PowerUps
{
    public class HealthPowerUp : PowerUp
    {
        public override void ActivatePowerUp(Collider2D collision)
        {
            collision.GetComponent<Player>().ResetHealth();
        }
    }
}
