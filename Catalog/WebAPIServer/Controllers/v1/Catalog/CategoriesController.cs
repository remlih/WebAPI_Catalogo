using Catalog.Application.Features.Categories.Commands.AddEdit;
using Catalog.Application.Features.Categories.Commands.Delete;
using Catalog.Application.Features.Categories.Queries.Export;
using Catalog.Application.Features.Categories.Queries.GetAll;
using Catalog.Application.Features.Categories.Queries.GetById;
using Catalog.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPIServer.Controllers.v1.Catalog
{
    public class CategoriesController : BaseApiController<CategoriesController>
    {
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns>Status 200 OK</returns>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Categorys = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(Categorys);
        }

        /// <summary>
        /// Get a Category By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Category = await _mediator.Send(new GetCategoryByIdQuery() { Id = id });
            return Ok(Category);
        }

        /// <summary>
        /// Create a Category
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Categories.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Update a Category
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Categories.Edit)]
        [HttpPut]
        public async Task<IActionResult> Put(AddEditCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Categories.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCategoryCommand { Id = id }));
        }

        /// <summary>
        /// Search Categories and Export to Excel
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [Authorize(Policy = Permissions.Categories.Export)]
        [HttpGet("export")]
        public async Task<IActionResult> Export(string searchString = "")
        {
            return Ok(await _mediator.Send(new ExportCategoriesQuery(searchString)));
        }
    }
}