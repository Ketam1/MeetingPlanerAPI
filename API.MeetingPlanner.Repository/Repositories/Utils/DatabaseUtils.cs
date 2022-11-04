using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Entities;
using API.MeetingPlanner.Frontier.Interfaces.Repository;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace API.MeetingPlanner.Repository
{
    public static class DatabaseUtils
    {
        private const string PATH_SEPARATOR = ".";

        public static string LoadResourceFile(string resourcePath, string resourceName)
        {
            var executingAssembly = typeof(DatabaseUtils).Assembly;
            var sqlStatement = string.Empty;
            var pathBuilder = new StringBuilder();

            pathBuilder.Append(resourcePath);
            pathBuilder.Append(PATH_SEPARATOR);
            pathBuilder.Append(resourceName);

            var sqlResourcePath = pathBuilder.ToString();

            using (Stream stm = executingAssembly.GetManifestResourceStream(sqlResourcePath))
            {
                if (stm != null)
                {
                    sqlStatement = new StreamReader(stm).ReadToEnd();
                }
            }
            return sqlStatement;
        }

        public static IEnumerable<T> TrimStrings<T>(IEnumerable<T> objects)
        {
            var stringProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType == typeof(string) && x.CanRead && x.CanWrite);
            foreach (var prop in stringProps)
            {
                foreach (var obj in objects)
                {
                    string valor = (string)prop.GetValue(obj);
                    string valorTrim = SafeTrim(valor);
                    prop.SetValue(obj, valorTrim);
                }
            }
            return objects;
        }

        public static string SafeTrim(string original)
        {
            if (original == null)
            {
                return null;
            }
            return original.Trim();
        }
    }
}