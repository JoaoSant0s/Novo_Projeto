using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    ConstantForce2D constForce;

    public Rigidbody2D Rigidbody
    {
        get { return rb; }
    }

    public ConstantForce2D ConstantForce
    {
        get { return constForce; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.layer == LayerMask.NameToLayer("Plataform") )
        {
            DestroyObject(gameObject);
        }
    }

}
