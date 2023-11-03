using Microsoft.AspNetCore.Mvc;
using Techsnovel.Application.Common.Models;
using Techsnovel.Application.Products.Commands.CreateProduct;
using Techsnovel.Application.Products.Commands.DeleteProduct;
using Techsnovel.Application.Products.Commands.UpdateProduct;
using Techsnovel.Application.Products.Queries.GetProductWithPagination;

namespace Techsnovel.Host.Controllers;


public class ProductController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ProductBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetProductWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}
