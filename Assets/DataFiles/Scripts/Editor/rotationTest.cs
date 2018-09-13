using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NUnit.Framework.Internal;

public class NewEditModeTest
{
    
    [Test]
    public void rotaion_on_the_z_axis()
    {
        var gameobject = new GameObject();
        var rotation = gameobject.AddComponent<rotation>();
        Assert.AreEqual(1, rotation.calRotation(0, 0, 1).z / Time.deltaTime);
    }

    [Test]
    public void rotation_on_the_y_axis()
    {
        var gameobject = new GameObject();
        var rotation = gameobject.AddComponent<rotation>();
        Assert.AreEqual(1, rotation.calRotation(0, 1, 0).y / Time.deltaTime);
    }

    [Test]
    public void rotation_on_the_x_axis()
    {
        var gameobject = new GameObject();
        var rotation = gameobject.AddComponent<rotation>();
        Assert.AreEqual(1, rotation.calRotation(1, 0, 0).x / Time.deltaTime);
    }

}