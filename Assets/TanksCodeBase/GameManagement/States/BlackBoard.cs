using System;
using System.Collections.Generic;

namespace TanksCodeBase
{
  public class BlackBoard
  {
    public Dictionary<String, bool> conditions;

    public BlackBoard()
    {
      conditions = new Dictionary<string, bool>();
    }

    public void SetFlag(String k, bool v)
    {
      conditions[k] = v;
    }

    public bool CheckFlag(String k)
    {
      bool v;
      conditions.TryGetValue(k, out v);
      return v;
    }
    
  }
}