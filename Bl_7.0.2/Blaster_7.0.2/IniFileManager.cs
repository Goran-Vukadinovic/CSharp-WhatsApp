using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

public sealed class IniFileManager
{
    public string m_strIniFilePathName;

    public IniFileManager(string strFilePath)
    {
        m_strIniFilePathName = strFilePath;
    }

    [DllImport("kernel32", EntryPoint = "WritePrivateProfileString")]
    private static extern long WritePrivateProfileString(string strAppName, string strKeyName, string strData, string strFilePath);

    [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
    private static extern int GetPrivateProfileString(string strAppName, string strKeyName, string strDefault, StringBuilder sbReturnString, int nSize, string strFilePath);

    public void WriteSetting(string strAppName, string strKeyName, string strData)
    {
        WritePrivateProfileString(strAppName, strKeyName, strData, m_strIniFilePathName);
    }

    public string ReadSetting(string strAppName, string strKeyName)
    {
        StringBuilder stringBuilder = new StringBuilder(255);
        GetPrivateProfileString(strAppName, strKeyName, "", stringBuilder, 255, m_strIniFilePathName);
        return stringBuilder.ToString();
    }

    public void SavePositionSetting(string strBasePath, string strSection, Point position)
    {
        m_strIniFilePathName = Path.Combine(strBasePath, "settings.ini");
        WriteSetting("Blaster", strSection + ".X", position.X.ToString());
        WriteSetting("Blaster", strSection + ".Y", position.Y.ToString());
    }

    public Point ReadPositionSetting(string strBasePath, string strKeyName)
    {
        m_strIniFilePathName = Path.Combine(strBasePath, "settings.ini");
        int[] array = new int[2];
        int.TryParse(ReadSetting("Blaster", strKeyName + ".X"), out array[0]);
        int.TryParse(ReadSetting("Blaster", strKeyName + ".Y"), out array[1]);
        if (array[0] == 0 && array[1] == 0)
        {
            return Point.Empty;
        }
        return new Point(array[0], array[1]);
    }
}
