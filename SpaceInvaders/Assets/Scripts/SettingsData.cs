using UnityEngine;

[CreateAssetMenu(fileName = "settingsData", menuName = "ScriptableObjects/SettingsData")]
public class SettingsData : ScriptableObject
{
    public float volume;
    public bool isFullScreen;
}