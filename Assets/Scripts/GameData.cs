[System.Serializable]
public class GameData
{
	public string scene;
	public string car;
	public string difficulty;

	public GameData(string sceneString, string carString, string difficultyString)
	{
		scene = sceneString;
		car = carString;
		difficulty = difficultyString;
	}
}