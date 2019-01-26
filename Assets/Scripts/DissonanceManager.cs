using UnityEngine;

public class DissonanceManager 
{
    public static float HealthyDistance = 1;
    public static float RotationWeight = 1;
    public static float DistanceWeight = 1;

    public struct Dissonance 
    {
        public float Score;
        public float Distance;
        public float Rotation;

        public Dissonance(float score, float distance, float rotation)
        {
            Score = score;
            Distance = distance;
            Rotation = rotation;
        }
    }

    public static Dissonance GetDissonance(GameObject player, GameObject home)
    {
        var currentDistance = Vector3.Distance(
            home.transform.position,
            player.transform.position
        );
        var distanceDissonance = GetDistanceDissonance(currentDistance);;

        var rotationAngle = GetRotationAngle(player, home);
        var rotationDissonance = (180 - rotationAngle) / 180;

        var weightedDissonance = 
            ((distanceDissonance * DistanceWeight) +
             (rotationDissonance * RotationWeight)) /
            (DistanceWeight + RotationWeight);

        return new Dissonance(weightedDissonance, currentDistance, rotationAngle);
    }

    private static float GetDistanceDissonance(float distance)
    {
        var distanceRatio = HealthyDistance / distance;
        var clampedRatio = Mathf.Clamp01(distanceRatio);
        var ratioComplement = Mathf.Abs(1-clampedRatio);
        return ratioComplement;
    }

    private static float GetRotationAngle(GameObject player, GameObject home)
    {
        var forward = player.transform.forward;
        var diff = player.transform.position - home.transform.position;
        var currentAngle = Vector3.Angle(forward, diff);
        return currentAngle;
    }
}
