using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using ManagedCommon;
using Wox.Infrastructure;
using Wox.Plugin;
using BrowserInfo = Wox.Plugin.Common.DefaultBrowserInfo;

namespace Community.PowerToys.Run.Plugin.Gemini
{
    public class Main : IPlugin, IPluginI18n
    {
        private PluginInitContext _context;
        private string _iconPath;

        // Matches the ID in plugin.json
        public static string PluginID => "B8D38372-96AC-444C-8F8D-906567300702";

        public string Name => "PowerToys Gemini";
        public string Description => "Ask Gemini";

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();

            var search = query.Search?.Trim() ?? string.Empty;
            var prompt = search;

            results.Add(new Result
            {
                Title = prompt.Length > 0 ? prompt : "Open Gemini",
                SubTitle = prompt.Length > 0 ? "Open and send in your signed-in browser" : "Open Gemini",
                QueryTextDisplay = search,
                IcoPath = _iconPath ?? "Icon/Gemini.png",
                Action = action =>
                {
                    if (prompt.Length > 0)
                    {
                        Clipboard.SetText(prompt);
                    }

                    if (!Helper.OpenCommandInShell(
                        BrowserInfo.Path,
                        BrowserInfo.ArgumentsPattern,
                        "https://gemini.google.com/app"))
                    {
                        return false;
                    }

                    if (prompt.Length > 0)
                    {
                        _ = Task.Run(async () =>
                        {
                            await Task.Delay(TimeSpan.FromSeconds(4));
                            System.Windows.Forms.SendKeys.SendWait("^v");
                            await Task.Delay(250);
                            System.Windows.Forms.SendKeys.SendWait("~");
                        });
                    }

                    return true;
                }
            });

            return results;
        }

        public void Init(PluginInitContext context)
        {
            _context = context;
            _context.API.ThemeChanged += (oldTheme, newTheme) => UpdateIconPath(newTheme);
            UpdateIconPath(_context.API.GetCurrentTheme());
        }

        public string GetTranslatedPluginTitle() => Name;
        public string GetTranslatedPluginDescription() => Description;

        private void UpdateIconPath(Theme theme)
        {
        
           _iconPath = "Icon/Gemini.png";

        }
    }
}