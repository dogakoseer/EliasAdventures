using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mech_Game_Box : Mech_Game
{
    public Transform holdPoint; // yönü falan götürdüðümdeki konumu gibi
    private GameObject heldBox; // kutuyu tutmasý
    private Rigidbody2D heldBoxRb;
    public Button dropButton;

    public override void Apply()
    {
        base.Apply();
        if (heldBox == null)
        {
            Collider2D detectedBox = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Mech"));

            if (detectedBox != null && detectedBox.CompareTag("Pushable"))
            {
                heldBox = detectedBox.gameObject;
                heldBoxRb = heldBox.GetComponent<Rigidbody2D>();

                if (heldBoxRb != null)
                {
                    heldBoxRb.simulated= false; // fizik motoru durdur
                    //heldBox.transform.position = holdPoint.position;
                    heldBox.transform.position = holdPoint.position; // kutunun konumunun karakterin tutulmasýndaki yeri
                    heldBox.transform.parent = holdPoint;
                    SetDropButton();
                }
            }
        }
    }

    public override void Applied()
    {
        base.Applied();
    }
    public void SetDropButton()
    {
        dropButton.gameObject.SetActive(true);
        dropButton.onClick.AddListener(DropBox);
    }
    public void DropBox()
    {
        if (heldBox != null)
        {
            heldBox.transform.parent = null; // kutu karakter ayýrýr null 
            heldBoxRb.simulated = true; // fizik aktif
            heldBox = null; // kutuyu tutmuyor
            heldBoxRb = null;
        }
        dropButton.gameObject.SetActive(false);
    }
}