﻿using System.Diagnostics;

namespace OvgRlp.EgvpEpReceiver.Services
{
  public class CommonHelper
  {
    public static string AssemblyVersion()
    {
      string rval = "n.v.";
      System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
      if (null != assembly)
      {
        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
        if (null != assembly)
          rval = fvi.FileVersion;
      }
      return rval;
    }
  }
}