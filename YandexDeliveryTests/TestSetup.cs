using NUnit.Framework;
using System.IO;
using DotNetEnv;

namespace YandexDeliveryTests;

[SetUpFixture]
public class TestSetup
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var envPath = FindEnvFile();
        if (envPath != null)
        {
            Env.Load(envPath);
        }
    }

    private static string FindEnvFile()
    {
        var currentDir = Directory.GetCurrentDirectory();
        var dirInfo = new DirectoryInfo(currentDir);

        // Поднимаемся пока не найдём .sln файл
        while (dirInfo != null)
        {
            if (dirInfo.GetFiles("*.sln").Length > 0)
            {
                var envPath = Path.Combine(dirInfo.FullName, ".env");
                return File.Exists(envPath) ? envPath : null;
            }

            dirInfo = dirInfo.Parent;
        }

        return null;
    }
}