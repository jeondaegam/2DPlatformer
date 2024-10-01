using TMPro;
using UnityEngine;

public class WavyText : MonoBehaviour
{
    public TMP_Text textComponent;
    public float waveSpeed = 3f;  // 물결치는 속도
    public float waveHeight = 10f; // 물결치는 높이

    void Start()
    {
        // 텍스트 컴포넌트 가져오기
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // 텍스트 메시 업데이트
        AnimateText();
    }

    void AnimateText()
    {
        // 텍스트의 메시 정보를 가져옵니다.
        textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;

        // 각 문자의 위치를 조정합니다.
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            var verts = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;

            // 각 문자의 네 개의 꼭짓점 좌표를 가져옵니다.
            for (int j = 0; j < 4; j++)
            {
                // Sin 함수를 이용하여 물결치는 효과를 줍니다.
                float waveOffset = Mathf.Sin((Time.time * waveSpeed) + (i * 0.5f)) * waveHeight;
                verts[textInfo.characterInfo[i].vertexIndex + j].y += waveOffset;
            }
        }

        // 텍스트의 메시를 업데이트합니다.
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}