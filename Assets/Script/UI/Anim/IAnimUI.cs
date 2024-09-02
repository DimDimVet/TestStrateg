using System.Threading.Tasks;
using UnityEngine;

public interface IAnimUI
{
    Task<bool> RunDOTween(bool isActiv, bool isDefaulPosition = false);
    Task<bool> RunDOTween(Transform transform, bool isActiv, bool isDefaulPosition = false);
    Task<bool> StopDOTween();
}

