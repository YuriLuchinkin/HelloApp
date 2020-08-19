using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ViewEngineApp.Util
{
    public class CustomView : IView
    {
        public CustomView(string viewPath)
        {
            Path = viewPath;
        }
        public string Path { get; set; }
        public async Task RenderAsync(ViewContext context)
        {
            string content = String.Empty;
            using (StreamReader viewReader = new StreamReader(Path))
            {
                content = await viewReader.ReadToEndAsync();
            }
            await context.Writer.WriteAsync(content);
        }
    }
}