using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace Identity.Models
{
    public class LoadNavigation
    {
        public static List<Theme> LoadThemes()
        {
            try
            {
                var json = File.ReadAllText("appsettings.json");
                var jObjectt = JObject.Parse(json);
                var themeJson = jObjectt["Theme"].ToString(); // Assuming "Themes" is the correct key in your JSON

                // Deserialize the JSON array into a List<Theme>
                var themes = JsonConvert.DeserializeObject<List<Theme>>(themeJson);

                return themes;
            }
            catch (FileNotFoundException ex)
            {
                // Handle file not found exception
                throw new FileNotFoundException("appsettings.json file not found", ex);
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing exception
                throw new JsonException("Error parsing appsettings.json", ex);
            }
        }
    }
}
