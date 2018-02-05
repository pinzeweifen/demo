using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArticle {
    int Type { get; }
    int Count { get; }
    Sprite Icon { get; }
}
