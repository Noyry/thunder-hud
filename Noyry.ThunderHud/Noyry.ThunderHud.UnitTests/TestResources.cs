using System.Reflection;

namespace Noyry.ThunderHud.UnitTests
{
    internal static class TestResources
    {
        private const string ResourceNameExceptionParameter = "filename";
        private const string ResourceFullNameExceptionParameter = "path";
        
        private static readonly string _projectResourcesPath = "Noyry.ThunderHud.UnitTests.Resourse";

        public static string GetFileContents(string resourceName)
        {
            var asm = Assembly.GetExecutingAssembly();
            string resourceFullName = $"{_projectResourcesPath}.{resourceName}";

            using (var stream = asm.GetManifestResourceStream(resourceFullName))
            {
                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }

            var ex = new InvalidOperationException("Resource in not found.");
            ex.Data.Add(ResourceNameExceptionParameter, resourceName);
            ex.Data.Add(ResourceFullNameExceptionParameter, resourceFullName);
            throw ex;
        }
    }
}
