using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ShopItem
{
    public override void Buy()
    {
        RoomsGenerator generator = FindObjectOfType<RoomsGenerator>();
        generator.transform.position = transform.position;
        generator.Start();
        Destroy(gameObject);
    }
}
