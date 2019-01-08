using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using SubordinatesTree.Models;

namespace SubordinatesTree.Helpers
{
    public static class ListHelper
    {
        public static HtmlString CreateChildrenList(this IHtmlHelper html, treeNode node)
        {
            if (node.childrens.Count == 0) return new HtmlString(" "); 
            string result = "<ul>";
            foreach (var item in node.childrens)
            {
                result += $"<li>{item.personNode.Name}";
                result += CreateChildrenList(html, item);
                result += $"</li>";
            }
            result += "</ul>";
            return new HtmlString(result);
        }
        public static HtmlString CreateList(this IHtmlHelper html, List<treeNode> rootlist)
        {
            string result = " ";
            foreach (var item in rootlist)
            {
                result += $"<li>{item.personNode.Name}";
                result += CreateChildrenList(html, item);
                result += $"</li>";
            }
            return new HtmlString(result);
        }
    }
}
