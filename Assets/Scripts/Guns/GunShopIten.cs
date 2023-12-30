using UnityEngine;

public class GunShopIten : ShopItem
{
    [SerializeField] private int _id;
    public override void Buy()
    {
        FindObjectOfType<GunSwipe>().GunItems[_id].CanSwap = true;
        base.Buy();
    }
}