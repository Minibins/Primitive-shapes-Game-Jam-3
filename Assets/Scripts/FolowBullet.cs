using TMPro;

using UnityEngine;

public class FolowBullet : Bullet
{
    public bool IsFolow;
    public float FollowSpeed;
    public Transform targetTransform;
    private void Start()
    {
        if(Vector2.Distance(targetTransform.position,transform.position)<4) Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        if(IsFolow) Folow();
    }
    protected override void OtherBulletCollision()
    {
        Instantiate(_bulletEffect[2],transform.position,Quaternion.identity);
    }
    public void Folow()
    {
        if (targetTransform != null)
        {
            Vector3 targetPosition = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, FollowSpeed * Time.fixedDeltaTime * (Mathf.Min(Vector2.Distance(targetPosition,transform.position),10)/10));
        }
    }
}
