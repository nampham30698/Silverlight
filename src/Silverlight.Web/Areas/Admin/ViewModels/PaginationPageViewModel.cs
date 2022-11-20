using System.Text;

namespace Silverlight.Web.Areas.Admin.ViewModels
{
    public class PaginationPageViewModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }  

        public PaginationPageViewModel(int totalCount,int pageIndex = 1,int pageSize = 20)
        {
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public string GeneratePage(string area, string controller, string action)
        {
            StringBuilder sb = new();

            int totalPages = (int)Math.Ceiling((decimal)TotalCount / (decimal)PageSize);

            int startPage = PageIndex - 5;
            int endPage = PageIndex + 4;

            if(startPage <= 0)
            {
                startPage = 1;
                endPage -= (startPage - 1);
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            string preDisabled = PageIndex == 1  ? "disabled" : "";
            string nextDisabled = (totalPages == 1 || PageIndex == totalPages) ? "disabled" : "";


            sb.Append($"<li class=\"paginate_button page-item previous {preDisabled}\" id=\"tbl_previous\"><a href=\"/{area}/{controller}/{action}?page={PageIndex - 1}\" class=\"page-link\">Previous</a></li>");
            
            for (int i = startPage; i <= endPage; i++)
            {
                string activeClass = i == PageIndex ? "active" : "";

                sb.Append($"<li class=\"paginate_button page-item {activeClass}\">");
                    sb.Append($"<a href=\"/{area}/{controller}/{action}?page={i}\" class=\"page-link\">{i}</a>");
                sb.Append("</li>");
            }

            sb.Append($"<li class=\"paginate_button page-item next {nextDisabled}\" id=\"tbl_next\"><a href=\"/{area}/{controller}/{action}?page={PageIndex + 1}\" class=\"page-link\">Next</a></li>");

            return sb.ToString();
        }
    }
}
