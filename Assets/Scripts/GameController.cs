using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Target;    //Префаб цілі (сфери)
    public static int _Score;    //Рахунок

    private GameObject scoreText;


    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreCount");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TargetSpown(); 
            
        }

        scoreText.GetComponent<Text>().text = "Score: " + _Score;
    }

    //Спаун цілі
    private void TargetSpown()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            Instantiate(Target, new Vector3 (hit.point.x, hit.point.y+0.2f, hit.point.z), Quaternion.identity);
        }
    }
}
