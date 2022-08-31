using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    protected override void PowerUp(Player player)
    {
        player.GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;
        player._invicible = true;
    }

    protected override void PowerDown(Player player)
    {
        StartCoroutine(PowerDownTime(_powerUpDuration, player));
    }

    IEnumerator PowerDownTime(float waitTime, Player player)
    {
        yield return new WaitForSeconds(waitTime);
        player.GetComponentInChildren<MeshRenderer>().material.color = new Color(0.2693534f, 0.764151f, 0.2198736f);
        player._invicible = false;
        gameObject.SetActive(false);
    }

}
