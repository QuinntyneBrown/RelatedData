using System.Net;
using System.Threading.Tasks;
using RelatedData.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RelatedData.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{categoryId}", Name = "GetCategoryByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCategoryById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCategoryById.Response>> GetById([FromRoute] GetCategoryById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Category == null)
            {
                return new NotFoundObjectResult(request.CategoryId);
            }

            return response;
        }

        [HttpGet(Name = "GetCategoriesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCategories.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCategories.Response>> Get()
            => await _mediator.Send(new GetCategories.Request());

        [HttpPost(Name = "CreateCategoryRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCategory.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCategory.Response>> Create([FromBody] CreateCategory.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetCategoriesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCategoriesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCategoriesPage.Response>> Page([FromRoute] GetCategoriesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateCategoryRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCategory.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCategory.Response>> Update([FromBody] UpdateCategory.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{categoryId}", Name = "RemoveCategoryRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCategory.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCategory.Response>> Remove([FromRoute] RemoveCategory.Request request)
            => await _mediator.Send(request);

    }
}
