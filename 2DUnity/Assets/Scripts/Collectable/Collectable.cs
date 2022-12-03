using UnityEngine;

public enum CollectableItem
{
    Coin,
}

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableItem _item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (_item == CollectableItem.Coin)
            {
                collision.gameObject.GetComponent<Player>().CollectCoin();
                Destroy(this.gameObject);
            }
        }
    }
}
