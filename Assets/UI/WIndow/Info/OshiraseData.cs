

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
    // ���i�̃C���X�^���X�i�z��j���C���X�y�N�^�[�ɕ\�������܂��Bproduct�́AProduct�^�̃t�B�[���h�ɂȂ�܂��B
    public OshiraseData[] osrs;
}

