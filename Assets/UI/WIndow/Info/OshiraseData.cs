

[System.Serializable]
public class OshiraseData//お知らせデータ
{
    public int ID;
    public string TITLE;
    public string ABOUT;
    public string DATE;
}
[System.Serializable]
class OshiraseWrapper:object//ラッパークラス
{
    public OshiraseData[] osrs;//お知らせデータの配列
}

