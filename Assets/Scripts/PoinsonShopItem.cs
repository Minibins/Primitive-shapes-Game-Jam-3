public class PoinsonShopItem : ShopItem
{
  public override void Buy()
  {
    FindObjectOfType<PlayerHealth>().RegenerateHealth(2);
    base.Buy();
  }
}
