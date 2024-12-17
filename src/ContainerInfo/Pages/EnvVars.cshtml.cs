using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;

namespace ContainerInfo.Pages
{
    public class EnvVarsModel : PageModel
    {
        public IDictionary<string,string>? EnvironmentVariables { get; set; }

        public void OnGet()
        {
            var sortedEntries = Environment.GetEnvironmentVariables()
                .Cast<DictionaryEntry>()
                .OrderBy(entry => entry.Key)
                .ToDictionary(entry => (string)entry.Key, entry => entry.Value as string);
            EnvironmentVariables = new SortedDictionary<string, string>(sortedEntries);
        }
    }
}
