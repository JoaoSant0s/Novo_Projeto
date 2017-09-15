using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("AI System")]

    [SerializeField]
    TriggerDistance trigger;
    [SerializeField]
    bool fixedEnemy;
    [SerializeField]
    float attackDistance;    
    [SerializeField]
    float velocity;
    [SerializeField]
    Action action;

    [SerializeField]
    Rigidbody2D rg;

    public enum State
    {
        IDLE,
        FOLLOWING,
        ATTACKING
    }

    State state;

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

    void Start()
    {
        state = State.IDLE;
        character = FindObjectOfType<Character>();
    }   

    private void Update()
    {
        if (!trigger.TriggerFollow) return;

        var direction = (character.transform.position - transform.position);
        direction.Normalize();

        Flip(direction);

        //&& state == State.IDLE) state = State.FOLLOWING;        

        if (Mathf.Abs(character.transform.position.x - transform.position.x) < attackDistance)
        {
            state = State.ATTACKING;
        }
        else
        {
            state = State.FOLLOWING;          
        }

        if (state == State.FOLLOWING)
        {            
            MoveTo(direction);            
        } else if(state == State.ATTACKING)
        {
            action.ExecuteAction();
        }
    }

    void MoveTo(Vector3 direction)
    {
        rg.velocity = new Vector2(velocity * direction.x, rg.velocity.y);        
    }

    void Flip(Vector3 direction)
    {
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
