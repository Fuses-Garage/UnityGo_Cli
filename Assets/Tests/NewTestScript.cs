using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class NewTestScript
{
    // -2~2�̃����_���Ȓl��10��e�X�g
    [Test]
    public void Clamp01Test([Random(-2, 2f, 10)] float value)
    {
        Assert.IsTrue(0 <= Mathf.Clamp01(value));
        Assert.IsTrue(Mathf.Clamp01(value) <= 1);
    }
}
