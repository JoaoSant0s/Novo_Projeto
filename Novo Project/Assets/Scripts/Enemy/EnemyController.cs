using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum Direction
    {
        left,
        right
    }
    private Direction flipDirection;

    private Character character;

    public Character Character {
        get { return character; }
    }

    private void Start()
    {
        character = FindObjectOfType<Character>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shot")
        {
            DestroyObject(collision.gameObject);
            DestroyObject(gameObject);
        }
    }

    private void Update()
    {
        Flip();               
    }

    void Flip()
    {
        var direction = (character.transform.position - transform.position);
        direction.Normalize();

        if(direction.x < 0 && flipDirection == Direction.right)
        {
            flipDirection = Direction.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(direction.x >= 0 && flipDirection == Direction.left)
        {
            flipDirection = Direction.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
             
    }
}
