

[System.Serializable]
public class OshiraseData//���m�点�f�[�^
{
    public int ID;
    public string TITLE;
    public string ABOUT;
    public string DATE;
}
[System.Serializable]
class OshiraseWrapper:object//���b�p�[�N���X
{
    public OshiraseData[] osrs;//���m�点�f�[�^�̔z��
}

