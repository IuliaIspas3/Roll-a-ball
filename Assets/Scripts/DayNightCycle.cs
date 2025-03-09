using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight;  // Reference to the Directional Light (Sun)
    public Material daySkybox;      // Day Skybox Material
    public Material nightSkybox;    // Night Skybox Material
    public float dayDuration = 60f; // Duration of one full cycle (in seconds)
    private float timeOfDay = 0f;   // Time passed in the cycle (0 = day, 1 = night)

    private void Update()
    {
        // Increase the time of day
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay > 1f) timeOfDay = 0f; // Loop back to start after a full cycle

        // Rotate the sun (Directional Light)
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3(timeOfDay * 360f, 170f, 0f));

        // Adjust the intensity of the sunlight based on the time of day
        float intensity = Mathf.Lerp(0.2f, 1f, Mathf.Cos(timeOfDay * Mathf.PI));
        directionalLight.intensity = intensity;

        // Change the skybox based on the time of day
        if (timeOfDay < 0.5f)
        {
            // Daytime: Use the day skybox
            RenderSettings.skybox = daySkybox;
        }
        else
        {
            // Nighttime: Use the night skybox
            RenderSettings.skybox = nightSkybox;
        }
    }
}