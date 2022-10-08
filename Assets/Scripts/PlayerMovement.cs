using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //마우스 오른쪽: 방향 전환
    //마우스 왼쪽: 이동

    private Camera camera;    //마우스 위치 월드로 표시하기 위해
    private Vector3 destination;

    public float speed = 3f;
    public float turnSpeed = 1.5f;
    Quaternion dir;  //쿼터니언이 바라볼 방향값

    //public float attackDelay = 10f;
    //float attackTime=0f;

    InputManager playerInput;
    Rigidbody playerRigidbody;
    Animator playerAnimator;

    RaycastHit hit;
    

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Horizon();

        playerAnimator.SetBool("Idle", Input.GetMouseButtonDown(0));
        if (Input.GetMouseButton(0))
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50f);
            destination = hit.point;
            destination.y = transform.position.y; //y위치는 고정

            dir = Quaternion.LookRotation((destination - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, dir, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
           
                OnAttack();
                //attackTime = Time.time;
           

        }
    }

    private void Move()
    {

        if (playerInput.move > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.forward), 0.5f);

            playerRigidbody.MovePosition(playerRigidbody.position + transform.forward * Time.deltaTime * speed);

            playerAnimator.SetFloat("Move", Mathf.Abs(playerInput.move));
        }
        if (playerInput.move < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.forward), 0.5f);

            playerRigidbody.MovePosition(playerRigidbody.position - transform.forward * Time.deltaTime * speed );

            playerAnimator.SetFloat("Move", Mathf.Abs(playerInput.move));
        }
    }
    void Horizon()
    {
       
        Vector3 Horizon = playerInput.hor * speed * transform.right * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + Horizon);
        playerAnimator.SetFloat("Hor", playerInput.hor);
 
    }
    
    public void OnAttack()
    {
        playerAnimator.SetTrigger("Attack");
    }
}

