//Classe creata da noi per contenere i dati di gioco da salvare e da caricare
[System.Serializable]
public class GameData
{
	public string scene;
	public string car;
	public string difficulty;
	public int level;

	public GameData(string sceneString, string carString, string difficultyString, int levelInt)
	{
		scene = sceneString;
		car = carString;
		difficulty = difficultyString;
		level = levelInt;
	}
}