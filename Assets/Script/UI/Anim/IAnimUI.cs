using System.Threading.Tasks;
using UnityEngine;

public interface IAnimUI
{
    Task<object> RunDOTween(bool isActiv);
    Task<object> RunDOTween(Transform transform, bool isActiv);
    Task<object> StopDOTween();
}

