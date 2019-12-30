using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGiris.Library
{
    public static class MyExtencions
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string id, ButtonType typ, string text)
        {
            string html = $"<button id='{id}' name='{id}' type='{typ}'>{text}</button>";
            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString ButtonRenkli(this HtmlHelper helper, string id, ButtonType typ, string text,ButtonRenk rnk)
        {
            string html = $"<button class='btn btn-{rnk}' id='{id}' name='{id}' type='{typ}'>{text}</button>";
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString ButtonRenkli(this HtmlHelper helper, string id, ButtonType typ, string text, ButtonRenk rnk,string val="")
        {
            TagBuilder tag = new TagBuilder("button");
            tag.AddCssClass("btn btn-" + rnk);
            tag.GenerateId(id);
            tag.Attributes.Add(new KeyValuePair<string, string>("type", typ.ToString()));
            tag.Attributes.Add(new KeyValuePair<string, string>("name", id));
            tag.Attributes.Add(new KeyValuePair<string, string>("value", val));
            tag.SetInnerText(text);
            return MvcHtmlString.Create(tag.ToString());
        }
    }


    public enum ButtonType
    {
        button=0,
        submit=1,
        reset=2
    }

    public enum ButtonRenk
    {
        primary=0,
        success=1,
        danger=2,
        warning=3,
        light=4,
        dark=5,
        secondary=6

    }
}