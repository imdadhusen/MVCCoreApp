using HisabPro.DTO.Response;

namespace HisabPro.Web.ViewModel
{
    public class CategoryModel
    {
        public List<CategoryListRes> AllCategoryList { get; set; }
        public List<ParentCategoryRes> ParentCategoryList { get; set; }
        public List<ChildCategoryRes> ChildCategoryList { get; set; }

        public CategoryModel() { }
    }
}
