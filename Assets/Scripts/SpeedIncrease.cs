using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float _speedAmount = 0.5f;

    protected override void Collect(Player player)
    {
        TankController controller = player.GetComponent<TankController>();
        if (controller != null)
        {
            controller.MaxSpeed += _speedAmount;
        }
    }

    protected override void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(MoveSpeed, MoveSpeed, MoveSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
