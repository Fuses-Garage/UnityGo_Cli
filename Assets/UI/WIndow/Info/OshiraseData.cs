

[System.Serializable]
public class OshiraseData
{
    public int ID;
    public string TITLE;
    public string ABOUT;
    public string DATE;
}
[System.Serializable]
class OshiraseWrapper:object
{
    // 商品のインスタンス（配列）をインスペクターに表示させます。productは、Product型のフィールドになります。
    public OshiraseData[] osrs;
}

