#if UNITY_EDITOR

using UnityEditor;

/// <summary>
/// �G�f�B�^�Đ��O�ɃA�Z�b�g���X�V���܂��B
/// </summary>
public class RefreshPlay
{
    // ����:
    // �X�N���v�g��ύX����Unity�ɖ߂��Ă��邽�тɃ����[�h�������
    // �ł܂����悤�ȏ�ԂɂȂ��ēx�X��Ƃ����f����Ă��܂��B
    // 
    // �����������邽�߂ɂ܂��A�ȉ��̐ݒ��OFF�ɐݒ肷��
    // Edit > Prefe.. > Asset Pipiline > Auto Refresh
    //
    // ��������� [Ctrl + R] �ł����X�V����Ȃ��Ȃ邪
    // ���x�� Play �����Ƃ��ɍX�V���ꂸ�Ɏ��s����Ă��܂��̂�
    // �ȉ��̃X�N���v�g�Ŏ��s�O�ɃA�Z�b�g�̋������t���b�V�����s����������荞�܂���
    // ���s���ɂ͍ŐV�̏�Ԃ��ۂ����悤�ɂ���X�N���v�g

    [InitializeOnLoadMethod]
    public static void Run()
    {
        EditorApplication.playModeStateChanged += (PlayModeStateChange state) =>
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                AssetDatabase.Refresh();
            }
        };
    }
}

#endif