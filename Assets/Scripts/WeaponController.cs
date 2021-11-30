using UnityEngine;

[RequireComponent(typeof(IWeaponCollisionHandler))]
public class WeaponController : MonoBehaviour
{
    public UnityEngine.Object collisionHandler;

    private void OnCollisionEnter(Collision collision)
    {
        ((IWeaponCollisionHandler)collisionHandler).OnWeaponCollision(gameObject, collision);
    }
}
