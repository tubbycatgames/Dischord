using UnityEngine;

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
        var currentDistance = Vector3.Distance(
            home.transform.position,
            player.transform.position
        );
        distance = currentDistance;
        var distanceDissonance = GetDistanceDissonance(currentDistance);

        var rotationAngle = 180 - GetRotationAngle(player, home);
        rotation = rotationAngle;
        var rotationDissonance = rotationAngle / 180;

        var weightedDissonance = 
            ((distanceDissonance * DistanceWeight) +
             (rotationDissonance * RotationWeight)) /
            (DistanceWeight + RotationWeight);
        score = weightedDissonance;
    }

    private float GetDistanceDissonance(float distance)
    {
        var distanceRatio = HealthyDistance / distance;
        var clampedRatio = Mathf.Clamp01(distanceRatio);
        var ratioComplement = Mathf.Abs(1-clampedRatio);
        return ratioComplement;
    }

    private float GetRotationAngle(GameObject player, GameObject home)
    {
        var forward = player.transform.forward;
        var diff = player.transform.position - home.transform.position;
        var currentAngle = Vector3.Angle(forward, diff);
        return currentAngle;
    }
}
