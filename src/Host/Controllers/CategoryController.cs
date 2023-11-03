using Microsoft.AspNetCore.Mvc;
using Techsnovel.Application.Categories.Commands.CreateCategory;
using Techsnovel.Application.Categories.Commands.DeleteCategory;
using Techsnovel.Application.Categories.Commands.UpdateCategory;
using Techsnovel.Application.Categories.Queries.GetProducts;

namespace Techsnovel.Host.Controllers;


public class CategoryController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CategoryVm>> Get()
    {
        return await Mediator.Send(new GetCategoryQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
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
        await Mediator.Send(new DeleteCategoryCommand(id));

        return NoContent();
    }
}
