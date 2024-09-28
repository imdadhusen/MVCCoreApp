namespace HisabPro.DTO.Response
{
    public class CategoryListWithChild
    {
        public List<CategoryListRes> AllCategoryList { get; set; }
        public List<ParentCategoryRes> ParentCategoryList { get; set; }
        public List<ChildCategoryRes> ChildCategoryList { get; set; }
    }
}
