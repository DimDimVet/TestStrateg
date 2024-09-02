using System.Threading.Tasks;
using UnityEngine;

public interface IAnimUI
{
    Task<bool> RunDOTween(bool isActiv);
    Task<bool> RunDOTween(Transform transform, bool isActiv);
    Task<bool> StopDOTween();
}

