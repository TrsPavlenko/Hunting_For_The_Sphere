using UnityEngine;

public class Player : MonoBehaviour
{

    private GameObject target;
    private int speed;

    // Start is called before the first frame update
    private void Awake()
    {
        speed = 3;
        gameObject.GetComponent<ParticleSystem>().Stop();
    }


    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Target"))
        {
            MovePlayer();
        }
    }

    //Переміщення гравця до цілі
    private void MovePlayer()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        transform.LookAt(target.transform);
        transform.position += (target.GetComponent<Transform>().position - transform.position) * speed *
                              Time.deltaTime;
    }

    //Дії при зіткненні з ціллю
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<AudioSource>().Play(); //Звук розбитої цілі
            gameObject.GetComponent<ParticleSystem>().Play();    //Частки розбитої цілі
            GameController._Score++; //Збільшення рахунку
        }

    }
}
