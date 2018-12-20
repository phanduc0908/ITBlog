using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITBLOG.WEBUI.Paging
{
    public class Pagination
    {
        public string PagedList(int total, int page, int Take, int offset, string Controler, string View, string Params)
        {
            if (total > 0)
            {
                //string c_url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
                //string URL = c_url.Substring(0, c_url.IndexOf(Controler.ToLower()));
                string URL = "http://localhost:50655/Blog/";
                double itemPerPage = Take;
                if (Convert.ToDouble(total) < Take)
                {
                    itemPerPage = Convert.ToDouble(total);
                }

                int totalPage = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(total) / itemPerPage));
                int current = page;
                int record = offset;
                int pageStart = Convert.ToInt16(Convert.ToDouble(current) - Convert.ToDouble(offset));
                int pageEnd = Convert.ToInt16(Convert.ToDouble(current) + Convert.ToDouble(offset));
                string numPage = "";
                if (totalPage < 1) return "";
                numPage += "<ul class='pagination pagination-template d-flex justify-content-center'>";
                // Add(hidden) previous button
                if (current > 1)
                {
                    numPage += "<li class='page-item'><a href='" + URL + Controler + View + "?Page=" + (page - 1) + Params + "' class='page-link'> <i class='fa fa-angle-left'></i></a></li>";
                }
                else
                {
                    numPage += "<li class='page-item hidden'><a href='#' class='page-link'> <i class='fa fa-angle-left'></i></a></li>";
                }
                //--
                //if (current > (offset + 1))
                //{
                //    numPage += "<li><a href='" + URL + Controler + View + "?Page=1" + Params + "' name='page1'>1</a></li><li class='disabled spacing-dot'><a href='#'>...</a></li>";

                //}
                for (int i = 1; i <= totalPage; i++)
                {
                    if (pageStart <= i && pageEnd >= i)
                    {
                        if (i == current) numPage += "<li class='page-item'><a href='#' class='page-link active'>" + i + "</a></li>";
                        else numPage += "<li class='page-item'><a href='" + URL + Controler + View + "?Page=" + i + Params + "' class='page-link'>" + i + "</a></li>";
                    }
                }
                //if (totalPage > pageEnd)
                //{
                //    record = offset;
                //    numPage += "<li class='disabled spacing-dot'><a href='#'>...</a></li><li><a href='" + URL + Controler + View + "?Page=" + (totalPage) + Params + "'>" + totalPage + "</a></li>";
                //}
                // Add(Hidden) next button
                if (current < totalPage)
                {
                    numPage += "<li class='page-item'><a href='"+URL + Controler + View + "?Page=" +(page + 1) + Params + "'class='page-link'> <i class='fa fa-angle-right'></i></a></li>";
                }
                else
                {
                    numPage += "<li class='page-item hidden'><a href='#' class='page-link'> <i class='fa fa-angle-right'></i></a></li>";
                }
                numPage += "</ul>";
                //--
                return numPage;
            }
            else
            {
                return "no records found";
            }
        }
    }
}

