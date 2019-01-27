using UnityEngine;
using UnityEngine.AI;

public class DissonanceManager : MonoBehaviour
{

    public float HealthyDistance = 1;
    public float RotationWeight = 1;
    public float DistanceWeight = 1;

    private float score = 0;
    public float Score
    {
        get { return score; }
    }

    private float distance = 0;
    public float Distance
    {
        get { return distance; }
    }

    private float rotation = 0;
    public float Rotation
    {
        get { return rotation; }
    }

    private static DissonanceManager instance;
    public static DissonanceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject
                    .FindWithTag("DissonanceManager")
                    .GetComponent<DissonanceManager>();
                return instance;
            }
            else
            {
                return instance;
            }

        }
    }

    private GameObject player;
    private GameObject home;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        home = GameObject.FindWithTag("Home");
    }

    void Update()
    {
        var playerHit = new NavMeshHit();
        NavMesh.SamplePosition(
            player.transform.position, 
            out playerHit,
            10, 
            NavMesh.AllAreas);

        var homehit = new NavMeshHit();
        NavMesh.SamplePosition(
            home.transform.position,
            out homehit,
            10,
            NavMesh.AllAreas
        );

        var path = new NavMeshPath();
        var foundPath = NavMesh.CalculatePath(
            playerHit.position,
            homehit.position,
            NavMesh.AllAreas,
            path
        );

        if (foundPath)
        {
            var corners = path.corners;

            var totalDistance = 0.0f;
            for (var i = 0; i < corners.Length - 1; i++)
            {
                totalDistance += Vector3.Distance(
                    corners[i],
                    corners[i+1]
                );
            }
            distance = totalDistance;
            var distanceDissonance = GetDistanceDissonance(totalDistance);

            var rotationAngle = 180 - GetRotationAngle(corners[1]);
            rotation = rotationAngle;
            var rotationDissonance = rotationAngle / 180;

            var weightedDissonance = 
                ((distanceDissonance * DistanceWeight) +
                 (rotationDissonance * RotationWeight)) /
                (DistanceWeight + RotationWeight);
            score = weightedDissonance;   
        }
        else 
        {
            Debug.Log("Not on Mesh");
        }
    }

    private float GetDistanceDissonance(float distance)
    {
        var distanceRatio = HealthyDistance / distance;
        var clampedRatio = Mathf.Clamp01(distanceRatio);
        var ratioComplement = Mathf.Abs(1-clampedRatio);
        return ratioComplement;
    }

    private float GetRotationAngle(Vector3 waypoint)
    {
        var forward = player.transform.forward;
        var diff = player.transform.position - waypoint;
        var currentAngle = Vector3.Angle(forward, diff);
        return currentAngle;
    }
}
