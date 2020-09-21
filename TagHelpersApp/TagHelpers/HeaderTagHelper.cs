﻿using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement(Attributes = "header")]
public class HeaderTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "h2";
        output.Attributes.RemoveAll("header");
    }
}