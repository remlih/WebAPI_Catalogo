using Catalog.Application.Requests;
using Catalog.Infrastructure.Services;

namespace Project.Test.UnitTest.Infrastucture.Test
{
    public class UploadServiceTests
    {
        [Fact]
        public void UploadRequest_DataNull_ReturnStringEmpty()
        {
            //Preparación
            var uploadService = new UploadService();
            var valContext = new UploadRequest
            {
                FileName = "NewFile",
                Extension = "pdf",
                UploadType = Catalog.Application.Enums.UploadType.Product,
                Data = null
            };

            //Ejecución
            var result = uploadService.UploadAsync(valContext);

            //Verification
            Assert.Equal(String.Empty, result.ToString());
        }

        [Fact]
        public void UploadRequest_OK_ReturnPath()
        {

        }
    }
}