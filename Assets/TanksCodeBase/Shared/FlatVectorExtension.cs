using UnityEngine;

namespace TanksCodeBase
{
  public static class FlatVectorExtension
  {
    public static Vector3 xz(this Vector3 vv)
    {
      return new Vector3(vv.x, 0, vv.z);
    }
  }
}