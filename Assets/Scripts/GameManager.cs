using UnityEngine;
using CodeMonkey.MonoBehaviours;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]private CameraFollow cameraFollow;
    [SerializeField]private float zoomMin;
    [SerializeField]private float zoomMax;
    private GameController gameController;
    //private Text uiText1;
    //private Text uiText2;
    private Vector3 cameraPosition;
    private float orthoSize = 10f;

    public GameObject personPrefab;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        cameraFollow = Camera.main.gameObject.GetComponent<CameraFollow>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (cameraFollow != null)
        {
            cameraFollow.Setup(() => cameraPosition, () => orthoSize, true, false);
        }
        GridBase grid = new GridBase();
        grid.Build(25, 30, 1f, new Vector3(-10, -10));
        //uiText1 = GameObject.Find("GuestBug").GetComponent<Text>();
    } 

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        float scrollAxis = Input.GetAxis("Mouse ScrollWheel");
        float cameraSpeed = 10f;


        //uiText1.text = "ZAx: " + scrollAxis + " | x2" + scrollAxis * 2f;

        if (gameController.people.Count > 0)
        {
            cameraPosition = gameController.people[0].gameObject.transform.position;
        }
        else
        {
            if (horizontalAxis > 0) cameraPosition += new Vector3(+1, 0) * cameraSpeed * Time.deltaTime;
            if (horizontalAxis < 0) cameraPosition += new Vector3(-1, 0) * cameraSpeed * Time.deltaTime;
            if (verticalAxis > 0) cameraPosition += new Vector3(0, +1) * cameraSpeed * Time.deltaTime;
            if (verticalAxis < 0) cameraPosition += new Vector3(0, -1) * cameraSpeed * Time.deltaTime;
        }
        if (orthoSize <= zoomMin)
        {
            orthoSize = zoomMin;
        }
        if (orthoSize >= zoomMax)
        {
            orthoSize = zoomMax;
        }
        orthoSize -= scrollAxis;

    }


    public void CreatePerson()
    {
        GameObject person = Instantiate(personPrefab, new Vector3(10f,10f,1f), Quaternion.identity) as GameObject;
        //person.GetComponent
        person.name = "New Person";
    }
}
