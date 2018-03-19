using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public ReplacementDress replacementDress;

    public SkinnedMeshRenderer eye;
    public SkinnedMeshRenderer face;
    public SkinnedMeshRenderer hair;
    public SkinnedMeshRenderer pant;
    public SkinnedMeshRenderer shoes;
    public SkinnedMeshRenderer body;
    
    private void Start()
    {
        //先一次性添加所有需要变换的装扮
        replacementDress.AddSkin(eye);
        replacementDress.AddSkin(face);
        replacementDress.AddSkin(hair);
        replacementDress.AddSkin(pant);
        replacementDress.AddSkin(shoes);
        replacementDress.AddSkin(body);

        //显示装扮
        replacementDress.GeneraterSkin();
    }
}
