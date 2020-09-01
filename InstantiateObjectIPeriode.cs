using UnityEngine;

public class FakeBallMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardVelocity= 10f;
    public ParticleSystem smokeParticle ;
    public GameObject Ball;
    public GameObject fakeBall;
    private Vector3 fakeBallPosition = new Vector3(20f, 0f, 0f);
    private Vector3 randomYPosition = new Vector3(0f, 0f, 0f);
    private float[] possibleYPositions = {0f, 0.5f ,0.8f, 7.5f,7.8f, 8f, 8.3f};
    private float lifetime = 2f;
    Renderer rend;



    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        smokeParticle.Play();
        this.GetComponent<MaterialColorChange>().ChangeColorMaterial();
        
    }
    void Update(){
      
        rb.velocity = new Vector3(forwardVelocity * Time.deltaTime, 0f, 0f);
        instantiateFakeBall();
        
    }

    void instantiateFakeBall() {
        if(lifetime > 0) {
            lifetime -= Time.deltaTime;

            if(lifetime <= 0) {

                randomYPosition = new Vector3(0f,selectRandomY(),0f);
                Instantiate(fakeBall,new Vector3(Ball.transform.position.x,0f,0f) + fakeBallPosition + randomYPosition, Ball.transform.rotation);
                this.GetComponent<MaterialColorChange>().ChangeColorMaterial();
            }
        }
    }
    void Destruction() {
        Destroy(this.gameObject);
    }

    private float selectRandomY() {
        
        int selectYPosition  = Random.Range(0, possibleYPositions.Length);
        return possibleYPositions[selectYPosition];

    }
}