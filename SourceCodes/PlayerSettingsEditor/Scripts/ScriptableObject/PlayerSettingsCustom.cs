using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettingsCustom", menuName = "PlayFab Integration Test/PlayerSettingsCustom", order = 0)]
public class PlayerSettingsCustom : ScriptableObject {
	
	[Header("Project Informations")]
	public string companyName;
	public string productName;

	[Header("Package Informations")]
	public string packageName;

	
}
