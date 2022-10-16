using Catalog.WebAPIServer.Controllers.v1.Catalog;

namespace Project.Test.UnitTest.WebAPIServer.Test
{
    public class CategoriesControllerTests
    {
        private readonly CategoriesController _categoriesController;

        public CategoriesControllerTests()
        {
            _categoriesController = new CategoriesController();
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(0)]
        public async void Test1(int id)
        {
            ////preparación
            
            
            ////Ejecución
            //var query = await _categoriesController.GetById(id);

            ////Verification
            //var result = query as Result<GetCategoryByIdResponse>;

            //Assert.Null(result.Data);

        }
    }
}