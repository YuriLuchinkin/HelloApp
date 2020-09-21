using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpersApp.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace TagHelpersApp.TagHelpers
{
    public class TimerTagHelper : TagHelper
    {
        ITimeService timeService;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public TimerTagHelper(ITimeService timeServ)
        {
            timeService = timeServ;
        }
        public bool SecondsIncluded { get; set; }
        public string Color { get; set; }
        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{
        //    var now = DateTime.Now;
        //    var time = String.Empty;
        //    if (SecondsIncluded)    // если true добавляем секунды
        //        time = now.ToString("HH:mm:ss");
        //    else
        //        time = now.ToString("HH:mm");

        //    output.TagName = "div";    // заменяет тег <timer> тегом <div>
        //                               // устанавливаем содержимое элемента
        //    output.TagMode = TagMode.StartTagAndEndTag;
        //    // устанавливаем цвет
        //    output.Attributes.SetAttribute("style", $"color:{Color};");
        //    output.Attributes.SetAttribute("class", "timer");
        //    // элемент перед тегом
        //    output.PreElement.SetHtmlContent("<h4>Дата и время</h4>");

        //    output.Content.SetContent(time);
        //    // элемент после тега
        //    output.PostElement.SetHtmlContent($"<div>Дата: {DateTime.Now.ToString("dd/MM/yyyy")}</div>");
        //}
        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{
        //    output.TagName = "div";
        //    output.TagMode = TagMode.StartTagAndEndTag;
        //    output.Content.SetContent($"Текущее время: {timeService.GetTime()}");
        //}
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // получаем из строки запроса параметр font
            string font = ViewContext?.HttpContext.Request.Query["font"];

            if (String.IsNullOrEmpty(font)) font = "Verdana";

            output.Attributes.SetAttribute("style", $"font-family:{font};font-size:18px;");
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent($"Текущее время: {timeService.GetTime()}");
        }
    }
    public class DateTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetContent($"Текущая дата: {DateTime.Now.ToString("dd/mm/yyyy")}");
        }
    }
    public class SummaryTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            // получаем вложенный контекст из дочерних tag-хелперов
            var target = await output.GetChildContentAsync();
            var content = "<h3>Общая информация</h3>" + target.GetContent();
            output.Content.SetHtmlContent(content);
        }
    }
}