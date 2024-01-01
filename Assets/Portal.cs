using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ShopItem
{
    public override void Buy()
    {
        FindObjectOfType<RoomsGenerator>().Start();
    }
}
