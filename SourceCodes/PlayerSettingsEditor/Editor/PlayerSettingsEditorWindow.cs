#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class PlayerSettingsEditorWindow : EditorWindow {

	[MenuItem("Tools/Player Settings Editor")]
	private static void ShowWindow() {
		var window = GetWindow<PlayerSettingsEditorWindow>();
		window.titleContent = new GUIContent("Player Settings Editor");
		window.Show();
	}
	public PlayerSettingsCustom projectsettingsSelected;
	string packageName;
	Vector2 scrollpos;
	private void OnGUI() {
		#region Tittle
		GUILayout.Label("Player Settings Editor",EditorStyles.largeLabel);	
		#endregion
		projectsettingsSelected = (PlayerSettingsCustom) EditorGUILayout.ObjectField(projectsettingsSelected,typeof(PlayerSettingsCustom),true);

		GUILayout.Space(10);

		scrollpos= EditorGUILayout.BeginScrollView(scrollpos);

		if(projectsettingsSelected != null){
			
			projectsettingsSelected.companyName =	EditorGUILayout.TextField("Company Name",projectsettingsSelected.companyName);
			projectsettingsSelected.productName =	EditorGUILayout.TextField("Product Name",projectsettingsSelected.productName);

			projectsettingsSelected.packageName =	EditorGUILayout.TextField("Package Name",projectsettingsSelected.packageName);
			
		}


		EditorGUILayout.EndScrollView();
		#region Save
		EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
		if(GUILayout.Button("Save Current Changes",EditorStyles.toolbarButton)){
			SaveCurrentPlayerSettings();
		}
		EditorGUILayout.EndHorizontal();
		GUILayout.Space(5);
		#endregion

		this.Repaint();
	}


	public void SaveCurrentPlayerSettings(){

		//PlayerSettings.applicationIdentifier = settingsSelected.packageName;
		
		PlayerSettings.companyName = projectsettingsSelected.companyName;
		PlayerSettings.productName = projectsettingsSelected.productName;
		
		PlayerSettings.SetApplicationIdentifier( BuildTargetGroup.Android, projectsettingsSelected.packageName);
		PlayerSettings.SetApplicationIdentifier( BuildTargetGroup.iOS, projectsettingsSelected.packageName);

		PlayerSettings.SplashScreen.show = false;
		PlayerSettings.SplashScreen.showUnityLogo = false;
		
	}


}
#endif