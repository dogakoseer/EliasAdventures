using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechCheck : MonoBehaviour
{
    void FixedUpdate()
    {
        Collider2D tutos = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Mech"));
        if (tutos != null)
            tutos.GetComponent<Mech_Game>().Show();
    }
}
