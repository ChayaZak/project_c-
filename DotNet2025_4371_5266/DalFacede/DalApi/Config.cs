﻿namespace DalApi;
using System.Xml.Linq;

/// <summary>
/// מחלקת קונפיגורציה של DAL
/// </summary>
static class DalConfig
{
    internal static string s_dalName;
    internal static Dictionary<string, string> s_dalPackages;

    static DalConfig()
    {
        XElement dalConfig = XElement.Load("C:\\Users\\user1\\Documents\\שנה ב\\C#\\my project\\project_c-\\DotNet2025_4371_5266\\xml\\dal-config.xml") ??
        throw new DalConfigException("dal-config.xml file is not found");

        s_dalName = dalConfig.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing");

        var packages = dalConfig.Element("dal-packages")?.Elements() ??
        throw new DalConfigException("<dal-packages> element is missing");
        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
    }
}

/// <summary>
/// חריגות קונפיגורציה של DAL
/// </summary>
[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}

