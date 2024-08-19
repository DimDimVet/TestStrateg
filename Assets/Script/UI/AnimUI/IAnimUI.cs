using System.Threading.Tasks;
using UnityEngine;

public interface IAnimUI
{
    Task RunDOTween(bool isActiv);
    Task RunDOTween(Transform transform, bool isActiv);
}

